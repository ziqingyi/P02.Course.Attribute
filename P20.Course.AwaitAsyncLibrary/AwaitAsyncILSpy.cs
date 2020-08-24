using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P20.Course.AwaitAsyncLibrary
{
    public class AwaitAsyncILSpy
    {
        public static void Show()
        {
            Console.WriteLine($"1 Show() start to run in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Async();
            
            Console.WriteLine($"2 Show() finish running in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        public static async void Async()
        {
            Console.WriteLine($"5 Async() start to run in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            await Task.Run(() =>
                {
                    Thread.Sleep(500);
                    Console.WriteLine($"3 Async() is running task in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
            );
            Console.WriteLine($"4 Async() finish running in ThreadId = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
        }


    }
}
