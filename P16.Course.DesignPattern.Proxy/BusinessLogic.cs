using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.Proxy
{
    public class BusinessLogic: ISubject
    {
        public BusinessLogic()
        {
            Console.WriteLine("    construct business logic........");
        }

        public bool GetData()
        {
            Console.WriteLine("  business logic try to get something.....");
            Console.WriteLine("  business logic get the data, can process !!!!!!!");
            return true;
        }

        public void DoTransaction()
        {
            Console.WriteLine("    business logic process data...........");
        }


    }
}
