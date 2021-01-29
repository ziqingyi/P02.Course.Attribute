using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P37.Course.MVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name:"About",
                url:"About",
                defaults: new {controller ="Home", action="About", id = UrlParameter.Optional}
                );

            //http://localhost:2018/Test/time?year=2019&month=02&day=07
            routes.MapRoute(
                name: "Test",
                url: "Test/{action}/{id}",
                defaults: new { controller = "Second", action = "Index", id = UrlParameter.Optional }
                );

            //http://localhost:2018/second/time_2019_02_07 SUCCESS
            //http://localhost:2018/TEST/time_2019_02_07 FAILED
            routes.MapRoute(
                name: "Regex",
                url: "{controller}/{action}_{year}_{month}_{day}",
                defaults: new { controller = "Second", action = "Index", id = UrlParameter.Optional },
                constraints:new {year =@"\d{4}", month=@"\d{2}", day=@"\d{2}"}
                );

            //error when https://localhost:44332/home/index if no namespaces added,
            //because it will load all class based on controller from all areas when registering
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                ,namespaces: new string[] { "P37.Course.MVC5.Controllers", "P37.Course.MVC5.Plugins" }
                );
        }
    }
}
