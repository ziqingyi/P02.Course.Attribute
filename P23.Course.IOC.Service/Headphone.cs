using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class Headphone : IHeadphone
    {
        public Headphone(IMicrophone microphone)
        {
            Console.WriteLine("Headphone is being constructed.....in thread : " + Thread.CurrentThread.ManagedThreadId);
        }

    }
}
