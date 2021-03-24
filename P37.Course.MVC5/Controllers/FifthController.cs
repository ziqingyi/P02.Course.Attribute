using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Extensions;

namespace P37.Course.MVC5.Controllers
{
    public class FifthController : Controller
    {
        #region Index and LogIn

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]//response to get
        public ViewResult Login()
        {
            return View();
        }


        public ActionResult Login(string name, string password, string verify)
        {
            string formName = base.HttpContext.Login(name, password, verify);



            return null;
        }
        #endregion







    }
}