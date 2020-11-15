using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Service;

namespace P28.Coures.MyRedis
{
    public class BlogPageList
    {
        public static void Show()
        {
            using (RedisListService service = new RedisListService())
            {
                //use rpush to put new passage on right, so latest one on top.
                //service.RPush("newBlog", "Id001_Topic1");
                service.FlushAll();
                for (int i = 0; i < 200; i++)
                {
                    string blogIDName = "Id" + i.ToString("000") + "_Topic" + i;
                    service.RPush("newBlog", blogIDName);
                }


                //only keep latest few passage, remove the first few
                service.TrimList("newBlog",0,100);//max: 2^32

                //paging, 20 per page
                List<string> page1 =  service.Get("newBlog", 0, 20);

                List<string> page2 = service.Get("newBlog", 21, 40);

                //eg. only show first 7 pages, if user click 7, then calculate remaining num of pages.
                //    because calculating total pages will take time. 


            }


        }







    }
}
