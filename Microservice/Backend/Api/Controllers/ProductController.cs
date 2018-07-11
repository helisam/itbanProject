using System;
using Domain.Interfaces.Services;
using Nancy;
using Nancy.ModelBinding;
using Newtonsoft.Json;
using Services.Exceptions;
using Domain.Entities;

namespace Api.Controllers
{
    public class ProductController : ModuloBasico
    {
        #region Attributes

        private readonly IProdutoService _productService;

        #endregion

        #region Constructor

        public ProductController(IProdutoService productService)
            : base("produtos")
        {
            _productService = productService;
        }

        #endregion

        #region Routes

        protected override void RegistrarRotas()
        {
            Get["/listar"] = Listar;
            Put["/adicionar"] = Adicionar;
            Put["/adicionarsp"] = AdicionarComSp;
            Delete["/remover"] = Remover;
            Post["/atualizar"] = Atualizar;
        }

        #endregion

        private dynamic Listar(dynamic arg)
        {
            try
            {
                return SerializeObject(_productService.Listar());
            }
            catch (Exception excecao)
            {
                if (excecao is ParametroInvalidoException)
                    return ExceptionResponse(excecao, HttpStatusCode.BadRequest);

                return ExceptionResponse(excecao, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic Adicionar(dynamic arg)
        {
            var dto = this.Bind<Product>();
            try
            {
                _productService.Adicionar(dto);
                return HttpStatusCode.Created;
            }
            catch (Exception excecao)
            {
                if (excecao is ParametroInvalidoException)
                    return ExceptionResponse(excecao, HttpStatusCode.BadRequest);

                return ExceptionResponse(excecao, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic AdicionarComSp(dynamic arg)
        {
            var dto = this.Bind<Product>();
            try
            {
                _productService.AdicionarComSp(dto);
                return HttpStatusCode.Created;
            }
            catch (Exception excecao)
            {
                if (excecao is ParametroInvalidoException)
                    return ExceptionResponse(excecao, HttpStatusCode.BadRequest);

                return ExceptionResponse(excecao, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic Remover(dynamic arg)
        {
            var dto = this.Bind<Product>();
            try
            {
                _productService.Remover(dto.Id);
                return HttpStatusCode.OK;
            }
            catch (Exception excecao)
            {
                if (excecao is ParametroInvalidoException)
                    return ExceptionResponse(excecao, HttpStatusCode.BadRequest);

                return ExceptionResponse(excecao, HttpStatusCode.InternalServerError);
            }
        }

        private dynamic Atualizar(dynamic arg)
        {
            var dto = this.Bind<Product>();
            try
            {
                _productService.Atualizar(dto);
                return HttpStatusCode.OK;
            }
            catch (Exception excecao)
            {
                if (excecao is ParametroInvalidoException)
                    return ExceptionResponse(excecao, HttpStatusCode.BadRequest);

                return ExceptionResponse(excecao, HttpStatusCode.InternalServerError);
            }
        }

        #region Assistants methods

        protected T DeserializeObject<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        public string SerializeObject(object model)
        {
            return JsonConvert.SerializeObject(model,
                Formatting.None,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateFormatString = "yyyy-MM-ddTHH:mmZ"
                });
        }

        #endregion

    }
}