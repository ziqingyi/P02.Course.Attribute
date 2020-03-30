using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Course.Delegate
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ClassId { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine($"the student {Name} is studying ");
        }

        public void SayHi(string name, PeopleType pt)
        {
            switch (pt)
            {
                case PeopleType.Chinese:
                    Console.WriteLine($"{name} ni hao");
                    break;
                case PeopleType.American:

                    Console.WriteLine($"hello......, {name}");
                    break;
                default:
                    throw new Exception("wrong peopeType");
            }

        }
        public void SayHiChinese(string name)
        {
            //Console.WriteLine("prepare SayHi..");

            Console.WriteLine($"{name}, ni hao");
        }
        public void SayHiEnglish(string name)
        {
            //Console.WriteLine("prepare SayHi..");

            Console.WriteLine($"Hi, ....{name}");
        }

        public void SayHiPerfect(string name, SayHiDelegate method)
        {
            Console.WriteLine("----some parts being shared by multiple method-----");
            //then call the delegate method to show their different behavior.
            method.Invoke(name);
        }

        public static void Staticstudy()
        {
            Console.WriteLine("study as static");
        }


    }

    public delegate void SayHiDelegate(string name);

    public enum PeopleType
    {
        Chinese = 1,
        American = 2
    }



}
