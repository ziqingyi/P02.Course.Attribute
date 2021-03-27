using System.Web;
using System.Web.Mvc;
using P37.Course.Web.Core.Attributes;

namespace P37.Course.MVC5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            //attribute will take effect on all controllers
            //filters.Add(new CustomAuthorizeAttribute());
        }
    }
}
