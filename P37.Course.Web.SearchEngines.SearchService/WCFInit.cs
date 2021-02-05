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

            foreach (ServiceHost host in hostList)
            {
                host.Opened += (sender, e) => Console.WriteLine("{0} Begin!", host.Description);
                host.Open();
            }

        }


        public static void Stop()
        {
            if (hostList != null)
                foreach (ServiceHost host in hostList)
                {
                    Console.WriteLine("{0} Stop !", host.Description);
                    host.Abort();
                }
        }






    }
}
