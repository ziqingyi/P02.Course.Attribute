﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;
using P42.Course.WebSocketProj.Utility;

namespace P42.Course.WebSocketProj.Controllers
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
                //HttpContext.AcceptWebSocketRequest(ProcessChatForOne);
                //HttpContext.AcceptWebSocketRequest(ProcessChatBetweenTwoUsers);
                HttpContext.AcceptWebSocketRequest(ProcessChatInGroup);

            }
            else
            {
                HttpContext.Response.Write("not processed");
            }
        }


        public async Task ProcessChatInGroup(AspNetWebSocketContext socketContext)
        {
            WebSocket socket = socketContext.WebSocket;
            CancellationToken token = new CancellationToken();
            string socketGuid = Guid.NewGuid().ToString();
            ChatManagerForGroup.AddUserSocket(socketGuid, this._userName, socket, token);
            await ChatManagerForGroup.SendGroupMessage(token, this._userName, this._userName + " Enter Chat Room");

            //check socket state and wait for message
            while (socket.State == WebSocketState.Open)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[2048]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, token);

                //if the user close the socket
                if (result.MessageType == WebSocketMessageType.Close)
                {
                    ChatManagerForGroup.RemoveUser(socketGuid);
                    await ChatManagerForGroup.SendGroupMessage(token, this._userName, "leave Chat Room");
                    await socket.CloseAsync(WebSocketCloseStatus.NormalClosure, string.Empty, token);
                }
                else
                {                
                    string userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);
                    await ChatManagerForGroup.SendGroupMessage(token, this._userName, userMessage);
                }


            }


        }

        public async Task ProcessChatBetweenTwoUsers(AspNetWebSocketContext socketContext)
        {
            //each web socket connection is a user. initialised by front end: socket = new WebSocket(socketurl);
            //super socket is implemented by session, but web socket is Socket. 

            System.Net.WebSockets.WebSocket socket = socketContext.WebSocket;
            CancellationToken token = new CancellationToken(); 
            string socketGuid = Guid.NewGuid().ToString();
            ChatManager.AddUser(socketGuid,this._userName, socket);

            while (socket.State == WebSocketState.Open)
            {

                #region send from server

                byte[] serverMessage = Encoding.UTF8.GetBytes("message from server: Server Listening.....");
                ArraySegment<byte> buffer1 = new ArraySegment<byte>(serverMessage);
                await socket.SendAsync(buffer1, WebSocketMessageType.Text, true, token);

                #endregion

                #region Wait for receive

                ArraySegment<byte> buffer2 = new ArraySegment<byte>(new byte[4096]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer2, token);
                string userMessage = Encoding.UTF8.GetString(buffer2.Array, 0, buffer2.Count);

                #endregion

                #region Send to another user

                ChatManager.SendOne(userMessage,token);


                #endregion


            }

        }

        public async Task ProcessChatForOne(AspNetWebSocketContext socketContext)
        {
            //each web socket connection is a user. initialised by front end: socket = new WebSocket(socketurl);
            //super socket is implemented by session, but web socket is Socket. 

            WebSocket socket = socketContext.WebSocket;
            CancellationToken token = new CancellationToken();

            while (socket.State == WebSocketState.Open)
            {
                #region test  send
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