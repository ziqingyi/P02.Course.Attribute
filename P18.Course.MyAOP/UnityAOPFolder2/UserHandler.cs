using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder2
{
    public class UserHandler: ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            if (user.Password.Length < 10)
            {
                return input.CreateExceptionMethodReturn(new Exception("Password should more than 10"));
            }

            Console.WriteLine("Parameter correct");

            IMethodReturn methodReturn = getNext().Invoke(input, getNext);

            return methodReturn;

        }



    }
}
