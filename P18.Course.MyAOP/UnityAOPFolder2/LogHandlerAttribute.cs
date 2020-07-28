using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Interception.PolicyInjection.Pipeline;
using Unity.Interception.PolicyInjection.Policies;

namespace P18.Course.MyAOP.UnityAOPFolder2
{
    public class LogHandlerAttribute: HandlerAttribute
    {
        public override ICallHandler CreateHandler(IUnityContainer container)
        {
            LogHandler result = new LogHandler()
            {
                Order = this.Order
            };
            return result;
        }


    }
}
