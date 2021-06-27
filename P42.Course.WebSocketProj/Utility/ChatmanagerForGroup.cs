using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebGrease.Css.Extensions;

namespace P42.Course.WebSocketProj.Utility
{
    public class ChatManagerForGroup
    {
        //a group of people, test data, should read from database
        public static List<SocketModel> userGroup = new List<SocketModel>()
        {
            new SocketModel(){SocketGuid = "", UserName = "user1", Socket = null},
            new SocketModel(){SocketGuid = "", UserName = "user2", Socket = null},
            new SocketModel(){SocketGuid = "", UserName = "user3", Socket = null},
            new SocketModel(){SocketGuid = "", UserName = "user4", Socket = null},
        };
        //if the user is offline (no socket now), we keep the message from others in a list. 
        public static Dictionary<string, List<ArraySegment<byte>>> userMessageBuffer = new Dictionary<string, List<ArraySegment<byte>>>();

        public static void AddUserSocket(string socketGuid, string userName, WebSocket socket, CancellationToken token)
        {
            #region If the user is in the group, add the socket to it.
            userGroup.ForEach(item =>
            {
                if (userName == item.UserName)
                {
                    item.Socket = socket;
                    item.SocketGuid = socketGuid;
                }
            });
            #endregion

            #region send history message to the user's socket when user log in 

            if( userMessageBuffer.ContainsKey(userName) && userMessageBuffer[userName].Count > 0 )
            {
                foreach (ArraySegment<byte> msg in userMessageBuffer[userName])
                {
                    socket.SendAsync(msg, WebSocketMessageType.Text, true, token);
                } 
                //remove all the history message from buffer
                userMessageBuffer[userName].Clear();
            }
            #endregion
        }

        public static void RemoveUser(string socketGuid)
        {
            userGroup.ForEach(item =>
            {
                if (socketGuid == item.SocketGuid)
                {
                    item.Socket = null;
                    item.SocketGuid = "";
                }
            });
        }

        public static async Task SendGroupMessage(CancellationToken token, string userName, string content)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes($"{DateTime.Now.ToString()} {userName} : {content}  ");

            ArraySegment<byte> messageSeg = new ArraySegment<byte>(dataBytes);

            //send message to all users in the group
            foreach (SocketModel userModel in userGroup)
            {
                // if user is offline
                if (userModel.Socket == null)
                {
                    //if the user's message buffer has build, just add
                    if (userMessageBuffer.ContainsKey(userModel.UserName))
                    {
                        userMessageBuffer[userModel.UserName].Add(messageSeg);
                    }
                    else
                    {
                        userMessageBuffer.Add(userModel.UserName,new List<ArraySegment<byte>>(){messageSeg});
                    }
                }
                else
                {
                    await userModel.Socket.SendAsync(messageSeg, WebSocketMessageType.Text, true, token);
                }


            }






        }



    }
}