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
                // "server=.;uid=sa;pwd=123;database=advanced7"; 
                string home = "data source=.;initial catalog=advanced7;Integrated Security=true;MultipleActiveResultSets=True;";
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
