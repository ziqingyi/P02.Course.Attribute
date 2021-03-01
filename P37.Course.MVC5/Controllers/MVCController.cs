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
            //get param,by ? request's get and post//test with <a>, only get no post.
            // looks for the key "id" only in the query string; 
            string id1 = Request["id"]??ToString(); //get   post (data from address bar and form)

            //looks for the key "id" in all of the HTTP request collections.
            string id2 = Request.QueryString["id"]; //get  (data only from address bar)


            //get param by route/ 
            object id3 = RouteData.Values["id"]??ToString();//get route information

            //get param by post(hide)


            return View();
        }


        public ActionResult ProductList()
        {
            return View();
        }


    }
}