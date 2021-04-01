using P37.Course.Web.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace P37.Course.Web.Core.FiltersTest
{
    public class CustomControllerTestActionFilterAttribute:ActionFilterAttribute
    {
        private Logger logger = new Logger(typeof(CustomControllerTestActionFilterAttribute));
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string msg = "ControllerTest: CustomControllerTestActionFilterAttribute OnActionExecuting() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = $"ControllerTest: CustomControllerTestActionFilterAttribute OnActionExecuted() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = $"ControllerTest: CustomControllerTestActionFilterAttribute OnResultExecuting() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = $"ControllerTest: CustomControllerTestActionFilterAttribute OnResultExecuted() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuted(filterContext);
        }

    }
}
