using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.FiltersTest
{
    public class CustomActionTestActionFilterAttribute:ActionFilterAttribute
    {
        private Logger logger = new Logger(typeof(CustomActionTestActionFilterAttribute));
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string msg = "ActionTest: CustomActionTestActionFilterAttribute OnActionExecuting() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = $"ActionTest: CustomActionTestActionFilterAttribute OnActionExecuted() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = $"ActionTest: CustomActionTestActionFilterAttribute OnResultExecuting() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = $"ActionTest: CustomActionTestActionFilterAttribute OnResultExecuted() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuted(filterContext);
        }

    }
}
