using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P14.Course.DesignPattern.Adapter
{
    public class RedisHelperObject : IHelper
    {
        public RedisHelperObject()
        {
            Console.WriteLine($"Construct {this.GetType().Name}");
        }
        private RedisHelper _redisHelper = new RedisHelper();//method1: must have old logic as instance

        //method2: may be initialized in this way,not guarantee.
        //but can pass a derived class instance
        public RedisHelperObject(RedisHelper redisHelper)
        {
            this._redisHelper = redisHelper;
        }
        //method 3: inject through method, may not be executed. 
        public void SetObject(RedisHelper redisHelper)
        {
            this._redisHelper = redisHelper;
        }


        public void Add<T>()
        {
            this._redisHelper.AddRedis<T>();
        }

        public void Delete<T>()
        {
            this._redisHelper.DeleteRedis<T>();
        }

        public void Query<T>()
        {
            this._redisHelper.QueryRedis<T>();
        }

        public void Update<T>()
        {
            this._redisHelper.UpdateRedis<T>();
        }


    }
}
