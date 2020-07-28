using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder2
{
    public class ExceptionHandler : ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("No Exception");
            }
            else
            {
                Console.WriteLine($" Exception: {methodReturn.Exception.Message}");
            }

            return methodReturn;
        }


    }
}
