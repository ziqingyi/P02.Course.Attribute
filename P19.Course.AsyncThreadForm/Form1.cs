using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            InitializeComponent();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"*************button Sync Click Start, Thread Id is: " +
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
            Console.WriteLine($"*************btnSync_Click End , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }


        // a time consuming task
        private void DoSomethingLong(string name)
        {
            Console.WriteLine($"+++++++++++++DoSomethingLong Start by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);

            Console.WriteLine($"++++++++++++++DoSomethingLong End by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");

        }

        private void btnAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsync_Click Start, Thread Id is: " +
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


            Console.WriteLine($"****************btnAsync_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }

        private void btnAsyncAdvanced_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsyncAdvanced_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            Console.WriteLine("----------------------------------------------------------------------");
            
            {
                //1 call back. callback will be called when the action finished,
                //        you can pass some parameters to callback

                Action<string> action = this.DoSomethingLong;

                IAsyncResult asyncresult = null;

                AsyncCallback callback = ar =>
                {
                    Console.WriteLine($"{object.ReferenceEquals(ar, asyncresult)}");
                    Console.WriteLine($"btnasyncadvanced_click finish successfully, " +
                                      $"{ar.AsyncState}. {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                };

                asyncresult = action.BeginInvoke("btnasyncadvanced_click", callback, "any object being passed in....");
            }

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"****************btnAsyncAdvanced_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }

        private void btnAsyncAdvanced2_IAsyncResult_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsyncAdvanced2_IAsyncResult_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            Console.WriteLine("----------------------------------------------------------------------");

            {
                // 2 check asyncResult IsCompleted. The main thread will wait and provide notification.

                Action<string> action = this.DoSomethingLong;
                IAsyncResult asyncResult = null;

                //public delegate void AsyncCallback(IAsyncResult ar); //definition of AsyncCallback
                //ar is the result of invoke. 
                AsyncCallback callback = ar =>
                {
                    Console.WriteLine($"AsyncCallback and IAsyncResult are same? : {object.ReferenceEquals(ar, asyncResult)}");
                    Console.WriteLine($"btnAsyncAdvanced2_IAsyncResult_Click's new thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} finish successfully, " +
                                      $"objects passed by --- ar.AsyncState : {ar.AsyncState}. ");
                };

                asyncResult = action.BeginInvoke("btnAsyncAdvanced2_IAsyncResult_Click", callback, "any parameters being passed in....");

                int i = 0;
                Thread.Sleep(100);//wait for sub thread to start. not a good solution. 
                while (!asyncResult.IsCompleted)
                {
                    //Thread.Sleep(200); //one line more, because when sleep, another thread finish. 
                    if (i < 9)
                    {
                        Console.WriteLine($" the action is being processing {++i * 10}%...." +
                                          $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");//notification
                    }
                    else
                    {
                        Console.WriteLine($"the action has completed 99.999999%" +
                                          $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");//notification
                    }

                    Thread.Sleep(200); // add this to adjust number of notifications
                }
                Console.WriteLine("the action has completed 100%, " +
                                  $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")} ");

            }


            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"****************btnAsyncAdvanced2_IAsyncResult_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
        }

        private void btnAsyncAdvanced3_WaitOne_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsyncAdvanced3_WaitOne_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            Console.WriteLine("----------------------------------------------------------------------");

            {
                // 3 AsyncWaitHandle.WaitOne()   wait for task finishing. 
                Action<string> action = this.DoSomethingLong;
                IAsyncResult asyncResult = null;

                //public delegate void AsyncCallback(IAsyncResult ar); //definition of AsyncCallback
                //ar is the result of invoke. 
                AsyncCallback callback = ar =>
                {
                    Thread.Sleep(1000);//make it execute after main finish. WaitOne not wait for call back.
                    Console.WriteLine($"AsyncCallback and IAsyncResult are same? : {object.ReferenceEquals(ar, asyncResult)}");
                    Console.WriteLine($"btnAsyncAdvanced3_WaitOne_Click's new thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} finish successfully, " +
                                      $"objects passed by --- ar.AsyncState : {ar.AsyncState}. ");
                };

                asyncResult = action.BeginInvoke("btnAsyncAdvanced3_WaitOne_Click", callback, "any parameters being passed in....");

                asyncResult.AsyncWaitHandle.WaitOne();//wait until sub task(action) finish, then execute main thread,not wait for callback
                //asyncResult.AsyncWaitHandle.WaitOne(1000);//wait 1000 miliseconds 


                Console.WriteLine("the action has completed 100%, " +
                                  $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")} ");

            }

            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"****************btnAsyncAdvanced3_WaitOne_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }

        private void btnAsyncAdvanced4_EndInvoke_Click(object sender, EventArgs e)
        {
            Console.WriteLine($"****************btnAsyncAdvanced4_EndInvoke_Click Start, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")}" +
                              $" {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");
            Console.WriteLine("----------------------------------------------------------------------");

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
                    Console.WriteLine($"AsyncCallback and IAsyncResult are same? : {object.ReferenceEquals(ar, asyncResult)}");
                    Console.WriteLine($"btnAsyncAdvanced4_EndInvoke_Click's new thread " +
                                      $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} finish successfully, " +
                                      $"objects passed by --- ar.AsyncState : {ar.AsyncState}. ");
                };

                asyncResult = func.BeginInvoke("btnAsyncAdvanced4_EndInvoke_Click", callback, "any parameters being passed in....");


                long funcResult = func.EndInvoke(asyncResult);//EndInvoke can also get return value


                Console.WriteLine($"the action has completed 100%, result is {funcResult}" +
                                  $" checked by thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")} ");

            }


            Console.WriteLine("----------------------------------------------------------------------");
            Console.WriteLine($"****************btnAsyncAdvanced4_EndInvoke_Click End, Thread Id is:  " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"***************");

        }

        // a time consuming task with return 
        private long DoSomethingLongReturn(string name)
        {
            Console.WriteLine($"+++++++++++++DoSomethingLong Start by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}" +
                              $"++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            //Thread.Sleep(2000);
            
            Console.WriteLine($"++++++++++++++DoSomethingLong End by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
            return lResult;

        }

        private void btnThread_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnThread_Click Start, Thread Id is: {0} Now:{1}***************", 
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                 DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            {
                #region some methods with Join
                //ThreadStart method = () => this.DoSomethingLong("btnThread_Click");
                //Thread newthread1 = new Thread(method); 
                //newthread1.Priority = ThreadPriority.Lowest;//set priority, may not execute first or last.

                ////a new thread to compare the priority
                //ThreadStart method2 = () => { Console.WriteLine("thread with highest priority..."); };
                //Thread newthread2 = new Thread(method2);
                //newthread2.Priority = ThreadPriority.Highest;//normally it will execute in between of method 1.

                //newthread1.Start();//start a thread to run the delegate 
                //newthread2.Start();


                //newthread.Suspend();//may not suspend immediately , deprecated
                //newthread.Resume(); //deprecated
                //newthread.Abort();  //rarely used
                //newthread.ResetAbort();//rarely used

                ////1 thread run this will wait newthread by checking the ThreadState
                //while (newthread.ThreadState != ThreadState.Stopped)
                //{
                //    Thread.Sleep(200);
                //}
                //2 the thread run this  will wait for newthread finish,can set max time of waiting.
                //newthread.Join(1000);

                #endregion

            }
            {
                #region new thread with parameter
                //ParameterizedThreadStart method = o => this.DoSomethingLong(o.ToString() + "btnThread_Click");
                //Thread thread = new Thread(method);
                //thread.Start(123);
                #endregion 

            }
            {
                #region background thread
                    ThreadStart method = () => this.DoSomethingLong("btnThread_Click");
                    Thread newthread = new Thread(method);
                    newthread.Start();//start a thread to run the delegate 

                    newthread.IsBackground = false;//if process stops, this thread will still running.
                    //newthread.IsBackground = true;//if process stops, thread stops. 
                #endregion

            }


            Console.WriteLine("****************btnThread_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }



        private void btnThread_CallBack_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnThread_CallBack_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));


            ThreadStart threadStart = () => this.DoSomethingLong("btnThread_CallBack_Click");
            Action actionCallBack = () =>
            {
                Thread.Sleep(2000);
                Console.WriteLine($"This is Callback in thread: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
            };

            this.ThreadWithCallBack(threadStart,actionCallBack);



            Console.WriteLine("****************btnThread_CallBack_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
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
            Console.WriteLine("****************btnThread_CallBack_Return_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            Func<long> funcNeedReturn = ()=> DoSomethingLongReturn("btnThread_CallBack_Return_Click");


            Func<long> funcForNewThreadReturn = ThreadWithReturn(funcNeedReturn);//non-block,just get Func and thread. 
            Console.WriteLine("do something else......"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Console.WriteLine("do something else......");
            Console.WriteLine("do something else......");
            Console.WriteLine("do something else......");
            Console.WriteLine("do something else......");
            Console.WriteLine("do something else......");
            Console.WriteLine("do something else......" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            long iResult = funcForNewThreadReturn.Invoke();//block thread

            


            Console.WriteLine("****************btnThread_CallBack_Return_Click End, Result is {2} " +
                              "Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                iResult);
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
            Console.WriteLine(" show the thread is start? ");
            return new Func<T>(()=>
            {
                thread.Join();
                return t;
            });

        }

        private void btnTheadCount_Click(object sender, EventArgs e)
        {
            List<Thread> threads = new List<Thread>();
            for (int i = 0; i < 100; i++)
            {
                if (threads.Count(t => t.ThreadState == ThreadState.Running) < 10)
                {
                    Thread thread = new Thread(()=>{
                        Console.WriteLine("a new thread with ID: "+Thread.CurrentThread.ManagedThreadId);
                    });

                    thread.Start();
                    threads.Add(thread);
                }
                else
                {
                    Thread.Sleep(200);
                }
            }
        }

        private void btnThreadPool_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnThreadPool_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            //wait for new thread complete

            ManualResetEvent mre = new ManualResetEvent(false);

            //all thread pool threads are background thread, //if process stops, thread stops. 
            ThreadPool.QueueUserWorkItem(o =>
                {
                    this.DoSomethingLong("btnThreadPool_Click param: " + o.ToString());
                    mre.Set();// set mre
                },
                "state value");// state will pass to o
            Console.WriteLine("Do something else...."+Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Do something else....");
            Console.WriteLine("Do something else....");
            mre.WaitOne();//wait for thread finish set() in the thread pool




            Console.WriteLine("****************btnThreadPool_Click End, " +
                              "Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void btnThreadPool_MaxMin_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnThreadPool_MaxMin_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));




            ThreadPool.GetMaxThreads(out int workerThreadsMax, out int completionPortThreadsMax);
            Console.WriteLine($"The computer's max workerThreads = {workerThreadsMax} " +
                              $"max completion port threads = {completionPortThreadsMax}");

            ThreadPool.GetMinThreads(out int workerThreadsMin, out int completionPortThreadsMin);
            Console.WriteLine($"The computer's min workerThreads = {workerThreadsMin} " +
                              $"min completion port threads = {completionPortThreadsMin}");

            //the ThreadPool Max and Min value is set for whole process, 
            //will affect Task, Parallel, async/await, they all use ThreadPool
            // new Thread will use thread from the pool, reduce Max threads available.. 
            ThreadPool.SetMaxThreads(5, 5);// the max number must be more than computer's num of processors 

            ThreadPool.SetMinThreads(3, 3);


            ThreadPool.GetMaxThreads(out int workerThreadsMax1, out int completionPortThreadsMax1);
            Console.WriteLine($"The computer's max workerThreads = {workerThreadsMax1} " +
                              $"max completion port threads = {completionPortThreadsMax1}");

            ThreadPool.GetMinThreads(out int workerThreadsMin1, out int completionPortThreadsMin1);
            Console.WriteLine($"The computer's min workerThreads = {workerThreadsMin1} " +
                              $"min completion port threads = {completionPortThreadsMin1}");





            Console.WriteLine("****************btnThreadPool_MaxMin_Click End, " +
                              "Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void btnThreadPoolLock_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnThreadPoolLock_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            ThreadPool.SetMaxThreads(9, 9);
            ManualResetEvent mre = new ManualResetEvent(false);

            int numOfTheadNeedToOpen = 9;
            for (int i = 1; i <= numOfTheadNeedToOpen; i++)
            {
                int k = i;

                ThreadPool.QueueUserWorkItem(t =>
                {
                    Console.WriteLine($"ThreadPool thread ID is: {Thread.CurrentThread.ManagedThreadId.ToString("00")} show k is {k}");
                    if (k == numOfTheadNeedToOpen)//if numOfTheadNeedToOpen > Max Threads in pool, mre will not execute Set(), then lock.
                    {
                        mre.Set();
                    }
                    else
                    {
                        mre.WaitOne();
                    }
                });

            }

            if (mre.WaitOne())
            {
                Console.WriteLine("all tasks completed ....");
            }


            Console.WriteLine("****************btnThreadPoolLock_Click End, " +
                              "Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void btnTask_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnTask_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            
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
                    TaskFactory taskFactory = Task.Factory;
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
                        Console.WriteLine($"This is {k} running" +
                                          $"ThreadId ={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                        Thread.Sleep(2000);
                    });
                }
            }

            Console.WriteLine("****************btnTask_Click End, " +
                              "Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void btnTask_LimitNumOfTasks_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnTask_LimitNumOfTasks_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            HashSet<string> collectAllThreadId = new HashSet<string>();


            //limit num of tasks running.
            List<int> list = new List<int>();
            for (int i = 0; i < 1000; i++)
            {
                list.Add(i);
            }
            //complete 1000 tasks with 11 theads
            Action<int> action = i =>
            {
                
                Console.WriteLine($"action {i} start with thread id: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Thread.Sleep(new Random(i).Next(100,300));
                Console.WriteLine($"action {i} finish with thread id: {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                collectAllThreadId.Add(Thread.CurrentThread.ManagedThreadId.ToString("00"));//collect thread ID
            };
            List<Task> taskList = new List<Task>();

            foreach (var i in list)
            {
                int k = i;
                ////invoke a new thread, can also use a taskfactory.StartNew(), to pass state
                taskList.Add(
                    Task.Run(
                        () => 
                        action.Invoke(k)
                        )
                    );

                if (taskList.Count > 10)
                {
                    Console.WriteLine("there are {0} tasks running in the list, just wait any to finish.",taskList.Count);
                    
                    //task list is full, show all task id
                    StringBuilder sb = new StringBuilder();
                    sb.Append("all running tasks' Task Id : ");
                    foreach (Task t in taskList)
                    {
                        sb.Append(t.Id + ", ");
                    }

                    Console.WriteLine(sb.ToString());


                    //wait any to complete
                    Task.WaitAny(taskList.ToArray());
                    //remove the completed tasks.
                    taskList = taskList.Where(t => t.Status != TaskStatus.RanToCompletion).ToList();
                    Console.WriteLine("some tasks are finished, so now task list have {0} tasks.",taskList.Count);

                    //now check task id again
                    StringBuilder sb2 = new StringBuilder();
                    sb2.Append("anyone finished, now all running task Id : ");
                    foreach (Task t in taskList)
                    {
                        sb2.Append(t.Id + ", ");
                    }

                    Console.WriteLine(sb2.ToString());

                }
            }
            Task.WhenAll(taskList.ToArray());

            //print out all thread id, may exceed 10 because the limitation is set to num of thread at a time. 
            Console.WriteLine(collectAllThreadId.ToArray() +"    "+ collectAllThreadId.Count);
            foreach (string s in collectAllThreadId.OrderBy(s=>s))
            {
                Console.WriteLine("we use thread ids: "+s);
            }

            Console.WriteLine(@"****************btnTask_LimitNumOfTasks_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }



        private void btnTaskDelay_Click(object sender, EventArgs e)
        {
            Console.WriteLine("****************btnTask_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine("before the sleep....");

                Thread.Sleep(2000);//windows freeze 

                Console.WriteLine("after the sleep.....");

                sw.Stop();

                Console.WriteLine($" sleep takes {sw.ElapsedMilliseconds}");
            }
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                Console.WriteLine("before the delay...");

                Task task = Task.Delay(2000).ContinueWith(t =>//new task will not freeze window
                {
                    sw.Stop();
                    Console.WriteLine($"Delay takes {sw.ElapsedMilliseconds}");
                    Console.WriteLine($"this is ThreadId={Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                });

                Console.WriteLine("after the delay.....");

            }

            Console.WriteLine("****************btnTask_Click End, " +
                              "Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));

        }

        private void btnTask_Teach_Proj_Click(object sender, EventArgs e)
        {
            Console.WriteLine(
                @"****************btnTask_Teach_Proj_Click Start, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
            Teach("Professor Adrian", "lesson 1"); //no concurrency, must complete one by one
            Teach("Professor Adrian", "lesson 2");

            Console.WriteLine(@"Now start a project...");

            TaskFactory taskFactory = new TaskFactory();
            List<Task> taskList = new List<Task>();
            taskList.Add(taskFactory.StartNew(o => coding("student1", " Portal "),"async state Protal"));
            taskList.Add(taskFactory.StartNew(o =>coding("student2", " DBA "),"async state DBA" ));
            taskList.Add(taskFactory.StartNew(()=>coding("student3","Backend")));


            //Task.WaitAny(taskList.ToArray()); // if any task complete, do something using main thread. 
            //Console.WriteLine(@"Professor Adrian start to config environment");  // can use ContinueWhenAll
            Task continueTask = taskFactory.ContinueWhenAny(taskList.ToArray(), rArray =>
            {
                Console.WriteLine("AsyncState is : "+rArray.AsyncState);
                
                Console.WriteLine($"one of the Project is finished, current thread ID IS {Thread.CurrentThread.ManagedThreadId.ToString("00")}");
                Console.WriteLine(@"Professor Adrian start to config environment ");
            });//ContinueWhenAny will pick a new thread from the threadpool, maybe the one of the previous thread, may not. But not main thread ID. 

            
            //if you need to wait for callback task finish, just add to taskList
            taskList.Add(continueTask);



            //Task.WaitAll(taskList.ToArray()); //wait until all finished, then can do something with main thread.  
            //
            //do something when all finish
            taskFactory.ContinueWhenAll(taskList.ToArray(), rArray =>
            {
                Console.WriteLine($"Project is FINISHED, current thread ID is {Thread.CurrentThread.ManagedThreadId.ToString("00")}");

                
                //one way of get task result and then do something,but block main thread running the task
                Task<int> res = Task.Run<int>(() => { return 1;} );
                Console.WriteLine(res.Result); 

                //another way of get task result and then do something, not block main thread running the task
                Task toGrade = Task.Run<int>(() => 
                {
                    Thread.Sleep(2000);//will block the thread, will give a score
                    Random r = new Random();
                    return r.Next(50, 100);
                }).ContinueWith(tint =>
                    {
                        int result = tint.Result; 
                        Console.WriteLine(@"Professor Adrian start to review the project, Score is  "+result);
                    });

            });//ContinueWhenAny will pick a new thread from the threadpool, maybe the one of the previous thread, may not. 





            Console.WriteLine(@"****************btnTask_Teach_Proj_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }

        private void Teach(string name,string course)
        {
            Console.WriteLine($"+++++++++++++Tutorial {course} Start by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")}++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }

            Console.WriteLine($"++++++++++++++Tutorial  {course} End by {name}  , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
        }
        private void coding(string name, string prjectName)
        {
            Console.WriteLine($"+++++++++++++{name} is working on project {prjectName} , Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} ++++++++++++");
            long lResult = 0;
            for (int i = 0; i < 1_000_000_000; i++)
            {
                lResult += i;
            }
            Console.WriteLine($"++++++++++++++{name} finish the project {prjectName}, Thread Id is: " +
                              $"{Thread.CurrentThread.ManagedThreadId.ToString("00")} " +
                              $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff")} " +
                              $"result is : {lResult}+++++++++++");
        }


    }
}
