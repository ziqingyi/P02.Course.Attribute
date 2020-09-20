using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P19.Course.ConsoleWriterProj
{
    public static class ConsoleWriter
    {
        private static object _messageLock = new Object();

        public static void WriteLine(string message)
        {
            lock (_messageLock)
            {
                Console.ResetColor();
                Console.WriteLine(message);
            }
        }

        public static void WriteLineYellow(string message)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

        public static void WriteLineGreen(string message)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }

    }
}
