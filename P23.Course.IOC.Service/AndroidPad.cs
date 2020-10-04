using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P23.Course.IOC.Framework.DIOC;
using P23.Course.IOC.IBLL;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class AndroidPad:AbstractPad
    {
        
        public AndroidPad(IBaseBll baseBll)
        {
            Console.WriteLine("{0} (AndroidPhone)construction method with {1}", this.GetType().Name, baseBll.GetType());
        } 
        
        [XInjectionConstructor]
        public AndroidPad(IPower power)
        {
            Console.WriteLine("{0} (AndroidPad)construction method with {1}", this.GetType().Name, power.GetType());
        }


        public override void Show()
        {
            Console.WriteLine($"This is {nameof(ApplePad)}");
        }

    }
}
