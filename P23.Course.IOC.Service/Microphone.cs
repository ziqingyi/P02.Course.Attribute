using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class Microphone :IMicrophone
    {
        public Microphone(IPower power)
        {
            Console.WriteLine("Microphone is being constructed....in thread : " + Thread.CurrentThread.ManagedThreadId);
        }

    }
}
