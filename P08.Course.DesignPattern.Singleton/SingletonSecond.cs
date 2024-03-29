﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    public class SingletonSecond
    {
        private static SingletonSecond _singletonSecond = null;

        static SingletonSecond()
        {
            _singletonSecond = new SingletonSecond();
            Console.WriteLine("static constructor create instance...");
        }

        private SingletonSecond()
        {
            long _lResult = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                _lResult++;
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0} is being created, _lResult is {1} ", this.GetType().Name, _lResult);
        }

        public SingletonSecond CreateInstancePrototype()
        {
            SingletonSecond second = (SingletonSecond)_singletonSecond.MemberwiseClone();
            return second;
        }




    }
}
