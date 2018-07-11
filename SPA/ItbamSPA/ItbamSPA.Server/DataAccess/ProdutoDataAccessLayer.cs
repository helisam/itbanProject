using ItbamSPA.Shared.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ItbamSPA.Server.DataAccess
{
    public class ProdutoDataAccessLayer
    {
        #region Atributos

        ItbamContext db = new ItbamContext();

        #endregion

        #region Métodos Crud

        public IEnumerable<Produto> Listar()
        {
            try
            {
                return db.Produto.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void Adicionar(Produto produto)
        {
            try
            {
                db.Produto.Add(produto);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Atualizar(Produto produto)
        {
            try
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Produto ObterProdutoPorId(int id)
        {
            try
            {
                var employee = db.Produto.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        public void Remover(int id)
        {
            try
            {
                var emp = db.Produto.Find(id);
                db.Produto.Remove(emp);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        #endregion
    }
}
