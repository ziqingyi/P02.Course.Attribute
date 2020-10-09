using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class ApplePod:IHeadphone
    {
        private string Type;
        public ApplePod(string type)
        {
            Type = type;
            Console.WriteLine("{0} construction method with type {1} in thread {2}...", this.GetType().Name, type, Thread.CurrentThread.ManagedThreadId);
        }

        public void playmusic()
        {
            Console.WriteLine($"earpod ({Type}) is playing music");
        }

    }
}
