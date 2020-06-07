using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P06.Course.IOSerialize.Serialize
{
    public class Users
    {
        [XmlArrayItem(typeof(User))]
        [XmlArrayItem("User", typeof(User))]
        public Serialize.Users[] User { get; set; }
    }
}
