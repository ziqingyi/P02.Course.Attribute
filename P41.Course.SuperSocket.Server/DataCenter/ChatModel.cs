using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41.Course.SuperSocket.Server.DataCenter
{
    public class ChatModel
    {

        public string Id { get; set; }

        public string FromId { get; set; }

        public string ToId { get; set; }

        public string Message { get; set; }
    
        public DateTime CreateTime { get; set; }
        /// <summary>
        /// message state  0 undelivered  1 sent   2 received
        /// </summary>
        public int State { get; set; }






    }
}
