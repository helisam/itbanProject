using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IRepositorioProduto : IRepositorio<Product>
    {
        void AdicionarComSP(Product produto);
        void Excluir(int id);
    }
}
