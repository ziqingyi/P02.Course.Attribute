using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using P30.Course.SOA.WCF.Service;

namespace P30.Course.SOA.WCF.Project
{
    public class ServiceInit
    {
        public static void Process()
        {

            //ServiceHost object
            List<ServiceHost> hosts = new List<ServiceHost>()
            {
                new ServiceHost(typeof(MathService)),
                new ServiceHost(typeof(CalculatorService))
            };

            foreach (ServiceHost host in hosts)
            {
                host.Opening += (s, e) => Console.WriteLine($"{host.GetType().Name} start to open....");
                host.Opened += (s,e)=>Console.WriteLine($"{host.GetType().Name} is open");
                host.Closing += (s, e) => Console.WriteLine($"{host.GetType().Name} is closing....");
                host.Closed += (s, e) => Console.WriteLine($"{host.GetType().Name} is closed");

                host.Open();
            }



            Console.WriteLine("stop when receiving any character......");
            Console.Read();
            foreach (ServiceHost host in hosts)
            {
                host.Close();
            }

            Console.Read();

        }


        private static void Host_Closing(object sender, EventArgs e)
        {

        }



    }
}
