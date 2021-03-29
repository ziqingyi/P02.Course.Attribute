using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.Extensions;
using P37.Course.Web.Core.Filters;
using P37.Course.Web.Core.ImageHelper;
using P37.Course.Web.Core.IOC;
using P37.Course.Web.Core.Models;
using Unity;

namespace P37.Course.MVC5.Controllers
{
    [CustomAuthorize]
    public class FifthController : Controller
    {
        #region Index and LogIn
        public ActionResult Index()
        {
            return View();
        }

        //log in page allow anonymous
        [HttpGet]//response to get
        [CustomAllowAnonymous]
        public ViewResult Login()
        {
            CurrentUser cur = new CurrentUser(){Name = "",Password = ""};

            return View(cur);
        }
        //for submit for authentication
        [HttpPost]
        [CustomAllowAnonymous]
        public ActionResult Login(string name, string password, string captcha)
        {
            string formName = base.HttpContext.Request.Form["Name"];
            LoginResult result = base.HttpContext.Login(name, password, captcha, GetUser,CheckPass, CheckStatusActive);
            if (result == LoginResult.Success)
            {
                //CurrentUrl was assigned the last request URL in session by auth-attr. if not empty, need to direct.
                if (base.HttpContext.Session["CurrentUrl"] != null)
                {
                    string url = base.HttpContext.Session["CurrentUrl"].ToString();
                    base.HttpContext.Session.Remove("CurrentUrl");
                    return base.Redirect(url);
                }
                else
                {
                    return base.Redirect("/Fifth/Index");
                }
            }
            else
            {
                ModelState.AddModelError("failed",result.GetRemark());
                return View();
            }

        }
        #endregion

        #region LogOut 
        [HttpPost]
        [CustomAllowAnonymous]
        public ActionResult Logout()
        {
            this.HttpContext.UserLogout();
            return RedirectToAction("Index", "Fifth");
        }

        #endregion


        #region user check methods
        [ChildActionOnly]
        public User GetUser(string name)
        {
            using (IUserCompanyService service = DIFactory.GetContainer().Resolve<IUserCompanyService>())
            {
                User user = service.Set<User>().FirstOrDefault(u => u.Name.Equals(name) || u.Account.Equals(name));

                return user;
            }
        }
        [ChildActionOnly]
        public bool CheckPass(User user, string password)
        {
            return user.Password == password;
        }
        [ChildActionOnly]
        public bool CheckStatusActive(User user)
        {
            return user.State == 1;
        }

        #endregion

        #region Captcha Verification
        [CustomAllowAnonymous]
        public ActionResult CreateCaptchaFile()
        {
            string code = "";
            Bitmap bitmap = CaptchaHelper.CreateCaptchaObject(out code);
            base.HttpContext.Session["CheckCode"] = code;//session is used for identify the user
            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);
            return File(stream.ToArray(), "image/gif");//return FileContentResult picture
        }
        [CustomAllowAnonymous]
        public void CreateCaptchaResponse()
        {
            string code = "";
            Bitmap bitmap = CaptchaHelper.CreateCaptchaObject(out code);
            base.HttpContext.Session["CheckCode"] = code;
            bitmap.Save(base.Response.OutputStream, ImageFormat.Gif);
            base.Response.ContentType = "image/gif";
        }
        #endregion







    }
}