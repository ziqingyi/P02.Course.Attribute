using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
    Socket sSocket=

namespace P40.Course.Socket.Server
{
    public class SocketServer
    {
        public static void Process()
        {
            int port = 2018; 
            string host = "127.0.0.1";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            System.Net.Sockets.Socket sSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sSocket.Bind(ipe);
            sSocket.Listen(0);

            //receive a socket
            System.Net.Sockets.Socket serverSocket = sSocket.Accept();
            Console.WriteLine("Listening to port: " + port );

            //receive message

            while (true)
            {
                string recStr = "";
                byte[] recByte = new byte[4069];
                int bytes = serverSocket.Receive(recByte, recByte.Length, 0);




            }





        }









}
}
