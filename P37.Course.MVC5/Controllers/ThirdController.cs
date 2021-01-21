using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P33.Course.Model;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P34.Course.Business.Service;

namespace P37.Course.MVC5.Controllers
{
    public class ThirdController : Controller
    {
        // GET: Third
        public ActionResult Index()
        {
            JDDbContext context = new JDDbContext();
            IUserService service = new UserService(context);
            User user = service.Find<User>(2);

            return View();
        }
    }
}