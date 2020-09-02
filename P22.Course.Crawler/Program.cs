using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using P22.Course.Crawler.Model;
using P22.Course.Crawler.Utility;

namespace P22.Course.Crawler
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("-------------------Crawler Start-----------------------------");

                #region test DownloadHTML

                {
                    string html = HttpHelper.DownloadHtml(@"https://hairbeauty.livingstone.com.au/",Encoding.UTF8);
                }
                #endregion

                #region test getting product list
                {
                    string testCategory="{\"Id\":73,\"Code\":\"02f01s01T\",\"ParentCode\":\"02f01s\",\"Name\":\"烟机/灶具\",\"Url\":\"http://list.jd.com/list.html?cat=737,13297,1300\",\"Level\":3}";
                    
                    Category category = JsonConvert.DeserializeObject<Category>(testCategory);

                    ISearch search = new CommoditySearch(category);

                    search.Crawler();

                }
                #endregion



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.ReadLine();
        }





    }
}
