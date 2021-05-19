using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomActionFilterAttribute: Attribute, IActionFilter
    {
        //private ILogger<CustomActionFilterAttribute> _logger = null;

        //public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        //{
        //    this._logger = logger;
        //}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Response.WriteAsync("ActionFilter Executing!");
            //this._logger.LogDebug("ActionFilter Executing!");
            Console.WriteLine("ActionFilter Executing!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //context.HttpContext.Response.WriteAsync("ActionFilter Executed!");
            //this._logger.LogInformation("ActionFilter Executed!");
            Console.WriteLine("ActionFilter Executed!");
        }

    }
}
