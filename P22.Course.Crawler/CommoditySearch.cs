using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using P22.Course.Crawler.Model;
using P22.Course.Crawler.Utility;

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
                string html = HttpHelper.DownloadUrl(category.Url);
                {
                    //HtmlAgilityPack can help to load the html
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);


                    {
                        //copy the xpath from the web browser. then get node from the path. 
                        string path = @"//*[@id='brand-11026']/a";
                        HtmlNode node = document.DocumentNode.SelectSingleNode(path);
                        string title = node.Attributes["title"].Value;

                    }
                    {
                        //copy the xpath from the web browser. then get nodes from the path. 
                        string path = "//*[@class=\"J_valueList v-fixed\"]/li";
                        HtmlNodeCollection nodecollection = document.DocumentNode.SelectNodes(path);
                        foreach (HtmlNode node in nodecollection)
                        {
                            Console.WriteLine(node.Id);
                        }
                    }



                }
                







            }
            catch (Exception ex)
            {
                logger.Error("Crawler mulit exception",ex);
                Console.WriteLine(ex);
                
            }























        }







    }
}
