using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using P37.Course.Web.Core.Attributes;

namespace P38.Course.LayUI.WebApi.Controllers
{
    public class FileController : ApiController
    {
        [CustomAllowAnonymous]
        [HttpPost]
        [Route("api/File/SaveFile")]
        public string SaveFile()
        {
            try
            {
                //get request
                HttpContextBase context = (HttpContextBase)Request.Properties["MS_HttpContext"];
                HttpRequestBase request = context.Request;

                //get file info
                var file = request.Files[0];
                //get file name
                var fileName = file.FileName;




            }
            catch (Exception e)
            {
                throw e;
            }



        }





    }
}
