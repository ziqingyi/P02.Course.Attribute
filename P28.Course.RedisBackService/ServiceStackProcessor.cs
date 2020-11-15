using P28.Course.Redis.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ServiceStack.Redis;

namespace P28.Course.RedisBackService
{
    public class ServiceStackProcessor
    {
        public static void Show()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string tag = path.Split('/', '\\').Last(s => !string.IsNullOrEmpty(s));
            Console.WriteLine($"{tag} start to execute....");
            using (RedisListService service = new RedisListService())
            {
                Action act = new Action(() =>
                {
                    while (true)
                    {
                        string[] keys = new string[]{"test", "task"};
                        ItemRef result = service.BlockingPopItemFromLists(keys, TimeSpan.FromHours(3));

                        Thread.Sleep(100);

                        Console.WriteLine($"this is {tag} is receiving message {result.Id} {result.Item}");
                    }
                });

                act.EndInvoke(act.BeginInvoke(null,null));
            }

        }
    }
}
