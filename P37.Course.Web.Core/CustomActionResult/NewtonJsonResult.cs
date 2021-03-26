using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.Web.Core.CustomActionResult
{
    public class NewtonJsonResult: ActionResult
    {
        private object _data = null;

        public NewtonJsonResult(object data)
        {
            this._data = data;
        }
        //Newtonsoft's JsonConvert has better performance than JavaScriptSerializer
        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/json";
            response.Write(Newtonsoft.Json.JsonConvert.SerializeObject(this._data));
        }
    }
}
