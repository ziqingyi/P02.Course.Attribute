using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P37.Course.Web.SearchEngines.SearchService.AOP.Handler
{
    public class AfterLogHandler : ICallHandler
    {
        public int Order { get; set; }
        public IMethodReturn Invoke(IMethodInvocation input, GetNextHandlerDelegate getNext)
        {
            IMethodReturn methodReturn = getNext()(input, getNext);
            StringBuilder sb = new StringBuilder();
            foreach (var para in input.Inputs)
            {
                sb.AppendFormat("Para={0} ", para == null ? "null" : para.ToString());
            }
            Console.WriteLine("logging is finished, end request {0}", sb.ToString());
            return methodReturn;
        }
    }
}
