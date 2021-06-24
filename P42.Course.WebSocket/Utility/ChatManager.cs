using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Net.WebSockets;
using System.Threading.Tasks;

//your namespace is WebSocket so must declare

namespace P42.Course.WebSocket.Utility
{
    public class ChatManager
    {
        public static List<SocketModel> socketList = new List<SocketModel>();

        public static void SendOne(string message, CancellationToken cancellationToken)
        {
            string[] messageArray = message.Split(';');
            string toUser = messageArray[0];
            string toMessage = messageArray[1];
            SocketModel socketModel = socketList.FirstOrDefault(a => toUser.Equals(a.UserName));
            if (socketModel != null)
            {
                System.Net.WebSockets.WebSocket toSocket = socketModel.Socket;
                ArraySegment<byte> buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(toMessage));
                toSocket.SendAsync(buffer, WebSocketMessageType.Text, true, cancellationToken);
            }
        }

        public static void AddUser(string socketGuid, string userName, System.Net.WebSockets.WebSocket socket)
        {
            socketList.Add(new SocketModel(){
                SocketGuid = socketGuid,
                UserName = userName,
                Socket = socket
            });
        }

        public static void RemoveUser(string socketGuid)
        {
            socketList = socketList.Where(a => a.SocketGuid != socketGuid).ToList();
        }


        //broadcast message
        public static async Task SendMessage(CancellationToken token, string userName, string content)
        {
            //WebSocket send message buffer
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
            byte[] msgBytes = Encoding.UTF8.GetBytes($"{DateTime.Now.ToString("MM/dd/yyyy")} {userName} : {content}");
            buffer = new ArraySegment<byte>(msgBytes);

            foreach (SocketModel model in socketList)
            {
                await model.Socket.SendAsync(buffer, WebSocketMessageType.Text, true, token);
            }
        }














    }
}