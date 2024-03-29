﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomControllerActionFilterAttribute : Attribute, IActionFilter
    {
        private ILogger<CustomControllerActionFilterAttribute> _logger = null;
        public CustomControllerActionFilterAttribute(ILogger<CustomControllerActionFilterAttribute> logger)
        {
            this._logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //Console.WriteLine("CustomControllerActionFilterAttribute Executing!");
            this._logger.LogInformation("CustomControllerActionFilterAttribute Executing!");
            //context.HttpContext.Response.WriteAsync("CustomControllerActionFilterAttribute Executing!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //Console.WriteLine("CustomControllerActionFilterAttribute Executed!");
            this._logger.LogInformation("CustomControllerActionFilterAttribute Executed!");
            //context.HttpContext.Response.WriteAsync("CustomControllerActionFilterAttribute Executed!");
        }



    }
}
