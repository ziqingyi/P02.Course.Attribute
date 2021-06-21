﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            System.Net.WebSockets.WebSocket socket = socketContext.WebSocket;
            CancellationToken token = new CancellationToken();

            string socketGuid = Guid.NewGuid().ToString();








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