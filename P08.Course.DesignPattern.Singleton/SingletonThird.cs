using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    public class SingletonThird
    {
        // using static field, instance is being created earlier than static constructor. 
        private static SingletonThird _singletonThird = new SingletonThird();
        private SingletonThird()
        {
            long _lResult = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                _lResult++;
            }
            Thread.Sleep(1000);
            Console.WriteLine("{0} is being created, _lResult is {1} ", this.GetType().Name, _lResult);
        }

        public static SingletonThird CreateInstance()
        {
            return _singletonThird;
        }

        public void Show()
        {
            Console.WriteLine("this is show for type: {0}",this.GetType().Name);
        }




    }
}
