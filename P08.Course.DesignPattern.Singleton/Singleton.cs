using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    public class Singleton
    {
        //1 Lock( Singleton_Lock ) should be used with volatile, Singleton_Lock must be unique.

        //2 volatile means the field will not be put into cache, only in memory and must read
        //    from memory address, then every access will be the latest one.
        //
        //    volatile will not allow threads to keep it's own cache. 
        //
        //     but still not safe, because different threads can access and change it. 
        //   if there is no volatile, program can put the value in cache and read from cache,
        //   but actually it is changed by some other thread in memory.  so it needs lock
        //
        //3 private static means no other obj or class can access. keep it being shared.

        private static volatile Singleton _singleton;
        private static readonly object Singleton_Lock = new object();

        private Singleton()
        {
            Console.WriteLine("private constructor is being called");
        }

        public Singleton CreateInstance()
        {
            if (_singleton == null)
            {
                lock (Singleton_Lock)// force threads into queue. 
                {
                    if (_singleton == null)
                    {
                        _singleton = new Singleton();
                    }

                }
            }
            return _singleton;
        }


    }
}
