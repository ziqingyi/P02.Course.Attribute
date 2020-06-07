using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.Serialize
{
    [Serializable]
    public abstract class People: Object
    {
        public string ID { get; set; }
        private string age { get; set; }
        public abstract string voice();

    }
}
