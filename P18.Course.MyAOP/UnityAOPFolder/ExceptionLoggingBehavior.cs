using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class ExceptionLoggingBehavior: IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Exception Logging Behavior");
            IMethodReturn methodReturn = getNext()(input, getNext);
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("No exception");
            }
            else
            {
                Console.WriteLine($" Exception: {methodReturn.Exception.Message}");
            }

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }


    }
}
