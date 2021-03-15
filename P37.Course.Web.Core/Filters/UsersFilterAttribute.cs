using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.Web.Core.Filters
{
    public class UsersFilterAttribute:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //authorization of log in
            if (  filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true)   )
            {
                return;
            }


            //try to get session.
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            if (session["CurUser"] == null)
            {
                //if no session value, go to log in
                filterContext.Result = new RedirectResult("~/users/Login");

            }

            //base.OnAuthorization(filterContext);//use default 
        }


    }
}
