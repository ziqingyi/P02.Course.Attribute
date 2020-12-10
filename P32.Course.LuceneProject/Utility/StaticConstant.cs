using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P32.Course.LuceneProject.Utility
{
    public class StaticConstant
    {
        public static string IndexPath = ConfigurationManager.AppSettings["IndexPath"];

        public static string TestIndexPath = AppDomain.CurrentDomain.BaseDirectory+"\\index\\";

        public static string ConnStr = ConfigurationManager.ConnectionStrings["mvc5"].ConnectionString;
    }
}
