using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ResultInformation
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.MapRoute("test", "saria", new { controller = "Home", action = "Index" }, @namespaces: new string[] { "ResultInformation.Controllers" });

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                @namespaces:new string[]{"ResultInformation.Controllers"}
            );
           // routes.MapRoute("test","hisaria",new {"Saria",action="Index"});
        }
    }
}
