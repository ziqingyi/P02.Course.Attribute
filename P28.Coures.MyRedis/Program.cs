using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P28.Coures.MyRedis
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                {
                    Console.WriteLine("****************ServiceStackTest***************");
                    //ServiceStackTest.Show();
                }

                {
                    Console.WriteLine("****************Oversell test***************");
                    OversellTest.Show();

                }






            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }


            Console.ReadKey();

        }
    }
}
