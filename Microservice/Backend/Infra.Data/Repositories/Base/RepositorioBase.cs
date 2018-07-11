using System;
using System.Linq;
using System.Linq.Expressions;
using Domain.Interfaces;

namespace Infra.Data.Repositories.Base
{
    /// <summary>
    /// Implementaçao básica de um repositório genérico
    /// </summary>
    /// <typeparam name="TEntidade">Tipo da entidade persistida no banco</typeparam>
    public abstract class RepositorioBase<TEntidade> : IRepositorio<TEntidade> where TEntidade : class
    {
        /// <summary>
        /// Contexto que implementa a persistencia
        /// </summary>
        protected IDataContext _contexto;

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="contexto">Contexto que implementa a persistencia</param>
        protected RepositorioBase(IDataContext contexto)
        {
            this._contexto = contexto;
        }

        /// <summary>
        /// Retorna um IQueryable de consulta de uma entidade TEntidade
        /// </summary>
        public virtual IQueryable<TEntidade> Entidades()
        {
            return _contexto.Entity<TEntidade>();
        }

        /// <summary>
        /// Retorna um IQueryable de consulta de uma entidade TEntidade baseada na expressao de consulta
        /// </summary>
        /// <param name="expressao">expressao de condiçao da consulta</param>
        public virtual IQueryable<TEntidade> Consultar(Expression<Func<TEntidade, bool>> expressao)
        {
            return _contexto.Query(expressao);
        }

        /// <summary>
        /// Adiciona uma entidade
        /// </summary>
        public virtual void Adicionar(TEntidade entidade)
        {
            _contexto.Add(entidade);
            _contexto.CommitChanges();
        }

        /// <summary>
        /// Atualizar uma entidade
        /// </summary>
        public virtual void Atualizar(TEntidade entidade)
        {
            _contexto.Update(entidade);
            _contexto.CommitChanges();
        }

        /// <summary>
        /// Exclui uma entidade
        /// </summary>
        public virtual void Excluir(TEntidade entidade)
        {
            _contexto.Delete(entidade);
            _contexto.CommitChanges();
        }

        /// <summary>
        /// Retorna se existe uma entidade que corresponda a expressao de consulta
        /// </summary>
        /// <param name="expressao">expressao de condiçao da entidade</param>
        public virtual bool Existe(Expression<Func<TEntidade, bool>> expressao)
        {
            return _contexto.Any(expressao);
        }
    }
}