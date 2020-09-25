using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P20.Course.AwaitAsyncConsole
{
    public class AwaitAsync_Illustrate
    {

        public static void Run()
        {
            MyDownloadString ds = new MyDownloadString();
            ds.DoRun();

        }
    }


    class MyDownloadString
    {
        Stopwatch sw = new Stopwatch();

        public void DoRun()
        {
            const int LargeNumber = 6000000;
            sw.Start();

            Task<int> t1 = CountCharacterAsync(1, "https://www.microsoft.com/en-au/");

            Task<int> t2 = CountCharacterAsync(2, "http://www.illustratedcsharp.com/");

            CountToALargeNumber(1, LargeNumber);
            CountToALargeNumber(2, LargeNumber);
            CountToALargeNumber(3,LargeNumber);
            CountToALargeNumber(4, LargeNumber);

            Console.WriteLine("Chars in https://www.microsoft.com/en-au/ : {0}", t1.Result );
            Console.WriteLine("Chars in http://www.illustratedcsharp.com/ : {0}", t2.Result);

        }

        private  async Task<int> CountCharacterAsync(int id, string site)
        {
            WebClient wc = new WebClient();
            Console.WriteLine("starting call {0} : {1, 4:N} ms {2}", id, sw.Elapsed.TotalMilliseconds, Thread.CurrentThread.ManagedThreadId.ToString());

            string result = await wc.DownloadStringTaskAsync(new Uri(site));

            Console.WriteLine("call {0} completed : {1, 4:N} ms {2}", id, sw.Elapsed.TotalMilliseconds, Thread.CurrentThread.ManagedThreadId.ToString());

            return result.Length;
        }


        private void CountToALargeNumber(int id, int value)
        {
            for (long i = 0; i < value; i++) 
                ;
            Console.WriteLine("End counting {0} : {1, 4:N} ms", id, sw.Elapsed.TotalMilliseconds);

        }









    }



}
