using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public abstract class AbstractValidateAttribute : Attribute
    {
        public abstract bool Validate(Object obj);
    }
}
