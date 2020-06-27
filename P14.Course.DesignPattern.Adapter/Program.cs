using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P14.Course.DesignPattern.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                Console.WriteLine("**************************");
                IHelper helper = new SqlserverHelper();
                helper.Add<Item>();
                helper.Delete<Item>();
                helper.Update<Item>();
                helper.Query<Item>();
            }
            {
                Console.WriteLine("**************************");
                IHelper helper = new MySqlHelper();
                helper.Add<Item>();
                helper.Delete<Item>();
                helper.Update<Item>();
                helper.Query<Item>();
            }
            {
                Console.WriteLine("*********business old logic*************");
                RedisHelper oldRedisHelper = new RedisHelper();
                oldRedisHelper.AddRedis<Item>();
                oldRedisHelper.DeleteRedis<Item>();
                oldRedisHelper.QueryRedis<Item>();
                oldRedisHelper.UpdateRedis<Item>();
            }
            {
                Console.WriteLine("************************************");
                Console.WriteLine("new redis helper through Inherit, adjust new way of calling");
                IHelper helper = new RedisHelperInherit();
                helper.Delete<Item>();
                helper.Add<Item>();
                helper.Update<Item>();
                helper.Query<Item>();
                //still have the base class method
                RedisHelperInherit InheritHelper = new RedisHelperInherit();
                InheritHelper.AddRedis<Item>();
            }
            {
                Console.WriteLine("*****************************");
                Console.WriteLine("new redis helper through Encapsulation, better than inherit ");
                IHelper helper = new RedisHelperObject();
                helper.Delete<Item>();
                helper.Add<Item>();
                helper.Update<Item>();
                helper.Query<Item>();
            }

        }
    }
}
