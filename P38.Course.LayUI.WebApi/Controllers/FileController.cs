using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
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

                //get extend name
                int idxStart = fileName.LastIndexOf(".")+1;
                string extensionName = fileName.Substring(idxStart, fileName.Length - idxStart);

                //get Guid for file name
                string fileStorageName = Guid.NewGuid().ToString();

                //generate file address
                string filePath = Path.Combine(HostingEnvironment.MapPath("~/fileUpload"),
                    $"{fileStorageName}.{extensionName}");

                //save to this address
                request.Files[0].SaveAs(filePath);

                //return result
                var result = new
                {
                    StorageName = $"{fileStorageName}.{extensionName}", //save file name used for storage
                    OldFileName = fileName,
                    IsImage = file.ContentType.Split('/')[0] == "image"
                };
                string JsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(result);
                return JsonResult;
            }
            catch (Exception e)
            {
                throw e;
            }



        }





    }
}
