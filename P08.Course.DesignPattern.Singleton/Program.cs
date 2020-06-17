using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            { // test singleton
                Singleton s1 = Singleton.CreateInstance();
                Singleton s2 = Singleton.CreateInstance();
                bool same = object.ReferenceEquals(s1, s2);
            }
            {
                int numOfThread = 5;
                Console.WriteLine("Start {0} thread to create instance", numOfThread);
                for (int i = 0; i < numOfThread; i++)
                {
                    Task.Run(() =>
                    {
                        Singleton s1 = Singleton.CreateInstance();
                        s1.Show();// add 1 to the obj value
                    }).Wait();
                    //Wait()  the calling thread to wait until the current task has completed.
                    //otherwise  the main thread would continue before the task complete 
                    // or you use WaitAll();
                }

                // show result: 
                Singleton.Test();

                int numOfThread2 = 30;
                Thread.Sleep(5000);
                Console.WriteLine("Start another {0} thread to create instance",numOfThread2); 
                
                List<Task> taskList = new List<Task>();
                for (int i = 0; i < numOfThread2; i++)
                {
                    Task t = Task.Run(()=>
                    {
                        Singleton s1 = Singleton.CreateInstance();
                        s1.Show();
                    });

                    taskList.Add(t);
                }

                Task.WaitAll(taskList.ToArray());

                // show result: 
                Singleton.Test();

            }











        }
    }
}
