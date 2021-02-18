using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Main()
        {
            return new FilePathResult("~/Views/Admin/Main.html", "text/html");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult testDIV()
        {
            return new FilePathResult("~/Views/Admin/testDIV.html", "text/html");
        }

    }
}