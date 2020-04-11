using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace P04.Course.Lambda
{
    //.net 3.0
    public class LinqShow
    {
        private List<Student> GetStudentList()
        {
            #region 初始化数据
            List<Student> studentList = new List<Student>()
            {
                new Student()
                {
                    Id=1,
                    Name="s1o",
                    ClassId=1,
                    Age=35
                },
                new Student()
                {
                    Id=1,
                    Name="s2pp",
                    ClassId=2,
                    Age=23
                },
                 new Student()
                {
                    Id=1,
                    Name="s3",
                    ClassId=2,
                    Age=27
                },
                 new Student()
                {
                    Id=1,
                    Name="s4h",
                    ClassId=1,
                    Age=26
                },
                new Student()
                {
                    Id=1,
                    Name="s5k",
                    ClassId=2,
                    Age=25
                },
                new Student()
                {
                    Id=1,
                    Name="s6kj",
                    ClassId=1,
                    Age=24
                },
                new Student()
                {
                    Id=1,
                    Name="s7",
                    ClassId=2,
                    Age=21
                },
                 new Student()
                {
                    Id=1,
                    Name="s8",
                    ClassId=1,
                    Age=22
                },
                 new Student()
                {
                    Id=1,
                    Name="s9kj",
                    ClassId=2,
                    Age=34
                },
                 new Student()
                {
                    Id=1,
                    Name="s10",
                    ClassId=1,
                    Age=20
                },
                new Student()
                {
                    Id=1,
                    Name="s11",
                    ClassId=2,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="s12kjk",
                    ClassId=1,
                    Age=30
                },
                new Student()
                {
                    Id=1,
                    Name="s13",
                    ClassId=2,
                    Age=28
                },
                new Student()
                {
                    Id=1,
                    Name="s14ioio",
                    ClassId=1,
                    Age=30
                },
                 new Student()
                {
                    Id=3,
                    Name="s15",
                    ClassId=3,
                    Age=15
                },
                  new Student()
                {
                    Id=4,
                    Name="s16fgf",
                    ClassId=3,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="s17",
                    ClassId=3,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="s18",
                    ClassId=1,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="s19gffg",
                    ClassId=1,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="s20",
                    ClassId=3,
                    Age=22
                },
                  new Student()
                {
                    Id=4,
                    Name="s21jhjh",
                    ClassId=3,
                    Age=23
                },
                  new Student()
                {
                    Id=4,
                    Name="s22",
                    ClassId=1,
                    Age=25
                },
                  new Student()
                {
                    Id=4,
                    Name="s23oioi",
                    ClassId=1,
                    Age=26
                },
                  new Student()
                {
                    Id=4,
                    Name="s24",
                    ClassId=3,
                    Age=28
                },
                  new Student()
                {
                    Id=4,
                    Name="s25ioi",
                    ClassId=2,
                    Age=22
                },
                  new Student()
                {
                    Id=4,
                    Name="s26",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="s27",
                    ClassId=2,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="s28",
                    ClassId=4,
                    Age=24
                },
                  new Student()
                {
                    Id=4,
                    Name="s29",
                    ClassId=4,
                    Age=30
                }
            };
            #endregion
            return studentList;
        }

        public void Show()
        {
            var studentlist = this.GetStudentList();

            //{
            //    //normal way
            //    Console.WriteLine("************normal way***************");
            //    var list = new List<Student>();
            //    foreach (var item in studentlist)
            //    {
            //        if (item.Age < 30 
            //            && item.Name.Length > 2)
            //        {
            //            list.Add(item);
            //            Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, list.Count);
            //        }
            //    }
            //}

            #region Linq

            //{
            //    Console.WriteLine("************lambda ***************");
            //    var list = studentlist.Where<Student>(s => s.Age < 30 && s.Name.Length > 2);
            //    int i = 1;
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++ );
            //    }
            //}
            //{
            //    Console.WriteLine("***********Linq ****************");
            //    int i = 1;
            //    var list = from s in studentlist
            //               where s.Age < 30 && s.Name.Length > 2
            //               select s;

            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
            //    }
            //}

            //{
            //    Console.WriteLine("***********lambda , for extend****************");
            //    int i = 1;
            //    var result = ExtendMethod.ExtendWhere(studentlist, new Func<Student, bool>(s => s.Name.Length > 2 && s.Age < 30));
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
            //    }

            //    // same to use this
            //    Console.WriteLine("          extend simplify****************");
            //    i = 1;
            //    var result2 = studentlist.ExtendWhere(s => s.Name.Length > 2 && s.Age < 30);
            //    foreach (var item in result2)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
            //    }
            //    //var result3 = studentlist.ExtendWhereT<Student>(s => s.Name.Length > 2 && s.Age < 30); // <T> is not necessary, s is based on para

            //    Console.WriteLine("        generic ****************");
            //    i = 1;
            //    var result4 = studentlist.ExtendWhereT(s => s.Name.Length > 2 && s.Age < 30);
            //    foreach (var item in result4)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
            //    }

            //    Console.WriteLine("        iterator ****************");
            //    i = 1;
            //    var result5 = studentlist.ExtendWhereTIterator(s => s.Name.Length > 2 && s.Age < 30);
            //    foreach (var item in result5)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
            //    }
            //}
            //#endregion
            //#region   linq to object  ---where   filter

            //{
            //    Console.WriteLine("------where and select: Projects each element of a sequence into a new type---------");
            //    var list = studentlist.Where<Student>(s=>s.Age < 30)//new anonymous class, so use var
            //        .Select(s=>new
            //        {
            //            IdName = s.Id + s.Name,
            //            ClassName = s.ClassId ==2? "advanced": "basic"
            //        });
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
            //    }
            //}
            //{
            //    Console.WriteLine("------linq from where--------------");//be compiled to the upper case
            //    var list = from s in studentlist
            //        where s.Age < 30
            //        select new
            //        {
            //            IdName = s.Id + s.Name,
            //            ClassName = s.ClassId == 2 ? "advanced" : "basic"
            //        };
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
            //    }
            //}

            //{
            //    Console.WriteLine("------labmda and linq in --------------");
            //    var list = studentlist.Where<Student>(s => s.Age < 30)
            //        .Where(s => new int[]{1,2,3,4}.Contains(s.ClassId))
            //        .Select(s=> new
            //        {
            //            IdName = s.Id + s.Name,
            //            ClassName = s.ClassId == 2 ? "advanced" : "basic"
            //        });
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
            //    }
            //}

            //{
            //    Console.WriteLine("------linq order by skip and take --------------");
            //    var list = studentlist.Where(s => s.Age < 30)
            //        .Select(s => new
            //        {
            //            Id = s.Id,
            //            ClassId = s.ClassId,
            //            IdName = s.Id + s.Name,
            //            ClassName = s.ClassId == 2 ? "advanced" : "basic"
            //        })
            //        .OrderBy(s => s.ClassId)
            //        .ThenBy(s => s.Id)// orderby and thenby can work together
            //        .OrderByDescending(s => s.ClassId) // OrderByDescending will work as it is the last one. 
            //        .Skip(2)
            //        .Take(3);
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
            //    }
            //}
            //{
            //    Console.WriteLine("------ linq  group by --------------");
            //    var list = from s in studentlist
            //               where s.Age < 30
            //               group s by s.ClassId 
            //               into sg
            //               select new//get the max age in each group. 
            //               {
            //                   key = sg.Key,
            //                   maxAge = sg.Max(t => t.Age)
            //               };
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("group key = {0} max age = {1} ", item.key, item.maxAge);
            //    }

            //    Console.WriteLine("------  check group property --------------");
            //    var list2 = from s in studentlist
            //        where s.Age < 30
            //        group s by s.ClassId
            //        into sg
            //        select sg;
            //    foreach (var egroup in list2)
            //    {
            //        Console.WriteLine("group key = {0} ", egroup.Key);
            //        foreach (var item in egroup)
            //        {
            //            Console.WriteLine("id = {0} Name = {1} Age = {2} ", item.Id, item.Name, item.Age);
            //        }
            //    }
            //    Console.WriteLine("------  use delegate --------------");

            //    var list3 = studentlist.GroupBy(s => s.ClassId)
            //        .Select(sg => new
            //        {
            //            key = sg.Key,
            //            maxAge = sg.Max(t => t.Age)
            //        });

            //    foreach (var item in list3)
            //    {
            //        Console.WriteLine("group key = {0} max age = {1} ", item.key, item.maxAge);
            //    }

            //}

            #endregion
            Console.WriteLine("------  use Join --------------");
            List<Class> classList = new List<Class>()
            {
                new Class()
                {
                    Id = 1,
                    ClassName = "Basic"
                },
                new Class()
                {
                    Id = 2,
                    ClassName = "Advanced"
                },
                new Class()
                {
                    Id = 3,
                    ClassName = "Website"
                }
            };

            {
                Console.WriteLine("------  use Join with lambda--------------");
                var list = studentlist.Join(classList, s => s.ClassId, c => c.Id,
                    (s, c) => new 
                    {
                        Name = s.Name,
                        ClassName = c.ClassName
                    });
                foreach (var item in list)
                {
                    Console.WriteLine($"Name = {item.Name}, Class Name = {item.ClassName}");
                }
            }
            {
                Console.WriteLine("------  use Join with from in --------------");
                var list = from s in studentlist
                    join c in classList
                        on s.ClassId equals c.Id // cannot use ==
                    select new
                    {
                        Name = s.Name,
                        ClassName = c.ClassName
                    };
                foreach (var item in list)
                {
                    Console.WriteLine($"Name = {item.Name}, Class Name = {item.ClassName}");
                }

            }
            {
                Console.WriteLine("------  use left Join with linq--------------");
                var testlist = from s in studentlist
                               join c in classList
                                   on s.ClassId equals c.Id
                                   into tt
                               select tt;


                var list = from s in studentlist
                           join c in classList
                               on s.ClassId equals c.Id
                               into scList  //add in a new group
                           from sc in scList.DefaultIfEmpty() // for left join,because it display students without class
                           select new
                           {
                               Name = s.Name,
                               ClassName = sc == null ? "no class" : sc.ClassName
                           };

                foreach (var item in list)
                {
                    Console.WriteLine($"Name = {item.Name}, Class Name = {item.ClassName}");
                }
                Console.WriteLine(list.Count());
            }
            {
                Console.WriteLine("------  use left Join with labmda--------------");
                var list = studentlist.Join(classList, s => s.ClassId, c => c.Id,
                    (s, c) => new
                    {
                        Name = s.Name,
                        ClassName = c.ClassName
                    }).DefaultIfEmpty();// if




            }




        }
    }
}
