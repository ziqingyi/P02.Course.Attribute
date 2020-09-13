using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using P22.Course.Crawler.Interface;
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
                #region test for one item
                //{
                //    //1 download the html based on Url. 
                //    string html = HttpHelper.DownloadUrl(category.Url);

                //    //2 HtmlAgilityPack can help to load the html
                //    HtmlDocument document = new HtmlDocument();
                //    document.LoadHtml(html);

                //    //3 select single node or nodes, then analyze it. 
                //    {
                //        //copy the xpath from the web browser. then get node from the path. 
                //        string path = @"//*[@id='brand-11026']/a";
                //        HtmlNode node = document.DocumentNode.SelectSingleNode(path);
                //        string title = node.Attributes["title"].Value;

                //    }
                //    {
                //        //get image link from the page 
                //        string path = @"//*[@id='J_goodsList']/ul/li/div/div[1]/a/img";
                //        HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(path);
                //        foreach (HtmlNode node in nodes)
                //        {
                //            HtmlAttributeCollection attcol = node.Attributes;
                //            string imglink = " https:"+ attcol[3].Value;
                //            Console.WriteLine(imglink);
                //        }
                //    }

                //    {
                //        //get price for one item
                //        string path = @"//*[@id='J_goodsList']/ul/li[1]/div/div[2]/strong/i";
                //        HtmlNode node = document.DocumentNode.SelectSingleNode(path);
                //        string price = node.InnerText;
                //    }
                //    {
                //        //copy the xpath from the web browser. then get nodes from the path. 
                //        string path = "//*[@class=\"J_valueList v-fixed\"]/li";
                //        HtmlNodeCollection nodecollection = document.DocumentNode.SelectNodes(path);
                //        foreach (HtmlNode node in nodecollection)
                //        {
                //            Console.WriteLine(node.Id);
                //        }
                //    }
                //}
                #endregion

                {
                    #region paging: find items in different pages, then get price. 
                    //1 download the html based on Url. 
                    string html = HttpHelper.DownloadUrl(category.Url);

                    //2 HtmlAgilityPack can help to load the html
                    HtmlDocument document = new HtmlDocument();
                    document.LoadHtml(html);

                    //3 get url link
                    string rootUrl = category.Url;

                    //4 find the total pages, larger page number would be last page. 
                    string totalPagePath = @"//*[@id='J_topPage']/span/i";
                    HtmlNode node = document.DocumentNode.SelectSingleNode(totalPagePath);

                    //5 assemble the link with page number 
                    if (node != null)
                    {
                        string sPage = node.InnerText;//get the total page 

                        Regex re = new Regex("[0-9]*");
                        object res = re.Match(sPage);
                        int ipage = int.Parse(res.ToString());
                        for (int i = 1; i <= ipage; i++)
                        {
                            string url = $"{rootUrl}&Page={i}";
                            Console.WriteLine(url);

                            //read every page 
                            this.skuIdList = new List<string>();

                            this.FindCommodityPage(url);

                            this.FindPrice();
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
            catch (Exception ex)
            {
                logger.Error("Crawler mulit exception", ex);
                Console.WriteLine(ex);
            }
        }

        private void FindCommodityPage(string url)
        {
            //use HttpHelper to get html 
            string html = HttpHelper.DownloadUrl(url);

            //method 1: get items by search through the html
            //method 2: locate the items in html and find attributes there. 

            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);

            //locate the items area in html
            string cPath = "//*[@id=\"J_goodsList\"]/ul/li";
            HtmlNodeCollection nodes = document.DocumentNode.SelectNodes(cPath);

            //process each item node
            foreach (HtmlNode node in nodes)
            {
                //node.OuterHtml// including the label like li
                
                FindCommoditySingle(node);
            }
        }


        private List<string> skuIdList = new List<string>();

        private void FindCommoditySingle(HtmlNode node)
        {
            //otherwise load first item each time
            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(node.OuterHtml);
            node = htmlDocument.DocumentNode;

            {
                string namePath = "//*[@class=\"p-name p-name-type-3\"]/a/em";
                //string namePath = "//li/*[@class=\"gl-i-wrap\"]/*[@class=\"p-name p-name-type-3\"]/a/em";
                HtmlNode nameNode = node.SelectSingleNode(namePath);
                string name = nameNode.InnerText;
                Regex pattern = new Regex("[\n\t]");
                name = pattern.Replace( name,"").Substring(0, 20);


                string urlPath = "//*[@class=\"p-name p-name-type-3\"]/a";
                HtmlNode urlNode = node.SelectSingleNode(urlPath);
                string url1 = $"https:{urlNode.Attributes["href"].Value}";

                string pricePath = "//*[@class=\"p-price\"]/strong/i";
                HtmlNode priceNode = node.SelectSingleNode(pricePath);
                string price = priceNode is null ? "": priceNode.InnerText;


                string picturePath = "//*[@class=\"p-img\"]/a/img";
                HtmlNode picNode = node.SelectSingleNode(picturePath);
                //string pictureUrl = $"https:{picNode.Attributes["src"].Value}";

                string pictureUrl = null;
                if (picNode == null)
                {
                    Console.WriteLine("Empty src attribute");
                }
                else if (picNode.Attributes["src"] == null) 
                {
                    pictureUrl = $"https:{picNode.Attributes["data-lazy-img"].Value}";
                }
                else if(picNode.Attributes["src"] != null && picNode.Attributes["src"].Value.ToString().StartsWith("//") )
                {
                    pictureUrl= $"https:{picNode.Attributes["src"].Value}";
                }
                else if (picNode.Attributes["src"] != null && picNode.Attributes["src"].Value.ToString().StartsWith("https"))
                {
                    pictureUrl = $"{picNode.Attributes["src"].Value}";
                }
                else
                {
                    pictureUrl = $"{picNode.Attributes["src"].Value}";
                }

                //get id 
                string skuId = url1.Substring(url1.LastIndexOf('/') + 1).Replace(".html", "");
                skuIdList.Add(skuId);

                string price2 = FindPriceForOne(skuId);

                Console.WriteLine($"                     {DateTime.Now}: {skuId}   {name}: {url1}");
                Console.WriteLine($"                     Price: {price} : {price2} PicUrl: {pictureUrl}");
                Console.WriteLine();
            }


        }


        private void FindPrice()
        {
            var items = this.skuIdList.Select(id =>
                {
                    return "J_" + id;
                }
                );

            var itemUrl = string.Join("%2C",items);

            //Console.WriteLine(itemUrl);

            string url = $"https://p.3.cn/prices/mgets?callback=jQuery7771421&type=1&area=53283_53347_0_0&skuIds="
                         + itemUrl
                         + $"&pdbp=0&pdtk=&pdpin=&pduid=15895467570321140053578&source=search_pc&_=1599965198653";

            string jsonPrice = HttpHelper.DownloadUrl(url);

        }

        //one item one request will take long time
        private string FindPriceForOne(string sku)
        {
            string url = $"https://p.3.cn/prices/mgets?callback=jQuery7771421&type=1&area=53283_53347_0_0&skuIds="
                         + "J_"+sku
                         + $"&pdbp=0&pdtk=&pdpin=&pduid=15895467570321140053578&source=search_pc&_=1599965198653";

            string jsonPrice = HttpHelper.DownloadUrl(url);

            Regex re = new Regex("\"p\":\"[0-9.]+\"");
            string Saleprice = re.Match(jsonPrice).ToString();

            Regex res = new Regex("[0-9.]+");
            string price = res.Match(Saleprice).ToString();

            return price;
        }

    }
}
