using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using P37.Course.Web.Core.Attributes;

namespace P38.Course.LayUI.WebApi.Controllers
{
    public class MenuController : ApiController
    {
        [CustomAllowAnonymous]
        [HttpPost]
        public string AddNodeDetail(string parentId, string nodeName)
        {
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    Success = true,
                    Message = "add successfully"
                });

            return jsonResult;
        }



        public string GetUpdateNode(string parentGuid, string title, int random)
        {
            string jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    Success = true,
                    Message = "update successfully"
                });

            return jsonResult;
        }


    }
}
