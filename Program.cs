using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P02.Course.Attribute.EnumExtend;

namespace P02.Course.Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------------Attribute --------------");
            Student s = new Student()
            {
                Id = 123,
                Name = " Tom "
            };
            s.Study();
            s.Answer(" Tom ");

            #region MyRegion

            UserState userState = UserState.Frozen;
            {
                Student student = new Student()
                {
                    Id = 123,
                    Name = "Alex"
                };

                InvokeCenter.ManagerStudent(student);
            }
            string remark = AttributeExtend.GetRemark(userState);

            #endregion

            #region validate

            StudentVip sp = new StudentVip()
            {
                Id = 123,
                Name = "vip student 1",
                QQ = 12345,
                Salary = 500000
            };
            if (sp.Validate())
            {
                Console.WriteLine("validate is success!!!!!!");
            }
            else
            {
                Console.WriteLine("some is not validate");
            }
            

            #endregion





        }
    }
}
