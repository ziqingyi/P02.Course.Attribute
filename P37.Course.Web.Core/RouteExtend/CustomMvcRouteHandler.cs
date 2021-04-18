using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P37.Course.Web.Core.RouteExtend
{
    public class CustomMvcRouteHandler : MvcRouteHandler
    {
        protected override IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            //IHttpHandler httpHandler = base.GetHttpHandler(requestContext);
            //use custom HttpHandler
            IHttpHandler httpHandler = new CustomHttpHandler();

            return httpHandler;
        }
    }
}
