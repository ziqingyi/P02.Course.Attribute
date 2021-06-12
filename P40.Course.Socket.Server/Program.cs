using System;

namespace P40.Course.Socket.Server
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Socket Server Test");
                SocketServer.Process();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }



        }
    }
}
