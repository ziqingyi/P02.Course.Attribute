using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P18.Course.MyAOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****************Decorator Show********************");
            DecoratorAOP.Show();

            Console.WriteLine("************ProxyAOP Show*******************");
            ProxyAOP.Show();



        }
    }
}
