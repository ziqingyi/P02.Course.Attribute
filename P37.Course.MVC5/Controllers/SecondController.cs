using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class SecondController : Controller
    {
        // GET: Second
        public ActionResult Index()
        {
            return View();
        }

        public string getString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
        }

        //http://localhost:2018/Second/time?year=2019&month=02&day=07
        //http://localhost:2018/Test/time?year=2019&month=02&day=07
        //http://localhost:2018/second/time_2019_02_07
        public string Time(int year, int month, int day)
        {
            return $"date passed in: {year}-{month}-{day}";
        }


        public ViewResult RazorExtend()
        {
            return View();
        }

        [ChildActionOnly]//can only be referenced
        public ViewResult ChildAction(string name)
        {
            base.ViewBag.Name = name;
            return View();
        }



    }
}