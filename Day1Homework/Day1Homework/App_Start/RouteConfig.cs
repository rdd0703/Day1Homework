using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day1Homework
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Skilltree_YYMM",
                url: "skilltree/{year}/{month}",
                defaults: new { controller = "Home", action = "Index", year = UrlParameter.Optional, month = UrlParameter.Optional },
                namespaces: new[] { "Day1Homework.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "skilltree/{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Day1Homework.Controllers" }
            );
        }
    }
}
