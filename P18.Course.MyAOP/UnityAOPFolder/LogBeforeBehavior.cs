using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class LogBeforeBehavior:IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBeforeBehavior");
            foreach (var item in input.Inputs)// out put all parameters
            {
                Console.WriteLine("Logging inputs: {0} , method name: {1}",
                    item.ToString(), input.MethodBase.Name);//reflection? Json serialization ? 
            }

            return getNext().Invoke(input, getNext);

        }

        public bool WillExecute
        {
            get { return true; }
        }

    }
}
