using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class SixthExceptionCtorController : Controller
    {
        //test error in controller constructor
        public SixthExceptionCtorController()
        {
            throw new Exception("SixthExceptionCtorController controller ctor error");
        }



        // GET: SixthExceptionCtor
        public ActionResult Index()
        {
            return View();
        }
    }
}