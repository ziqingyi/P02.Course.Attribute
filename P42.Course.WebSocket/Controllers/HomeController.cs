using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P42.Course.WebSocket.Controllers
{
    public class HomeController : Controller
    {
        private string _userName = "";
        public ActionResult WebSocket()
        {
            return View();
        }




















        #region default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion


    }
}