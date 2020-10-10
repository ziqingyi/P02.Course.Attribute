using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P23.Course.IOC.IDAL;

namespace P23.Course.IOC.DAL
{
    public class DBContextDAL<T> : IDBContext<T>
    {
        public void DoNothing()
        {
            Console.WriteLine($"{typeof(T)} is doing nothing");
        }
    }
}
