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
    public class CustomAuthorize :CommandFilterAttribute
    {

        public override void OnCommandExecuting(CommandExecutingContext commandContext)
        {
            ChatSession session = (ChatSession) commandContext.Session;
            string command = commandContext.CurrentCommand.Name;
            if (!session.IsLogin)
            {
                if (!command.Equals("Check"))
                {
                    session.Send("please log in");
                    commandContext.Cancel = true;
                }

            }
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
