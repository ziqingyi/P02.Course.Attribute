﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P01.Course.Generic.Extend
{
    public class GenericCacheTest
    {
        public static void Show()
        {
            var ii = 3;
            Console.WriteLine(ii);
            List<Birdt> bb= new List<Birdt>(5);
            for (int i = 0; i < 5; i++)
            {
                Birdt a = new Birdt();
                a.name = i.ToString();
                bb.Add(a);
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<int>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<long>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<DateTime>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<string>.GetCache());
                Thread.Sleep(10);
                Console.WriteLine(GenericCache<GenericCacheTest>.GetCache());
                Thread.Sleep(10);
            }

        }

    }



    class GenericCache<T>
    {
        private static string _type="";
        static GenericCache()
        {
            Console.WriteLine("This is Generic Cache");
            _type = string.Format("{0}_{1}", typeof(T).FullName, DateTime.Now);
        }

        public static string GetCache()
        {
            return _type;
        }
        
    }

    class Birdt
    {
        public string name = "";
    }
        

}
