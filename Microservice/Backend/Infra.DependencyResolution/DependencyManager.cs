using System.Collections.Generic;
using Infra.DependencyResolution.Resolvers.Data;
using Infra.DependencyResolution.Resolvers.Interfaces;
using Infra.DependencyResolution.Resolvers.Repositories;
using Nancy.TinyIoc;

namespace Infra.DependencyResolution
{
    public class DependencyManager
    {
        readonly List<IDependencyResolver> _resolvers;
        readonly TinyIoCContainer _container;

        public DependencyManager(TinyIoCContainer container)
        {
            _container = container;
            _resolvers = new List<IDependencyResolver>();
            InicializarResolvers();
        }

        private void InicializarResolvers()
        {
            _resolvers.Add(new ContextResolver());
            //_resolvers.Add( new ClientsResolver() );
            _resolvers.Add(new RepositoriesResolver());
            //_resolvers.Add( new ServicesResolver() );
        }

        public void RegistrarDependencias()
        {
            foreach (var resolver in _resolvers)
                resolver.Register(_container);
        }
    }
}