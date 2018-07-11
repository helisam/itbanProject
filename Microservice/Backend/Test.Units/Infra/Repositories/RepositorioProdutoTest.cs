using Infra.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Units.Stubs;
using System.Linq;
using Domain.Entities;
using System.Collections.Generic;
using System.Reflection;

namespace Test.Units.Infra.Repositories
{
    [TestClass]
    public class RepositorioProdutoTest : BaseTest
    {
        #region Constantes

        const string CATEGORIA_TESTE = "RepositorioProduto";

        #endregion

        #region Testes

        [TestMethod]
        [TestCategory(CATEGORIA_TESTE)]
        public void DeveListarProdutos()
        {
            // System Under Test
            ContextStub contexto = InicializarBancoEmMemoria(MethodBase.GetCurrentMethod().Name);

            RepositorioProduto repositorioProduto = new RepositorioProduto(contexto);

            // Exercise
            repositorioProduto.Adicionar(new Product { Id = 1, Nome = "Prod1", Preco = "2,75", Categoria = "Esporte" });
            repositorioProduto.Adicionar(new Product { Id = 2, Nome = "Prod2", Preco = "2,75", Categoria = "Esporte2" });
            repositorioProduto.Adicionar(new Product { Id = 3, Nome = "Prod3", Preco = "2,75", Categoria = "Esporte3" });
            repositorioProduto.Adicionar(new Product { Id = 4, Nome = "Prod4", Preco = "2,75", Categoria = "Esporte4" });

            // Assertives
            var produtos = repositorioProduto.Entidades().ToList();
            Assert.AreEqual(4, produtos.Count, "Deveriam possuir {0} produtos.", 4);

            var produto = produtos.FirstOrDefault();
            Assert.AreEqual(1, produto.Id, "Deveria ter sido cadastrado o produto de id{0}.", 1);
        }

        [TestMethod]
        [TestCategory(CATEGORIA_TESTE)]
        public void DeveAdicionarUmProduto()
        {
            // System Under Test
            ContextStub contexto = InicializarBancoEmMemoria(MethodBase.GetCurrentMethod().Name);

            RepositorioProduto repositorioProduto = new RepositorioProduto(contexto);

            // Pre-conditions
            List<Product> produtosZerados = repositorioProduto.Entidades().ToList();

            // Exercise
            repositorioProduto.Adicionar(new Product { Id = 1, Nome = "Prod1", Preco = "2,75", Categoria = "Esporte" });

            var produtos = repositorioProduto.Entidades().ToList();

            // Assertives
            Assert.AreEqual(0, produtosZerados.Count, "Não deveria possuir nenhum produto, pois não existem registros.");
            Assert.AreEqual(1, produtos.Count, "Deveria possuir um produto.");

            var produto = produtos.FirstOrDefault();
            Assert.AreEqual(1, produto.Id, "Deveria ter sido cadastrado o produto de id{0}.", 1);
        }

        [TestMethod]
        [TestCategory(CATEGORIA_TESTE)]
        public void DeveAtualizarUmProduto()
        {
            // System Under Test
            ContextStub contexto = InicializarBancoEmMemoria(MethodBase.GetCurrentMethod().Name);

            RepositorioProduto repositorioProduto = new RepositorioProduto(contexto);

            // Pre-conditions
            repositorioProduto.Adicionar(new Product { Id = 1, Nome = "Prod1", Preco = "2,75", Categoria = "Esporte" });
            var produto = repositorioProduto.Entidades().FirstOrDefault();

            // Exercise
            var nomeAlterado = "ProdAlterado";
            produto.Nome = nomeAlterado;
            contexto.Update(produto);
            contexto.SaveChanges();


            // Assertives
            var produtos = repositorioProduto.Entidades().ToList();
            Assert.AreEqual(1, produtos.Count, "Deveria possuir um produto.");

            var produtoAlterado = produtos.FirstOrDefault();
            Assert.AreEqual(nomeAlterado, produtoAlterado.Nome, "Deveria ter sido cadastrado o produto de id{0}.", nomeAlterado);
        }

        [TestMethod]
        [TestCategory(CATEGORIA_TESTE)]
        public void DeveRemoverUmProduto()
        {
            // System Under Test
            ContextStub contexto = InicializarBancoEmMemoria(MethodBase.GetCurrentMethod().Name);

            RepositorioProduto repositorioProduto = new RepositorioProduto(contexto);

            // Pre-conditions
            repositorioProduto.Adicionar(new Product { Id = 1, Nome = "Prod1", Preco = "2,75", Categoria = "Esporte" });
            var produto = repositorioProduto.Entidades().FirstOrDefault();

            // Exercise
            repositorioProduto.Excluir(produto.Id);
            contexto.SaveChanges();


            // Assertives
            var produtos = repositorioProduto.Entidades().ToList();
            Assert.AreEqual(0, produtos.Count, "Não deveria possuir um produto, pois o único foi excluído.");
        }


        #endregion
    }
}
