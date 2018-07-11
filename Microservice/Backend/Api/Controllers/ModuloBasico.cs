using System;
using Nancy;
using Nancy.Responses.Negotiation;

namespace Api.Controllers
{
    public abstract class ModuloBasico : NancyModule
    {
        protected ModuloBasico(string path)
            : base(path)
        {
            RegistrarRotas();
        }
        protected abstract void RegistrarRotas();

        public Negotiator ExceptionResponse(Exception exception)
        {
            return ExceptionResponse(exception, HttpStatusCode.BadRequest);
        }

        public Negotiator ExceptionResponse(Exception exception, HttpStatusCode statusCode)
        {
            string mensagem = statusCode == HttpStatusCode.InternalServerError ? "Ocorreu um erro uma falha em nossos servidores" : exception.Message;
            return Negotiate
                .WithModel(mensagem)
                .WithStatusCode(statusCode);
        }
    }
}