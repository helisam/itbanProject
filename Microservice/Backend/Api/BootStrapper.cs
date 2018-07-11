using Infra.DependencyResolution;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;

namespace Api
{
    public class BootStrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var dependencyManager = new DependencyManager(container);
            dependencyManager.RegistrarDependencias();
            //pipelines.AfterRequest.AddItemToStartOfPipeline( ctx => container.Resolve<IDataContext>().Dispose() );
        }

        protected override void ConfigureConventions(NancyConventions conventions)
        {
            conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("assets/css", @"content/css"));
            base.ConfigureConventions(conventions);
        }
    }
}
