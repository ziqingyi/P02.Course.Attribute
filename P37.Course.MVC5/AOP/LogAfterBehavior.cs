using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P37.Course.MVC5.AOP
{
    public class LogAfterBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //transaction can start here
            IMethodReturn methodReturn = getNext()(input, getNext);
            //transaction can commit here


            Console.WriteLine($"{input.MethodBase.Name} LogAfterBehavior..Start.");
            foreach (var item in input.Inputs)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(item));
            }
            Console.WriteLine($"{input.MethodBase.Name} LogAfterBehavior..  End.");
            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
