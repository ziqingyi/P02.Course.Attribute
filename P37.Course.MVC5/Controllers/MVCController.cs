using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class MVCController : Controller
    {
        // GET: MVC
        public ActionResult IndexBootstrap()
        {
            return new FilePathResult("~/Views/MVC/IndexBootstrap.html", "text/html");//
        }

        public ActionResult Table()
        {
            return new FilePathResult("~/Views/MVC/table.html","text/html");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            //get values, request's get and post
            string id1 = Request["id"]??ToString(); //get   post
            string id2 = Request.QueryString["id"]; //get 
            object id3 = RouteData.Values["id"]??ToString();//get route information




            return View();
        }


        public ActionResult ProductList()
        {
            return View();
        }


    }
}