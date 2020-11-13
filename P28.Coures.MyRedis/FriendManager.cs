using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Service;

namespace P28.Coures.MyRedis
{
    public class FriendManager
    {

        public static void Show()
        {
            //set will remove duplicates, eg. voting IP, like button, friend application. 
            using (RedisSetService service = new RedisSetService())
            {
                service.FlushAll();
                service.Add("Eleven","Alex");
                service.Add("Eleven", "Cecil");
                service.Add("Eleven", "Calvin");
                service.Add("Eleven", "Dell");
                service.Add("Eleven", "Dina");
                service.Add("Eleven", "Dina");//duplicates, removed automatically. 


                service.Add("Powell", "Eleven");
                service.Add("Powell", "Cecil");
                service.Add("Powell", "Durga");
                service.Add("Powell", "Eddy");
                service.Add("Powell", "Eliza");

                HashSet<string> intersect = service.GetIntersectFromSets("Eleven", "Powell");

                HashSet<string> differences1 = service.GetDifferencesFromSet("Eleven", "Powell");//param1 has but not in param2

                HashSet<string> differences2 = service.GetDifferencesFromSet("Powell","Eleven");

                HashSet<string> union = service.GetUnionFromSets("Eleven", "Powell");


            }


        }


    }
}
