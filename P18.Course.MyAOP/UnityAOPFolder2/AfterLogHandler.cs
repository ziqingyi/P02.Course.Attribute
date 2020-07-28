using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder2
{
    public class AfterLogHandler: ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext().Invoke(input, getNext);
            User user = input.Inputs[0] as User;
            string message = string.Format("RegUser : Username:{0} , Password: {1} ", user.Name, user.Password);

            Console.WriteLine("Log is created, Message: {0} , Ctime: {1}, result is {2}", message,DateTime.Now, methodReturn.ReturnValue);

            return methodReturn;
        }

    }
}
