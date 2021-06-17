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
        /// message state undelivered 0  sent 1   received 2 
        /// </summary>
        public ChatState State { get; set; }

    }
}
