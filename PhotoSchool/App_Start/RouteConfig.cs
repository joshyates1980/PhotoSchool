using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PhotoSchool
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Display photo's details",
                url: "photos/{action}/{id}",
                defaults: new { controller = "Photos", action = "PhotoDetails", id = UrlParameter.Optional },
                namespaces: new[] { "PhotoSchool.Web.Controllers"}
            );

            //routes.MapRoute(
            //    name: "Display question",
            //    url: "questions/{id}/{url}",
            //    defaults: new { controller = "Questions", action = "Display" }
            //);

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "PhotoSchool.Web.Controllers"}
            );

            routes.MapRoute(
                name: "StaticPages",
                url: "{action}",
                defaults: new { controller = "Home" },
                namespaces: new[] { "PhotoSchool.Web.Controllers" }
            );
        }
    }
}
