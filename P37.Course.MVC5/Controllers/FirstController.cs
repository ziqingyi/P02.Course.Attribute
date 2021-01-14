using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Controllers
{
    public class FirstController : Controller
    {
        // GET: First
        public ActionResult Index()
        {
            return View();
        }

        //https://localhost:44332/First/IndexId/3  id is directed by router. only id can do this way.
        // https://localhost:44332/First/IndexId?id=3 url address pass param. 
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