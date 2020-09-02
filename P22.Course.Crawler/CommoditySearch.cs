using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P22.Course.Crawler.Model;
using P22.Course.Crawler.Utility;
using HtmlAgilityPack;



namespace P22.Course.Crawler
{
    public class CommoditySearch: ISearch
    {
        private Logger logger = new Logger(typeof(CommoditySearch));

        private Category category = null;

        public CommoditySearch(Category _category)
        {
            category = _category;
        }

        public void Crawler()
        {
            try
            {


                //if category.Url is not null
                string html = HttpHelper.DownloadUrl(category.Url);
                {
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);
                    {
                        string path;


                    }


                }









            }
            catch (Exception ex)
            {
                logger.Error("CrawlerMuti Exception", ex);
            }


        }






    }
}
