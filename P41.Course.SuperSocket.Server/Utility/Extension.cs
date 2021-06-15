using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P41.Course.SuperSocket.Server.Utility
{
    public static class Extension
    {
        public static string Format(this string words)
        {
            return $"{words}\r\n";
        }



    }
}
