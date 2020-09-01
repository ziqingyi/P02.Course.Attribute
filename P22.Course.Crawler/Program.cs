using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
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
