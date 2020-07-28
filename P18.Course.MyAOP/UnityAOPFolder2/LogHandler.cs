using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder2
{
    public class LogHandler: ICallHandler
    {
        public int Order { get; set; }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            User user = input.Inputs[0] as User;
            string message = $"RegUser Username: {user.Name} , Password: {user.Password}";
            Console.WriteLine("Log is created, message: {0}, Ctime: {1} ", message,DateTime.Now);

            return getNext().Invoke(input, getNext);
        }


    }
}
