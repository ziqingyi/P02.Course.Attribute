using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P37.Course.Web.SearchEngines.SearchService.AOP.Handler
{
    public class ExceptionHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);
            if (methodReturn.Exception == null)
            {
                Console.WriteLine("no exception");
            }
            else
            {
                Console.WriteLine("Exception:{0}", methodReturn.Exception.Message);
            }
            return methodReturn;
        }
    }
}
