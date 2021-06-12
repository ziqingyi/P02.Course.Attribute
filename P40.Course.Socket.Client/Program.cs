using System;


namespace P40.Course.Socket.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                SocketClient.Process();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }
    }
}
