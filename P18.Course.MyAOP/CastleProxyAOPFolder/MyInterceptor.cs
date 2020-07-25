using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace P18.Course.MyAOP.CastleProxyAOPFolder
{
    public class MyInterceptor:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            PreProceed(invocation);
            invocation.Proceed();
            AfterProceed(invocation);
        }

        public void PreProceed(IInvocation invocation)
        {
            Console.WriteLine("before proceed method {0}", invocation);
        }
        public void AfterProceed(IInvocation invocation)
        {
            Console.WriteLine("After proceed method {0}", invocation);
        }
    }
}
