using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator.Decorator
{
    public class StudentPreviewDecorator:BaseStudentDecorator
    {
        public StudentPreviewDecorator(AbstractStudent student) : base(student)
        {
            Console.WriteLine("Student Preview Decorator constructor..");
        }

        public override void Study()
        {
            base.Study();
            Console.WriteLine("Student Preview Decorator: preview.....");
        }

    }
}
