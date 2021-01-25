using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P37.Course.Web.Core.AOP
{
    public class LogBeforeBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            //Session, Log user activities
            Console.WriteLine($"{input.MethodBase.Name} LogBeforeBehavior..Start.");
            //try to get input parameter's name and value.
            for (int i = 0; i<input.Inputs.Count;i++)
            {
                ParameterInfo item = input.Inputs.GetParameterInfo(i);
                var value = input.Inputs[i];
                Console.WriteLine($"{item.Name}：{Newtonsoft.Json.JsonConvert.SerializeObject(value)}");
            }
            Console.WriteLine($"{input.MethodBase.Name} LogBeforeBehavior..  End.");
            return getNext().Invoke(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }
    }
}
