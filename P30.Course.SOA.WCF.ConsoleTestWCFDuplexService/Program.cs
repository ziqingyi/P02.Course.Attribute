using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P30.Course.SOA.WCF.ConsoleTestWCFDuplexService.MyConsoleWCTTcpDuplex;

namespace P30.Course.SOA.WCF.ConsoleTestWCFDuplexService
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                MyConsoleWCTTcpDuplex.CalculatorServiceClient client= null;
                try
                {
                    //ICalculatorService must have callback, because (CallbackContract = typeof(ICallBack))

                    Console.WriteLine($"duplex start {Thread.CurrentThread.ManagedThreadId.ToString()}");

                    InstanceContext callbackInstance = new InstanceContext(new CustomCallback());

                    //pass callback function, then server can call the callback function. 
                    client = new MyConsoleWCTTcpDuplex.CalculatorServiceClient(callbackInstance);

                    //will start a new thread. 
                    client.Plus(222,555);

                    client.Close();

                    Console.WriteLine($"duplex end {Thread.CurrentThread.ManagedThreadId.ToString()}");
                }
                catch (Exception e)
                {
                    if (client != null)
                    {
                        client.Abort();
                    }

                    Console.WriteLine(e.Message);
                }





            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
               
            }

            Console.ReadKey();


        }
    }
}
