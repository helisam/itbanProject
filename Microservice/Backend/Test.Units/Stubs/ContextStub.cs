using Domain.Interfaces;
using Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Test.Units.Stubs
{
    /// <summary>
    /// Stub do contexto de banco
    /// </summary>
    public class ContextStub : DbContext, IDataContext
    {
        /// <summary>
        /// Indica se foram ou não efetuadas mudanças em informaçoes da base de dados
        /// </summary>
        private bool _hasChanges;

        public ContextStub()
            : base("Name=ConnectionString")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public ContextStub(DbConnection dbConnection)
            : base(dbConnection, true)
        {
        }

        public ContextStub(DbConnection dbConnection, bool contextOwnsConnection)
            : base(dbConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var ensureDLLIsCopied =
                System.Data.Entity.SqlServer.SqlProviderServices.Instance;   
            Configurar(modelBuilder);
            CriarMapeamentoTabelas(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// Método responsável pelo mapeamento entre entity e o banco
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void CriarMapeamentoTabelas(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
        }

        /// <summary>
        /// Método responsável por configurar o mapeamento do banco para Entity
        /// </summary>
        /// <param name="modelBuilder"></param>
        private static void Configurar(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        /// <summary>
        /// Implementação genérica de consulta de uma entidade
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <returns></returns>
        public IQueryable<TEntidade> Entity<TEntidade>() where TEntidade : class
        {
            return Set<TEntidade>().AsQueryable();
        }

        /// <summary>
        /// Implementação genérica de consulta de uma entidade usando uma expressão de condição
        /// </summary>
        /// <typeparam name="TEntidade">tipo da entidade</typeparam>
        /// <param name="expressao">expressão de condição</param>
        /// <returns></returns>
        public IQueryable<TEntidade> Query<TEntidade>(Expression<Func<TEntidade, bool>> expressao) where TEntidade : class
        {
            return Set<TEntidade>().Where(expressao);
        }

        /// <summary>
        /// Adição de uma entidade na base de dados
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entity"></param>
        public void Add<TEntidade>(TEntidade entity) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State != System.Data.Entity.EntityState.Detached)
            {
                dbEntityEntry.State = System.Data.Entity.EntityState.Added;
            }
            else
            {
                Set<TEntidade>().Add(entity);
            }
            _hasChanges = true;
        }

        /// <summary>
        /// Remove uma entidade do banco de dados
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entity"></param>
        public void Delete<TEntidade>(TEntidade entity) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State != System.Data.Entity.EntityState.Deleted)
            {
                dbEntityEntry.State = System.Data.Entity.EntityState.Deleted;
            }
            else
            {
                Set<TEntidade>().Attach(entity);
                Set<TEntidade>().Remove(entity);
            }
            _hasChanges = true;
        }

        /// <summary>
        /// Atualiza uma entidade no banco de dados
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="entity"></param>
        public void Update<TEntidade>(TEntidade entity) where TEntidade : class
        {
            DbEntityEntry dbEntityEntry = Entry(entity);
            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                Set<TEntidade>().Attach(entity);
            }
            dbEntityEntry.State = EntityState.Modified;
            _hasChanges = true;
        }

        /// <summary>
        /// Verifica a existência de um entidade na base de dados
        /// </summary>
        /// <typeparam name="TEntidade"></typeparam>
        /// <param name="expressao"></param>
        /// <returns></returns>
        public bool Any<TEntidade>(Expression<Func<TEntidade, bool>> expressao) where TEntidade : class
        {
            return Set<TEntidade>().Any(expressao);
        }

        /// <summary>
        /// Efetuar dispode do contexto e salvar caso necessário
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && _hasChanges)
                {
                    SaveChanges();
                }
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        /// <summary>
        /// Remove a entidade do contexto
        /// </summary>
        public void Detach<TEntidade>(TEntidade entidade) where TEntidade : class
        {
            DbEntityEntry<TEntidade> dbEntry = Entry(entidade);
            if (dbEntry.State == System.Data.Entity.EntityState.Added)
            {
                Detach<TEntidade>(entidade);
            }
        }

        /// <summary>
        /// Salva as alterações efetuadas
        /// </summary>
        public void CommitChanges()
        {
            SaveChanges();
        }
    }
}
