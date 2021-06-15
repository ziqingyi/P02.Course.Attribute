using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperSocket.SocketBase;

namespace P41.Course.SuperSocket.Server.Session
{
    public class ChatSession :AppSession<ChatSession>
    {
        public string Id { get; set; }

        public string PassWord { get; set; }

        public bool IsLogin { get; set; }

        public DateTime LoginTime { get; set; }

        public DateTime LastHbTime { get; set; }

        public bool IsOnline
        {
            get { return this.LastHbTime.AddSeconds(10) > DateTime.Now; }
        }



    }
}
