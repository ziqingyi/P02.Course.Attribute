﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using P34.Course.Business.Interface.TestCore;
using P39.Course.EntityFrameworkCore3;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
    public class EFifthController : Controller
    {

        #region Identity

        private ILoggerFactory _Factory = null;
        private ILogger<EFifthController> _logger = null;
        private ITestServiceA _ITestServiceA = null;
        private ITestServiceB _ITestServiceB = null;
        private ITestServiceC _ITestServiceC = null;
        private ITestServiceD _ITestServiceD = null;

        //test AOP
        private IA _IA = null;


        public EFifthController(ILoggerFactory loggerFactory,
            ILogger<EFifthController> logger
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

            this._ITestServiceB.Show();

            this._IA.Show(1, "test AOP in interface IA");

            return View();
        }

        public IActionResult Info()
        {
            using (JDDbContext dbContext = new JDDbContext())
            {
                var list = dbContext.Users.Where(u => u.Id > 10);
                base.ViewBag.Users = Newtonsoft.Json.JsonConvert.SerializeObject(list);
            }


            return View();
        }



    }
}
