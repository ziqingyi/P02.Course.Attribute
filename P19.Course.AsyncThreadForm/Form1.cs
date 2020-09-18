using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreadState = System.Threading.ThreadState;

namespace P19.Course.AsyncThreadForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Console.WindowWidth = Console.WindowWidth * 3/2;

            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"*************button Sync Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss. fff")}" +
                              $"*********************");

            int l = 3;
            int m = 4;
            int n = l + m;
            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnSync_Click_{i}");
                this.DoSomethingLong(name);
            }
            ConsoleWriter.WriteLine($"*************btnSync_Click End , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }


        // a time consuming task
        private void DoSomethingLong(string name)
        {
            ConsoleWriter.WriteLineYellow($"+++++++++++++DoSomethingLong Start by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            ConsoleWriter.WriteLineYellow($"++++++++++++++DoSomethingLong End by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnAsync_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            Action<string> action = this.DoSomethingLong;//new Action<string>(this.DoSomethingLong);
            //action += this.DoSomethingLong;//wrong, The delegate must have only one target for multi-thread.but you can write methods in s=>{}; then assign to action.

            //action.Invoke("btnAsync_Click"); //sync way
            //action("btnAsync_Click");  // syntactic sugar 

            //action.BeginInvoke("btnAsync_Click",null,null);//async need 2 extra params

            for (int i = 0; i < 5; i++)
            {
                string name = string.Format($"btnAsync_Click_{i}");
                action.BeginInvoke(name, null, null);
            }


            ConsoleWriter.WriteLine($"****************btnAsync_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }

        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            
            {
                //1 call back. callback will be called when the action finished,
                //        you can pass some parameters to callback

                Action<string> action = this.DoSomethingLong;

                IAsyncResult asyncresult = null;

                AsyncCallback callback = ar =>
                {
                    ConsoleWriter.WriteLineGreen($"IAsyncResult are passed to AsyncCallback func? {object.ReferenceEquals(ar, asyncresult)}");
                    ConsoleWriter.WriteLineGreen($"btnasyncadvanced_click computation finished, IAsyncResult state is " +
                                      $"{ar.AsyncState} in thread {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                };

                asyncresult = action.BeginInvoke("btnasyncadvanced_click", callback, "any object being passed in....");

                ConsoleWriter.WriteLine(asyncresult.AsyncState.ToString() +"  "+asyncresult.IsCompleted.ToString());
            }
            
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }

        private void btnAsyncAdvanced2_IAsyncResult_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced2_IAsyncResult_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");

            {
                // 2 check asyncResult IsCompleted. The main thread will wait and provide notification.

                Action<string> action = this.DoSomethingLong;
                IAsyncResult asyncResult = null;

                //public delegate void AsyncCallback(IAsyncResult ar); //definition of AsyncCallback
                //ar is the result of invoke. 
                AsyncCallback callback = ar =>
                {
                    ConsoleWriter.WriteLineGreen($"AsyncCallback and IAsyncResult are same? : {object.ReferenceEquals(ar, asyncResult)}");
                    this.DoSomethingLong("callback");//just make call back running long time for checking whether IsCompleted means callback finished. 
                    ConsoleWriter.WriteLineGreen($"btnAsyncAdvanced2_IAsyncResult_Click's new thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} finish successfully, " +
                                      $"objects passed by --- ar.AsyncState : {ar.AsyncState}. ");
                };

                asyncResult = action.BeginInvoke("btnAsyncAdvanced2_IAsyncResult_Click", callback, "any parameters being passed in....");

                int i = 0;
                //Thread.Sleep(100);//wait for sub thread to start. not a good solution. 
                while (!asyncResult.IsCompleted)//not wait for call back
                {
                    //Thread.Sleep(200); //one line more, because when sleep, another thread finish. 
                    if (i < 9)
                    {
                        ConsoleWriter.WriteLine($" the action is being processing {++i * 10}%...." +
                                          $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");//notification
                    }
                    else
                    {
                        ConsoleWriter.WriteLine($"the action has completed 99.999999%" +
                                          $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");//notification
                    }

                    Thread.Sleep(200); // add this to adjust number of notifications, this is check time gap
                }
                ConsoleWriter.WriteLine("the action has completed 100%, " +
                                  $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")} ");

            }


            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced2_IAsyncResult_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }

        private void btnAsyncAdvanced3_WaitOne_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced3_WaitOne_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");

            {
                // 3 AsyncWaitHandle.WaitOne()   wait for task finishing. 
                Action<string> action = this.DoSomethingLong;
                IAsyncResult asyncResult = null;

                //public delegate void AsyncCallback(IAsyncResult ar); //definition of AsyncCallback
                //ar is the result of invoke. 
                AsyncCallback callback = ar =>
                {
                    Thread.Sleep(1000);//make it execute after main finish. WaitOne not wait for call back.
                    ConsoleWriter.WriteLineGreen($"AsyncCallback and IAsyncResult are same? : {object.ReferenceEquals(ar, asyncResult)}");
                    ConsoleWriter.WriteLineGreen($"btnAsyncAdvanced3_WaitOne_Click's new thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} finish successfully, " +
                                      $"objects passed by --- ar.AsyncState : {ar.AsyncState}. ");
                };

                asyncResult = action.BeginInvoke("btnAsyncAdvanced3_WaitOne_Click", callback, "any parameters being passed in....");

                asyncResult.AsyncWaitHandle.WaitOne();//wait until sub task(action) finish, then execute main thread,not wait for callback
                //asyncResult.AsyncWaitHandle.WaitOne(1000);//wait 1000 miliseconds 


                ConsoleWriter.WriteLine("the action has completed 100%, " +
                                  $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")} ");

            }

            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced3_WaitOne_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }

        private void btnAsyncAdvanced4_EndInvoke_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced4_EndInvoke_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");

            {
                // 4  EndInvoke, can wait for end of sub thread delegate and get return value 
                //                 one async operation only have one EndInvoke
                Func<string,long> func = this.DoSomethingLongReturn;
                IAsyncResult asyncResult = null;

                //public delegate void AsyncCallback(IAsyncResult ar); //definition of AsyncCallback
                //ar is the result of invoke. 
                long funcResult2;
                AsyncCallback callback = ar =>
                {
                    //funcResult2 = func.EndInvoke(ar);
                    //Console.WriteLine(funcResult2);//can also get here but one async can only get one endInvoke.
                    ConsoleWriter.WriteLineGreen($"AsyncCallback and IAsyncResult are same? : {object.ReferenceEquals(ar, asyncResult)}");
                    DoSomethingLong("callback");
                    ConsoleWriter.WriteLineGreen($"btnAsyncAdvanced4_EndInvoke_Click's new thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} finish successfully, " +
                                      $"objects passed by --- ar.AsyncState : {ar.AsyncState}. ");
                };

                //long funcResult1 = func.Invoke("btnAsyncAdvanced4_EndInvoke_Click");  //normal way of invoke action, just wait for method running. 
                
                
                asyncResult = func.BeginInvoke("btnAsyncAdvanced4_EndInvoke_Click", callback, "any parameters being passed in....");
                long funcResult = func.EndInvoke(asyncResult);//EndInvoke also wait return value(not IAsyncResult), still not wait for callback. 
                //so it's better to wait for EndInvoke in the callback function, because the UI will not get stuck.

                ConsoleWriter.WriteLine($"the action has completed 100%, result is {funcResult}" +
                                  $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")} ");

            }


            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnAsyncAdvanced4_EndInvoke_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }

        // a time consuming task with return 
        private long DoSomethingLongReturn(string name)
        {
            ConsoleWriter.WriteLineYellow($"+++++++++++++DoSomethingLong Start by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            ConsoleWriter.WriteLineYellow($"++++++++++++++DoSomethingLong End by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
            return lResult;

        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThread_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            {
                #region ThreadStart with Join

                //new thread without parameter
                ThreadStart method1 = () => this.DoSomethingLong("method1 in newthread1");
                Thread newthread1 = new Thread(method1);
                newthread1.Priority = ThreadPriority.AboveNormal;//set priority, may not execute first or last.
                newthread1.IsBackground = false;

                //a new thread without parameter to compare the priority
                ThreadStart method2 = () => { Console.WriteLine("method2 start by newthread2 with highest priority..."); };
                Thread newthread2 = new Thread(method2);
                newthread2.Priority = ThreadPriority.Highest;//normally it will execute in between of method 1.it will not guarantee first.


                //a new thread with parameter
                ParameterizedThreadStart method3 = o =>
                {
                    ConsoleWriter.WriteLineYellow("method3 is started in ID: " + Thread.CurrentThread.ManagedThreadId.ToString("00"));
                    Thread.Sleep(50);
                    this.DoSomethingLong("method3 in newthread3 with param: " + o.ToString());
                    Thread.Sleep(5000);
                };
                Thread newthread3 = new Thread(method3);
                newthread3.Priority = ThreadPriority.Lowest;
                newthread3.IsBackground = false;


                newthread1.Start();//start a thread to run the delegate 
                newthread2.Start();
                newthread3.Start(123);

                //newthread.Suspend();//may not suspend immediately , deprecated
                //newthread.Resume(); //deprecated
                //newthread.Abort();  //rarely used
                //newthread.ResetAbort();//rarely used

                //1 thread run this will wait newthread by checking the ThreadState
                while (newthread1.ThreadState != ThreadState.Stopped)
                {
                    Console.WriteLine("main thread check newthread1 is running....ID: "+ Thread.CurrentThread.ManagedThreadId.ToString("00"));
                    Thread.Sleep(200);
                }
                //2 the thread(main) run this  will wait for newthread1 finish, can set max time of waiting.eg: newthread1.Join(5000);
                //just wait for newthread1 (higher priority may finish early) , will freeze form. 
                //then, when newthread1 is completed, even form is closed, newthread3 will continue,due to IsBackground.
                newthread1.Join();

                #endregion

            }
            {
                #region background thread
                    //ThreadStart method4 = () => this.DoSomethingLong("method4");
                    //Thread newthread4 = new Thread(method4);
                    //newthread4.Start();//start a thread to run the delegate 

                    //newthread4.IsBackground = false;//if process stops, this thread will still running.
                    ////newthread4.IsBackground = true;//if process stops, thread stops. 
                #endregion

            }

            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThread_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
        }



        private void btnThread_CallBack_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThread_CallBack_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");

            ThreadStart threadStart = () => this.DoSomethingLong("btnThread_CallBack_Click");
            Action actionCallBack = () =>
            {
                Thread.Sleep(2000);
                ConsoleWriter.WriteLineYellow($"This is Callback in thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            };

            this.ThreadWithCallBack(threadStart,actionCallBack);



            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThread_CallBack_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
        }        
        
        private void ThreadWithCallBack(ThreadStart threadStart, Action actionCallback)
        {
            /*start a new thread and execute the thread and action in sequence*/

            //1 join will block the main thread
            //Thread thread = new Thread(threadStart);
            //thread.Start();
            //thread.Join();//main thread will be blocked.
            
            //2 ThreadStart and Action can invoke, it is a delegate, So put two methods in one Thread

            ThreadStart method = new ThreadStart(
                () =>
                {
                    threadStart.Invoke();
                    actionCallback.Invoke();
                });

            Thread t = new Thread(method);
            t.Start();
        }

        private void btnThread_CallBack_Return_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThread_CallBack_Return_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");

            Func<long> funcNeedReturn = ()=>
            {
                ConsoleWriter.WriteLineYellow("start calculating....");
                long re =DoSomethingLongReturn("btnThread_CallBack_Return_Click");
                return re;
            };


            Func<long> funcForNewThreadReturn = ThreadWithReturn(funcNeedReturn);//non-block,just get Func and new thread is running for calculation.
            ConsoleWriter.WriteLine("do something else......"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            ConsoleWriter.WriteLine("do something else......");
            ConsoleWriter.WriteLine("do something else......");
            Thread.Sleep(1000);//make main thread task running longer so new thread task can be started.
            ConsoleWriter.WriteLine("do something else......");
            ConsoleWriter.WriteLine("do something else......");
            ConsoleWriter.WriteLine("do something else......");
            ConsoleWriter.WriteLine("do something else......" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            long iResult = funcForNewThreadReturn.Invoke();//block main thread, need to wait for calculation



            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThread_CallBack_Return_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"Result is {iResult}***************");
        }

        private Func<T> ThreadWithReturn<T>(Func<T> func)
        {
            //1 async and no block
            //2 get final result
            T t = default(T);
            ThreadStart threadStart = new ThreadStart(
                () =>
                {
                     t = func.Invoke();
                });

            Thread thread = new Thread(threadStart);
            thread.Start();

            //return delegate, just a method. 
            return new Func<T>(()=>
            {
                //add check process, not necessary
                if (thread.ThreadState == ThreadState.Running)
                {
                    ConsoleWriter.WriteLineYellow("ThreadWithReturn() 's new thread is running");
                }

                thread.Join();//thread running this will block and wait for result. 
                return t;
            });

        }

        private void btnTheadCount_Click(object sender, EventArgs e)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(200);//wait for thread to start run, otherwise start 100 threads before anyone running.
                if (threads.Count(t => t.ThreadState == ThreadState.Running) < 10)
                {
                    Thread thread = new Thread(()=>{
                        ConsoleWriter.WriteLineGreen("a new thread with ID: "+Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(5000);
                        ConsoleWriter.WriteLineGreen("thread finished ID: " + Thread.CurrentThread.ManagedThreadId);
                    });

                    thread.Start();
                    threads.Add(thread);
                }
                else
                {
                    ConsoleWriter.WriteLineGreen("there are 10 threads running.....");
                    Thread.Sleep(200);
                }
            }
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThreadPool_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            //wait for new thread complete
            ManualResetEvent mre = new ManualResetEvent(false);


            //all thread pool threads are background thread, //if process stops, thread stops. 
            //ManualResetEvent: false  -- close state ---Set() to Open ---become true ---WaitOne() pass
            //                  true   -- Open state ---ReSet() to Close----become false ---WaitOne() must wait. 
            ThreadPool.QueueUserWorkItem(o =>
                {
                    this.DoSomethingLong("btnThreadPool_Click with param: " + o.ToString());
                    mre.Set();// set mre
                    //mre.Reset();
                },
                "state value");// state will pass to o


            ConsoleWriter.WriteLine("Do something else...."+Thread.CurrentThread.ManagedThreadId);
            ConsoleWriter.WriteLine("Do something else....");
            ConsoleWriter.WriteLine("Do something else....");

            ConsoleWriter.WriteLine(mre.WaitOne().ToString());//wait for thread finish set() in the thread pool


            ConsoleWriter.WriteLine("ThreadPool threads should finished....");


            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThread_CallBack_Return_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }

        private void btnThreadPool_MaxMin_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThreadPool_MaxMin_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");



            ThreadPool.GetMaxThreads(out int workerThreadsMax, out int completionPortThreadsMax);
            ConsoleWriter.WriteLine($"The computer's max workerThreads = {workerThreadsMax} " +
                              $"max completion port threads = {completionPortThreadsMax}");

            ThreadPool.GetMinThreads(out int workerThreadsMin, out int completionPortThreadsMin);
            ConsoleWriter.WriteLine($"The computer's min workerThreads = {workerThreadsMin} " +
                              $"min completion port threads = {completionPortThreadsMin}");

            //the ThreadPool Max and Min value is set for whole process, 
            //will affect Task, Parallel, async/await, they all use ThreadPool
            // new Thread will use thread from the pool, reduce Max threads available.. 
            ThreadPool.SetMaxThreads(5, 5);// the max number must be more than computer's num of processors 

            ThreadPool.SetMinThreads(3, 3);

            ConsoleWriter.WriteLine("after set the max and min threads numbers");


            ThreadPool.GetMaxThreads(out int workerThreadsMax1, out int completionPortThreadsMax1);
            ConsoleWriter.WriteLine($"The computer's max workerThreads = {workerThreadsMax1} " +
                              $"max completion port threads = {completionPortThreadsMax1}");

            ThreadPool.GetMinThreads(out int workerThreadsMin1, out int completionPortThreadsMin1);
            ConsoleWriter.WriteLine($"The computer's min workerThreads = {workerThreadsMin1} " +
                              $"min completion port threads = {completionPortThreadsMin1}");




            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThreadPool_MaxMin_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }

        private void btnThreadPoolLock_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThreadPoolLock_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");




            ThreadPool.SetMaxThreads(9, 9);
            ThreadPool.GetMaxThreads(out int workerThreadsMax, out int completionPortThreadsMax);
            ConsoleWriter.WriteLine($"The computer's max workerThreads = {workerThreadsMax} " +
                                    $"max completion port threads = {completionPortThreadsMax}");

            ManualResetEvent mre = new ManualResetEvent(false);

            int numOfTheadNeedToOpen = 9;
            for (int i = 1; i <= numOfTheadNeedToOpen; i++)
            {
                int k = i;

                //start new threads
                ThreadPool.QueueUserWorkItem(t =>
                {
                    ConsoleWriter.WriteLineYellow($"ThreadPool thread ID is: {Thread.CurrentThread.ManagedThreadId.ToString("00")} show thread no is {k} start ");
                    if (k == numOfTheadNeedToOpen)//if numOfTheadNeedToOpen > Max Threads in pool, mre will not execute Set(), then lock.
                    {
                        mre.Set();
                    }
                    else
                    {
                        mre.WaitOne();//it's better not to block thread in the thread pool, as cannot predict what will happen outside.
                        ConsoleWriter.WriteLineYellow($"ThreadPool thread ID is: {Thread.CurrentThread.ManagedThreadId.ToString("00")} show thread no is {k} end");
                    }
                });

            }

            if (mre.WaitOne())
            {
                ConsoleWriter.WriteLine("all tasks completed ....");
            }




            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThreadPoolLock_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }
        private void btnThreadPoolReturn_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnThreadPoolReturn_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");



            Func<long> t = ()=>DoSomethingLongReturn("btnThreadPoolReturn_Click");


            Func<long> getReturn = ThreadPoolWithReturn(t);

            long result = getReturn.Invoke();

            ConsoleWriter.WriteLine("result is : " +result);


            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnThreadPoolReturn_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }

        private Func<T> ThreadPoolWithReturn<T>(Func<T> func)
        {
            //use thread pool to start thread and get return
            // use ManualResetEvent to check status

            ManualResetEvent mre = new ManualResetEvent(false);

            T t = default(T);
            ThreadPool.QueueUserWorkItem(o =>
            {
                ConsoleWriter.WriteLineYellow("ThreadPoolWithReturn() is working in thread: "+ $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} ");
                t = func.Invoke();
                ConsoleWriter.WriteLineYellow("ThreadPoolWithReturn() is finish in thread: " + $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} ");
                mre.Set();
            });

            Func<T> re = () =>
            {
                ConsoleWriter.WriteLine("ThreadPoolWithReturn() wait in thread: " + $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} ");
                mre.WaitOne();
                return t;
            };

            return re;
        }







        private void btnTask_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnTask_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");



            {
                //// 3 ways to start task.
                List<Task> allTask = new List<Task>();
                {
                    Task task = new Task(() => this.DoSomethingLong("btnTask_Click_new_task.Start()"));
                    task.Start();

                    allTask.Add(task);
                }
                {
                    Task task = Task.Run(() => DoSomethingLong("btnTask_Click_Task.Run()"));

                    allTask.Add(task);
                }
                {
                    TaskFactory taskFactory = new TaskFactory();//Task.Factory;
                    Task task = taskFactory.StartNew(() => DoSomethingLong("btnTask_Click_taskFactory.StartNew()"));

                    allTask.Add(task);
                }
                //just add this to separate the test cases. 
                Task.WaitAll(allTask.ToArray());

            } 

            {
                //
                //ThreadPool is singleton, so if you set max value, the who program will be limited. 
                //in this case, we set to 8, which limiting the speed. The threads in the pool will be reused. 
                ThreadPool.SetMaxThreads(8,8);

                for (int i = 0; i < 100; i++)
                {
                    int k = i;
                    Task.Run(() =>
                    {
                        ConsoleWriter.WriteLineYellow($"This is {k} running" +
                                          $"ThreadId ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(2000);
                        ConsoleWriter.WriteLineYellow($"{k} is finished...");
                    });
                }
            }

            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnTask_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }

        private void btnTask_LimitNumOfTasks_Click(object sender, EventArgs e)
        {

            ConsoleWriter.WriteLine($"****************btnTask_LimitNumOfTasks_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            HashSet<string> collectAllThreadId = new HashSet<string>();

            //limit num of tasks running.
            int TotalNumOfTask = 100;
            //complete 1000 tasks with 11 theads
            Action<int> action = i =>
            {

                ConsoleWriter.WriteLineYellow($"action {i} start with thread id: {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                Thread.Sleep(new Random(i).Next(100,300));
                ConsoleWriter.WriteLineYellow($"action {i} finish with thread id: {Thread.CurrentThread.ManagedThreadId.ToString("00")} {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");
                collectAllThreadId.Add(Thread.CurrentThread.ManagedThreadId.ToString("00"));//collect thread ID
            };

            List<Task> taskList = new List<Task>();

            for (int i =0;i<TotalNumOfTask;i++)
            {
                ConsoleWriter.WriteLine("*****start a new task*****");
                ////invoke a new thread, can also use a taskfactory.StartNew(), to pass state
                taskList.Add(
                    Task.Run(
                        () => 
                        action.Invoke(i)
                        )
                    );

                if (taskList.Count > 10)//set max num of running tasks in the list. 
                {
                    ConsoleWriter.WriteLine($"there are {taskList.Count} tasks running in the list, just wait any to finish.");
                    
                    //task list is full, show all task id
                    StringBuilder sb = new StringBuilder();
                    sb.Append("all running tasks' Task Id : ");
                    foreach (Task t in taskList)
                    {
                        sb.Append(t.Id + ", ");
                    }

                    ConsoleWriter.WriteLine(sb.ToString());

                    //wait any to complete
                    Task.WaitAny(taskList.ToArray());
                    //remove the completed tasks.
                    taskList = taskList.Where(t => t.Status != TaskStatus.RanToCompletion).ToList();
                    ConsoleWriter.WriteLine($"some tasks are finished, so now task list have {taskList.Count} tasks. {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}");

                    //now check task id again
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("anyone finished, now all running task Id : ");
                    foreach (Task t in taskList)
                    {
                        sb2.Append(t.Id + ", ");
                    }

                    ConsoleWriter.WriteLine(sb2.ToString() + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

                }
            }
            Task.WaitAll(taskList.ToArray());

            //print out all thread id, may exceed 10 because the limitation is set to num of thread at a time. 
            ConsoleWriter.WriteLine("Hashset: collectAllThreadId  has  "+ collectAllThreadId.Count +" thread ids");
            foreach (string s in collectAllThreadId.OrderBy(s=>s))
            {
                ConsoleWriter.WriteLine("we use thread ids: "+s);
            }

            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnTask_LimitNumOfTasks_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");

        }



        private void btnTaskDelay_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnTask_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ConsoleWriter.WriteLine("before the sleep....");

                Thread.Sleep(2000);//windows freeze 

                ConsoleWriter.WriteLine("after the sleep.....");

                sw.Stop();

                ConsoleWriter.WriteLine($" sleep takes {sw.ElapsedMilliseconds}");
            }
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                ConsoleWriter.WriteLine("before the delay...");

                Task task = Task.Delay(2000).ContinueWith(t =>//new task will not freeze window
                {
                    sw.Stop();
                    ConsoleWriter.WriteLineYellow($"Delay takes {sw.ElapsedMilliseconds}");
                    ConsoleWriter.WriteLineYellow($"this is ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                });

                ConsoleWriter.WriteLine("after the delay.....");

            }

            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnTask_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");

        }

        private void btnTask_Teach_Proj_Click(object sender, EventArgs e)
        {

            ConsoleWriter.WriteLine($"****************btnTask_Teach_Proj_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            Teach("Professor Adrian", "lesson 1"); //no concurrency, must complete one by one
            Teach("Professor Adrian", "lesson 2");

            ConsoleWriter.WriteLine(@"Now start a project...");

            TaskFactory taskFactory = new TaskFactory();
            List<Task> taskList = new List<Task>();

            taskList.Add(taskFactory.StartNew( o =>coding(o.ToString(), " Portal "), "student1 async state Protal"));
            taskList.Add(taskFactory.StartNew(o =>coding("student2", " DBA "),"async state DBA" ));
            taskList.Add(taskFactory.StartNew(()=>coding("student3","Backend")  ));


            //Task.WaitAny(taskList.ToArray()); // if any task complete, do something using main thread. 
            //Console.WriteLine(@"Professor Adrian start to config environment");  // can use ContinueWhenAll
            Task continueTask = taskFactory.ContinueWhenAny(taskList.ToArray(), rArray =>
            {
                ConsoleWriter.WriteLineGreen("AsyncState is : "+rArray.AsyncState +" finish first, very good...");

                ConsoleWriter.WriteLineGreen($"one of the Project is finished, current thread ID IS {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                ConsoleWriter.WriteLineGreen(@"Professor Adrian start to config environment ");
            });//ContinueWhenAny will pick a new thread from the threadpool, maybe the one of the previous thread, may not. But not main thread ID. 

            
            //if you need to wait for callback task finish, just add to taskList
            taskList.Add(continueTask);



            //Task.WaitAll(taskList.ToArray()); //wait until all finished, then can do something with main thread.  
            //
            //do something when all finish
            taskFactory.ContinueWhenAll(taskList.ToArray(), rArray =>
            {
                ConsoleWriter.WriteLineGreen($"Project is FINISHED, current thread ID is {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                
                //one way of get task result and then do something,but block main thread running the task
                Task<int> res = Task.Run<int>(() => { return 1;} );
                ConsoleWriter.WriteLineGreen("wait for result: "+res.Result.ToString()); 

                //another way of get task result and then do something, not block main thread running the task
                Task toGrade = Task.Run<int>(() => 
                {
                    Thread.Sleep(2000);//will block the thread, will give a score
                    string threadId = Thread.CurrentThread.ManagedThreadId.ToString("00");
                    ConsoleWriter.WriteLineYellow($"in process of marking...in thread {threadId}");
                    Random r = new Random();
                    return r.Next(50, 100);
                }).ContinueWith(tint =>
                    {
                        int result = tint.Result;
                        string threadId = Thread.CurrentThread.ManagedThreadId.ToString("00");
                        ConsoleWriter.WriteLineGreen($"Professor Adrian start to review the project in thread {threadId}, Score is  " + result);
                    });//Task.Run(...).ContinueWith(...) will use new Thread ID in most cases for callback. 

            });//ContinueWhenAny will pick a new thread from the threadpool, maybe the one of the previous thread, may not. 



            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnTask_Teach_Proj_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }

        private void Teach(string name,string course)
        {
            ConsoleWriter.WriteLineYellow($"+++++++++++++Tutorial {course} Start by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }

            ConsoleWriter.WriteLineYellow($"++++++++++++++Tutorial  {course} End by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
        }
        private void coding(string name, string prjectName)
        {
            ConsoleWriter.WriteLineYellow($"+++++++++++++{name} is working on project {prjectName} , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} ++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            ConsoleWriter.WriteLineYellow($"++++++++++++++{name} finish the project {prjectName}, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
        }

        private void btnParallel_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnParallel_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            //Parallel run multiple actions with multiple thread, 
            //main thread will join in computation, eg. thread 01, so here Parallel will finish one and then start next one.
            //main thread will wait all tasks finish, similar to TaskWaitAll + main thread computation.

            //Parallel.Invoke()
            Parallel.Invoke(()=>DoSomethingLong("btnParallel_Click_00"),
                ()=>DoSomethingLong("btnParallel_Click_01"),
                ()=>DoSomethingLong("btnParallel_Click_02"),
                ()=>DoSomethingLong("btnParallel_Click_03"),
                ()=>DoSomethingLong("btnParallel_Click_04"));

            ConsoleWriter.WriteLine("------------------------set max to 3, Parallel.For()---------------------------------");
            //then set limit to num of parallel tasks at a time. 
            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 3;

            //Parallel.For(), main thead will be used
            Parallel.For(5,10,options,i=>DoSomethingLong($"btnParallel_Click_{i}"));

            ConsoleWriter.WriteLine("------------------------Parallel.ForEach()--------------------------------");
            //Parallel.ForEach() , main thead will be used
            Parallel.ForEach(new int[] {11, 12}, i => DoSomethingLong($"btnParallel_Click_{i}"));



            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnParallel_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }

        private void btnParallel_no_block_Click(object sender, EventArgs e)
        {
            ConsoleWriter.WriteLine($"****************btnParallel_no_block_Click Start, Thread Id is: " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                                    $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                                    $"***************");
            ConsoleWriter.WriteLine("----------------------------------------------------------------------");


            Action someParallelTasks = () =>
            {
                ParallelOptions options = new ParallelOptions();
                options.MaxDegreeOfParallelism = 3;
                Parallel.For(0, 10, options, i => DoSomethingLong($"btnParallel_no_block_Click_{i}"));
            };

            Task.Run(someParallelTasks);

            ConsoleWriter.WriteLine("----------------------------------------------------------------------");
            ConsoleWriter.WriteLine($"****************btnParallel_no_block_Click End, Thread Id is:  " +
                                    $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                                    $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                                    $"***************");
        }


        private void btnThreadCore_Exception_Click(object sender, EventArgs e)
        {
            Console.WriteLine(@"****************btnThreadCore_Exception_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            //exception in one thread will only stop current thread, but not affect other threads.
            //so use waitall to catch the exceptions.
            //the best practice is to try catch(may have log) in the sub tasks(threads),
            //which means no error in delegate in tasks. this is applied in next button.
            try
            {
                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 100; i++)
                {
                    string name = $"btnThreadCore_Exception_Click_{i}";
                    taskList.Add(
                        Task.Run(() =>
                        {
                            if (name.Equals("btnThreadCore_Exception_Click_10"))
                            {
                                throw new Exception("btnThreadCore_Exception_Click_10 Exception...."+ Thread.CurrentThread.ManagedThreadId.ToString("00"));
                            }
                            else if (name.Equals("btnThreadCore_Exception_Click_11"))
                            {
                                throw new Exception("btnThreadCore_Exception_Click_11 Exception...." + Thread.CurrentThread.ManagedThreadId.ToString("00"));
                            }
                            else if (name.Equals("btnThreadCore_Exception_Click_12"))
                            {
                                throw new Exception("btnThreadCore_Exception_Click_12 Exception...." + Thread.CurrentThread.ManagedThreadId.ToString("00"));
                            }
                            Console.WriteLine($"This is {name} success, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                        })
                    );
                }
                Task.WaitAll(taskList.ToArray());//if not wait all, exception will not be catched. waitAny will not catch exception.
            }
            catch (AggregateException aex)
            {
                foreach (var exception in aex.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine(@"****************btnThreadCore_Exception_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void btnThreadCore_CancellationTokenSource_Click(object sender, EventArgs e)
        {

            Console.WriteLine(@"****************btnThreadCore_CancellationTokenSource_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                List<Task> taskList = new List<Task>();
                for (int i = 0; i < 30; i++)
                {
                    string name = $"btnThreadCore_Exception_Click_{i}";
                    taskList.Add(
                        Task.Run(() =>
                        {
                            try
                            {
                                if (!cts.IsCancellationRequested)// check cancellation request
                                {
                                    Console.WriteLine($"This is {name} start, " +
                                                      $"Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                                    Thread.Sleep(new Random().Next(50, 100));

                                    if (name.Equals("btnThreadCore_Exception_Click_10"))
                                    {
                                        throw new Exception("btnThreadCore_Exception_Click_10 Exception...." + Thread.CurrentThread.ManagedThreadId.ToString("00"));
                                    }
                                    else if (name.Equals("btnThreadCore_Exception_Click_11"))
                                    {
                                        throw new Exception("btnThreadCore_Exception_Click_11 Exception...." + Thread.CurrentThread.ManagedThreadId.ToString("00"));
                                    }
                                    else if (name.Equals("btnThreadCore_Exception_Click_12"))
                                    {
                                        throw new Exception("btnThreadCore_Exception_Click_12 Exception...." + Thread.CurrentThread.ManagedThreadId.ToString("00"));
                                    }

                                    if (!cts.IsCancellationRequested) //check cancellation request
                                    {
                                        Console.WriteLine($"This is {name} success, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"This is {name} stops in middle, Thread Id = {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                                cts.Cancel();// cancel() in  CancellationTokenSource
                                throw;
                            }

                        }, cts.Token) // show the cancelled tasks, these tasks did not execute
                    );
                }
                Task.WaitAll(taskList.ToArray());//if not wait all, exception will not be catched. waitAny will not catch exception.
            }
            catch (AggregateException aex)
            {
                foreach (var exception in aex.InnerExceptions)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            Console.WriteLine(@"****************btnThreadCore_CancellationTokenSource_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void btnThreadCore_Variable_Click(object sender, EventArgs e)
        {
            Console.WriteLine(@"****************btnThreadCore_Variable_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            for (int i = 0; i < 5; i++)
            {
                int k = i; //show the different between i and k, i is shared. 
                Task.Run(()=>
                {
                    Console.WriteLine($"this is btnThreadCore_Variable_Click_{i}_{k}, " +
                                      $"ThreadId ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                });
            }

            Console.WriteLine(@"****************btnThreadCore_Variable_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        List<Task> waitList = new List<Task>();

        private int iNumSync = 0;
        private List<int> iListSync = new List<int>();

        private int iNumAsync = 0;
        private static readonly object Form_lock = new object();

        private void btnThreadCore_ThreadSafety_Click(object sender, EventArgs e)
        {
            Console.WriteLine(@"****************btnThreadCore_Variable_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            int numOfTasks = 10000;

            //Sync method
            for (int i = 0; i < numOfTasks; i++)
            {
                iNumSync++;
            }

            //1 ThreadSafety method one, use Lock

            //run 1000 tasks at same time. use lock for safety.
               
            //use lock (Syntactic sugar), in IL, it's Monitor.Enter, it will occupy the ref of the ref type. 
            //Lock object should be private static readonly object.
            //private: not used in other classes, static:only have one in one class, 
            //readonly: should not be modified. object: must be reference type.
            //(null will be exception in threads)(string will have sharing issue.)
            //(lock(this))
            for (int i = 0; i < numOfTasks; i++)
            {
                Task t = Task.Run(() =>
                {
                    lock (Form_lock)
                    { 
                        Thread.Sleep(5); 
                        return iNumAsync++;
                    }
                });

                waitList.Add(t);
            }

            //test List, which is not thread safe.
            for (int i = 0; i < numOfTasks; i++)
            {
                int k = i;
                Task.Run(() => iListSync.Add(k));
            }

            Task.WaitAll(waitList.ToArray());//just wait all task complete

            Console.WriteLine($"iNumSync = {iNumSync}, iNumAsync={iNumAsync}, IListSync.Count={iListSync.Count}");


            //2 ThreadSafety method two, use thread-safe collections. Performance better than lock.
            //System.Collections.Concurrent.ConcurrentBag<int> cbag;


            //3 ThreadSafety method three, the best solution is to separate the tasks with each threads.
            //  one thread work in one task from begin to finish.Then combine task result together. Safe and high performance. 

            Console.WriteLine(@"****************btnThreadCore_Variable_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void ThreadCore_LockThis_Click(object sender, EventArgs e)
        {
            Console.WriteLine(@"****************ThreadCore_LockThis_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            //main thread lock the same object with sub threads. 
            // in this case, the DoTest() method lock this, which is same to task in ContinueWith
            // so two thread lock same object. 
            TestLock test = new TestLock();
            
            Task.Delay(1000).ContinueWith(
                t =>
                {
                    lock (test)
                    {
                        Console.WriteLine("*******Begin**********");
                        Thread.Sleep(5000);
                        Console.WriteLine("*******End**********");
                    }
                }
                );
            
            test.DoTestLockThis();

            Console.WriteLine(@"****************ThreadCore_LockThis_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
        class TestLock
        {
                private int iDoTestNum = 0;

                public void DoTestLockThis()
                {
                    //will not lock, because this is locked by same thread.
                    //lock is used for preventing other threads.
                    lock (this)
                    {
                        Thread.Sleep(500);
                        this.iDoTestNum++;
                        if (DateTime.Now.Day < 28 && iDoTestNum < 10)
                        {
                            Console.WriteLine($"This is the {iDoTestNum}th , {DateTime.Now.Day}");
                            this.DoTestLockThis();
                        }
                        else
                        {
                            Console.WriteLine("this is 28");
                        }

                    }
                }

                private string LockString = "LockString";
                public void DoTestLockString()
                {
                    
                    lock (LockString)
                    {
                        Thread.Sleep(500);
                        this.iDoTestNum++;
                        if (DateTime.Now.Day < 28 && iDoTestNum < 10)
                        {
                            Console.WriteLine($"This is the {iDoTestNum}th , {DateTime.Now.Day}");
                            this.DoTestLockThis();
                        }
                        else
                        {
                            Console.WriteLine("this is 28");
                        }

                    }
                }

        }

        private void btnThreadCore_LockStringNull_Click(object sender, EventArgs e)
        { 
            Console.WriteLine(@"****************ThreadCore_LockThis_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            string a = "abc";
            string b = a;
            Console.WriteLine(object.ReferenceEquals(a, b) + b); //true abc
            a = "def";
            Console.WriteLine(object.ReferenceEquals(a,b) + b);//false abc

            int aa = 123;
            int bb = aa;
            aa = 456;
            Console.WriteLine(aa + " " + bb);//123  456

            //main thread lock the same object with sub threads. 
            //all the strings are different references with the same value to a single string object.
            //This is because the ldstr IL instruction interns literal strings and reuses them
            //rather than allocate per ldstr.
            // so two thread lock same object.

            // lock null will pass compile but will not be able to run 
            // There is only one thread in Lock(){}, so do not put too many code inside. 

            TestLock test = new TestLock();
            
            string LockString = "LockString";

            Task.Delay(1000).ContinueWith(
                t =>
                {
                    lock (LockString)
                    {
                        Console.WriteLine("*******Begin**********");
                        Thread.Sleep(5000);
                        Console.WriteLine("*******End**********");
                    }
                }
            );

            test.DoTestLockString();

            Console.WriteLine(@"****************ThreadCore_LockThis_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            Console.Clear();
        }


    }

    



}
