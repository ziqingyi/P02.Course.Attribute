using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace P37.Course.MVC5.Plugins
{
    public class CacheController: Controller 
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

    }
}
