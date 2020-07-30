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
            IMethodReturn returnMethod = null;
            // one way of check is to test method name. 
            if (input.MethodBase.Name.Equals("GetUser"))
            {
                Console.WriteLine("we have cache for GetUser method.....");
                //only create return value for this method
                returnMethod = input.CreateMethodReturn(new User() { Id = 8, Name="user8_cached_by_method", Password = "fdasde56536"});
                
            }
            //another way of checking whether caching is necessary for this method is to use attribute
            var methodAttributesttributelist = input.MethodBase.GetCustomAttributes(typeof(MethodFilterAttribute), true);
            if (methodAttributesttributelist.Length > 0)
            {
                returnMethod = input.CreateMethodReturn(new User() { Id = 8, Name = "user8_cached_by_attr", Password = "llllllllkjjj" });
            }

            if (returnMethod != null)
            {
                Console.WriteLine("User {0} has registered successfully...", ((User)returnMethod.ReturnValue).Name);
                return returnMethod;
            }
            else
            {
                return getNext().Invoke(input, getNext);
            }
            
        }

        public bool WillExecute
        {
            get { return true; }
        }

    }
}
