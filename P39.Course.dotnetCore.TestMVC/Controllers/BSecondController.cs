using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P34.Course.Business.Interface.TestCore;
using P39.Course.dotnetCore.TestMVC.Utility;
using P39.Course.dotnetCoreLib.Filters;


namespace P39.Course.dotnetCore.TestMVC.Controllers
{

    [CustomControllerActionFilter]
    public class BSecondController : Controller
    {
        #region Identity

        private ILoggerFactory _Factory = null;
        private ILogger<BSecondController> _logger = null;
        private ITestServiceA _ITestServiceA = null;
        private ITestServiceB _ITestServiceB = null;
        private ITestServiceC _ITestServiceC = null;
        private ITestServiceD _ITestServiceD = null;

        //test AOP
        private IA _IA = null;


        public BSecondController(ILoggerFactory loggerFactory,
            ILogger<BSecondController> logger
            ,
            ITestServiceA testServiceA,
            ITestServiceB testServiceB,
            ITestServiceC testServiceC,
            ITestServiceD testServiceD
            ,
            IA a
        )
        {
            this._Factory = loggerFactory;
            this._logger = logger;
            this._ITestServiceA = testServiceA;
            this._ITestServiceB = testServiceB;
            this._ITestServiceC = testServiceC;
            this._ITestServiceD = testServiceD;
            this._IA = a;
        }

        #endregion

        [ServiceFilter(typeof(CustomActionFilterAttribute), Order = 1)] //default order is 0. must add in startup for the filter.
        //[CustomActionFilter]
        [CustomResultFilter]
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

            this._IA.Show(1,"test AOP in interface IA");

            this._ITestServiceB.Show();

            return View();
        }


        public ActionResult Exception()
        {
            int i = 0;
            int k = 10 / i;
            return View();
        }


    }



    #region test area

    [Intercept(typeof(CustomAutofacAop))]
    public class A : IA
    {
        private ILoggerFactory _Factory = null;
        private ILogger<A> _logger = null;
        public A(ILoggerFactory loggerFactory,
            ILogger<A> logger)
        {
            this._Factory = loggerFactory;
            this._logger = logger;
        }
        public void Show(int id, string name)
        {
            _logger.LogInformation($"This is {id} _ {name}");
        }

    }

    #endregion

}
