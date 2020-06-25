using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P14.Course.DesignPattern.Adapter
{
    public class RedisHelperInherit: RedisHelper,IHelper
    {
        public RedisHelperInherit()
        {
            Console.WriteLine($"Construct {this.GetType().Name}");
        }

        public void Add<T>()
        {
            base.AddRedis<T>();
        }

        public void Delete<T>()
        {
            base.DeleteRedis<T>();
        }

        public void Update<T>()
        {
            base.UpdateRedis<T>();
        }

        public void Query<T>()
        {
            base.QueryRedis<T>();
        }
    }
}
