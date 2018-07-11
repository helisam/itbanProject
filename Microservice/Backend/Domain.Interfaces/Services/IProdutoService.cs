using System.Collections.Generic;
using Domain.Entities;

namespace Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Product Obter(string nome);
        List<Product> Listar();
        void Adicionar(Product produto);
        void AdicionarComSp(Product produto);
        void Atualizar(Product produto);
        void Remover(int id);
    }
}
