using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Attributes
{
    public class RemarkAttribute:Attribute
    {
        private string _remark = string.Empty;

        public RemarkAttribute(string remark)
        {
            _remark = remark;
        }

        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        public string Description { get; set; }

    }


    public enum ShowAttribute
    {
        [Remark("This is good", Description = "this is good in Description")]
        Good =0,
        Bad =1
    }









}
