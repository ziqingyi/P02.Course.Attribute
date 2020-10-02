using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Service
{
    public class ApplePadChild :ApplePad
    {
        public ApplePadChild()
        {
            Console.WriteLine("{0} (ApplePadChild) construction method", this.GetType().Name);
        }
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"This is {nameof(ApplePadChild)}");
        }

    }
}
