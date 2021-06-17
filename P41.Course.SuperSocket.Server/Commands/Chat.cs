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
    public class Chat : CommandBase<ChatSession, StringRequestInfo>
    {
        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {
                string toId = requestInfo.Parameters[0];
                string message = requestInfo.Parameters[1];
                ChatSession toSession = session.AppServer.GetAllSessions().FirstOrDefault(a => toId.Equals(a.Id));

                string MessageId = Guid.NewGuid().ToString();

                if (toSession != null)
                {
                    toSession.Send($"Id: {session.Id}  send message to you: {message}  {MessageId}");

                    ChatModel chatModel = new ChatModel()
                    {
                        FromId = session.Id,
                        ToId = toId,
                        Message = message,
                        Id = MessageId,
                        State = ChatState.Sent //just send, not sure whether receive or not.
                    };

                    ChatDataManager.Add(toId,chatModel);


                }
                else
                {
                    

                    session.Send("Message is not delivered");
                }





            }



        }
    }
}
