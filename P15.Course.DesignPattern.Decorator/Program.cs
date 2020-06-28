using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P15.Course.DesignPattern.Decorator.Decorator;

namespace P15.Course.DesignPattern.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Liskov Substitution principle");
            AbstractStudent student = new StudentVip("s1", 1);
            student.Study();
            {
                AbstractStudent abstractClassRef = new BaseStudentDecorator(student);
                abstractClassRef.Study();
                abstractClassRef.absOwn();//will call abstract's method

                BaseStudentDecorator baseClassRef = (BaseStudentDecorator) abstractClassRef;
                baseClassRef.absOwn();//will call base  class new method
            }
            {
                Console.WriteLine("ref same to class");
                StudentVideoDecorator dec = new StudentVideoDecorator(student);

                Console.WriteLine("Liskov Substitution principle");
                BaseStudentDecorator baseClassRef = new StudentVideoDecorator(student);
                baseClassRef.Study();

                AbstractStudent abstractClassRef = new StudentVideoDecorator(student);
                abstractClassRef.Study();
            }
            {
                Console.WriteLine("****************Decorator***********************");
                student = new StudentVideoDecorator(student);
                student = new StudentCommentDecorator(student);
                student = new StudentHomeworkDecorator(student);
                student = new StudentPayDecorator(student);
                student.Study();
            }


        }
    }
}
