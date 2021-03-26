using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Serialization;

namespace P37.Course.Web.Core.CustomActionResult
{

    public class XmlResultXML : ActionResult
    {
        private object _data = null;
        public XmlResultXML(object data)
        {
            this._data = data;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            HttpResponseBase response = context.HttpContext.Response;
            response.ContentType = "application/xml";

            XmlSerializer serializer = new XmlSerializer(_data.GetType());
            serializer.Serialize(response.Output, _data);


        }


    }
}
