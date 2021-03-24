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


        public ActionResult Login(string name, string password, string captcha)
        {
            LoginResult result = base.HttpContext.Login(name, password, captcha, GetUser,CheckPass,CheckStatus);
            if (result == LoginResult.Success)
            {
                if (base.HttpContext.Session["CurrentUrl"] != null)
                {
                    string url = base.HttpContext.Session["CurrentUrl"].ToString();
                    base.HttpContext.Session.Remove("CurrentUrl");
                    return base.Redirect(url);
                }
                else
                {
                    base.Redirect("/Home/Index");
                }
            }
            
            {
                ModelState.AddModelError("failed",result.GetRemark());
                return View();
            }

        }
        #endregion




        #region user check methods
        [ChildActionOnly]
        public User GetUser(string name)
        {
            using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            {
                User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name));

                return user;
            }
        }
        [ChildActionOnly]
        public bool CheckPass(User user, string password)
        {
            return user.Password == password;
        }
        [ChildActionOnly]
        public bool CheckStatus(User user)
        {
            return user.State != 1;
        }

        #endregion

        #region Captcha Verification

        
        



        #endregion







    }
}