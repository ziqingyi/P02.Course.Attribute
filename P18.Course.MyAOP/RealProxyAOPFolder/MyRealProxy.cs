using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP.RealProxyAOPFolder
{
    public class MyRealProxy<T>: RealProxy
    {
        private T tTarget;

        public MyRealProxy(T target) : base(typeof(T))
        {
            this.tTarget = target;
        }

        public override IMessage Invoke(IMessage msg)
        {
            BeforeProceeds(msg);

            IMethodCallMessage callMessage = (IMethodCallMessage) msg;
            object returnValue = callMessage.MethodBase.Invoke(this.tTarget, callMessage.Args);

            AfterProceeds(msg);

            var result = new ReturnMessage(returnValue, new object[0],0,null, callMessage);

            return result;
        }

        public void BeforeProceeds(IMessage msg)
        {
            Console.WriteLine("execute before proceed logic....");
        }
        public void AfterProceeds(IMessage msg)
        {
            Console.WriteLine("execute after proceed logic....");
        }


    }
}
