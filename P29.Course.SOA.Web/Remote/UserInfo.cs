using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace P29.Course.SOA.Web.Remote
{

    //if do not have parameterless ctor, must use DataContract and DataMember for serialization. otherwise not visible. 
    [DataContractAttribute]
    public class UserInfo
    {
        public UserInfo()
        {

        }
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        
        public int Age { get; set; }
        
        [DataMember]
        public string Description { get; set; }

    }
}