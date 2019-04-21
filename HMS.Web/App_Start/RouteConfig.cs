using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace HMS.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Dashboards", action = "Dashboard_2", id = UrlParameter.Optional }
            );
        }
    }
}
