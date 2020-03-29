using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-----study delegate------");
            //MyDelegate myDelegate = new MyDelegate();
            //myDelegate.Show();

            Student ss = new Student()
            {
                Id = 123,
                Name = "Rab",
                Age = 23,
                ClassId = 1
            };
            ss.SayHi("Cath", PeopleType.Chinese);

            {
                SayHiDelegate method = new SayHiDelegate(ss.SayHiChinese);
                ss.SayHiPerfect("wang", method);
            }


        }
    }
}
