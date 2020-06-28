using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator.Decorator
{
    public class StudentPayDecorator :BaseStudentDecorator
    {
        public StudentPayDecorator(AbstractStudent student) : base(student)
        {
            Console.WriteLine("Student Pay Decorator constructor");
        }

        public override void Study()
        {
            base.Study();
            Console.WriteLine("Student Pay Decorator: paying....");
        }
    }
}
