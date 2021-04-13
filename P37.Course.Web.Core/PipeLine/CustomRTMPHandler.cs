using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace P37.Course.Web.Core.PipeLine
{
    public class CustomRTMPHandler:IHttpHandler
    {
        public bool IsReusable => true;

        
        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("This is CustomRTMPHandler ProcessRequest AAA");
            context.Response.ContentType = "text/html";
        }



    }
}
