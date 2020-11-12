using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Service;

namespace P28.Coures.MyRedis
{
    public class UserInfoTest
    {
        public static void Show()
        {
            UserInfo user = new UserInfo()
            {
                Id=1,
                Account = "Administrator",
                Address="sydney, NSW",
                Email = "xxxx@gmail.com",
                Password = "2341231",
                QQ=555666777
            };

            //keep UserInfo class object in Redis
            using (RedisStringService service = new RedisStringService())
            {
                string key = $"userinfo_{user.Id}";

                service.Set<UserInfo>(key, user);

                List<UserInfo> userCacheList = service.Get<UserInfo>(new List<string>(){ key });

                UserInfo userCache = userCacheList.FirstOrDefault();

                userCache.Account = "Admin_RedisObj";

                service.Set<UserInfo>(key, userCache);
            }

            // serialize object and store in redis.  deserialize object from redis
            using (RedisStringService service = new RedisStringService())
            {
                string key = $"userinfo_{user.Id}";


                string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                service.Set<string>(key, serializedObject);

                List<string> userCacheList = service.Get<string>(new List<string>(){key});
                string SerializedUser = userCacheList.FirstOrDefault();

                UserInfo userCache = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(SerializedUser);
                userCache.Account = "Admin_RedisSerialize";


                string newSerializeObject = Newtonsoft.Json.JsonConvert.SerializeObject(userCache);
                service.Set<string>(key, newSerializeObject);

            }













        }



    }
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public long QQ { get; set; }
    }
}
