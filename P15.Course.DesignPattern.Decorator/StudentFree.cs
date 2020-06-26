using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P15.Course.DesignPattern.Decorator
{
    public class StudentFree: AbstractStudent
    {
        public StudentFree(string name, int id)
        {
            base.Name = name;
            base.Id = id;
        }

        public override void Study()
        {
            Console.WriteLine("{0} is a vip student studying .net Vip", base.Name);
        }
    }
    // decorate by derived class 
    public class StudentVipVideo : StudentVip
    {
        public StudentVipVideo(string name, int id): base(name, id)
        {
             
        }
        public override void Study()
        {
            base.Study();
            Console.WriteLine("get vip video");
        }
    }
    // decorate to the instance being passed into. 
    public class StudentCombination
    {
        private AbstractStudent student = null;

        public StudentCombination(AbstractStudent abstractStudent)
        {
            student = abstractStudent;
        }

        public void Study()
        {
            this.student.Study();
            Console.WriteLine("get vip video");
        }

    }



}
