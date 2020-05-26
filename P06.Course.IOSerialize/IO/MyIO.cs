using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize.IO
{
    public class MyIO
    {
        private static string NotExistPath = ConfigurationManager.AppSettings["NotExistFolder"];
        private static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        private static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];
        private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;
        public static void Show()
        {
            if (Directory.Exists(LogPath))
            {

            }
            DirectoryInfo notReportError = new DirectoryInfo(NotExistPath);





        }



    }
}
