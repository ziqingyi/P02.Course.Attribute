using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P41.Course.SuperSocket.Server.CommandFilter;
using P41.Course.SuperSocket.Server.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Config;

namespace P41.Course.SuperSocket.Server.AppServer
{
    [CustomAuthorize]
    public class ChatServer:AppServer<ChatSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            Console.WriteLine("Read from configuration file");
            return base.Setup(rootConfig, config);
        }

        protected override void OnStarted()
        {
            Console.WriteLine("Chat Server Started....");
            base.OnStarted();
        }

        protected override void OnStopped()
        {
            Console.WriteLine("Chat Server Stopped....");
            base.OnStopped();
        }

        protected override void OnNewSessionConnected(ChatSession session)
        {
            Console.WriteLine($"Chat server join in the connection: {session.LocalEndPoint.Address.ToString()}");
            base.OnNewSessionConnected(session);
        }



    }
}
