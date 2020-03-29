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
    }
}
