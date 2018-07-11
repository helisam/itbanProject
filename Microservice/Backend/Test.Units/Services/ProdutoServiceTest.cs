using Domain.Entities;
using Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Impl;
using System.Reflection;
using Test.Units.Stubs;
using System.Linq;

namespace Test.Units.Services
{
    [TestClass]
    public class ProdutoServiceTest : BaseTest
    {
        #region Constantes

        const string SERVICES = "Services";

        #endregion

        #region Testes

        [TestMethod]
        [TestCategory(SERVICES)]
        public void DeveListarProdutos()
        {
            // System Under Test
            ContextStub contexto = InicializarBancoEmMemoria(MethodBase.GetCurrentMethod().Name);
            RepositorioProduto repositorioProduto = new RepositorioProduto(contexto);
            ProdutoService service = new ProdutoService(repositorioProduto);

            // Pre-conditions
            repositorioProduto.Adicionar(new Product { Id = 1, Nome = "Prod1", Preco = "2,75", Categoria = "Esporte" });
            repositorioProduto.Adicionar(new Product { Id = 2, Nome = "Prod2", Preco = "2,75", Categoria = "Esporte2" });
            repositorioProduto.Adicionar(new Product { Id = 3, Nome = "Prod3", Preco = "2,75", Categoria = "Esporte3" });
            repositorioProduto.Adicionar(new Product { Id = 4, Nome = "Prod4", Preco = "2,75", Categoria = "Esporte4" });

            // Exercise
            var produtos = service.Listar();

            // Assertive
            Assert.AreEqual(4, produtos.Count, "Deveriam possuir {0} produtos.", 4);

            var produto = produtos.FirstOrDefault();
            Assert.AreEqual(1, produto.Id, "Deveria ter sido cadastrado o produto de id{0}.", 1);
        }

        #endregion
    }
}
