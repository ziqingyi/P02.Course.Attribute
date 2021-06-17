using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P41.Course.SuperSocket.Server.DataCenter;
using P41.Course.SuperSocket.Server.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;

namespace P41.Course.SuperSocket.Server.Commands
{
    public class Confirm : CommandBase<ChatSession,StringRequestInfo>
    {

        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 1)
            {
                string ChatModelId = requestInfo.Parameters[0];
                Console.WriteLine($"user {session.Id} is confirmed, receive message {ChatModelId} ");
                ChatDataManager.Remove(session.Id, ChatModelId);
            }
            else
            {
                session.Send("parameter error");
            }
        }


    }
}
