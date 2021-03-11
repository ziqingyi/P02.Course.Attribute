using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Models;
using P37.Course.Web.ServiceNonEF;

namespace P37.Course.MVC5.Controllers
{
    public class PagingController : Controller
    {
        PagingService ps = new PagingService();
        // GET: Paging
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PagingUsers(int pageIndex=1, int pageSize=10)
        {
            
            Page<CurrentUser> page = ps.GetPages<CurrentUser>(pageIndex, pageSize);

            ViewBag.page = page;

            return View();
        }








    }
}