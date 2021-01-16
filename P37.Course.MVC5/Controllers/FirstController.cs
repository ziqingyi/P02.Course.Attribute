using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using P37.Course.MVC5.Models;

namespace P37.Course.MVC5.Controllers
{
    public class FirstController : Controller
    {
        #region User Data
        private List<CurrentUser> _UserList = new List<CurrentUser>()
        {
            new CurrentUser()
            {
                Id=1,
                Name="User1",
                Account="User1Administrator",
                Email="111111@qq.com",
                LoginTime=DateTime.Now,
                Password="123drd",
                Datas = new List<Data>()
                {
                    new Data(){Company = "company1"},
                    new Data(){Company = "company_a"}
                }
            },
            new CurrentUser()
            {
                Id=2,
                Name="User2",
                Account="User2Administrator",
                Email="222222@qq.com",
                LoginTime=DateTime.Now.AddMonths(-2),
                Password="123ljlji",
                Datas = new List<Data>()
                {
                    new Data(){Company = "company2"},
                    new Data(){Company = "company_b"}
                }
            },
            new CurrentUser()
            {
                Id=3,
                Name="User3",
                Account="User3Administrator",
                Email="33333@qq.com",
                LoginTime=DateTime.Now.AddDays(-5),
                Password="1ljkll56",
                Datas = new List<Data>()
                {
                    new Data(){Company = "company3"},
                    new Data(){Company = "company_c"}
                }
            },
        };
        #endregion
        ////ambitious
        //public ActionResult Index()
        //{
        //    return View();
        //}

        // GET: First,controller should just check user input and call service, not put business logic here.
        public ActionResult Index(int id = 3)
        {
            CurrentUser currentUser = this._UserList.FirstOrDefault(u=> u.Id == id)??this._UserList[0];

            #region ViewBag, ViewData, cannot be used between actions
            base.ViewBag.CurrentUserViewBag = this._UserList[1];//ViewBag is dynamic type
            base.ViewBag.TestProp = "view bag test prop value";//override by view data,because view data execute late

            base.ViewData["CurrentUserViewData"] = this._UserList[0];
            base.ViewData["TestProp"] = "view data test prop value";//ViewData ViewBag can override each other

            #endregion

            #region TempData, stored in session can be used between actions, and will be deleted once used

            base.TempData["CurrentUserTempData"] = currentUser; 
            base.TempData["TestProp"] = "temp data test prop value";//will not override other test prop,stored independently
            
            #endregion

            if (id <= 3)
            {
                return base.View(this._UserList[2]);//@model --for strong typed object
            }

            if (id < 10)
            {
                return base.View("~/Views/First/Index1.cshtml");//return cshtml view only
            }
            else
            {
                return base.RedirectToAction("TempDataShow");
            }

        }

        public ActionResult TempDataShow()
        {
            return base.View();
        }



        //https://localhost:44332/First/IndexId/3  id is directed by router. only id can do this way.
        //https://localhost:44332/First/IndexId?id=3 url address pass param. 
        public ViewResultBase IndexId(int id)
        {
            return View();
        }

        public ViewResult IndexIdNull(int? id)
        {
            return View();
        }



        #region return test
        //the only way to pass is: https://localhost:44332/first/stringname?name=dfghf
        public string StringName(string name)
        {
            return "This is " + name;
        }
        // https://localhost:44332/first/StringJson?name=dfghf
        public string StringJson(string name)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    Id = 123,
                    Name = name
                });
        }

        //https://localhost:44332/first/JsonResult?id=111&name=erwqr&remark=%22advanced%22
        public JsonResult JsonResult(int id, string name, string remark)
        {
            return new JsonResult()
                {
                    Data = new
                    {
                        Id = id,
                        Name = name,
                        Remark = remark ?? "default remark"
                    },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };
        }


        #endregion






    }
}