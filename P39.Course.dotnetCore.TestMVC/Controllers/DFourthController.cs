using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P39.Course.dotnetCoreLib.Filters;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
   
    public class DFourthController : Controller
    {
        #region Identity
        private ILoggerFactory _factory = null;
        private ILogger<DFourthController> _logger = null;
        public DFourthController(ILoggerFactory factory, ILogger<DFourthController> logger)
        {
            this._factory = factory;
            this._logger = logger;
        }
        #endregion


        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password)
        {
            string formName = base.HttpContext.Request.Form["Name"];
            this._logger.LogInformation($"{name} {password} Log into system");


            return View();
        }


    }
}