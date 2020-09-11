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
                    #region find first level and second level and third level

                    //find all large categories
                    string firstPath = "//*[@class='category-item m']";
                    HtmlNodeCollection CategoryNode = document.DocumentNode.SelectNodes(firstPath);
                    if (CategoryNode != null)
                    {
                        //iterate all the categories 
                        foreach (HtmlNode node1 in CategoryNode)
                        {
                            
                            //reload parts of html, for a large category, eg book, videos etc....
                            string firstHtml = node1.OuterHtml;
                            //use xpath to find second level
                            HtmlDocument documentChild1 = new HtmlDocument();
                            documentChild1.LoadHtml(firstHtml);


                            //find the category's topic first
                            string topicPath = "//*[@class='category-item m']/*[@class='mt']/*[@class='item-title']/span";
                            HtmlNode topic = documentChild1.DocumentNode.SelectSingleNode(topicPath);
                            Console.WriteLine($"-----------------------------------------{topic.InnerText}--------------------------------------------");




                            //find parts of line, including category and small categories
                            string secondPath = "//*[@class='clearfix']";
                            HtmlNodeCollection nodeList2 = documentChild1.DocumentNode.SelectNodes(secondPath);
                            if (nodeList2 != null)
                            {
                                //iterate the lines 
                                foreach (HtmlNode node2 in nodeList2)
                                {
                                    //reload the line html
                                    string secondHtml = node2.OuterHtml;
                                    HtmlDocument documentChild2 = new HtmlDocument();
                                    documentChild2.LoadHtml(secondHtml);


                                    string thirdPath1 = "//dt/a";
                                    HtmlNodeCollection nodeList31 = documentChild2.DocumentNode.SelectNodes(thirdPath1);
                                    if (nodeList31 != null)
                                    {
                                        foreach (HtmlNode node in nodeList31)
                                        {
                                            string url3 = node.Attributes["href"].Value;
                                            string name3 = node.InnerText;
                                            logger.Info($"{name3}: https:{url3}");
                                        }
                                    }


                                    string thirdPath2 = "//dd/a";
                                    HtmlNodeCollection nodeList32 = documentChild2.DocumentNode.SelectNodes(thirdPath2);
                                    if (nodeList32 != null)
                                    {
                                        foreach (HtmlNode node in nodeList32)
                                        {
                                            string url3 = node.Attributes["href"].Value;
                                            string name3 = node.InnerText;
                                            logger.Info($"            {name3}: https:{url3}");
                                        }
                                    }

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
