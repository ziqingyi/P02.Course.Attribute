using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace P37.Course.Web.Core
{
    public static class HtmlExtension
    {

        /// <summary>
        /// self defined @html.Submit()
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="value"></param>
        /// <param name="defaultClass"></param>
        /// <returns></returns>
        public static MvcHtmlString Submit(this HtmlHelper helper, string value,
            string defaultClass = "btn btn-default")
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "submit");
            builder.MergeAttribute("value",value);
            builder.MergeAttribute("class", defaultClass);
            builder.ToString(TagRenderMode.EndTag);
            return MvcHtmlString.Create(builder.ToString());
        }

        /// <summary>
        /// go to new line
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static MvcHtmlString Br(this HtmlHelper helper)
        {
            TagBuilder builder = new TagBuilder("br");
            string value = builder.ToString(TagRenderMode.SelfClosing);
            return MvcHtmlString.Create(value);
        }

        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt, string title, object htmlAttributes, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", alt);
            builder.MergeAttribute("title", title);
            builder.MergeAttribute("class", defaultClass);
            builder.MergeAttributes<string, object>(new RouteValueDictionary(htmlAttributes));
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }


        public static MvcHtmlString Link(this HtmlHelper helper, string href, string linkText, string defaultClass = "btn btn-default")
        {
            var builder = new TagBuilder("a");
            builder.MergeAttribute("href", href);
            builder.SetInnerText(linkText);
            builder.MergeAttribute("class", defaultClass);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, string id, string text, string onClick = null)
        {
            var builder = new TagBuilder("input");
            builder.GenerateId(id);
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("value", text);
            if (!string.IsNullOrWhiteSpace(onClick)) builder.MergeAttribute("onclick", onClick);
            builder.MergeAttribute("id", id);
            builder.MergeAttribute("name", id);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString ListViewAssemblies(this HtmlHelper helper)
        {
            TagBuilder ul = new TagBuilder("ul");
            //the compiled View files start with App_Web_
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a=>a.FullName.StartsWith("App_Web_")))
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml = string.Format("full name of the assembly: {0}", assembly.FullName);
                ul.InnerHtml += li.ToString();

                TagBuilder li2 = new TagBuilder("li");
                li2.InnerHtml = string.Format("dll location: {0}", assembly.Location);
                ul.InnerHtml += li2.ToString();
            }
            return MvcHtmlString.Create(ul.ToString());
        }




    }
}