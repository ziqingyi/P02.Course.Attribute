using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace P22.Course.Crawler.Utility
{
    public class HttpHelper
    {
        //note down the class name , static: because other methods are static.
        private static Logger logger = new Logger(typeof(HttpHelper));

        public static string DownloadUrl(string url)
        {
            return DownloadHtml(url,Encoding.UTF8);
        }

        public static string DownloadHtml(string url, Encoding encoding)
        {
            string html = string.Empty;
            try
            {
                logger.Info($"start to download {url}");
                HttpWebRequest request = HttpWebRequest.Create(url) as HttpWebRequest;
                request.Timeout = 30 * 1000;
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/84.0.4147.135 Safari/537.36";
                request.ContentType = "text/html; charset=utf-8";


                //add more to the Headers to make the full request,but make sure it's correct. 
                //request.Host = "nfa.jd.com";
                //request.Headers.Add("Cookie", @"shshshfpb=hzPNVCNjGTxJFzWoVg%20MjrQ%3D%3D; shshshfpa=a9861723-1ce4-5c55-2950-3dba4f651c4b-1577859332; __jdu=15895467570321140053578; __jdv=122270672|direct|-|none|-|1598956989875; areaId=53283; __jdc=122270672; 3AB9D23F7A4B3C9B=CPKCESYZUUPWO5ADT6CIFFK67ET34ZBQ6PB4AQ4CP5ICRHNW6VBDT5YIVNIEUG52MNFIFONGFYXRR34WNCZVHOWI4Y; ipLoc-djd=53283-53347-58679-0; shshshfp=ffa5084b2e5ed7a267e8f9e0c1c0f7a1; __jda=122270672.15895467570321140053578.1589546757.1599378979.1599646796.15; __jdb=122270672.4.15895467570321140053578|15.1599646796; shshshsID=1c19f73e27dd3f1b8a74316029d23fb6_2_1599646812283");
                //request.Headers.Add("Accept-Encoding", "gzip, deflate, br");
                //request.Headers.Add("Accept","*/*");
                request.Method = "Get";


                //read cookie
                request.CookieContainer = new CookieContainer();
                using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        logger.Warn(string.Format("HttpWebResponse's StatusCode is not ok, try to get {0} failed, response.StatusCode is {1}", url,response.StatusCode));
                    }
                    else
                    {
                        try
                        {
                            StreamReader sr = new StreamReader(response.GetResponseStream(), encoding);
                            html = sr.ReadToEnd();
                            sr.Close();
                        }
                        catch (Exception ex)
                        {
                            logger.Error(string.Format($"DownloadHtml StreamReader get {url} failed", ex));
                            html = null;
                        }

                    }

                }

            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("remote server error 306"))
                {
                    logger.Error("remote server error 306");
                    html = null;
                }
            }
            catch (Exception e)
            {
                logger.Error(string.Format("DowmloadHtml failed in download {0}", url));
                html = null;
            }

            return html;
        }


    }
}
