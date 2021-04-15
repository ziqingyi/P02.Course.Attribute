using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Microsoft.Win32;
using P37.Course.Web.Core.Models;

namespace P37.Course.MVC5.Controllers
{
    public class PipeController : Controller
    {
        // GET: Pipe
        public ActionResult Index()
        {
            //HttpRuntime.ProcessRequest(null);
            //HttpApplication
            return View();
        }

        #region HttpModule
        //Module in two areas: 1 windows   2 project web.config file 
        //C:\WINDOWS\Microsoft.NET\Framework64\v4.0.30319\Config\web.config
        //.net framework address, a global config for all the website in the computer.

        public ActionResult Module()
        {
            HttpApplication app = base.HttpContext.ApplicationInstance;
            List<SysEvent> sysEventsList = new List<SysEvent>();
            int i = 1;
            foreach (EventInfo e in app.GetType().GetEvents())
            {
                sysEventsList.Add(new SysEvent(){
                    Id= i++,
                    Name =e.Name,
                    TypeName = e.GetType().Name
                });
            }
            List<string> list = new List<string>();
            foreach (string item in app.Modules.Keys)
            {
                list.Add($"{item} : {app.Modules.Get(item)}");
            }

            ViewBag.Modules = string.Join(",", list);

            return View(sysEventsList);
        }


        #endregion


        #region Http Handler

        public ActionResult Handler()
        {
            base.ViewBag.HttpHandler = base.HttpContext.CurrentHandler.GetType().FullName;
            return View();
        }

        #endregion

    }


    public class HttpProcessDemo
    {
        public class HttpApplicationDemo : IHttpHandler
        {
            public bool IsReusable => true;

            public event Action BeginRequest;
            public event Action EndRequest;
            public event Action PreSomething1Handler;
            public event Action PostSomething1Handler;
            public event Action PreSomething2Handler;
            public event Action PostSomething2Handler;
            public event Action PreSomething3Handler;
            public event Action PostSomething3Handler;
            public event Action PreSomething4Handler;
            public event Action PostSomething4Handler;
            public event Action PreSomething5Handler;
            public event Action PostSomething5Handler;
            public event Action PreSomething6Handler;
            public event Action PostSomething6Handler;

            public void ProcessRequest(HttpContext context)
            {
                this.BeginRequest?.Invoke();

                this.PreSomething1Handler?.Invoke();
                Console.WriteLine("Something 1");
                this.PostSomething1Handler?.Invoke();

                this.PreSomething2Handler?.Invoke();
                Console.WriteLine("Something 2");
                this.PostSomething2Handler?.Invoke();

                this.PreSomething3Handler?.Invoke();
                Console.WriteLine("Something 3");
                this.PostSomething3Handler?.Invoke();

                this.PreSomething4Handler?.Invoke();
                Console.WriteLine("Something 4");
                this.PostSomething4Handler?.Invoke();

                this.PreSomething5Handler?.Invoke();
                Console.WriteLine("Something 5");
                this.PostSomething5Handler?.Invoke();

                this.PreSomething6Handler?.Invoke();
                Console.WriteLine("Something 6");
                this.PostSomething6Handler?.Invoke();

                this.EndRequest?.Invoke();
            }

        }




    }














}