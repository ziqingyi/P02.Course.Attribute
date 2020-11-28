using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using P31.Course.SOA.WebAPI.Utility;
using P31.Course.SOA.WebAPI.Utility.Filters;

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

            //filter for all controllers. so need some [AllowAnonymous] for some methods.  
            config.Filters.Add(new CustomBasicAuthorizeAttribute());


            // add a route similar to MVC
            config.Routes.MapHttpRoute(
                name:"CustomApi",
                routeTemplate:"api/{controller}/{action}/{id}",
                defaults:new {id = RouteParameter.Optional});




            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",//regex, api + controller + parameters.
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
