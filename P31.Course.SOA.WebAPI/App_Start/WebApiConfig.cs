﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using P31.Course.SOA.WebAPI.Utility;

namespace P31.Course.SOA.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.DependencyResolver = new UnityDependencyResolver(ContainerFactory.Container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",//regex, api + controller + parameters.
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
