using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.DB.SqlServer
{
    public class SqlServerHelper: IDBHelper
    {
        public SqlServerHelper()
        {
            Console.WriteLine("{0} is being initialized ", this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("{0}.Query is being called", this.GetType().Name);
        }
    }
}
