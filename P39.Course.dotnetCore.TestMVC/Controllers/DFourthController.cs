using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P39.Course.dotnetCoreLib.Filters;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
   
    public class DFourthController : Controller
    {



        public IActionResult Index()
        {
            return View();
        }
    }
}