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
    public class CheckLogin : CommandBase<ChatSession, StringRequestInfo>
    {

        public override void ExecuteCommand(ChatSession session, StringRequestInfo requestInfo)
        {
            if (requestInfo.Parameters != null && requestInfo.Parameters.Length == 2)
            {
                #region Database Authentication Process
                #endregion

                #region log off other sessions

                ChatSession oldSession = session.AppServer.GetAllSessions()
                    .FirstOrDefault(a => requestInfo.Parameters[0].Equals(a.Id));
                if (oldSession != null)
                {
                    oldSession.Send("a new session will be created, your session is expired...");
                    oldSession.Close();
                }

                #endregion

                #region Create new Session

                session.Id = requestInfo.Parameters[0];
                session.PassWord = requestInfo.Parameters[1];
                session.IsLogin = true;
                session.LoginTime = DateTime.Now;

                #endregion
                
                session.Send($"Login Successfully for Id: {session.Id}");

                #region get all message based on session id, and send when log in
                ChatDataManager.SendLogin(session.Id, c =>
                {
                    session.Send($"{c.FromId}  send you message: {c.Message} {c.Id} ");
                });
                
                #endregion



                
            }
            else
            {
                session.Send("Parameter error...");

            }

        }






    }
}
