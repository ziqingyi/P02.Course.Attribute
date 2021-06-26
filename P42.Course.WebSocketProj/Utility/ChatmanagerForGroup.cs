using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P42.Course.WebSocketProj.Utility
{
    public class ChatManagerForGroup
    {
        //a group of people, test data, should read from database
        public static List<SocketModel> socketList = new List<SocketModel>()
        {
            new SocketModel(){SocketGuid = "", UserName = "user1", Socket = null},
            new SocketModel(){SocketGuid = "", UserName = "user2", Socket = null},
            new SocketModel(){SocketGuid = "", UserName = "user3", Socket = null},
            new SocketModel(){SocketGuid = "", UserName = "user4", Socket = null},
        };
        //if the user is offline (no socket now), we keep the message from others in a list. 
        public static Dictionary<string, List<ArraySegment<byte>>> userMessageBuffer = new Dictionary<string, List<ArraySegment<byte>>>();

        //public static void AddUser(string socketGuid, string userName, System.Net.WebSockets.WebSocket )







    }
}