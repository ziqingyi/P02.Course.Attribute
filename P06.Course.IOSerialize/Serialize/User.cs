using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P06.Course.IOSerialize.Serialize
{
    [Serializable]
    public class User : People
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string Course { get; set; }

        public override string voice()
        {
            return Description;
        }
    }
}
