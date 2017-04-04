using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace VST
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //routes.RouteExistingFiles = true;

            routes.MapRoute(
                name: "Company",
                url: "{page}.htm",
                defaults: new { controller = "Company", action = "Index", page = UrlParameter.Optional }
            );

            //support old url. example: abc/test.htm
            routes.MapRoute(
                name: "CompanyDetail",
                url: "{code}/{page}.htm",
                defaults: new { controller = "Company", action = "CodeDetail", code = UrlParameter.Optional, page = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );            
        }
    }
}
