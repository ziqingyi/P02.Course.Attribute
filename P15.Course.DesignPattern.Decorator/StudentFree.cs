using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator
{
    public class StudentFree: AbstractStudent
    {
        public StudentFree(string name, int id)
        {
            base.Name = name;
            base.Id = id;
        }

        public override void Study()
        {
            Console.WriteLine("{0} is a vip student studying .net Vip", base.Name);
        }

    }
}
