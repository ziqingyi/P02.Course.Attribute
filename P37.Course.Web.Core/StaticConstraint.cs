using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P37.Course.Web.Core
{
    public class StaticConstraint
    {
        public readonly static string DBconnection = "";

        static StaticConstraint()
        {
            try
            {
                string home = "data source=.;initial catalog=advanced7;integrated security=True;";
                DBconnection = home;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

    }
}
