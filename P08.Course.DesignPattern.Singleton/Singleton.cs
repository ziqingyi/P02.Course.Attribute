﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    public class Singleton
    {
        //1 Lock( Singleton_Lock ) should be used with volatile, Singleton_Lock must be unique.

        //2 volatile means the field will not be put into cache, only in memory and must read
        //    from memory address, then every access will be the latest one.(may not efficient)
        //
        //    volatile will not allow threads to keep it's own cache. 
        //     not optimize by compiler.
        // (i think if every thread has copy,after computation, it will release lock before copying back to memory )
        //
        //     but still not safe, because different threads can access and change it. 
        //   if there is no volatile, program can put the value in cache and read from cache,
        //   but actually it is changed by some other thread in memory.  so it needs lock
        //
        //3 private static means no other obj or class can access. keep it being shared.

        private static volatile Singleton _singleton = null;
        private static readonly object Singleton_Lock = new object();//private: no other can modify

        private Singleton()
        {
            long iResult = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                iResult += 1;
            }
            Thread.Sleep(2000);
            Console.WriteLine("private constructor is being called for {0}, iResult is: {1}",
                this.GetType().Name,iResult );
        }

        public static Singleton CreateInstance()
        {
            if (_singleton == null)
            {
                lock (Singleton_Lock)// force threads into queue. So don't lock to much code. 
                {
                    if (_singleton == null)//only initialise once. 
                    {
                        _singleton = new Singleton();
                    }

                }
            }
            return _singleton;
        }

        #region test thread safety

        public volatile int iTotal = 0;

        public void Show()
        {
            lock (Singleton_Lock)
            {
                this.iTotal++;
            }
        }

        public static void Test()
        {
            Console.WriteLine("Test iTotal is : " + _singleton.iTotal);
        }

        #endregion




    }
}
