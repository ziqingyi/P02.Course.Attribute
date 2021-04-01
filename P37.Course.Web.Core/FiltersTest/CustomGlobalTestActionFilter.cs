using P32.Course.LuceneProject.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.FiltersTest
{
    public class CustomGlobalTestActionFilter:ActionFilterAttribute
    {
        private Logger logger = new Logger(typeof(CustomGlobalTestActionFilter));
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string msg = "Global: CustomGlobalTestActionFilter OnActionExecuting() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuting(filterContext);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string msg = $"Global: CustomGlobalTestActionFilter OnActionExecuted() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnActionExecuted(filterContext);
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            string msg = $"Global: CustomGlobalTestActionFilter OnResultExecuting() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            string msg = $"Global: CustomGlobalTestActionFilter OnResultExecuted() " + this.Order;
            this.logger.Info(msg);
            filterContext.HttpContext.Response.Write(msg + "<br>");
            //base.OnResultExecuted(filterContext);
        }



    }
}
