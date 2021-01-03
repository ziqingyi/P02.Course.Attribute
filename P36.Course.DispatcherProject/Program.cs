using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P36.Course.DispatcherProject.QuartzNet;

namespace P36.Course.DispatcherProject
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                DispatcherManager.Init().GetAwaiter().GetResult();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.Read();

        }
    }
}
