using System;
using System.Collections.Generic;
using System.Linq;
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
                Console.WriteLine("Start 5 thread to create instance");
                for (int i = 0; i < 5; i++)
                {
                    Task.Run(() =>
                    {
                        Singleton s1 = Singleton.CreateInstance();
                        s1.Show();
                    });
                }

                Thread.Sleep(5000);
                Console.WriteLine("Start another 5 thread to create instance");
                for (int i = 0; i < 5; i++)
                {
                    Task.Run(() =>
                    {
                        Singleton s1 = Singleton.CreateInstance();
                        s1.Show();
                    });
                }

                // show result: 
                Singleton.Test();
            }











        }
    }
}
