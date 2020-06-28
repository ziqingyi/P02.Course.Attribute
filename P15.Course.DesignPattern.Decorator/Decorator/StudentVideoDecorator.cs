using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator.Decorator
{
    public class StudentVideoDecorator :BaseStudentDecorator
    {
        public StudentVideoDecorator(AbstractStudent student) : base(student)
        {
            Console.WriteLine("Student Video Decorator Constructor");
        }
        public override void Study()
        {
            base.Study();
            Console.WriteLine("Student Video Decorator: review video.......");
        }

    }
}
