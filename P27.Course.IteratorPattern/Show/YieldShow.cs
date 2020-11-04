using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.Show
{
    public class YieldShow
    {
        public IEnumerable<int> CreateEnumerable()
        {
            try
            {
                Console.WriteLine("CreateEnumerable() method begin {0}", DateTime.Now);
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine("{0} start yield {1}", DateTime.Now,i);
                    yield return i;
                    Console.WriteLine("{0} yield end", DateTime.Now);

                    if (i == 4)
                    {
                        yield break;
                    }
                }
                Console.WriteLine("{0} yield with last value", DateTime.Now);

                yield return -1;

                Console.WriteLine("CreateEnumerable() method End {0}", DateTime.Now);
            }
            finally
            {
                Console.WriteLine("iterate stops");
                
            }
        }


        public void Show()
        {
            IEnumerable<int> iterable = this.CreateEnumerable();//1 will not execute immediately.
            IEnumerator<int> iterator = iterable.GetEnumerator();

            Console.WriteLine("begin iterator....");

            while (true)
            {
                Console.WriteLine("call MoveNext() method....");
                Boolean result = iterator.MoveNext();//2 begin CreateEnumerable() method
                Console.WriteLine("MoveNext() method return {0}", result);

                if (!result)
                {
                    break;
                }

                Console.WriteLine("getting current value...");
                Console.WriteLine("Current value is {0}",iterator.Current);

            }

            Console.ReadKey();

        }







    }
}
