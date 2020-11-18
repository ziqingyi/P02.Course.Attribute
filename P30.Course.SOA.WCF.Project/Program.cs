using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P30.Course.SOA.WCF.Project
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("**********SOA  WCF***************");

                ServiceInit.Process();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


        }
    }
}
