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
                Name = "Aaron Pena",
                Account = "Administrator",
                Address="sydney, NSW",
                Email = "xxxx@gmail.com",
                Password = "2341231",
                QQ=555666777
            };

            //keep UserInfo class object in Redis
            using (RedisStringService service = new RedisStringService())
            {
                service.FlushAll();

                string key = $"userinfo_{user.Id}_string1";

                service.Set<UserInfo>(key, user);

                List<UserInfo> userCacheList = service.Get<UserInfo>(new List<string>(){ key });

                UserInfo userCache = userCacheList.FirstOrDefault();

                userCache.Account = "Admin_RedisObj";//change some field, and save again

                service.Set<UserInfo>(key, userCache);
            }

            // serialize object and store in redis.  deserialize object from redis
            using (RedisStringService service = new RedisStringService())
            {
                string key = $"userinfo_{user.Id}_string_ser";


                string serializedObject = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                service.Set<string>(key, serializedObject);

                List<string> userCacheList = service.Get<string>(new List<string>(){key});
                string SerializedUser = userCacheList.FirstOrDefault();

                UserInfo userCache = Newtonsoft.Json.JsonConvert.DeserializeObject<UserInfo>(SerializedUser);
                userCache.Account = "Admin_RedisSerialize";//change some field, and save again


                string newSerializeObject = Newtonsoft.Json.JsonConvert.SerializeObject(userCache);
                service.Set<string>(key, newSerializeObject);

            }

            //using redis hash, save more space and easy to modify. 
            using (RedisHashService service = new RedisHashService())
            {
                string key = $"userinfo_{user.Id}_hash";
                //service.FlushAll();
                service.SetEntryInHash(key, "Name", user.Name);
                service.SetEntryInHash(key, "Account", user.Account);
                service.SetEntryInHash(key, "Password", user.Password);
                service.SetEntryInHash(key, "Email", user.Email);
                service.SetEntryInHash(key, "Address", user.Address);
                service.SetEntryInHash(key, "QQ", user.QQ.ToString());

                //update directly, no need to get and set.
                service.SetEntryInHash(key, "Name", "Abby Tan"); 


                service.StoreAsHash<UserInfo>(user);//must have id
                UserInfo userInfo1 = service.GetFromHash<UserInfo>(user.Id);
            }

            UserInfo user2 = new UserInfo()
            {
                Id = 2,
                Name = "Tom Pena",
                Account = "Administrator",
                Address = "sydney, NSW",
                Email = "xxxx@gmail.com",
                Password = "2341231",
                QQ = 555666777
            };

            //test redis hash with different field, add remark

            using (RedisHashService service = new RedisHashService())
            {
                string key = $"userinfo_{user2.Id}_hash_newField";
                service.SetEntryInHash(key, "Name", user2.Name);
                service.SetEntryInHash(key, "Account", user2.Account);
                service.SetEntryInHash(key, "Password", user2.Password);
                service.SetEntryInHash(key, "Email", user2.Email);
                service.SetEntryInHash(key, "Remark", user2.Address);

                service.StoreAsHash<UserInfo>(user2);
                UserInfo userInfo2 = service.GetFromHash<UserInfo>(user2.Id);

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
