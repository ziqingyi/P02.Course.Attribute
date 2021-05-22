using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using P39.Course.dotnetCoreLib.Models;

namespace P39.Course.dotnetCoreLib.Filters
{
    public class CustomAuthorityActionFilterAttribute:Attribute, IActionFilter
    {
        private ILogger<CustomAuthorityActionFilterAttribute> _logger = null;

        public CustomAuthorityActionFilterAttribute(ILogger<CustomAuthorityActionFilterAttribute> logger)
        {
            this._logger = logger;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            this._logger.LogInformation("CustomAuthorityActionFilterAttribute Executing!");
            string userString = context.HttpContext.Session.GetString("CurrentUser");
            if (!string.IsNullOrWhiteSpace(userString))
            {
                CurrentUserCore currentUser =
                    Newtonsoft.Json.JsonConvert.DeserializeObject<CurrentUserCore>(userString);

                this._logger.LogInformation($"CustomAuthorityActionFilterAttribute authorize user: {currentUser.Name} log in to the system");
            }
            else
            {
                context.Result = new RedirectResult("~/Fourth/Login");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            this._logger.LogInformation("CustomAuthorityActionFilterAttribute Executed!");
        }


    }
}
