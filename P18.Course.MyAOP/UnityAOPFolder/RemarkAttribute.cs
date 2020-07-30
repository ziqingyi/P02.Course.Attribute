using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class RemarkAttribute: Attribute
    {
        public string Remark
        {
            get;
            private set;
        }
        public RemarkAttribute(string rem)
        {
            this.Remark = rem;
        }

    }
}
