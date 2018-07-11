using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Services.Impl
{
    public class ProdutoService : IProdutoService
    {
        #region Atributos

        private readonly IRepositorioProduto _repositorioProduto;

        #endregion

        #region Construtores

        public ProdutoService(IRepositorioProduto repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        #endregion

        #region Métodos Principais

        public Product Obter(string nome)
        {
            return _repositorioProduto.Consultar(p => p.Nome.Equals(nome)).SingleOrDefault();
        }

        public List<Product> Listar()
        {
            return _repositorioProduto.Entidades().ToList();
        }

        public void Adicionar(Product produto)
        {
            _repositorioProduto.Adicionar(produto);
        }

        public void AdicionarComSp(Product produto)
        {
            _repositorioProduto.AdicionarComSP(produto);
        }

        public void Atualizar(Product produto)
        {
            _repositorioProduto.Atualizar(produto);
        }

        public void Remover(int id)
        {
            _repositorioProduto.Excluir(id);
        }

        #endregion
    }
}