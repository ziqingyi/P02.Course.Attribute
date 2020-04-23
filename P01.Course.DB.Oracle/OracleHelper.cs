using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P01.Course.DB.Interface;

namespace P01.Course.DB.Oracle
{
    public class OracleHelper: IDBHelper
    {
        public OracleHelper()
        {
            Console.WriteLine("{0} is being initialized ", this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("{0}.Query is being called", this.GetType().Name);
        }

    }
}
