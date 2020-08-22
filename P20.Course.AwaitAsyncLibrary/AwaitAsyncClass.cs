﻿using System;
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

            Console.WriteLine($"current static TestShow()  start thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            Console.ReadLine();
        }

        private async static Task Test()
        {
            Console.WriteLine($"current async Test() main start thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            {
                //normal case
                //NoReturnNoAwait();
            }
            {
                ////test 2 ways of recall,
                //NoReturn();//1 await
                ////NoReturnContinueWith();//2 ContinueWith
                //for (int i = 0; i < 10; i++)
                //{
                //    Thread.Sleep(300);//just to show main thread will continue do something. 
                //    Console.WriteLine($"current async Test()'s task running, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")} i={i}");
                //}
            }
            {
                Task t = NoReturn_returnTask();
                Console.WriteLine($"current async Test() running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                t.Wait();//wait for complation of t

                Console.WriteLine($"current async Test() running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                await t;//a thread from threadpool with execute logic after await

                Console.WriteLine($"current async Test() running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

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

            //here, the thread id would be any thread, these logic may be executed by task's thread, maybe a new thread, maybe main(01) thread.
            Console.WriteLine($"async NoReturn() end after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        private static async void NoReturnContinueWith()
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
            //the thread may be a new thread id,maybe same to task's thread id. 
            _ = task.ContinueWith(t =>
                   {
                       Console.WriteLine($"async NoReturn end after await something, " +
                                         $"ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                   }
           );
        }

        //await task,return task. after compilation, async will become stateMachine 
        private static async Task NoReturn_returnTask()
        {
            Console.WriteLine($"async NoReturn_returnTask() start running before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Task task = Task.Run(
                () =>
                {
                    Console.WriteLine($"NoReturn_returnTask()'s task Start, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    Console.WriteLine($"NoReturn_returnTask()'s task End, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
            );
            await task;

            //here, the thread id would be any thread, these logic may be executed by task's thread, maybe a new thread, maybe main(01) thread.
            Console.WriteLine($"async NoReturn_returnTask() end running after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }














    }
}
