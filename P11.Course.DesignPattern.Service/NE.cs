using P10.Course.DesignPattern.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P11.Course.DesignPattern.Service
{
    public class NE:IRace
    {
        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1} ", this.GetType().Name, "Moon");
        }
    }
}
