using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P33.Course.Model;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P34.Course.Business.Service;
using P37.Course.MVC5.Models;

namespace P37.Course.MVC5.Controllers
{
    public class ThirdController : Controller
    {
        private IUserService _iUserService = null;
        private ICompanyService _iCompanyService = null;
        private IUserCompanyService _iUserCompanyService = null;


        /// <summary>
        /// ctor function injection --controller is initialized by container
        /// </summary>
        /// <param name="userService"></param>
        /// <param name="companyService"></param>
        /// <param name="userCompanyService"></param>
        public ThirdController(IUserService userService, ICompanyService companyService,
            IUserCompanyService userCompanyService)
        {
            this._iUserService = userService;
            this._iCompanyService = companyService;
            this._iUserCompanyService = userCompanyService;
        }



        // GET: Third
        public ActionResult Index()
        {
            //bad way to integrate MVC, ORM
            //JDDbContext context = new JDDbContext();
            //IUserService service = new UserService(context);


            //Good way: use IOC to create Controller.
            //1 create default controller factory and set in controller builder in Global.asax.cs
            //2 the default controller factory will create singleton container with config files
            //3 container will be used to resolve different controller's  service based on config
            //4 if the controller need some service, it should get service from ctor parameters, container wil do that. 

            //config IOC, container factory used in controller factory to resolve different controller instance
            IUserService service = this._iUserService;

            User user = service.Find<User>(2);

            return View();
        }

        #region JsonResult:  JsonResult : ActionResult, which is abstract class containing one method ExecuteResult(ControllerContext context)
        //ExecuteResult(ControllerContext context) will be executed
        public JsonResult Json()
        {
            return Json(new
            {
                Id = 123,
                Name = "user Json"
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult JsonResult()
        {
            return new JsonResult()
            {
                Data = new
                { 
                    Id = 123, 
                    Name = "user Json"
                },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        public void JsonVoid()
        {
            var result = Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Id = 123,
                Name = "user JsonVoid"
            });

            base.HttpContext.Response.ContentType = "application/json";
            base.HttpContext.Response.Write(result);
        }
        #endregion






    }
}