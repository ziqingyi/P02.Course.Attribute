using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P34.Course.Business.Interface.TestCore;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
    public class BSecondController : Controller
    {
        #region Identity

        private ILoggerFactory _Factory = null;
        private ILogger<BSecondController> _logger = null;
        private ITestServiceA _ITestServiceA = null;
        private ITestServiceB _ITestServiceB = null;
        private ITestServiceC _ITestServiceC = null;
        private ITestServiceD _ITestServiceD = null;

        public BSecondController(ILoggerFactory loggerFactory,
            ILogger<BSecondController> logger
            ,
            ITestServiceA testServiceA,
            ITestServiceB testServiceB,
            ITestServiceC testServiceC,
            ITestServiceD testServiceD
            )
        {
            this._Factory = loggerFactory;
            this._logger = logger;
            this._ITestServiceA = testServiceA;
            this._ITestServiceB = testServiceB;
            this._ITestServiceC = testServiceC;
            this._ITestServiceD = testServiceD;

        }

        #endregion


        public IActionResult Index()
        {
            this._logger.LogInformation("this is  ILogger<BSecondController>");
            this._Factory.CreateLogger<BSecondController>().LogInformation(" this is  ILoggerFactory  create logger ");
            this._logger.LogWarning($"_ITestServiceA = {this._ITestServiceA.GetHashCode()}");
            this._logger.LogWarning($"_ITestServiceB = {this._ITestServiceB.GetHashCode()}");
            this._logger.LogWarning($"_ITestServiceC = {this._ITestServiceC.GetHashCode()}");
            this._logger.LogWarning($"_ITestServiceD = {this._ITestServiceD.GetHashCode()}");

            this._ITestServiceA.Show();
            this._ITestServiceB.Show();
            this._ITestServiceC.Show();
            this._ITestServiceD.Show();

            return View();
        }
    }
}
