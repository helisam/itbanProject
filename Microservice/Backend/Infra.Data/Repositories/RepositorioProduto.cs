using Domain.Entities;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using Infra.Data.Repositories.Base;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Infra.Data.Repositories
{
    public class RepositorioProduto : Repositorio<Product>, IRepositorioProduto
    {
        #region Construtor

        public RepositorioProduto(IDataContext contexto)
            : base(contexto)
        {
        }

        #endregion

        #region Métodos Principais

        public void AdicionarComSP(Product produto)
        {
            const string sp = "SP_InserirProduto @Nome, @Preco, @Categoria";

            var parametros = new SqlParameter[]
            {
                new SqlParameter { ParameterName = "@Nome",  Value =produto.Nome , Direction = ParameterDirection.Input},
                new SqlParameter { ParameterName = "@Preco",  Value =produto.Preco, Direction = ParameterDirection.Input },
                new SqlParameter { ParameterName = "@Categoria",  Value =produto.Categoria, Direction = ParameterDirection.Input },
            };

            _contexto.AddWithSP(produto, sp, parametros);
        }

        public void Atualizar(Product prod)
        {
            var produto = new Product
            {
                Id = prod.Id,
                Nome = prod.Nome,
                Preco = prod.Preco,
                Categoria = prod.Categoria
            };
            _contexto.Update(produto);
            _contexto.CommitChanges();
        }

        public void Excluir(int id)
        {
            Product produto = _contexto.Entity<Product>().SingleOrDefault( p => p.Id == id);
            _contexto.Delete(produto);
            _contexto.CommitChanges();
        }

        #endregion
    }
}
