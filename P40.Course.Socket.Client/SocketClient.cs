using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace P40.Course.Socket.Client
{
    public class SocketClient
    {
        public static void Process()
        {
            Console.WriteLine("Socket Server Connection starts....");
            int port = 9099;
            string host = "10.188.0.6";

            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);

            System.Net.Sockets.Socket clientSocket =
                new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            clientSocket.Connect(ipe);

            while (true)
            {
                Console.WriteLine("Please input message to server: ");
                string sendStr = Console.ReadLine();

                if (sendStr == "stop")
                    break;

                byte[] sendBytes = Encoding.ASCII.GetBytes(sendStr);
                clientSocket.Send(sendBytes);

                //receive message 
                string recStr = "";
                byte[] recBytes = new byte[1024];

                int bytes = clientSocket.Receive(recBytes, recBytes.Length, 0);
                recStr += Encoding.ASCII.GetString(recBytes, 0, bytes);

                Console.WriteLine($"Server Reply: {recStr}");
            }


            clientSocket.Close();


        }


    }
}
