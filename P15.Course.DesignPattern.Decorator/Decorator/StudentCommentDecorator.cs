using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator.Decorator
{
    public class StudentCommentDecorator: BaseStudentDecorator
    {
        public StudentCommentDecorator(AbstractStudent student) :base(student)
        {
            Console.WriteLine("Student Comment Decorator Constructor");
        }

        public override void Study()
        {
            base.Study();
            Console.WriteLine("Student Comment Decorator: comment.......");
        }


    }
}
