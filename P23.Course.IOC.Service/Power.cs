using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P23.Course.IOC.IBLL;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class Power:IPower
    {
        public Power(IBaseBll baseBll)
        {
            Console.WriteLine("Power is being constructed...");
        }


    }
}
