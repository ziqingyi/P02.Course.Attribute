using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        ///https://localhost:44332/First/IndexId/3  id is directed by router. only id can do this way.
        /// https://localhost:44332/First/IndexId?id=3 url address pass param. 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ViewResult IndexId(int id)
        {
            return View();
        }

        public ViewResult IndexIdNull(int? id)
        {
            return View();
        }

    }
}