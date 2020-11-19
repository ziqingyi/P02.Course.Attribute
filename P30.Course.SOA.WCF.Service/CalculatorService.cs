using P30.Course.SOA.WCF.Interface;
using P30.Course.SOA.WCF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.Service
{

    public class CalculatorService : ICalculatorService
    {

        public void Plus(int x, int y)
        {
            string id = Thread.CurrentThread.ManagedThreadId.ToString();
            System.Console.WriteLine($"start service: Plus.....x: {x} y:{y} in thread {id}");
            int result = x + y;
            Thread.Sleep(2000);


            ICallBack callBack = OperationContext.Current.GetCallbackChannel<ICallBack>();
            callBack.Show(x,y,result);
        }


    }
}
