using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.Model
{
    [DataContractAttribute]
    public class WCFUser
    {

        public int Id { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public int Sex { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }

    }


    public enum WCFUserSex
    {
        Female,
        Male,
        other
    }


}
