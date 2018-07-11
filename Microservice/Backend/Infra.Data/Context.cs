using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;
using Infra.Data.Mappings;
using Domain.Entities;
using System.Data.SqlClient;

namespace Infra.Data
{
    /// <summary>
    /// Contexto de persistência de dados
    /// </summary>
    public class Context : DbContext, IDataContext
    {
        /// <summary>
        /// Indica se foram ou nao efetuadas mudanças em informaçoes da base de dados
        /// </summary>
        private bool _houveAlteracoes;

        public Context()
            : base("Name=ConnectionString")
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
            Database.SetInitializer<Context>(null);
        }

        public Context(DbConnection dbConnection)
            : base(dbConnection, true)
        {
        }

        public Context(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Configurar(modelBuilder);
            CriarMapeamentoTabelas(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Método responsável pelo mapeamento entre entity e o banco
        /// </summary>
        private static void CriarMapeamentoTabelas(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }

        /// <summary>
        /// Método responsável por configurar o mapeamento do banco para Entity
        /// </summary>
        private static void Configurar(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// Implementaçao genérica de consulta de uma entidade
        /// </summary>
        public IQueryable<TEntidade> Entity<TEntidade>() where TEntidade : class
        {
            return Set<TEntidade>().AsQueryable();
        }

        /// <summary>
        /// Implementaçao genérica de consulta de uma entidade usando uma expressao de condiçao
        /// </summary>
        public IQueryable<TEntidade> Query<TEntidade>(Expression<Func<TEntidade, bool>> expressao) where TEntidade : class
        {
            return Set<TEntidade>().Where(expressao);
        }

        /// <summary>
        /// Adiçao de uma entidade na base de dados
        /// </summary>
        public void Add<TEntidade>(TEntidade entity) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;

            else
                Set<TEntidade>().Add(entity);

            _houveAlteracoes = true;
        }

        /// <summary>
        /// Remove uma entidade do banco de dados
        /// </summary>
        public void Delete<TEntidade>(TEntidade entity) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);

            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                Set<TEntidade>().Attach(entity);
                Set<TEntidade>().Remove(entity);
            }

            _houveAlteracoes = true;
        }

        /// <summary>
        /// Atualiza uma entidade no banco de dados
        /// </summary>
        public void Update<TEntidade>(TEntidade entity) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);

            //if (dbEntityEntry.State == EntityState.Detached)
            //    Set<TEntidade>().Attach(entity);

            dbEntityEntry.State = EntityState.Modified;
            _houveAlteracoes = true;
        }

        /// <summary>
        /// Verifica a existência de um entidade na base de dados
        /// </summary>
        public bool Any<TEntidade>(Expression<Func<TEntidade, bool>> expressao) where TEntidade : class
        {
            return Set<TEntidade>().Any(expressao);
        }

        /// <summary>
        /// Efetuar dispode do _contexto e salvar caso necessário
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && _houveAlteracoes)
                    SaveChanges();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Remove a entidade do _contexto
        /// </summary>
        public void Detach<TEntidade>(TEntidade entidade) where TEntidade : class
        {
            DbEntityEntry<TEntidade> dbEntry = Entry(entidade);

            if (dbEntry.State == EntityState.Added)
                Detach(entidade);
        }

        /// <summary>
        /// Salva as alterações efetuadas
        /// </summary>
        public void CommitChanges()
        {
            SaveChanges();
        }

        public void AddWithSP<TEntidade>(TEntidade entity, string sp, SqlParameter[] param) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);

            if (dbEntityEntry.State != EntityState.Detached)
                dbEntityEntry.State = EntityState.Added;

            else
                Set<TEntidade>().SqlQuery(sp, param).SingleOrDefault();

            _houveAlteracoes = true;
        }
    }
}