using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace P29.Course.SOA.Web.Remote
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ICustomService" in both code and config file together.
    [ServiceContract]
    public interface ICustomService
    {
        [OperationContract]
        void DoWork();


        [OperationContract]
        int Get();

        int GetWithoutAttr();

        [OperationContract]
        UserInfo GetUser();

    }
}
