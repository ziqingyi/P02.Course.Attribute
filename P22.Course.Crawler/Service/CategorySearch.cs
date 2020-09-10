using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using P22.Course.Crawler.Interface;
using P22.Course.Crawler.Utility;

namespace P22.Course.Crawler.Service
{
    public class CategorySearch: ISearch
    {
        private Logger logger = new Logger(typeof(CategorySearch));

        public void Crawler()
        {
            string html = HttpHelper.DownloadHtml("https://www.jd.com/allSort.aspx", Encoding.UTF8);

            if (string.IsNullOrEmpty(html))
            {
                logger.Info("empty html from HttpHelper.DownloadHtml()");
            }
            else
            {
                HtmlDocument document = new HtmlDocument();
                document.LoadHtml(html);
                
                //{
                //    #region all the second level link 

                //    string secondPath = "//dl/dt/a";
                //    HtmlNodeCollection nodeList = document.DocumentNode.SelectNodes(secondPath);
                //    if (nodeList != null)
                //    {
                //        foreach (HtmlNode node in nodeList)
                //        {
                //            string url = node.Attributes["href"].Value;
                //            string name = node.InnerText;
                //            logger.Info($"{name}:{url}");
                //        }
                //    }
                //    #endregion
                //}

                //{
                //    #region all the third level link 
                //    string thirdPath = "//dl/dd/a";
                //    HtmlNodeCollection nodeList = document.DocumentNode.SelectNodes(thirdPath);
                //    if (nodeList != null)
                //    {
                //        foreach (HtmlNode node in nodeList)
                //        {
                //            string url = node.Attributes["href"].Value;
                //            string name = node.InnerText;
                //            logger.Info($"{name}:{url}");
                //        }
                //    }
                //    #endregion
                //}
                {
                    #region find first level and second level

                    string firstPath = "//*[@class='category - item m']";
                    HtmlNodeCollection nodeList1 = document.DocumentNode.SelectNodes(firstPath);
                    if (nodeList1 != null)
                    {
                        foreach (HtmlNode node1 in nodeList1)
                        {
                            //find parts of html
                            string firstHtml = node1.OuterHtml;
                            //use xpath to find second level
                            HtmlDocument documentChild = new HtmlDocument();
                            documentChild.LoadHtml(firstHtml);


                            string secondPath = "//dl/dt/a";
                            HtmlNodeCollection nodeList2 = documentChild.DocumentNode.SelectNodes(secondPath);
                            if (nodeList2 != null)
                            {
                                foreach (HtmlNode node2 in nodeList2)
                                {
                                    string url = node2.Attributes["href"].Value;
                                    string name = node2.InnerText;
                                    logger.Info($"{name}:{url}");
                                }
                            }





                        }


                    }




                    #endregion

                }





            }


        }
    }
}
