using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using P37.Course.Web.Core.Models;

namespace P37.Course.MVC5
{
    /// <summary>
    /// Summary description for ForecastService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ForecastService : System.Web.Services.WebService
    {
        /*
         *When we invoke the asmx service in MVC project, the MVC tries to resolve the path as specified in RegisterRoutes.
         * Hence it tries to find a controller with that name and a method with the name same as that of the operation
         * inside that controller.
         *
         * The resolution, ignore the paths with .asmx extension.
         * You can do that by adding the following line in RouteConfig.cs :
         * routes.IgnoreRoute("{*x}", new { x = @".*\.asmx(/.*)?" }); 
         */

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Weather> GetWeathers(int CityCode)
        {
            List<Weather> list = new List<Weather>(){
                new Weather()
                {
                    City = "Rosebery", 
                    ShowDate = DateTime.Now.AddDays(1),
                    Icon = "https://localhost:44333/img/w1.png",
                    Temperature = "20~25",
                    WindSpeed = "20 km/h",
                    Remark = "Clouds and sun"
                },
                new Weather()
                {
                    City = "Mascot",
                    ShowDate = DateTime.Now.AddDays(1),
                    Icon = "https://localhost:44333/img/w2.png",
                    Temperature = "26~30",
                    WindSpeed = "10 km/h",
                    Remark = "Sunny"
                }

            };


            return list;
        }




    }
}
