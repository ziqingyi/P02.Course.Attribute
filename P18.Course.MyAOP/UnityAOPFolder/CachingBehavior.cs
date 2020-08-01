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

        private static Dictionary<string, object> CachingBehaviorDictionary = new Dictionary<string, object>();

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Caching Behavior...");

            IMethodReturn returnMethod = null;
            // 1 one way of check is to test method name.  this example is fake cache.
            if (input.MethodBase.Name.Equals("RegUser"))
            {
                Console.WriteLine("we have cache for GetUser method.....");
                //only create return value for this method
                returnMethod = input.CreateMethodReturn(new User() { Id = 8, Name="user8_cached_by_method", Password = "fdasde56536"});
            }

            // 2 a better way is to check both method name and parameters passed in to the method
                   //key is the method name and parameters.  if all same, we believe the result is same. 
            string key = $"{input.MethodBase.Name}_{Newtonsoft.Json.JsonConvert.SerializeObject(input.Inputs)}";
            if (CachingBehaviorDictionary.ContainsKey(key))
            {
                returnMethod = input.CreateMethodReturn(CachingBehaviorDictionary[key]);

                //return directly, will not execute following steps. like logging, param check
                return returnMethod;

            }
 
            
            //3 checking method 3: whether caching is necessary for this method is to use attribute, this example is fake cache.
            var methodAttributesttributelist = input.MethodBase.GetCustomAttributes(typeof(MethodFilterAttribute), true);
            if (methodAttributesttributelist.Length > 0)//if has cache.
            {
                string returnValue = new User() {Id = 8, Name = "user8_cached_by_attr", Password = "llllllllkjjj"}
                    .Password;//note: this is to pass return value
                returnMethod = input.CreateMethodReturn(returnValue);
            }

            //**************************************************************************************
                          //test method 1 and 3 , because ReturnValue is User object.
            if (returnMethod != null && input.MethodBase.Name.Equals("RegUser")  )
            {
                Console.WriteLine("User {0} has registered successfully...", ((User)returnMethod.ReturnValue).Name);
                return returnMethod;
            }

            if (returnMethod != null && methodAttributesttributelist.Length > 0)
            {
                Console.WriteLine("User has password {0}...", returnMethod.ReturnValue);//fake cache return User obj
                return returnMethod;
            }
                
                 // used for testing caching name and parameters. method 2, invoke and get result and cache result. 
                 //if it is first time running , it will do below. other method will return before.

            {
                IMethodReturn result = getNext().Invoke(input, getNext);
                if (result.ReturnValue != null)
                {
                    CachingBehaviorDictionary.Add(key, result.ReturnValue);//note: add result's ReturnValue
                }
                return result;
            }


        }


        public bool WillExecute
        {
            get { return true; }
        }

    }
}
