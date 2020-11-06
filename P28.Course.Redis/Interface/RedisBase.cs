using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P28.Course.Redis.Interface
{
    public abstract class RedisBase:IDisposable
    {
        public IRedisClient iClient { get; private set; }

        public RedisBase()
        {
            iClient = RedisManager
        }





    }
}
