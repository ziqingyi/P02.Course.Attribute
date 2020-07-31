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
    public class ParameterCheckBehavior: IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine("Parameter Check Behavior");
            User user = input.Inputs[0] as User;
            if (!AttributeExtend.Validate(user))//using extend method to check class's attribute
            {
                return input.CreateExceptionMethodReturn(new Exception("Password should be more than 10 characters..."));
            }
            else
            {
                Console.WriteLine("parameter all good");
                return getNext().Invoke(input, getNext);
            }
        }

        public bool WillExecute
        {
            get { return true; }
        }


    }
}
