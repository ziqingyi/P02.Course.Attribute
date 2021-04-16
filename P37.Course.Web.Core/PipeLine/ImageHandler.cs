using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace P37.Course.Web.Core.PipeLine
{
    public class ImageHandler:IHttpHandler
    {
        #region IHttpHandler Members

        public bool IsReusable
        {
            get { return true; }
        }
        //anti-theft chain, configure in Web.config
        public void ProcessRequest(HttpContext context)
        {
            // if Urlreferrer is empty, means trying to get the image by url link directly, like crawler, then return below.
            if (context.Request.UrlReferrer == null || context.Request.UrlReferrer.Host == null)
            {
                context.Response.ContentType = "image/JPEG";
                context.Response.WriteFile("/img/noImage.jpg");
            }
            else
            {
                // if Urlreferrer has server name, show request picture. 
                if (context.Request.UrlReferrer.Host.Contains("localhost"))
                {
                    //get physical path for the image
                    string fileName = context.Server.MapPath(context.Request.FilePath);
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile(fileName);
                }
                else
                {
                    context.Response.ContentType = "image/JPEG";
                    context.Response.WriteFile("/img/noImage.jpg");
                }
            }
        }

        #endregion


    }
}
