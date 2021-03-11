using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core.Attributes
{
    // used for link to the database table name, sometimes the class name is diff to table name.
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
    public class MappingClassAttribute : Attribute
    {
        public string MappingName { get; private set; }
        public MappingClassAttribute(string mappingName)
        {
            this.MappingName = mappingName;
        }
    }
}
