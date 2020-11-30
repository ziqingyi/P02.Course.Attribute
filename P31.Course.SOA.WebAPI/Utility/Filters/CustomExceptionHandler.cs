using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Results;

namespace P31.Course.SOA.WebAPI.Utility.Filters
{
    public class CustomExceptionHandler: ExceptionHandler
    {
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            string url = context.Request.RequestUri.AbsoluteUri;

            //bool result = base.ShouldHandle(context);
            bool result = url.Contains("/api/");
            return result;
        }


        public override void Handle(ExceptionHandlerContext context)
        {
            //log logic
            HttpResponseMessage msg = context.Request.CreateResponse(
                HttpStatusCode.OK,
                new 
                {
                    Result = false,
                    Msg ="error happens, please contact Admin"
                }

            );

            context.Result = new ResponseMessageResult(msg);





        }

    }
}