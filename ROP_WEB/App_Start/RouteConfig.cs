using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ROP_WEB
{
    public class RouteConfig
    {
    

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{cat}/{id}",
                defaults: new { controller = "Home", action = "Index", cat=UrlParameter.Optional, id = UrlParameter.Optional }
            );
        }
    }
}
