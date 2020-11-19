using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.Interface
{
    [ServiceContract(CallbackContract = typeof(ICallBack))]
    public interface ICalculatorService
    {
        //IsOneWay: Gets or sets a value that indicates whether an operation returns a reply message.
        //          true: if this method receives a request message and returns no reply message. 
        [OperationContract(IsOneWay = true)]
        void Plus(int x, int y);

    }
}
