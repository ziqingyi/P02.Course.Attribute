using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.Filters;
using P37.Course.Web.Core.FiltersTest;

namespace P37.Course.MVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            
            //replace with your Handle Error Attribute, affect all controllers
            //filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomHandleErrorAttribute());

            //test global action filters//write in response will affect pictures  
            //filters.Add(new CustomGlobalTestActionFilter());

            //attribute will take effect on all controllers
            //filters.Add(new CustomAuthorizeAttribute("~/Fifth/Login"));
        }
    }
}
