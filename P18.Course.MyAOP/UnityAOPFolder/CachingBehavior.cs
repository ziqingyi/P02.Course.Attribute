using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    public class CachingBehavior : IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Caching Behavior...");

            // one way of check is to test method name. 
            if (input.MethodBase.Name.Equals("GetUser"))
            {
                return input.CreateMethodReturn(new User() { Id = 8, Name="user8", Password = "fdasde56536"});
            }
            //another way of checking whether caching is necessary for this method is to use attribute
            if (input.Target.GetType().GetCustomAttributes(typeof(MethodFilterAttr), true).Length > 0)
            {
                return input.CreateMethodReturn(new User() { Id = 8, Name = "user8", Password = "fdasde56536" });
            }

            return getNext().Invoke(input, getNext);
        }

        public bool WillExecute
        {
            get { return true; }
        }

    }
}
