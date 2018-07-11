using ItbamSPA.Server.DataAccess;
using ItbamSPA.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ItbamSPA.Server.Controllers
{
    [Route("api/[controller]")]
    public class ProdutoController : Controller
    {

        #region Atributos

        ProdutoDataAccessLayer prodAux = new ProdutoDataAccessLayer();

        #endregion

        #region Métodos de Request

        [HttpGet]
        [Route("api/Produto/Index")]
        public IEnumerable<Produto> Index()
        {
            return prodAux.Listar();
        }

        [HttpPost]
        [Route("api/Produto/Criar")]
        public void Create([FromBody] Produto produto)
        {
            if (ModelState.IsValid)
                prodAux.Adicionar(produto);
        }

        [HttpGet]
        [Route("api/Produto/Info/{id}")]
        public Produto Details(int id)
        {

            return prodAux.ObterProdutoPorId(id);
        }

        [HttpPut]
        [Route("api/Produto/Editar")]
        public void Edit([FromBody]Produto produto)
        {
            if (ModelState.IsValid)
                prodAux.Atualizar(produto);
        }

        [HttpDelete]
        [Route("api/Produto/Remover/{id}")]
        public void Delete(int id)
        {
            prodAux.Remover(id);
        }

        #endregion
    }
}
