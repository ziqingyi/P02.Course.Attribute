using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace P42.Course.WebSocket.Controllers
{
    public class HomeController : Controller
    {
        private string _userName = "";
        public ActionResult WebSocket()
        {
            return View();
        }

        public void MyWebSocket(string name)
        {
            if (HttpContext.IsWebSocketRequest)
            {
                this._userName = name;
                HttpContext.AcceptWebSocketRequest(ProcessChat);
            }
            else
            {
                HttpContext.Response.Write("not processed");
            }
        }

        public async Task ProcessChat(AspNetWebSocketContext socketContext)
        {
            //each web socket connection is a user. initialised by front end: socket = new WebSocket(socketurl);
            //super socket is implemented by session, but web socket is Socket. 

            System.Net.WebSockets.WebSocket socket = socketContext.WebSocket;
            CancellationToken token = new CancellationToken();




            while (socket.State == WebSocketState.Open)
            {

                #region test  send
                string socketGuid = Guid.NewGuid().ToString();
                byte[] serverMessage = Encoding.UTF8.GetBytes("message from server: Server Listening.....");
                ArraySegment<byte> buffer1 = new ArraySegment<byte>(serverMessage);
                await socket.SendAsync(buffer1, WebSocketMessageType.Text, true, token);
                #endregion

                #region Wait for receive
                ArraySegment<byte> buffer2 = new ArraySegment<byte>(new byte[4096]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer2, token);
                string userMessage = Encoding.UTF8.GetString(buffer2.Array, 0, buffer2.Count);
                #endregion

            }




        }




        #region default
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        #endregion


    }
}