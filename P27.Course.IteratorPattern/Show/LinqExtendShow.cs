using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P27.Course.IteratorPattern.Show
{
    public class LinqExtendShow
    {
        private static List<Student> GetStudentList()
        {
            #region initialise data
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="Student1",
                    ClassId=2,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="Student2",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="Student3",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="Student4",
                    ClassId=2,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="Student5",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="Student6",
                    ClassId=2,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="Student7",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="Student8",
                    ClassId=2,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="Student9",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="Student10",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="Student11",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="Student12",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="Student13",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="Student14",
                    ClassId=2,
                    Age=30
                },
                 new Student()
                {
                    Id=3,
                    Name="Student15",
                    ClassId=3,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="Student16",
                    ClassId=4,
                    Age=30
                }
            };
            #endregion
            return studentList;
        }

        public static void Show()
        {
            List<Student> studentList = GetStudentList();

            IEnumerable<Student> result = studentList.Where(s => s.Age < 30);

            IEnumerable<Student> list = studentList.MyWhere(s =>
            {
                Console.WriteLine("show the lazy loading.....");
                return s.Age < 30;
            });

            foreach (Student s in list)
            {
                Console.WriteLine($"Name={s.Name} Age={s.Age}");
            }

        }

    }
}
