using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using P37.Course.MVC5.Controllers.Utility;

namespace P37.Course.MVC5.Utility
{
    public class MyCustomControllerFactory: DefaultControllerFactory
    {
        private Logger logger = new Logger(typeof(MyCustomControllerFactory));
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            this.logger.Info($"GetControllerInstance:  {controllerType.Name} is being constructed...");
            return base.GetControllerInstance(requestContext, controllerType);
        }

    }
}