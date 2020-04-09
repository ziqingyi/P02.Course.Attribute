﻿using System;
using System.Collections.Generic;
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
                    ClassId=2,
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
                    ClassId=2,
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
                    ClassId=2,
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
                    ClassId=2,
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
                    ClassId=2,
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
                    ClassId=2,
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
                    ClassId=2,
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
                    ClassId=4,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="s17",
                    ClassId=4,
                    Age=30
                }
                  ,
                  new Student()
                {
                    Id=4,
                    Name="s18",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="s19gffg",
                    ClassId=4,
                    Age=30
                },
                  new Student()
                {
                    Id=4,
                    Name="s20",
                    ClassId=4,
                    Age=22
                },
                  new Student()
                {
                    Id=4,
                    Name="s21jhjh",
                    ClassId=4,
                    Age=23
                },
                  new Student()
                {
                    Id=4,
                    Name="s22",
                    ClassId=4,
                    Age=25
                },
                  new Student()
                {
                    Id=4,
                    Name="s23oioi",
                    ClassId=4,
                    Age=26
                },
                  new Student()
                {
                    Id=4,
                    Name="s24",
                    ClassId=4,
                    Age=28
                },
                  new Student()
                {
                    Id=4,
                    Name="s25ioi",
                    ClassId=4,
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
                    ClassId=4,
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
            //    Console.WriteLine("************Linq 1***************");
            //    var list = studentlist.Where<Student>(s => s.Age < 30 && s.Name.Length > 2);
            //    int i = 1;
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++ );
            //    }
            //}
            //{
            //    Console.WriteLine("***********Linq 2****************");
            //    int i = 1;
            //    var list = from s in studentlist
            //               where s.Age < 30 && s.Name.Length > 2
            //               select s;

            //    foreach (var item in list)
            //    {
            //        Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
            //    }
            //}

            {
                Console.WriteLine("***********Linq 3, for extend****************");
                int i = 1;
                var result = ExtendMethod.ExtendWhere(studentlist, new Func<Student, bool>(s => s.Name.Length > 2 && s.Age < 30));
                foreach (var item in result)
                {
                    Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
                }

                // same to use this
                Console.WriteLine("          extend simplify****************");
                i = 1;
                var result2 = studentlist.ExtendWhere(s => s.Name.Length > 2 && s.Age < 30);
                foreach (var item in result2)
                {
                    Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
                }
                //var result3 = studentlist.ExtendWhereT<Student>(s => s.Name.Length > 2 && s.Age < 30); // <T> is not necessary, s is based on para
                
                Console.WriteLine("        generic ****************");
                i = 1;
                var result4 = studentlist.ExtendWhereT(s => s.Name.Length > 2 && s.Age < 30);
                foreach (var item in result4)
                {
                    Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
                }

                Console.WriteLine("        iterator ****************");
                i = 1;
                var result5 = studentlist.ExtendWhereTIterator(s => s.Name.Length > 2 && s.Age < 30);
                foreach (var item in result5)
                {
                    Console.WriteLine("number: {2} Name = {0}  Age = {1} ", item.Name, item.Age, i++);
                }
            }
            #endregion
            #region   linq to object  ---where   filter

            
            {
                Console.WriteLine("------where and select : Projects each element of a sequence into a new form.--------------");
                var list = studentlist.Where<Student>(s=>s.Age < 30)
                    .Select(s=>new
                    {
                        IdName = s.Id + s.Name,
                        ClassName = s.ClassId ==2? "advanced": "basic"
                    });
                foreach (var item in list)
                {
                    Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
                }
            }
            {
                Console.WriteLine("------from where--------------");
                var list = from s in studentlist
                    where s.Age < 30
                    select new
                    {
                        IdName = s.Id + s.Name,
                        ClassName = s.ClassId == 2 ? "advanced" : "basic"
                    };
                foreach (var item in list)
                {
                    Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
                }

            }
            {
                Console.WriteLine("------in --------------");
                var list = studentlist.Where<Student>(s => s.Age < 30)
                    .Where(s => new int[]{1,2,3,4}.Contains(s.ClassId))
                    .Select(s=> new
                    {
                        IdName = s.Id + s.Name,
                        ClassName = s.ClassId == 2 ? "advanced" : "basic"
                    });
                foreach (var item in list)
                {
                    Console.WriteLine("Name = {0} Age = {1} ", item.ClassName, item.IdName);
                }

            }






            #endregion


        }
    }
}
