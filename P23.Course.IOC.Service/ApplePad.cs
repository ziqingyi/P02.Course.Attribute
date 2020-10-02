using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class ApplePad : AbstractPad
    {
        public ApplePad()
        {
            Console.WriteLine("{0} (ApplePad) construction method", this.GetType().Name);
        }
        public override void Show()
        {
            Console.WriteLine($"This is {nameof(ApplePad)}");
        }


    }
}
