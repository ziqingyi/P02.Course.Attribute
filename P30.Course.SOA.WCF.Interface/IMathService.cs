using P30.Course.SOA.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.Interface
{
    [ServiceContract]
    public interface IMathService
    {
        [OperationContract]
        int PlusInt(int x, int y);

        int Minus(int x, int y);

        [OperationContract]
        WCFUser GetUser(int x, int y);

        [OperationContract]
        List<WCFUser> UserList();

        /*
         //must not be T. 
         //server must know the type when publishing the service. 
        //other programs may use this method using java, js.
        [OperationContract]
        List<T> TList<T>();
        */
    }
}
