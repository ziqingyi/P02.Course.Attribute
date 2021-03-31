using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Filters
{
    public class CustomActionFilterAttribute : ActionFilterAttribute
    {
        private Logger logger = new Logger(typeof(CustomActionFilterAttribute));
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string msg = "CustomActionFilterAttribute OnActionExecuting()";
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg+"<br>");
            //base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = $"CustomActionFilterAttribute OnActionExecuted()";
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = $"CustomActionFilterAttribute OnResultExecuting()";
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = $"CustomActionFilterAttribute OnResultExecuted()";
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuted(filterContext);
        }

    }
}
