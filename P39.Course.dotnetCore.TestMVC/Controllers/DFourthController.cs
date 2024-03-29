﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Logging;
using P37.Course.Web.Core.IOC;
using P39.Course.dotnetCoreLib.Extensions;
using P39.Course.dotnetCoreLib.Filters;
using P39.Course.dotnetCoreLib.Models;

namespace P39.Course.dotnetCore.TestMVC.Controllers
{
    /* 1 test CustomAuthorityActionFilterAttribute and log in process, update and check session in attribute, UserManagerCore and view pages. 
     *
     *
     *
     **/


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

        //[TypeFilter(typeof(CustomAuthorityActionFilterAttribute), Order = -999)]//make smaller order to execute first.
        //[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
        //[Authorize(Roles = "Admin")]//only allow Admin roles to log in 
        [Authorize(Policy = "AdvancedStudent")]//only allow user with the policy to log in 
        public IActionResult Index()
        {
            this._logger.LogInformation("This is ILogger<FourthController>  ");
            this._factory.CreateLogger<DFourthController>().LogError("This is ILoggerFactory DFourthController");
            this._logger.LogInformation($"User Name { base.HttpContext.User?.Identity?.Name}");

            return View();
        }
        [CustomAllowAnonymous]//by pass authorize if authorize is configured globally or whole controller. 
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        [CustomAllowAnonymous]
        public ActionResult Login(string name, string password)
        {
            string formName = base.HttpContext.Request.Form["Name"];
            this._logger.LogInformation($"{name} {password} Log into system");

            LoginResult result = base.HttpContext.Login(name, password, GetUser, CheckPass, CheckStatusActive);

            if (result == LoginResult.Success)
            {
               
                return base.Redirect("/DFourth/Index");

            }
            else
            {
                return View();
            }


        }
        [CustomAllowAnonymous]
        public ActionResult Logout()
        {
            base.HttpContext.SignOutAsync().Wait();
            return this.Redirect("~/DFourth/Login");
        }




        #region user check methods

        /// <summary>
        /// Get user from database with same name, and use this user's information to check log in information.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        //[ChildActionOnly]
        public TempDatabaseUser GetUser(string name)
        {
            //get user by IOC, this is Framework version
            //using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            //{
            //    User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name) || u.Account.Equals(name));

            //    return user;
            //}

            //get user from database 
            return new TempDatabaseUser()
            {
                Id = 1,
                Name = "User1",
                Account = "Administrator",
                Password = "123456",
                Email = "werqfasdf@gmail.com",
                Role = "Admin",
                LastLoginTime = DateTime.Now,
                State = 1
            };

        }
        //[ChildActionOnly]
        public bool CheckPass(TempDatabaseUser user, string password)
        {
            return user.Password == password;
        }
        //[ChildActionOnly]
        public bool CheckStatusActive(TempDatabaseUser user)
        {
            return user.State == 1;
        }

        #endregion



    }
}