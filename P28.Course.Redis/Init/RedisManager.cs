﻿using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P28.Course.Redis.Init
{
    public class RedisManager
    {
        //config file 
        private static RedisConfigInfo redisConfigInfo = new RedisConfigInfo();

        //client pool
        private static PooledRedisClientManager prcManager;

        //test RedisNativeClient
        RedisNativeClient rnc = new RedisNativeClient();

        //static method, init pool redis client manager
        static RedisManager()
        {
            CreateManager();
        }

        private static void CreateManager()
        {
            string[] WriteServerConStr = redisConfigInfo.WriteServerList.Split(',');
            string[] ReadServerConStr = redisConfigInfo.ReadServerList.Split(',');

            RedisClientManagerConfig rcmc = new RedisClientManagerConfig()
            {
                MaxWritePoolSize = redisConfigInfo.MaxWritePoolSize,
                MaxReadPoolSize = redisConfigInfo.MaxReadPoolSize,
                AutoStart =  redisConfigInfo.AutoStart
            };

            prcManager=new PooledRedisClientManager(ReadServerConStr,WriteServerConStr,rcmc);
        }

        //get Client from pool redis client manager
        public static IRedisClient GetClient()
        {
            IRedisClient irc = prcManager.GetClient();
            return irc;
        }
        

    }
}
