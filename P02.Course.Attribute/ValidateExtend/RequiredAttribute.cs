using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.ValidateExtend
{
    public class RequiredAttribute : AbstractValidateAttribute
    {

        public override bool Validate(object oValue)
        {
            bool test1 = oValue != null ;
            bool test2 = !string.IsNullOrWhiteSpace(oValue.ToString());
            return test1 && test2 ;
        }
    }
}
