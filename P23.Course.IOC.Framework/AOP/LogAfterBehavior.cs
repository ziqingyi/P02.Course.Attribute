using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P23.Course.IOC.Framework.AOP
{
    public class LogAfterBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);//execute the following processes


            Console.WriteLine("LogAfterBehavior....after method:"+input.MethodBase.Name);
           
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            }
            Console.WriteLine("LogAfterBehavior with return" + methodReturn.ReturnValue);

            return methodReturn;

        } 
        
        public bool WillExecute
        {
            get { return true; }
        }
    }
}
