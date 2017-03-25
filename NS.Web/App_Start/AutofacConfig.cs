using Autofac;
using Autofac.Integration.Mvc;
using NS.Business;
using NS.Infrastructure;
using NS.Infrastructure.Logging;
using System.Web.Mvc;

namespace NS.Web
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterFilterProvider();
            builder.RegisterSource(new ViewRegistrationSource());
            builder.RegisterModule(new InfrastructureModule());
            builder.RegisterModule(new BusinessModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        } 
    }
}