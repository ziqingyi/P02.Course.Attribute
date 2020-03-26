using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.EnumExtend
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class RemarkAttribute : System.Attribute
    {
        //only provide get method to outside
        public string Remark
        {
            get;
            private set;
        }
        public RemarkAttribute(string remark)
        {
            this.Remark = remark;
        }

    }


}
