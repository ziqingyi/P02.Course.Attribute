using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace P39.Course.dotnetCoreLib.Filters
{
    /// <summary>
    /// handling exceptions. 
    /// </summary>
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        public CustomExceptionFilterAttribute(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
            _hostingEnvironment = hostingEnvironment;
        }

        public override void OnException(ExceptionContext filterContext)
        {
            string controllerName = (string)filterContext.RouteData.Values["controller"];
            string actionName = (string)filterContext.RouteData.Values["action"];
            string msgTemplate = "Exception happens in Controller[{0}]   ---   Action[{1}]";

            //check request header,whether it's XMLHttpRequest
            if (this.IsAjaxRequestInCore(filterContext.HttpContext.Request))
            {
                filterContext.Result = new JsonResult(
                    new
                    {
                        Result = false,
                        PromptMsg = "Exception happens, Please contact IT Dept",
                        DebugMessage = filterContext.Exception.Message
                    }
                );

            }
            else
            {
                var result = new ViewResult { ViewName = "~/Views/Shared/Error.cshtml" };
                result.ViewData = new ViewDataDictionary(_modelMetadataProvider, filterContext.ModelState);
                result.ViewData.Add("Exception", filterContext.Exception);
                filterContext.Result = result;
            }

            filterContext.ExceptionHandled = true;
        }

        #region For Core project, check Ajax request. HttpRequestBase in Framwork has the IsAjaxRequest() method.

        private bool IsAjaxRequestInCore(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            bool res = "XMLHttpRequest".Equals(header);
            return res;
        }

        #endregion

    }


}
