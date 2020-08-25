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
                Console.WriteLine("Main start to run......");

                //AwaitAsyncClass.TestShow();
                //AwaitAsyncILSpy.Show();
                AwaitAsyncILSpyWeb.Show();

                Console.WriteLine("Main finish running......");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           




        }
    }
}
