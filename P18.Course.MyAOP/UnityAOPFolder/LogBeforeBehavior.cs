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
            Console.WriteLine("Log Before Behavior");
            foreach (var item in input.Inputs)// out put all parameters
            {
                Console.WriteLine("Logging inputs: {0} , method name: {1}",
                    item.ToString(), input.MethodBase.Name);//reflection? 

                var jsonString = Newtonsoft.Json.JsonConvert.SerializeObject(item);

                Console.WriteLine("Log with Json serialize: {0}", jsonString);
            }

            return getNext().Invoke(input, getNext);// getNext() return a delegate, then invoke()

        }

        public bool WillExecute
        {
            get { return true; }
        }

    }
}
