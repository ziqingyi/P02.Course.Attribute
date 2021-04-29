using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Models
{
    public class AjaxApiModel<T> where T:class
    {
        public bool Result { get; set; } = false;

        public List<T> Data { get; set; }

        public string Message { get; set; }

        public AjaxApiModel()
        {
            Data = new List<T>();
        }

    }
}
