using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using P22.Course.Crawler.Model;
using P22.Course.Crawler.Utility;

namespace P22.Course.Crawler
{
    public class CommoditySearch : ISearch
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

                    {
                        #region paging: 
                        string rootUrl = category.Url;
                        //1 find the total pages, larger page number would be last page. 

                        string totalPagePath = @"//*[@id='J_bottomPage']/span[2]/em";
                        HtmlNode node = document.DocumentNode.SelectSingleNode(totalPagePath);
                        if (node != null)
                        {
                            string sPage = node.InnerText;//get the total page 
                                                          
                            Regex re = new Regex("[0-9]");
                            object res = re.Match(sPage);
                            int ipage = int.Parse(res.ToString());
                            for (int i = 1; i <= ipage; i++)
                            {
                                string url = $"{rootUrl}&Page={i}";
                                Console.WriteLine(url);
                                this.FindCommodityPage(url);
                            }
                        }
                        else
                        {
                            string url = $"{rootUrl}&Page=1";
                            Console.WriteLine(url);
                            this.FindCommodityPage(url);
                        }
                        #endregion
                    }



                }
            }
            catch (Exception ex)
            {
                logger.Error("Crawler mulit exception", ex);
                Console.WriteLine(ex);
            }
        }

        private void FindCommodityPage(string url)
        {

            string html = HttpHelper.DownloadUrl(url);

            //method 1: get items by search through the html
            //method 2: locate the items in html and find attributes there. 

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            string cPath = "//*[@id=\"J_goodsList\"]/ul/li";

            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(cPath);

            foreach (HtmlNode node in nodes)
            {
                //node.OuterHtml// including the label like li
                FindCommoditySingle(node);
            }
        }

        private void FindCommoditySingle(HtmlNode node)
        {
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(node.OuterHtml);
            node = htmlDocument.DocumentNode;

            {

                string namePath = "//*[@class=\"p-name p-name-type-3\"]/a/em";
                HtmlNode nameNode = node.SelectSingleNode(namePath);
                string name = nameNode.InnerText;


                string urlPath = "//*[@class=\"p-name p-name-type-3\"]/a";
                HtmlNode urlNode = node.SelectSingleNode(urlPath);
                string url1 = $"https:{urlNode.Attributes["href"].Value}";


                string picturePath = "//*[@class=\"p-img\"]/a/img";
                HtmlNode picNode = node.SelectSingleNode(picturePath);
                string pictureUrl = $"https:{picNode.Attributes["src"].Value}";

                Console.WriteLine($"{DateTime.Now}: {name}");
                Console.WriteLine($"{DateTime.Now}: {url1}");
                Console.WriteLine($"{DateTime.Now}: {pictureUrl}");
            }


        }




    }
}
