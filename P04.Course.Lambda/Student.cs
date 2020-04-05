using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    public class Student
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public void Study()
        {
            Console.WriteLine("{0} {1} is studying .net ", this.Id, this.Name);
        }

        public void StudyHard()
        {
            Console.WriteLine("{0} {1} is studying .net, study hard work hard ", this.Id, this.Name);
        }

        public void StudyPractise()
        {
            Console.WriteLine("{0} {1} is practice.......", this.Id, this.Name);
        }
    }

    public class Class
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
    }
}
