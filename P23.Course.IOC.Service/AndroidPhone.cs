using P23.Course.IOC.IBLL;
using P23.Course.IOC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Service
{
    public class AndroidPhone:Itelephone
    {
        public IMicrophone iMicrophone { get; set; } 
        public IHeadphone iHeadphone { get; set; }
        public IPower iPower { get; set; }


        public AndroidPhone()
        {
            Console.WriteLine("{0} construction method", this.GetType().Name);
        }
        public AndroidPhone(AbstractPad pad)
        {
            Console.WriteLine("{0} (AndroidPhone)construction method with {1}", this.GetType().Name, pad.GetType());
        }
        public AndroidPhone(IBaseBll baseBll)
        {
            Console.WriteLine("{0} (AndroidPhone)construction method with {1}", this.GetType().Name, baseBll.GetType());
        }

        public void Call()
        {
            Console.WriteLine("{0} call......", this.GetType().Name); ;
        }


    }
}
