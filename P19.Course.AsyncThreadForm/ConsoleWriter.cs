using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P19.Course.AsyncThreadForm
{
    public static class ConsoleWriter
    {
        private static object _messageLock = new Object();

        public static void WriteLine( string message)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
    }

    public static class ConsoleWhite
    {
        private static object _messageLock = new Object();

        public static void WriteLine(string message)
        {
            lock (_messageLock)
            {
                Console.WriteLine(message);
            }
        }
    }



}
