using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Castle.DynamicProxy;

namespace P39.Course.dotnetCore.TestMVC.Utility
{
    public class CustomAutofacAop:IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            Console.WriteLine($"Invocation. Method ={invocation.Method}");

            Console.WriteLine($"Invocation Arguments={string.Join(",",invocation.Arguments)}");

            invocation.Proceed();

            Console.WriteLine($" Method {invocation.Method} is finished.");
        }


    }
}
