using Domain.Interfaces;

namespace Infra.Data.Repositories.Base
{
    /// <summary>
    /// Classe de implementaçao genérica de um repositório
    /// </summary>
    /// <typeparam name="TEntidade">Tipo de entidade</typeparam>
    public class Repositorio<TEntidade> : RepositorioBase<TEntidade> where TEntidade : class
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="contexto">implementaçao do _contexto de persistência</param>
        public Repositorio(IDataContext contexto)
            : base(contexto)
        {
        }
    }
}
