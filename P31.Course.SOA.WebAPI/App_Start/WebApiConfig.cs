﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using P31.Course.SOA.WebAPI.Utility;
using P31.Course.SOA.WebAPI.Utility.Filters;
using System.Web.Http.Cors;

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

            //filter for all controllers. Exception: so need some [AllowAnonymous] for some methods.  
            //config.Filters.Add(new CustomBasicAuthorizeAttribute());

            //filter for all controllers. Exception catch. 
            //but for web api, the filters only works when error happens inside the method, 
            //        if the method is not hit, error will not be captured. 
            config.Filters.Add(new CustomExceptionFilterAttribute());

            //replace exception handler class,will affect all program classes
            config.Services.Replace(typeof(IExceptionHandler), new CustomExceptionHandler());



            //only one cors header can be added, otherwise error.
            config.EnableCors(new EnableCorsAttribute("*","*","*"));




            //a route similar to MVC, use for testing calling webApi with front/back end,
            //put first for mapping first
            config.Routes.MapHttpRoute(
                name: "CustomApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional });




            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",//regex, api + controller + parameters.
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
