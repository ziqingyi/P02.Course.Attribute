using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P23.Course.IOC.Framework.AOP
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
       
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("LogBeforeBehavior...");
            Console.WriteLine("the method going to Invoke is : "+input.MethodBase.Name);

            foreach (var item in input.Inputs)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            }

            return getNext().Invoke(input, getNext);
        } 
        
        public bool WillExecute
        {
            get { return true; }
        }

    }
}
