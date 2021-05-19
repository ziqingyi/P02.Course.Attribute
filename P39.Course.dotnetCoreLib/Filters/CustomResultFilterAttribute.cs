using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomResultFilterAttribute: Attribute, IResultFilter
    {
        //private ILogger<CustomResultFilterAttribute> _logger = null;

        //public CustomResultFilterAttribute(ILogger<CustomResultFilterAttribute> logger)
        //{
        //    this._logger = logger;
        //}
        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("OnResultExecuting Executing!");
            //_logger.LogInformation("OnResultExecuting Executing!");
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Console.WriteLine("OnResultExecuted Executed!");
            //_logger.LogInformation("OnResultExecuted Executed!");
        }




    }
}
