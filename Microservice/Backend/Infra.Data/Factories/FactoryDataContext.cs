using Domain.Interfaces;
using Domain.Interfaces.Factories;

namespace Infra.Data.Factory
{
    public class FactoryDataContext : IFactory<IDataContext>
    {
        public IDataContext Criar()
        {
            return new Context();
        }
    }
}
