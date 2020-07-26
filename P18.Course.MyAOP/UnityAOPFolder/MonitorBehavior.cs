using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Interception.InterceptionBehaviors;
using Unity.Interception.PolicyInjection.Pipeline;

namespace P18.Course.MyAOP.UnityAOPFolder
{
    //AOP extension for monitoring the behavior
    public class MonitorBehavior:IInterceptionBehavior
    {
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return Type.EmptyTypes;
        }

        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            Console.WriteLine(this.GetType().Name);
            string methodName = input.MethodBase.Name;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var methodReturn = getNext().Invoke(input, getNext);//execute following logic

            stopwatch.Stop();
            Console.WriteLine($"{this.GetType().Name} has method: {methodName} running time : {stopwatch.ElapsedMilliseconds} ms");

            return methodReturn;
        }

        public bool WillExecute
        {
            get { return true; }
        }


    }
}
