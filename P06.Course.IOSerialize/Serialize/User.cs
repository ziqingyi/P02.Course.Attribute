using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.Serialize
{
    public class User:People
    {
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
