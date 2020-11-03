using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P27.Course.DataStructure
{
    //Yield is syntactic sugar, compiler will generate Iterator code,
    //including movenext, current, reset.
    public class YieldDemo
    {
        public IEnumerable<int> Power()
        {
            for (int i = 0; i < 10; i++)
            {
                int res = this.Get(i);
                Console.WriteLine("Power result is " +res);
                yield return res;
            }
        }

        public IEnumerable<int> Common()
        {
            List<int> intList = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                intList.Add(this.Get(i));
            }

            return intList;
        }


        public int Get(int num)
        {
            Thread.Sleep(1000);
            return num * DateTime.Now.Second;
        }
    }

    public static class ExtendMethod
    {
        public static IEnumerable<T> ExtendWhere<T>(this IEnumerable<T> source, Func<T, bool> func)
        {
            if (source == null)
            {
                throw new Exception("source is null");
            }

            if (func == null)
            {
                throw new Exception("func is null");
            }

            foreach (T item in source)
            {
                if (func.Invoke(item))
                {
                    yield return item;
                }
            }

        }
    }














}
