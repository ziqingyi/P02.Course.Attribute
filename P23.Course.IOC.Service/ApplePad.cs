using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class ApplePad : AbstractPad
    {
        public ApplePad()
        {
            Console.WriteLine($"{this.GetType().Name} (ApplePad) construction method in thread {Thread.CurrentThread.ManagedThreadId}");
        }
        public override void Show()
        {
            Console.WriteLine($"This is {nameof(ApplePad)}");
        }


    }
}
