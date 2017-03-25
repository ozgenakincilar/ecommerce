using System.Web.Mvc;
using System.Web.Routing;

namespace NS.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            MapperConfig.ConfigureMappings();
        } 
    }
}
