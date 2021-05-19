using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomGlobalActionFilterAttribute:Attribute, IActionFilter
    {
        private ILogger<CustomActionFilterAttribute> _logger = null;
        public CustomGlobalActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Console.WriteLine("CustomGlobalActionFilterAttribute Executing!");
            this._logger.LogInformation("CustomGlobalActionFilterAttribute Executing!");
            //context.HttpContext.Response.WriteAsync("CustomGlobalActionFilterAttribute Executing!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Console.WriteLine("CustomGlobalActionFilterAttribute Executed!");
            this._logger.LogInformation("CustomGlobalActionFilterAttribute Executed!");
            //context.HttpContext.Response.WriteAsync("CustomGlobalActionFilterAttribute Executed!");
        }


    }
}
