using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P20.Course.AwaitAsyncLibrary;

namespace P20.Course.AwaitAsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Main is running......");

                AwaitAsyncClass.TestShow();


                Console.WriteLine("Main is running......");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           




        }
    }
}
