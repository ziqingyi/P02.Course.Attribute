using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P23.Course.IOC.Framework.AOP
{
    public class ParameterCheckBehavior: IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Type t = input.GetType();
            Console.WriteLine("Parameter Check Behavior ....");
            
            if (input.Inputs.Count>0)
            {
                foreach (IParameterCollection inp in input.Inputs)
                {
                    if (!AttributeExtend.Validate(inp))
                    { 
                        return input.CreateExceptionMethodReturn(new Exception("param check error"));
                    }
                }
                return getNext().Invoke(input, getNext);
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
