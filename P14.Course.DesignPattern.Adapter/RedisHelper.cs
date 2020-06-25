using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P14.Course.DesignPattern.Adapter
{
    public class RedisHelper
    {
        public RedisHelper()
        {
            Console.WriteLine($" RedisHelper Constructor");
        }
        public void AddRedis<T>()
        {
            Console.WriteLine("This is {0} Add", this.GetType().Name);
        }
        public void DeleteRedis<T>()
        {
            Console.WriteLine("This is {0} Delete", this.GetType().Name);
        }
        public void UpdateRedis<T>()
        {
            Console.WriteLine("This is {0} Update", this.GetType().Name);
        }
        public void QueryRedis<T>()
        {
            Console.WriteLine("This is {0} Query", this.GetType().Name);
        }
    }
}
