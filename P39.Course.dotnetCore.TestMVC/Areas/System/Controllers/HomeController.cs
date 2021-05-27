using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace P39.Course.dotnetCore.TestMVC.Areas.System.Controllers
{
    public class HomeController : Controller
    {

        //must add area nad route for area controllers.
        [Area("System")]
        [Route("System/[controller]")]//remove mapping for /[action] 
        public IActionResult Index()
        {
            return View();
        }
    }
}
