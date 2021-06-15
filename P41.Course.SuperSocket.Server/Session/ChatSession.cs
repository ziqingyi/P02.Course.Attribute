using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P41.Course.SuperSocket.Server.Utility;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Protocol;

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


        public override void Send(string message)
        {
            Console.WriteLine($"message send to Id: {this.Id}：{message}");
            base.Send(message.Format());
        }

        protected override void OnSessionStarted()
        {
            this.Send("Welcome to SuperSocket Chat Server, Session Started....");
        }

        protected override void OnInit()
        {
            this.Charset = Encoding.GetEncoding("gb2312");
            base.OnInit();
        }

        protected override void HandleUnknownRequest(StringRequestInfo requestInfo)
        {
            Console.WriteLine("Receive Request :" + requestInfo.Key.ToString());
            this.Send("Unknown request key " + requestInfo.Key.ToString() + " [request error]");
        }


        protected override void HandleException(Exception e)
        {
            this.Send($"\n\r Exception：{ e.Message}");
            //base.HandleException(e);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            Console.WriteLine("Session Closed ....");
            base.OnSessionClosed(reason);
        }



    }
}
