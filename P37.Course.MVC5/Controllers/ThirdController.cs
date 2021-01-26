using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;
using P33.Course.Model;
using P33.Course.Model.Models;
using P34.Course.Business.Interface;
using P34.Course.Business.Service;
using P37.Course.Web.Core.Models;
using P37.Course.Web.Core.IOC;
using Unity;

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
        [InjectionConstructor]//container will use this ctor
        public ThirdController(IUserService userService, ICompanyService companyService,
            IUserCompanyService userCompanyService)
        {
            this._iUserService = userService;
            this._iCompanyService = companyService;
            this._iUserCompanyService = userCompanyService;
        }



        // GET: Third default view, return a user information
        public ActionResult Index(int id=2)
        {
            User user1 = null;
            User user2 = null;
            User user3 = null;
            User user4 = null;

            //1 First way to get user is to use EF directly.
            using (JDDbContext context = new JDDbContext())
            {
                user1 = context.Set<User>().Find(id);
            }

            //2 Second way to get user is to use your service classes. 
            using(JDDbContext context = new JDDbContext())
            {
                using (IUserService NewUserService = new UserService(context))
                {
                    user2 = NewUserService.Find<User>(id);
                }
            }

            //3 Third Way: User container to Resolve the service, Resolve the DbContext for EF as well.remember to  "using Unity" first;
            using (IUserService userService = DIFactory.GetContainer().Resolve<IUserService>())
            {
                user3 = userService.Find<User>(id);
            }

            //4 Forth way is to use IOC to create Controller with your services class instance.
            //(1) create default controller factory and set in controller builder in Global.asax.cs
            //(2) the default controller factory will create singleton container with config files
            //(3) container will be used to resolve different controller's  service based on config
            //(4) if the controller need some service, it should get service from ctor parameters, container wil do that. 

            //config IOC, container factory used in controller factory to resolve different controller instance
            //all objects will be disposed after view(HTML) is generated. 
            using (IUserService service = this._iUserService)
            {
                user4 = service.Find<User>(id);
            }

            return View(user4);
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

        #region XmlResult

        public XmlResult XmlResult()
        {
            MyXMLData d = new MyXMLData() {Id = 222, Name = "User XmlResult"};
            return new XmlResult(d);
        }

        #endregion




    }

        
    public class XmlResult : ActionResult
    {
        private object _data = null;

        public XmlResult(object data)
        {
            this._data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            context.HttpContext.Response.ContentType = "text/xml";

            XmlSerializer xmlSerializer = new XmlSerializer(this._data.GetType());

            //context.HttpContext.Response.Write(XmlSerializer);
            //HttpResponseBase response = context.HttpContext.Response;
            //response.Write(xmlSerializer.Serialize(this._data));

            xmlSerializer.Serialize(context.HttpContext.Response.OutputStream, this._data);
        }
    }
    [Serializable]
    public class MyXMLData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


}