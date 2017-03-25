using System.Web.Mvc;
using System.Web.Routing;

namespace NS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                name: "ProductsByCategoryRoute",
                url: "Products/Search/{categoryName}/{id}",
                defaults: new { controller = "Products", action = "Search", id = UrlParameter.Optional , categoryName = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "ProductDetail",
                url: "Products/Detail/{productName}/{id}",
                defaults: new { controller = "Products", action = "Detail", id = UrlParameter.Optional, productName = UrlParameter.Optional }
            );
        }
    }
}
