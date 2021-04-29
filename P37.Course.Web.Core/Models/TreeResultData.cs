using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Models
{
    public class TreeResultData
    {
        public Guid id { get; set; }
        public string title { get; set; }
        public string href { get; set; }
  
        //public bool isChecked { get; set; }
        public bool disabled { get; set; }

        public List<TreeResultData> children { get; set; }


    }
}
