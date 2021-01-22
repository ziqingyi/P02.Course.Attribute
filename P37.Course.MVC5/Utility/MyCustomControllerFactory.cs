using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using P37.Course.MVC5.Controllers.Utility;
using Unity;

namespace P37.Course.MVC5.Utility
{
    /// <summary>
    /// 1 implement DefaultControllerFactory
    /// 2 SetFactory -- where the controller is initialized.
    /// 3 Use container -- initialize controller with container
    /// </summary>
    public class MyCustomControllerFactory: DefaultControllerFactory
    {
        private Logger logger = new Logger(typeof(MyCustomControllerFactory));
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            this.logger.Info($"GetControllerInstance:  {controllerType.Name} is being constructed...");

            //1 use container to create controller
            IUnityContainer container = DIFactory.GetContainer();
            IController controller = (IController)container.Resolve(controllerType);
            return controller;

            //2 original way of creating controller
            //return base.GetControllerInstance(requestContext, controllerType);
        }

    }
}