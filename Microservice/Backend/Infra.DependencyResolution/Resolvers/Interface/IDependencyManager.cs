using Nancy.TinyIoc;

namespace Infra.DependencyResolution.Resolvers.Interfaces
{
    public interface IDependencyResolver
    {
        void Register(TinyIoCContainer container);
    }
}
