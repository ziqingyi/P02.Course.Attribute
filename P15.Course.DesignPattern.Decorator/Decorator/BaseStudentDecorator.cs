using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator.Decorator
{
    public class BaseStudentDecorator: AbstractStudent
    {
        private AbstractStudent _Student = null;

        public BaseStudentDecorator(AbstractStudent student)
        {
            this._Student = student;
        }

        public override void Study()
        {
            this._Student.Study();
        }

        public new void absOwn()
        {
            Console.WriteLine("base student decorator new void absOwn");
        }
    }
}
