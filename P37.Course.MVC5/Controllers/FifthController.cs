using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P37.Course.Web.Core.Extensions;
using P37.Course.Web.Core.IOC;
using Unity;

namespace P37.Course.MVC5.Controllers
{
    public class FifthController : Controller
    {
        #region Index and LogIn

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]//response to get
        public ViewResult Login()
        {
            return View();
        }


        public ActionResult Login(string name, string password, string verify)
        {
            //string formName = base.HttpContext.Login(name, password, verify);



            return null;
        }
        #endregion




        #region methods
        [ChildActionOnly]
        public User GetUser(string name, string password)
        {
            using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            {
                User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name) && u.Password.Equals(password));

                return user;
            }
        }

        #endregion




    }
}