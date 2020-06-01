using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P06.Course.IOSerialize
{
    public class Constant
    {
        //get absolute path
        public static string LogPath = ConfigurationManager.AppSettings["LogPath"];
        public static string LogMovePath = ConfigurationManager.AppSettings["LogMovePath"];

        //get serialized data path
        public static string SerializeDataPath = ConfigurationManager.AppSettings["SerializeDataPath"];

        //get image path
        public static string ImagePath = ConfigurationManager.AppSettings["ImagePath"];
        public static string ImagePathNew = ConfigurationManager.AppSettings["ImagePathNew"];
        public static string VerifyPath = ConfigurationManager.AppSettings["VerifyPath"];

    }
}
