using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomActionFilterAttribute: Attribute, IActionFilter
    {
        private ILogger<CustomActionFilterAttribute> _logger = null;

        public CustomActionFilterAttribute(ILogger<CustomActionFilterAttribute> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this._logger.LogDebug("ActionFilter Executing!");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this._logger.LogInformation("ActionFilter Executed!");
        }

    }
}
