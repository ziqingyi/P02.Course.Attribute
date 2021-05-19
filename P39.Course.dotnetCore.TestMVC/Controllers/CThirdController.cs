using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P39.Course.dotnetCoreLib.Filters;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{


    [TypeFilter(typeof(CustomControllerActionFilterAttribute), Order = 1)]
    public class CThirdController : Controller
    {
        public CThirdController(ILogger<BSecondController> logger)
        {
            logger.LogInformation("initialize third controller");
        }



        [ServiceFilter(typeof(CustomActionFilterAttribute), Order = 1)] //default order is 0. must add in startup for the filter.
        //[CustomActionFilter]
        [CustomResultFilter]
        [CustomResourceFilter]
        public IActionResult Index()
        {
            base.ViewBag.Now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");

            return View();
        }
    }
}
