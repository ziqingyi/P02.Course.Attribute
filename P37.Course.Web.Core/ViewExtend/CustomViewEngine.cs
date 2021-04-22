using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace P37.Course.Web.Core.ViewExtend
{
    public class CustomViewEngine : RazorViewEngine
    {
        #region Ctor

        public CustomViewEngine() : this(null)
        {

        }

        public CustomViewEngine(IViewPageActivator viewPageActivator) : base(viewPageActivator)
        {
            this.SetEngine("");
        }

        #endregion


        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            if (controllerContext.HttpContext.Request.UserAgent.Contains("Chrome"))
            {
                this.SetEngine("Chrome");
            }

            return base.CreatePartialView(controllerContext, partialPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            if (controllerContext.HttpContext.Request.UserAgent.Contains("Chrome"))
            {
                this.SetEngine("Chrome");
            }

            return base.CreateView(controllerContext, viewPath, masterPath);
        }




        private void SetEngine(string browser)
        {
            if (!string.IsNullOrWhiteSpace(browser))
            {
                base.AreaViewLocationFormats = new string[]
                {
                    "~/Areas/{2}/"+browser + "Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/"+browser +"Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/"+browser+"Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/"+ browser + "Views/Shared/{0}.vbhtml"
                };
                base.AreaMasterLocationFormats = new string[]
                {
                    "~/Areas/{2}/"+browser + "Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/"+browser +"Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/"+browser+"Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/"+ browser + "Views/Shared/{0}.vbhtml"
                };

                base.AreaPartialViewLocationFormats = new string[]
                {
                    "~/Areas/{2}/"+browser + "Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/"+browser +"Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/" +browser+"Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/" + browser + "Views/Shared/{0}.vbhtml"
                };


                base.ViewLocationFormats = new string[]
                {
                    "~/" + browser +"Views/{1}/{0}.cshtml",
                    "~/" +browser +"Views/{1}/{0}.vbhtml",
                    "~/" + browser +"Views/Shared/{0}.cshtml",
                    "~/" + browser +"Views/Shared/{0}.vbhtml"
                };

                base.MasterLocationFormats = new string[]
                {
                    "~/" + browser +"Views/{1}/{0}.cshtml",
                    "~/" +browser +"Views/{1}/{0}.vbhtml",
                    "~/" + browser +"Views/Shared/{0}.cshtml",
                    "~/" + browser +"Views/Shared/{0}.vbhtml"
                };

                base.PartialViewLocationFormats = new string[]
                {
                    "~/" + browser +"Views/{1}/{0}.cshtml",
                    "~/" +browser +"Views/{1}/{0}.vbhtml",
                    "~/" + browser +"Views/Shared/{0}.cshtml",
                    "~/" + browser +"Views/Shared/{0}.vbhtml"
                };
            }
            else
            {
                base.AreaViewLocationFormats = new string[]
               {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
               };
                base.AreaMasterLocationFormats = new string[]
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                };

                base.AreaPartialViewLocationFormats = new string[]
                {
                    "~/Areas/{2}/Views/{1}/{0}.cshtml",
                    "~/Areas/{2}/Views/{1}/{0}.vbhtml",
                    "~/Areas/{2}/Views/Shared/{0}.cshtml",
                    "~/Areas/{2}/Views/Shared/{0}.vbhtml"
                };


                base.ViewLocationFormats = new string[]
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/{1}/{0}.vbhtml",
                    "~/Views/Shared/{0}.cshtml",
                    "~/Views/Shared/{0}.vbhtml"
                };

                base.MasterLocationFormats = new string[]
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/{1}/{0}.vbhtml",
                    "~/Views/Shared/{0}.cshtml",
                    "~/Views/Shared/{0}.vbhtml"
                };

                base.PartialViewLocationFormats = new string[]
                {
                    "~/Views/{1}/{0}.cshtml",
                    "~/Views/{1}/{0}.vbhtml",
                    "~/Views/Shared/{0}.cshtml",
                    "~/Views/Shared/{0}.vbhtml"
                };

                base.FileExtensions = new string[]
                {
                    "cshtml",
                    "vbhtml"
                };
            }


            //method ends
        }





    }
}
