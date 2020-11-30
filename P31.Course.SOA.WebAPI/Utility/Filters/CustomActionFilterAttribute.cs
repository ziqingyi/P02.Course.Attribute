using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace P31.Course.SOA.WebAPI.Utility.Filters
{
    public class CustomActionFilterAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            Console.WriteLine("OnActionExecuting....");
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine("OnActionExecuted....");
            actionExecutedContext.Response.Headers.Add("Access-Control-Allow-Origin","*");
        }

    }
}