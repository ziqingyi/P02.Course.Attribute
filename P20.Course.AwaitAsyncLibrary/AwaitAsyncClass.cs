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
            Console.WriteLine($"current async Test() main start thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            {
                //NoReturnNoAwait();
            }
            {
                NoReturn();
                //for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(5000);
                  //  Console.WriteLine($"Main Thread Task ManagedThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")} i={i}");
                }


            }


            Console.WriteLine($"current async Test() main end thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");


        }

        //if there is no await for async, it works like a normal method. 
        private static async void NoReturnNoAwait()
        {
            Console.WriteLine(@"****************async NoReturnNoAwait() Start,  Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            Task task = Task.Run(() =>
            {
                Console.WriteLine($"NoReturnNoAwait() begin sleep, thread id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(3000);
                Console.WriteLine($"NoReturnNoAwait() after sleep, thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            });

            Console.WriteLine(@"****************async NoReturnNoAwait() End after Task, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        //await task
        private static async void NoReturn()
        {
            Console.WriteLine($"async NoReturn() start before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(
                () =>
                {
                    Console.WriteLine($"NoReturn()'s task Start, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    Console.WriteLine($"NoReturn()'s task End, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
                );
            await task;

            //here, the thread id would be the thread used in running the task. Main thread will not execute logic after await. 
            Console.WriteLine($"async NoReturn end after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }






    }
}
