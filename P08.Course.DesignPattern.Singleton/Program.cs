using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            { // test singleton
                Singleton s1 = Singleton.CreateInstance();
                Singleton s2 = Singleton.CreateInstance();
                bool same = object.ReferenceEquals(s1, s2);
            }












        }
    }
}
