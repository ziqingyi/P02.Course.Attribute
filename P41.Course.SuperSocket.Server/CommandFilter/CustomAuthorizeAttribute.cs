using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P41.Course.SuperSocket.Server.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Metadata;

namespace P41.Course.SuperSocket.Server.CommandFilter
{
    public class CustomAuthorizeAttribute :CommandFilterAttribute
    {

        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            ChatSession session = (ChatSession) commandContext.Session;
            string command = commandContext.CurrentCommand.Name;
            //if session is logged in and command is not CheckLogin, cancel the session. 

            if (!session.IsLogin)
            {
                if (!command.Equals("CheckLogin"))
                {
                    session.Send("please log in");
                    //stop executing the command
                    commandContext.Cancel = true;
                }

            }
            // if off line but get message, update heart beat time.
            else if (!session.IsOnline)
            {
                session.LastHbTime = DateTime.Now;
            }

        }




        public override void OnCommandExecuted(CommandExecutingContext commandExecutingContext)
        {

        }
    }
}
