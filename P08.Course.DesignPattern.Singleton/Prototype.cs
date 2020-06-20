using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    public class Prototype
    {
        //copy object from memory and then return new object, but not created from new()

        //private constructor, consume resource when creating
        private Prototype()
        {
            long iResult = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                iResult += 1;
            }
            Thread.Sleep(2000);
            Console.WriteLine("private constructor is being called for {0}, iResult is: {1}",
                this.GetType().Name, iResult);
        }

        // unique static instance
        private static volatile Prototype _prototype = new Prototype();

        //public method to provide new obj based on one obj
        public static Prototype CreateInstance()
        {
            Prototype prototype = (Prototype)_prototype.MemberwiseClone();
            return prototype;
        }





    }
}
