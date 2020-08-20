using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P20.Course.AwaitAsyncLibrary
{
    public class AwaitAsyncClass
    {
        public static void TestShow()
        {

            Test();

            Console.ReadLine();
        }

        private async static Task Test()
        {
            Console.WriteLine($"current Test() main thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            {
                NoReturnNoAwait();
            }



            Console.WriteLine($"current Test() main thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        //if there is no await for async, it works like a normal method. 
        private static async void NoReturnNoAwait()
        {
            Console.WriteLine(@"****************NoReturnNoAwait Start,  Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"NoReturnNoAwait begin sleep, thread id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(3000);
                Console.WriteLine($"NoReturnNoAwait after sleep, thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            });

            Console.WriteLine(@"****************NoReturnNoAwait() Sleep after Task, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }


    }
}
