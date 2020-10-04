using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P23.Course.IOC.ServiceInterface;

namespace P23.Course.IOC.Service
{
    public class AppleDisplay: IDisplay
    {


        public void ShowRetina(string msg)
        {
            Console.WriteLine("Retina: "+ msg);
        }
    }
}
