using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using P37.Course.MVC5.App_Start;

using P37.Course.MVC5.Utility;
using P37.Course.Web.Core.Utility;

//using WebGrease.Configuration;

namespace P37.Course.MVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Logger logger = new Logger(typeof(MvcApplication));
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ControllerBuilder.Current.SetControllerFactory(new MyCustomControllerFactory());

            this.logger.Info("website start.....");
        }

        //handle errors in whole project. especially for errors not being handled by filter : handle error attributes.
        //this will get original URL, attribute in controller can get processed url.
        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            this.logger.Error($"{base.Context.Request.Url.AbsoluteUri} has error now");

            Response.Write("System is Error......");

            Server.ClearError();
        }



    }
}
