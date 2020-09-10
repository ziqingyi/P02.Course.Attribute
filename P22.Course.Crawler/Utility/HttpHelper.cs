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
