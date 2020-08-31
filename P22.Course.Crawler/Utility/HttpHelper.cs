using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P22.Course.Crawler.Utility
{
    public class HttpHelper
    {

        public static string DownloadUrl(string url)
        {
            return DownloadHtml(url,Encoding.UTF8);
        }

        public static string DownloadHtml(string url, Encoding encoding)
        {
            string html = string.Empty;
            try
            {




            }
            catch (System.Net.WebException ex)
            {
                if (ex.Message.Contains("306"))
                {

                    html = null;
                }
            }
            catch (Exception e)
            {


                html = null;
            }


            return html;
        }


    }
}
