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
            #region test singletone 1 

            //{
            //    // test singleton
            //    Singleton s1 = Singleton.CreateInstance();
            //    Singleton s2 = Singleton.CreateInstance();
            //    bool same = object.ReferenceEquals(s1, s2);
            //}
            //{
            //    // test singleton with multi-thread, number of result should same to thread number
            //    int numOfThread = 5;
            //    Console.WriteLine("Start {0} thread to create instance", numOfThread);
            //    for (int i = 0; i < numOfThread; i++)
            //    {
            //        Task.Run(() =>
            //        {
            //            Singleton s1 = Singleton.CreateInstance();
            //            s1.Show();// add 1 to the obj value
            //        }).Wait();
            //        //Wait()  the calling thread to wait until the current task has completed.
            //        //otherwise  the main thread would continue before the task complete 
            //        // or you use WaitAll();
            //    }

            //    // show result: 
            //    Singleton.Test();

            //    int numOfThread2 = 30;
            //    Thread.Sleep(5000);
            //    Console.WriteLine("Start another {0} thread to create instance",numOfThread2); 

            //    List<Task> taskList = new List<Task>();
            //    for (int i = 0; i < numOfThread2; i++)
            //    {
            //        Task t = Task.Run(()=>
            //        {
            //            Singleton s1 = Singleton.CreateInstance();
            //            s1.Show();
            //        });

            //        taskList.Add(t);
            //    }
            //    Task.WaitAll(taskList.ToArray());
            //    // show result: 
            //    Singleton.Test();
            //}
            #endregion

            #region test with prototype, shallow copy and deep copy
            {
                Prototype t1 = (Prototype)Prototype.ShallowClone();

                Prototype t2 = Prototype.DeepCloneWithT();
                t2.p._age = 20;

                Prototype t3 = Prototype.DeepCloneWithSerialize();
                t3.p._age = 10;

                bool compare1 = object.ReferenceEquals(t1, t2);
                bool compare2 = object.ReferenceEquals(t2, t3);
                bool compare3 = object.ReferenceEquals(t1, t3);

                Console.WriteLine("p1 age is : {0}",t1.p._age);//t1 is only shallow clone, so Person's age is changed by ts
                Console.WriteLine("p2 age is : {0}", t2.p._age);
                Console.WriteLine("p3 age is : {0}", t3.p._age);//deep clone, so only change it's own person's age
            }
            #endregion










        }
    }
}
