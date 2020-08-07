﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                ThreadStart method = () => this.DoSomethingLong("btnThread_Click");
                Thread thread = new Thread(method);
                thread.Start();//start a thread to run the delegate 
                //thread.Suspend();//may not suspend immediately , deprecated
                //thread.Resume(); //deprecated
                //thread.Abort();  //rarely used
                //Thread.ResetAbort();//rarely used



            }
            {
                ParameterizedThreadStart method = o => this.DoSomethingLong(o.ToString() + "btnThread_Click");
                Thread thread = new Thread(method);
                thread.Start(123);
            }







            Console.WriteLine("****************btnThread_Click End, Thread Id is: {0} Now:{1}***************",
                Thread.CurrentThread.ManagedThreadId.ToString("00"),
                DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff"));
        }
    }
}
