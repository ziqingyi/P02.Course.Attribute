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
            Console.WriteLine($"TestShow() start thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Test();

            Console.WriteLine($"TestShow() end thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            Console.ReadLine();
        }

        private async static Task Test()
        {
            Console.WriteLine($"async Test() method start thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            {
                #region normal case

                //NoReturnNoAwait();

                #endregion
            }
            {
                #region test 2 ways of recall
                //NoReturn();//1 await
                ////NoReturnContinueWith();//2 ContinueWith
                //for (int i = 0; i < 10; i++)
                //{
                //    Thread.Sleep(300);//just to show main thread will continue do something. 
                //    Console.WriteLine($"current async Test()'s task 1 running, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")} i={i}");
                //}
                #endregion
            }
            {
                #region test Wait() and await

                //Task t = NoReturn_returnTask();
                //Console.WriteLine($"current async Test() test 2 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                ////t.Wait();//1 main thread wait for completion of t, following will be main thread running

                //Console.WriteLine($"current async Test() test 2 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //await t;//2 main thread not wait for t(go out of method), a thread from threadpool with execute logic after await in the method.
                //        //following part will be a call back if t is not finished. 
                //        //if t completed before await, following will also be main thread running.
                //Console.WriteLine($"current async Test() test 2 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                #endregion
            }
            {
                #region  Task with return value with async

                //Console.WriteLine($"current async Test() test 3 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //Task<long> t = SumAsync();

                //Console.WriteLine($"current async Test() test 3 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //long lResult = t.Result;// same to t.Wait(),  wait for the result returns and then continue. 

                //Console.WriteLine($"current async Test() test 3 result is {lResult} thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                #endregion
            }
            {
                #region Task with return value return Task

                Console.WriteLine($"current async Test() test 4 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                // return a Task with return value
                Task<int> getResultTask =  SumFactory();


                // thread 1 continue do sth
                Console.WriteLine($"current async Test() test 4 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");


                //thread 1 wait for the result,  getResultTask.Result is same to getResultTask.Wait()
                Console.WriteLine($"current async Test() test 4 finish, result is {getResultTask.Result}" +
                                  $" thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                #endregion



            }





            Console.WriteLine($"async Test() method end thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
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
        /// <summary>
        /// Task with return value, getting result must wait for the task.
        ///
        /// await will make the program running synchronously and in steps, but not block main thread. it will open multiple threads.
        /// </summary>
        /// <returns></returns>
        private static async Task<long> SumAsync()
        {
            Console.WriteLine($"async SumAsync() start running before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            long result = 0;

            //await: the following logic in the method will wait for the await task. .
            await Task.Run(
                () =>
                {
                    for (int k = 0; k < 10; k++)
                    {
                        Console.WriteLine($"SumAsync() task {k} await Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(1000);
                    }

                    for (int i = 0; i < 999_999; i++)
                    {
                        result += i;
                    }

                }
                );

            Console.WriteLine($"SumAsync() is running, part 1 tasks finished, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            await Task.Run(
                () =>
                {
                    for (int k = 11; k < 20; k++)
                    {
                        Console.WriteLine($"SumAsync() task {k} await Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(1000);
                    }

                    for (int i = 0; i < 999_999; i++)
                    {
                        result += i;
                    }

                }
            );

            Console.WriteLine($"SumAsync() is running, part 2 tasks finished, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            await Task.Run(
                () =>
                {
                    for (int k = 20; k < 30; k++)
                    {
                        Console.WriteLine($"SumAsync() task {k} await Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(1000);
                    }

                    for (int i = 0; i < 999_999; i++)
                    {
                        result += i;
                    }

                }
            );

            Console.WriteLine($"SumAsync() is running, part 3 tasks finished, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Console.WriteLine($"async SumAsync() end running after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}"); 
            return result;
        }

        private static Task<int> SumFactory()
        {
            Console.WriteLine($"static SumFactory() start running before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();
            Task<int> iResult = taskFactory.StartNew<int>(
                () =>
                {
                    Thread.Sleep(10000);
                    Console.WriteLine($"SumFactory() task running Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    return 123;
                }
                );

            Console.WriteLine($"static SumFactory() end running after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            return iResult;
        }










    }
}
