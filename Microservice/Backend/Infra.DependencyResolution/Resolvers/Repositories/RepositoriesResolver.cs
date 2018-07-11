using Domain.Interfaces.Repositories;
using Infra.Data.Repositories;
using Infra.DependencyResolution.Resolvers.Interfaces;
using Nancy.Hosting.Aspnet;
using Nancy.TinyIoc;

namespace Infra.DependencyResolution.Resolvers.Repositories
{
    public class RepositoriesResolver : IDependencyResolver
    {
        public void Register(TinyIoCContainer container)
        {
            container.Register<IRepositorioProduto, RepositorioProduto>().AsPerRequestSingleton();
        }
    }
}
