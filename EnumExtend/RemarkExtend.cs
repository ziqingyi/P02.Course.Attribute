using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.Attribute.EnumExtend
{
    public static class RemarkExtend
    {
        public static string GetRemark(this Enum enumValue)
        {
            Type type = enumValue.GetType();
            FieldInfo field = type.GetField(enumValue.ToString());
            if(field.IsDefined( typeof(RemarkAttribute), true) )
            {
                RemarkAttribute remarkAttribute =(RemarkAttribute)field.GetCustomAttributes(typeof(RemarkAttribute));
                return remarkAttribute.Remark;
            }
            else
            {
                return enumValue.ToString();
            }

        }



    }
}
