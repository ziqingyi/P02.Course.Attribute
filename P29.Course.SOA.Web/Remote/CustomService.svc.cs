using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace P29.Course.SOA.Web.Remote
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "CustomService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select CustomService.svc or CustomService.svc.cs at the Solution Explorer and start debugging.
    public class CustomService : ICustomService
    {
        public void DoWork()
        {
            Console.WriteLine("do work.........");
        }

        public int Get()
        {
            return DateTime.Now.Year;
        }

    }
}
