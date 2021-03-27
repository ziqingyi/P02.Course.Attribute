using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using P37.Course.Web.Core.CustomActionResult;
using P37.Course.Web.Core.Models;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute:AuthorizeAttribute
    {
        private Logger logger = new Logger(typeof(CustomAuthorizeAttribute));
        private string _LoginUrl = null;

        public CustomAuthorizeAttribute(string loginUrl ="~/Fifth/Login")
        {
            this._LoginUrl = loginUrl;
        }


        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //base.OnAuthorization(filterContext);//use derived class's logic

            var httpContext = filterContext.HttpContext;//httpcontext contain many things

            if (filterContext.ActionDescriptor.IsDefined(typeof(CustomAllowAnonymousAttribute), true))
            {
                return;
            }
            else if (filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(
                typeof(CustomAllowAnonymousAttribute), true))
            {
                return;
            }
            else if (httpContext.Session["CurrentUser"] == null
                     || !(httpContext.Session["CurrentUser"] is CurrentUser))//session object is empty or not CurrentUser obj
            { 
                //if it is ajax request, need to return ajax format of data
                if (httpContext.Request.IsAjaxRequest())
                {
                   
                    filterContext.Result = new NewtonJsonResult(
                        new AjaxResult() 
                        {
                            Result = DoResult.OverTime,
                            DebugMessage = "Log in Expired",
                            RetValue = ""
                        });
                }
                //if it is http request, redirect to login page
                else
                {
                    //note down the current request URI 
                    httpContext.Session["CurrentUrl"] = httpContext.Request.Url.AbsoluteUri;
                    //short-circuiter, not RedirectResult(), that will execute attribute again. 
                    filterContext.Result = new RedirectResult(this._LoginUrl);
                }
            }
            else
            {
                CurrentUser user = (CurrentUser)httpContext.Session["CurrentUser"];
                return;//continue
            }


        }



    }
}
