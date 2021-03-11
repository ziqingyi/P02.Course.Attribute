using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.Core.Attributes;

namespace P37.Course.Web.Core.Extensions
{
    public static class DataAttributeExtend
    {
        // can not limit the T because this will not allow MySqlBuilder's type to get this mapping
        public static string ClassMapping<T>(this T t) //where T:BaseModel
        {
            Type type = t.GetType();
            if (type.IsDefined(typeof(MappingClassAttribute), true))
            {
                MappingClassAttribute att = (MappingClassAttribute)type.GetCustomAttribute(typeof(MappingClassAttribute), true);
                return att.MappingName;
            }
            else
            {
                return type.Name;
            }
        }
    }
}
