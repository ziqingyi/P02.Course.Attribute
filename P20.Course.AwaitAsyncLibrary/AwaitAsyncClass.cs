
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P19.Course.ConsoleWriterProj;


namespace P20.Course.AwaitAsyncLibrary
{
    public class AwaitAsyncClass
    {
        public static void TestShow()
        {
            //ConsoleWriter.WriteLine($"***********TestShow() start thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}***************");
           
            Test();

            //ConsoleWriter.WriteLine($"***********TestShow() end thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}***************");
        }

        private async static Task Test()
        {
            ConsoleWriter.WriteLine($"******async Test() method Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" );
            

            {
                #region normal case

                //NoReturnNoAwait();

                #endregion
            }
            {
                #region test 2 ways of recall
                //NoReturnWithAwait();//1 await
                ////NoReturnContinueWith();//2 ContinueWith, normally with new thread
                //for (int i = 0; i < 10; i++)
                //{
                //    Thread.Sleep(300);//just to show main thread will continue do something. 
                //    ConsoleWriter.WriteLine($"current async Test()'s task {i} running, ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                //}
                #endregion
            }
            {
                #region test Wait() and await

                //a async method, if there is no return value, the method can return Task.
                //Task t = NoReturn_returnTask();
                //ConsoleWriter.WriteLine($"test async NoReturn_returnTask() 1 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                ////t.Wait();//1 main thread wait for completion of t, following will be main thread running

                //ConsoleWriter.WriteLine($"test async NoReturn_returnTask() 2 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //await t;//2 main thread not wait for t(go out of method), a thread from threadpool with execute logic after await in the method.
                ////following part will be a call back if t is not finished. 
                ////if t completed before await, following will also be main thread running.
                //ConsoleWriter.WriteLineGreen($"test async NoReturn_returnTask() 3 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                #endregion
            }
            {
                #region  Task with return value with async
                //await will help to simplify the ContinueWith, many tasks can be done in steps in new thread

                //ConsoleWriter.WriteLine($"test async SumAsync()  1 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //Task<long> t = SumAsync();

                //ConsoleWriter.WriteLine($"test async SumAsync()  2 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                //long lResult = t.Result;// exactly same to t.Wait(),  wait for the result returns and then continue. 

                //ConsoleWriter.WriteLine($"test async SumAsync()  3 result is {lResult} thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                #endregion
            }
            {
                #region Task with return value return Task

                ConsoleWriter.WriteLine($"test  async SumFactory()  1 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                // return a Task with return value
                Task<int> getResultTask = SumFactory();


                // thread 1 continue do sth
                ConsoleWriter.WriteLine($"test async SumFactory()  2 running thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");


                //thread 1 wait for the result,  getResultTask.Result is same to getResultTask.Wait()
                ConsoleWriter.WriteLine($"test async SumFactory()  3 finish, result is {getResultTask.Result}" +
                                  $" thread is ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                #endregion
            }


            ConsoleWriter.WriteLine($"******async Test() End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} ");
        }

        //if there is no await for async, it works like a normal method. 
        private static async void NoReturnNoAwait()
        {
            ConsoleWriter.WriteLine($"---------- NoReturnNoAwait() Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");

            Task task = Task.Run(() =>
            {
                ConsoleWriter.WriteLineYellow($"NoReturnNoAwait() begin sleep, thread id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(3000);
                ConsoleWriter.WriteLineYellow($"NoReturnNoAwait() after sleep, thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            });

            ConsoleWriter.WriteLine($"----------NoReturnNoAwait() End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} ");
        }

        //await task
        private static async void NoReturnWithAwait()
        {
            ConsoleWriter.WriteLine($"---------async NoReturnWithAwait() start before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(
                () =>
                {
                    ConsoleWriter.WriteLineYellow($"NoReturnWithAwait()'s task Start, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    ConsoleWriter.WriteLineYellow($"NoReturnWithAwait()'s task End, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
                );
            await task;

            //here,the thread id would be any thread, these logic may be executed by task's thread, maybe a new thread, maybe main(01) thread.
            //your case use thread 3, same to task.
            ConsoleWriter.WriteLineGreen($"--------async NoReturnWithAwait() end after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        private static async void NoReturnContinueWith()
        {
            ConsoleWriter.WriteLine($"---------async NoReturnContinueWith() start before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();
            Task task = taskFactory.StartNew(
                () =>
                {
                    ConsoleWriter.WriteLineYellow($"NoReturnContinueWith()'s task Start, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    ConsoleWriter.WriteLineYellow($"NoReturnContinueWith()'s task End, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
            );
            //the thread may be a new thread id,maybe same to task's thread id. in your case, it's new thread 4. task's thread is 3.
            _ = task.ContinueWith(t =>
                   {
                       ConsoleWriter.WriteLineGreen($"async NoReturn end after await something, " + $"ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                   }
           );

            ConsoleWriter.WriteLine($"---------async NoReturnContinueWith() End , ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }

        //a async method, if there is no return value, can return a task. after compilation, async will become stateMachine 
        private static async Task NoReturn_returnTask()
        {
            ConsoleWriter.WriteLine($"async NoReturn_returnTask() start running before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            Task task = Task.Run(
                () =>
                {
                    ConsoleWriter.WriteLineYellow($"NoReturn_returnTask()'s task Start, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    Thread.Sleep(3000);
                    ConsoleWriter.WriteLineYellow($"NoReturn_returnTask()'s task End, ThreadID= {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                }
            );
            await task;

            //here, the thread id would be any thread, these logic may be executed by task's thread, maybe a new thread, maybe main(01) thread.
            ConsoleWriter.WriteLineGreen($"async NoReturn_returnTask() end running after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
        }
        /// <summary>
        /// Task with return value, getting result must wait for the task.
        ///
        /// await will make the program running synchronously and in steps, not block main thread. it will start multiple threads.
        /// </summary>
        private static async Task<long> SumAsync()
        {
            ConsoleWriter.WriteLine($"async SumAsync() start running before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            long result = 0;

            //await: the following logic in the method will wait for the await task. . //eg. thread 3
            await Task.Run(
                () =>
                {
                    for (int k = 0; k < 10; k++)
                    {
                        ConsoleWriter.WriteLineYellow($"SumAsync() task {k} await Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(1000);
                    }

                    for (int i = 0; i < 999_999; i++)
                    {
                        result += i;
                    }

                }
                );
            //eg. thread 3
            ConsoleWriter.WriteLineYellow($"SumAsync() is running, part 1 tasks finished, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            //eg. thread 4
            await Task.Run(
                () =>
                {
                    for (int k = 11; k < 20; k++)
                    {
                        ConsoleWriter.WriteLineYellow($"SumAsync() task {k} await Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(1000);
                    }

                    for (int i = 0; i < 999_999; i++)
                    {
                        result += i;
                    }

                }
            );
            //eg. thread 4
            ConsoleWriter.WriteLineYellow($"SumAsync() is running, part 2 tasks finished, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            
            //eg thread 3 
            await Task.Run(
                () =>
                {
                    for (int k = 20; k < 30; k++)
                    {
                        ConsoleWriter.WriteLineYellow($"SumAsync() task {k} await Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(1000);
                    }

                    for (int i = 0; i < 999_999; i++)
                    {
                        result += i;
                    }

                }
            );
            //eg thread 3 
            ConsoleWriter.WriteLineYellow($"SumAsync() is running, part 3 tasks finished, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            ConsoleWriter.WriteLineYellow($"async SumAsync() end running after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}"); 
            
            //method have async, just return a long value 
            return result;
        }

        private static Task<int> SumFactory()
        {
            ConsoleWriter.WriteLine($"static SumFactory() start running before await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

            TaskFactory taskFactory = new TaskFactory();
            Task<int> iResult = taskFactory.StartNew<int>(
                () =>
                {
                    Thread.Sleep(1000);
                    int re = 0;
                    for (int i = 0; i < 1000; i++)
                    {
                        re += i;
                    }
                    ConsoleWriter.WriteLineYellow($"SumFactory() task running Task.Run Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                    return re;
                }
                );

            //this line will be executed by main thread without waiting. 
            ConsoleWriter.WriteLine($"static SumFactory() end running after await something, ThreadID = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");


            //method do not have async, must return Task
            return iResult;
        }










    }
}
