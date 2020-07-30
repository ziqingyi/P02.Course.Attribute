using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class LogAfterBehavior: IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {

            IMethodReturn methodReturn = getNext()(input, getNext);

            Console.WriteLine("Log After Behavior");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine("Log After Behavior "+ methodReturn.ReturnValue);

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }

    }
}
