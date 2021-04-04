using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.Web.Core.Filters
{
    public class CacheFilterAttribute: ActionFilterAttribute
    {
        private int _MaxSecond = 0;

        public CacheFilterAttribute(int duration)
        {
            this._MaxSecond = duration;
        }

        public CacheFilterAttribute()
        {
            this._MaxSecond = 60;
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (this._MaxSecond <= 0) return;

            HttpCachePolicyBase cache = filterContext.HttpContext.Response.Cache;
            TimeSpan cacheDuration = TimeSpan.FromSeconds(this._MaxSecond);

            cache.SetCacheability(HttpCacheability.Public);
            //cache.SetLastModified(DateTime.Now.AddHours(8).Add(cacheDuration));
            //cache.SetExpires(DateTime.Now.AddHours(8).Add(cacheDuration));//GMT time
            cache.SetExpires(DateTime.Now.Add(cacheDuration));
            cache.SetMaxAge(cacheDuration);

            cache.AppendCacheExtension("must-revalidate, proxy-revalidate");

        }




    }
}
