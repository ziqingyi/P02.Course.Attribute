using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.AOP
{
    public static class AttributeExtend
    {
        public static bool Validate<T>(this T t)
        {
            Type type = t.GetType();
            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    object oValue = prop.GetValue(t);
                    foreach (AbstractValidateAttribute att in prop.GetCustomAttributes(typeof(AbstractValidateAttribute),true))
                    {
                        if (!att.Validate(oValue))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
