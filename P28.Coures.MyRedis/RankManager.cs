using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using P28.Course.Redis.Service;

namespace P28.Coures.MyRedis
{
    public class RankManager
    {

        private static List<string> userList = new List<string>()
        {
            "Player1", "Player2","Player3","Player4","Player5","Player5"
        };

        public static void Show()
        {
            using (RedisZSetService service = new RedisZSetService())
            {
                service.FlushAll();

                Task.Run(() =>
                {
                    while (true)
                    {
                        foreach (string user in userList)
                        {
                            Thread.Sleep(10);

                            //increase the value, not replace. 
                            service.IncrementItemInSortedSet("Star", user, new Random().Next(1, 100));
                        }

                        Thread.Sleep(5 * 1000);
                    }
                });

                Task.Run(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(6 * 1000);
                        Console.WriteLine("**************Rank****************");
                        int i = 1;

                        //foreach (string s in service.GetAllDesc("Star"))
                        //{
                        //    Console.WriteLine($"#{i++}   {s}");
                        //}

                        foreach (KeyValuePair<string, double> s in service.GetAllWithScoresFromSortedSet("Star"))
                        {
                            Console.WriteLine($"#{i++}   {s.Key}  Score: {s.Value}");
                        }
                    }
                }); 
                
                Console.ReadKey();
            }

            
        }

    }
}
