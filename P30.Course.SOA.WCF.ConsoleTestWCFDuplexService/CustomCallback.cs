using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.ConsoleTestWCFDuplexService
{
    public class CustomCallback:MyConsoleWCTTcpDuplex.ICalculatorServiceCallback
    {
        public void Show(int m, int n, int result)
        {

            string threadId = Thread.CurrentThread.ManagedThreadId.ToString();

            Console.WriteLine($"call back: {m} + {n} = {result} in thread {threadId}");
        }

    }
}
