using Autofac;
using NS.Infrastructure.Logging;

namespace NS.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoggingManager>().As<ILoggingManager>().InstancePerRequest();

            base.Load(builder);
        }
    }
}
