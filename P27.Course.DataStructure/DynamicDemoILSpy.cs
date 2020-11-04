using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.DataStructure
{
    class DynamicDemoILSpy
    {
        //check in IL Spy
        public void test()
        {
            //clr will generate several delegates in first time running, then next time, will invoke directly, faster than reflection. 
            dynamic str = "abcd";
            Console.WriteLine(str.Length);// everything in str will be dynamic. so Length, Substring() are also dynamic. 
            Console.WriteLine(str.Substring(1));
        }

    }
}
