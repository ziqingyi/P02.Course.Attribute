using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace P37.Course.Web.Core.RouteExtend
{
    public class CustomHttpHandler:IHttpHandler
    {
        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";

            string file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Web.config");

            context.Response.WriteFile(file);

        }


    }
}
