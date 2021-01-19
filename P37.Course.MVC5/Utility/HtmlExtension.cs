using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;

namespace P37.Course.MVC5.Utility
{
    public static class HtmlExtension
    {


        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            TagBuilder builder = new TagBuilder("br");
            string value = builder.ToString(TagRenderMode.SelfClosing);
            return MvcHtmlString.Create(value);
        }





    }
}