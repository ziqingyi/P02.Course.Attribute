﻿using P01.Course.DB.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Course.DB.MySql
{
    public class MySqlHelper: IDBHelper
    {
        public MySqlHelper()
        {
            Console.WriteLine("{0} is being initialized ", this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("{0}.Query is being called", this.GetType().Name);
        }
    }

    public class MySqlHelper2 : IDBHelper
    {
        public MySqlHelper2()
        {
            Console.WriteLine("{0} is being initialized ", this.GetType().Name);
        }
        public void Query()
        {
            Console.WriteLine("{0}.Query is being called", this.GetType().Name);
        }
    }
}
