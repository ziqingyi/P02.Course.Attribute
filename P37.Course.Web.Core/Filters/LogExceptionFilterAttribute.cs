using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Models;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Filters
{
    // http://www.cnblogs.com/Showshare/p/exception-handle-with-mvcfilter.html
    // will only be used in class level, in this case: Controller;
    // will only be executed once, in Controller level.

    [AttributeUsage(AttributeTargets.Class,Inherited = true, AllowMultiple=false)]
    public class LogExceptionFilterAttribute: HandleErrorAttribute
    {
        private Logger logger = Logger.CreateLogger(typeof(LogExceptionFilterAttribute));

        public override void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)// exception has not been handled 
            {
                string controllerName = (string) filterContext.RouteData.Values["controller"];
                string actionName = (string) filterContext.RouteData.Values["action"];
                string msgTemplate = "Exception happens in Controller[{0}]   ---   Action[{1}]";
                logger.Error(string.Format(msgTemplate,controllerName,actionName), filterContext.Exception);


                //check request header,whether it's XMLHttpRequest
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult()
                    {
                        Data = new AjaxResult()
                        {
                            Result = DoResult.Failed,
                            PromptMsg = "Exception happens, Please contact IT Dept",
                            DebugMessage = filterContext.Exception.Message
                        }
                    };
                }
                else
                {
                    filterContext.Result = new ViewResult()
                    {
                        ViewName = "~/Views/Shared/Error.cshtml",
                        ViewData = new ViewDataDictionary<string>(filterContext.Exception.Message)
                    };
                } 
                filterContext.ExceptionHandled = true;
            }
        }

        #region For Core project, check Ajax request.

        private bool IsAjaxRequestInCore(HttpRequest request)
        {
            string header = request.Headers["X-Requested-With"];
            bool res = "XMLHttpRequest".Equals(header);
            return res;
        }

        #endregion


    }


    public static class Process
    {
        public static bool SafeInvoke(this Action act)
        {
            try
            {
                act.Invoke();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }










}
