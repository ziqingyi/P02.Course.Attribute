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
    public class CheckLogin : CommandBase<ChatSession, StringRequestInfo>
    {

        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {




            }
            else
            {
                session.Send("Parameter error...");

            }

        }






    }
}
