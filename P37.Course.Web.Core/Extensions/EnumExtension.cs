using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using P37.Course.Web.Core.Attributes;
using P37.Course.Web.Core.Utility;

namespace P37.Course.Web.Core.Extensions
{
    public static class EnumExtension
    {
        private static Logger logger = Logger.CreateLogger(typeof(EnumExtension));

        public static string GetRemark(this Enum value)
        {
            string remark = string.Empty;
            Type type = value.GetType();
            FieldInfo fieldInfo = type.GetField(value.ToString());

            try
            {
                object[] attrs = fieldInfo.GetCustomAttributes(typeof(RemarkAttribute), false);
                RemarkAttribute attr = (RemarkAttribute)attrs.FirstOrDefault(a => a is RemarkAttribute);
                if (attr == null)
                {
                    remark = fieldInfo.Name;
                }
                else
                {
                    remark = attr.Remark;
                }

            }
            catch (Exception x)
            {
                logger.Error("EnumExtension has error in GetRemark",x);
            }

            return remark;
        }
    }
}
