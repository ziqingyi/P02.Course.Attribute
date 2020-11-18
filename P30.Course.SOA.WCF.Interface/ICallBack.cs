using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.Interface
{
    //no contract, it is a constraint, implemented by client. 
    public interface ICallBack
    {
        [OperationContract(IsOneWay = true)]
        void Show(int m, int n, int result);
    }
}
