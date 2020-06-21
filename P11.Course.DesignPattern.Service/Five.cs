using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P10.Course.DesignPattern.Interface;

namespace P11.Course.DesignPattern.Service
{
    public class Five : IRace
    {
        public Five()
            : this(1, "old", 1)//call below constructor, default value
        {

        }
        public Five(int id, string name, int version)
        { }

        public void ShowKing()
        {
            Console.WriteLine("The King of {0} is {1}", this.GetType().Name, "Moon");
        }


    }
}
