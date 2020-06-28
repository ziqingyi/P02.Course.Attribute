using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator
{
    public abstract class AbstractStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public abstract void Study();

        public void absOwn()
        {
            Console.WriteLine("abstract own method");
        }
    }
}
