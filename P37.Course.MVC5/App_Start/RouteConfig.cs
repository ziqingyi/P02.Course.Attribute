﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using P37.Course.Web.Core.RouteExtend;

namespace P37.Course.MVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*x}", new { x = @".*\.asmx(/.*)?" });
            routes.IgnoreRoute("CustomerService/{*pathInfo}");


            #region this will block all non-chrome access, so comment out 

            //routes.Add("chrome", new CustomRoute());

            #endregion 
            



            routes.Add("config", new Route("Config/{path}", new CustomMvcRouteHandler()));


            routes.MapRoute(
                name:"About",
                url: "About",
                defaults: new {controller ="Home", action="About", id = UrlParameter.Optional }
                );


            routes.MapRoute(
                "product1",
                "mvc/{action}/{id}"
                ,new { controller = "MVC", action = "productlist", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "product2",
                "mvc/{action}/{typeid}/{productid}"
                ,new {controller = "MVC", action = "productlist", id = UrlParameter.Optional}
            );

            routes.MapRoute(
                name: "paging",
                url: "Paging/{action}/{pageIndex}/{pageSize}"
                , defaults: new {controller="Paging", action= "PagingUsers", pageSize = UrlParameter.Optional, pageIndex=UrlParameter.Optional }
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
            //because it will load all class based on base controller from all areas when registering
            //so if the controller name and action are same in different areas, it will has error. 
            //name spaces will make the route pick up from nominated namespaces if the controller names are same

            //https://localhost:44332/system/areahome/index area page must be accessed with area name
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
                ,namespaces: new string[] { "P37.Course.MVC5.Controllers", "P37.Course.MVC5.Plugins" }
                );
        }
    }
}
