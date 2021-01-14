using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P19.Course.ConsoleWriterProj
{
    public static class ConsoleWriter
    {
        private static object _messageLock = new Object();

        #region WriteLine

        public static void WriteLine(string message)
        {
            lock (_messageLock)
            {
                Console.ResetColor();
                Console.WriteLine(message);
            }
        }

        public static void WriteLineAdv(string msg, bool appendTimeThread, ConsoleColor color)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = color;
                //foreach (char c in msg.ToCharArray())
                //{Console.Write($"{c}");}

                if (appendTimeThread)
                {
                    msg += getThreadTime();
                }
                Console.WriteLine($"{msg}");
                Console.ResetColor();
            }
        }

        /// <summary>
        ///append thread and time at the end of msg inside lock, get lock early and print early.
        /// as thread execute early not necessarily get lock early. 
        /// </summary>
        /// <returns></returns>
        private static string getThreadTime()
        {
            string threadId = Thread.CurrentThread.ManagedThreadId.ToString("00");
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
            return " In Thread: " + threadId + " Time: " + time;
        }
        #endregion


        #region Yellow, Green, Red.  message or with two arg0
        public static void WriteLineYellow(string message)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        public static void WriteLineYellow(string format, object arg0, object arg1)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(format,  arg0,  arg1);
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
        public static void WriteLineGreen(string format, object arg0, object arg1)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(format, arg0, arg1);
                Console.ResetColor();
            }
        }


        public static void WriteLineRed(string message)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(message);
                Console.ResetColor();
            }
        }
        public static void WriteLineRed(string format, object arg0, object arg1)
        {
            lock (_messageLock)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(format, arg0, arg1);
                Console.ResetColor();
            }
        }

        #endregion






    }
}
