using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P39.Course.dotnetCoreLib.Filters;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{

    //[CustomControllerActionFilter]
    [TypeFilter(typeof(CustomControllerActionFilterAttribute), Order = 1)]
    public class CThirdController : Controller
    {




        [ServiceFilter(typeof(CustomActionFilterAttribute), Order = 1)] //default order is 0. must add in startup for the filter.
        //[CustomActionFilter]
        [CustomResultFilter]
        [CustomResourceFilter]
        public IActionResult Index()
        {
            return View();
        }
    }
}
