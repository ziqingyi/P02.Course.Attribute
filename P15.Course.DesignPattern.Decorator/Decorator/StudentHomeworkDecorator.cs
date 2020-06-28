using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator.Decorator
{
    public class StudentHomeworkDecorator: BaseStudentDecorator
    {
        public StudentHomeworkDecorator(AbstractStudent student):base(student)
        {
            Console.WriteLine("Student Homework Decorator Constructor");
        }

        public override void Study()
        {
            base.Study();
            Console.WriteLine("Student Homework Decorator: student is doing homework.....");
        }
    }
}
