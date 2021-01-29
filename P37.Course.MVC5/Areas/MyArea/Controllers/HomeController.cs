using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Areas.MyArea.Controllers
{
    public class HomeController : Controller
    {
        // GET: MyArea/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}