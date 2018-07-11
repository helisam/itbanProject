using System;
using System.Linq;
using System.Linq.Expressions;

namespace Domain.Interfaces
{
    /// <summary>
    /// Interface de representaçao dos repositórios
    /// </summary>
    /// <typeparam name="TEntidade">Tipo de entidade</typeparam>
    public interface IRepositorio<TEntidade> where TEntidade : class
    {
        /// <summary>
        /// Listar as entidades.
        /// </summary>
        /// <returns>todas as entidades</returns>
        IQueryable<TEntidade> Entidades();

        /// <summary>
        /// Consultar as entidades de acordo com a expressao de condiçao
        /// </summary>
        /// <param name="expressao">expressao de condiçao da consulta</param>
        /// <returns>lista de entidades correspondentes a condiçao</returns>
        IQueryable<TEntidade> Consultar(Expression<Func<TEntidade, bool>> expressao);

        /// <summary>
        /// Armazenar uma entidade
        /// </summary>
        void Adicionar(TEntidade entidade);

        /// <summary>
        /// Atualizar a entidade selecionada
        /// </summary>
        void Atualizar(TEntidade entidade);

        /// <summary>
        /// Excluir a entidade selecionada
        /// </summary>
        void Excluir(TEntidade entidade);

        /// <summary>
        /// Pesquisa a existencia de um objeto persistido com base na expressao de condiçao
        /// </summary>
        bool Existe(Expression<Func<TEntidade, bool>> expressao);
    }
}
