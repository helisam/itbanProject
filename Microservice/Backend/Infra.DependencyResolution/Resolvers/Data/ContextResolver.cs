using Domain.Interfaces;
using Infra.Data;
using Infra.DependencyResolution.Resolvers.Interfaces;
using Nancy.Hosting.Aspnet;
using Nancy.TinyIoc;

namespace Infra.DependencyResolution.Resolvers.Data
{
    public class ContextResolver : IDependencyResolver
    {
        public void Register(TinyIoCContainer container)
        {
            container.Register<IDataContext, Context>().AsPerRequestSingleton();
        }
    }
}
