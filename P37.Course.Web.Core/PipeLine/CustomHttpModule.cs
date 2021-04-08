using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace P37.Course.Web.Core.PipeLine
{
    public class CustomHttpModule : IHttpModule
    {
        void IHttpModule.Dispose()
        {
            Console.WriteLine();
        }

        void IHttpModule.Init(HttpApplication context)
        {
            context.BeginRequest += (s, e) =>
            {
                HttpContext.Current.Response.Write("CustomHttpModule.BeginRequest" + "<br>");
            };

            context.EndRequest += (s, e) =>
            {
                HttpContext.Current.Response.Write("CustomHttpModule.EndRequest" + "<br>");
            };



        }


    }
}
