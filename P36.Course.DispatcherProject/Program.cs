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
                //DispatcherManager.InitTestJob().GetAwaiter().GetResult();

                //DispatcherManager.InitTestStatefulJob().GetAwaiter().GetResult();

                DispatcherManager.InitTestWebJob().GetAwaiter().GetResult();

                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
