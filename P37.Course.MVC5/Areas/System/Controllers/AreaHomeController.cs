using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Areas.System.Controllers
{
    public class AreaHomeController : Controller
    {
        // GET: System/AreaHome
        public ActionResult Index()
        {
            return View();
        }
    }
}