using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.Show
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("{0} {1} is studying .net", this.Id, this.Name);
        }
    }
}
