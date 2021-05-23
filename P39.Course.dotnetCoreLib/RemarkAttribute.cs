using System;
using System.Collections.Generic;
using System.Text;

namespace P39.Course.dotnetCoreLib
{
    public class RemarkAttribute : Attribute
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




}
