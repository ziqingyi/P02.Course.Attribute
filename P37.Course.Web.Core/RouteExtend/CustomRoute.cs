﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P37.Course.Web.Core.RouteExtend
{
    public class CustomRoute:RouteBase
    {
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            if (httpContext.Request.UserAgent.Contains("Chrome"))
            {
                return null;//continue following logic
            }
            else
            {
                RouteData routeData = new RouteData(this, new MvcRouteHandler());
                routeData.Values.Add("controller","pipe");
                routeData.Values.Add("action","refuse");
                return routeData;// break route mapping
            }

        }

        /// <summary>
        /// assign virtual path
        /// </summary>
        /// <param name="requestContext"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {
            return null;
        }
    }
}
