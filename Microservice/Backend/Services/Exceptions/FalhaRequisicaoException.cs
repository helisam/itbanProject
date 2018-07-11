using System;
using System.Net;

namespace Services.Exceptions
{
    /// <summary>
    /// Excessao que deve ser lançada quando houver falha no acesso ao recurso de uma api externa
    /// </summary>
    [Serializable]
    public class FalhaRequisicaoException : Exception
    {
        /// <summary>
        /// Mensagem com o motivo da falha da requisiçao
        /// </summary>
        private readonly string _motivo;

        /// <summary>
        /// Url da requisiçao
        /// </summary>
        private readonly string _url;

        /// <summary>
        /// Codigo http de status
        /// </summary>
        private HttpStatusCode _statusCode;

        /// <summary>
        /// Propriedade para acesso do motivo da falha da requisiçao
        /// </summary>
        public string Motivo
        {
            get { return _motivo; }
        }

        /// <summary>
        /// Propriedade para acesso da url para qual foi disparada a requisiçao
        /// </summary>
        public string Url
        {
            get { return _url; }
        }

        public FalhaRequisicaoException(string url, string motivo, HttpStatusCode statusCode)
            : base(motivo)
        {
            _url = url;
            _motivo = motivo;
            _statusCode = statusCode;
        }
    }
}