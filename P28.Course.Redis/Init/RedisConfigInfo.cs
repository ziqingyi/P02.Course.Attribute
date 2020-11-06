using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P28.Course.Redis.Init
{
    public sealed class RedisConfigInfo
    {

        public string WriteServerList = "127.0.0.1:6379";

        public string ReadServerList = "127.0.0.1:6379";


        public int MaxWritePoolSize = 60;

        public int MaxReadPoolSize = 60;

        //local cache expire time
        public int LocalCacheTime = 180;

        public bool AutoStart = true;

        //use to check error, if working well, set to false.
        public bool RecordLog = false;


    }
}
