using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using P01.Course.DB.Interface;
using P01.Course.DB.SqlServer;

namespace P01.Course.Reflection
{
    public class Monitor
    {
        public static void Show()
        {
            Console.WriteLine("*******************Monitor, compare two ways of creating method*******************");
            long commonTime = 0;
            long reflectionTime = 0;
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < 1000000; i++)
                {
                    IDBHelper iDbHelper = new SqlServerHelper();
                    // for simple, please remove the Console.WriteLine() in the constructor
                    iDbHelper.Query();
                }

                sw.Stop();
                commonTime = sw.ElapsedMilliseconds;
            }
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                for (int i = 0; i < 1_000_000; i++)
                {
                    Assembly assembly = Assembly.Load("P01.Course.DB.SqlServer");
                    Type t = assembly.GetType("P01.Course.DB.SqlServer.SqlServerHelper");
                    object o = Activator.CreateInstance(t);
                    IDBHelper dbHelper = (IDBHelper) o;
                    dbHelper.Query();
                }

                sw.Stop();
                reflectionTime = sw.ElapsedMilliseconds;

            }

            Console.WriteLine("commonTime={0} reflectionTime={1}", commonTime, reflectionTime);

        }



    }
}
