using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Filters
{
    public class CustomHandleErrorAttribute: HandleErrorAttribute
    {

        private Logger logger = new Logger(typeof(CustomHandleErrorAttribute));

        //error happens, execute OnException.
        public override void OnException(ExceptionContext filterContext)
        {
            var httpContext = filterContext.HttpContext;
            if (!filterContext.ExceptionHandled)
            {
                this.logger.Error($"error happens when accessing {httpContext.Request.Url.AbsoluteUri}, error message" +
                                  $"{filterContext.Exception.Message}");

                filterContext.Result = new ViewResult()
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                };
                filterContext.ExceptionHandled = true;//error is handled.
            }

        }

    }
}
