using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P20.Course.AwaitAsyncLibrary
{
    public class AwaitAsyncILSpyWeb
    {
        public static void Show()
        {
            Console.WriteLine($"1 Show() start to run in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Task<string> GetContent = GetResult();
            Console.WriteLine(GetContent.Result);

            Console.WriteLine($"2 Show() finish running in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        public static async Task<string> GetResult()
        {
            Console.WriteLine($"5 Async() start to run in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            WebClient client = new WebClient();
            Uri uri = new Uri("https://www.google.com/");
            string content = await client.DownloadStringTaskAsync(uri);

            Console.WriteLine($"4 Async() finish running in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}"); 
            return content;
        }

    }
}
