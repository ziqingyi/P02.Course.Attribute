using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P02.Course.Attribute.ValidateExtend;

namespace P02.Course.Attribute.EnumExtend
{
    public static class AttributeExtend
    {
        public static bool Validate<T>(this T t)
        {
            Type type = t.GetType();
            foreach (var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidateAttribute), true))
                {
                    object oValue = prop.GetValue(t);
                    foreach (AbstractValidateAttribute att in prop.GetCustomAttributes(typeof(AbstractValidateAttribute),true))
                    {
                        if (!att.Validate(oValue))
                            return false;
                    }
                }
            }
            return true;
        }

        public static string GetRemark(this Enum value)
        {
            Type type = value.GetType();
            var field = type.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute attribute = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return attribute.Remark;
            }
            else
            {
                return value.ToString();
            }
        }
    }
}
