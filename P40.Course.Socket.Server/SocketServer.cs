using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace P40.Course.Socket.Server
{
    public class SocketServer
    {
        public static void Process()
        {
            int port = 9099; 
            string host = "10.188.0.6";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            System.Net.Sockets.Socket sSocket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            sSocket.Bind(ipe);
            sSocket.Listen(0);

            //receive a socket
            Console.WriteLine("Listening to port: " + port );
            System.Net.Sockets.Socket serverSocket = sSocket.Accept();

            //receive message

            while (true)
            {
                string recStr = "";
                byte[] recByte = new byte[4069];
                int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
                recStr += Encoding.ASCII.GetString(recByte, 0, bytes);

                Console.WriteLine("Get message from server: {0}", recStr);

                if (recStr.Equals("stop"))
                {
                    Console.WriteLine("close connection" + serverSocket.RemoteEndPoint.AddressFamily); 
                    serverSocket.Close();
                    break;
                }

                //reply to client
                Console.WriteLine("Please input message to client....");
                string sendStr = Console.ReadLine();
                byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
                serverSocket.Send(sendBytes, sendBytes.Length, 0);
            }

            sSocket.Close();



        }









}
}
