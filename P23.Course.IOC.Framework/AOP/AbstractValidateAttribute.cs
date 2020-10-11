using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.AOP
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(object obj);
    }
}
