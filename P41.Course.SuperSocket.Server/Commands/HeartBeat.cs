using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P41.Course.SuperSocket.Server.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace P41.Course.SuperSocket.Server.Commands
{
    /*
     Heartbeat package : The reason why it is called a heartbeat packet is that it is sent every regular time like a heartbeat
     to tell the server that the client is still alive. 
    In fact, this is to maintain a long connection. 
    As for the content of this package, there is no special provision, but it is usually a small package, or only an empty package containing the header. 
    In general, the heartbeat package is mainly used for keep-alive and disconnection of long connections. 
    Under normal application, the judgment time is better in 30-40 seconds. If the real demand is high, then it is 6-9 seconds.
    */
    public class HeartBeat: CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 1)
            {
                if (requestInfo.Parameters[0].Equals("R"))
                {
                    session.LastHbTime = DateTime.Now;
                    session.Send("R");
                }
                else
                {
                    session.Send("parameter error");
                }
            }
            else
            {
                session.Send("parameter error");
            }


        }

    }
}
