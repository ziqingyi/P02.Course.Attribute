using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace P31.Course.SOA.WebAPI.Utility.Filters
{
    /// <summary>
    /// Exception without catch will be captured by this filter.
    /// response will be 200, ok. 
    /// </summary>
    public class CustomExceptionFilterAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            Console.WriteLine(actionExecutedContext.Exception.Message);//log?

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                System.Net.HttpStatusCode.OK,
                new 
                {
                    Result = false,
                    Msg ="new exception, please contact admin"
                }
            );// response to front  end. 



        }

    }
}