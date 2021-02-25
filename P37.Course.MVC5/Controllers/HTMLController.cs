using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class HTMLController : Controller
    {
        // GET: HTML
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ImageList()
        {
            return new FilePathResult("~/Views/HTML/ImageList.html","text/html");
        }


        public ActionResult Selectors()
        {
            return new FilePathResult("~/Views/HTML/Selectors.html", "text/html");
        }
        public ActionResult MouseActions()
        {
            return new FilePathResult("~/Views/HTML/mouseActions.html", "text/html");
        }

        public ActionResult BindActions()
        {
            return new FilePathResult("~/Views/HTML/bindActions.html", "text/html");
        }


        public ActionResult Detach()
        {
            return new FilePathResult("~/Views/HTML/Detach.html", "text/html");
        }








    }
}