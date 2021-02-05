using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;

namespace P37.Course.Web.SearchEngines.SearchService
{
    public class WCFInit
    {
        private static List<ServiceHost> hostList = null;

        public static void Start()
        {
            hostList = new List<ServiceHost>()
            {
                new ServiceHost(typeof(Searcher))
            };



        }












    }
}
