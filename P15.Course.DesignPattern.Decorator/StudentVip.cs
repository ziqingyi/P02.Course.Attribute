using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator
{
    public class StudentVip :AbstractStudent
    {
        public StudentVip(string name, int id)
        {
            base.Name = name;
            base.Id = id;
        }

        public override void Study()
        {
            Console.WriteLine("{0} is a free student studying .net Free", base.Name);
        }
    }
}
