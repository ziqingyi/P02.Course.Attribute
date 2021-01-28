﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace P37.Course.MVC5.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Web Api Config and service


            //Web Api route
            config.MapHttpAttributeRoutes();


            config.Routes.MapHttpRoute(
                name:"DefaultApi",
                routeTemplate:"api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );

        }

    }
}