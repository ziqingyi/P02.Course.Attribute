using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P42.Course.WebSocketProj.Utility
{
    public class SocketModel
    {
        /// <summary>
        /// ID for socket
        /// </summary>
        public string SocketGuid { get; set; }


        public string UserName { get; set; }

        /// <summary>
        /// create socket instance for each connection
        /// </summary>
        public System.Net.WebSockets.WebSocket Socket { get; set; }



    }
}