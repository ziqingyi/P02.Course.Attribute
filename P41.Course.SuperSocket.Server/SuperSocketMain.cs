using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;
using SuperSocket.SocketEngine;

namespace P41.Course.SuperSocket.Server
{
    public class SuperSocketMain
    {

        public static void Init()
        {
            try
            {
                IBootstrap bootstrap = BootstrapFactory.CreateBootstrap();
                if (!bootstrap.Initialize())
                {
                    Console.WriteLine("Initialize failed..");
                    Console.ReadKey();
                }

                Console.WriteLine("Start the Server");

                foreach (var server in bootstrap.AppServers)
                {
                    if (server.State == ServerState.Running)
                    {
                        Console.WriteLine($"{server.Name} is running...");
                    }
                    else
                    {
                        Console.WriteLine($"{server.Name} failed...");
                    }

                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            Console.Read();

        }




    }
}
