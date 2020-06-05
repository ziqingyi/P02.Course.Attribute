using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.Serialize
{
    public abstract class People
    {
        public string ID { get; set; }
        private string color { get; set; }
        public abstract string voice();

    }
}
