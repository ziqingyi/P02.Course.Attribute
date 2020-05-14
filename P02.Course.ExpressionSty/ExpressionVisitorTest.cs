using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using P05.Course.ExpressionSty.Extend;
using P05.Course.ExpressionSty.Visitor;

namespace P05.Course.ExpressionSty
{
    public class ExpressionVisitorTest
    {
        public static void Show()
        {
            //{
            //    Console.WriteLine("---------modify expression tree---------------");
            //    Expression<Func<int,int,int>> exp = (m,n) =>n* m * n * n + 2;
            //    OperationsVisitor visitor = new OperationsVisitor();

            //    Expression expNew = visitor.Modify(exp);

            //    double result = ((Expression<Func<int, int, int>>)expNew).Compile().Invoke(2,3);
            //    Console.WriteLine(result);
            //}
            //{
            //    Console.WriteLine("------------visitor to visit labmda, and transfer to sql-----");
            //    Expression<Func<People, bool >> lambda = x => x.Age > 5 && x.Id > 6;
            //    var test = new List<People>().AsQueryable().Where(lambda);
            //    // select * from people where age > 5 and id > 6

            //    ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
            //    visitor.Visit(lambda);

            //    Console.WriteLine(visitor.Condition());

            //}
            {
                Console.WriteLine("------------visitor to visit labmda, and transfer to sql, a complex case-----");
                Expression<Func<People, bool>> lambda = x => x.Age > 5 && x.Id < 5
                                                                       && x.Id == 3
                                                                       && x.Name.StartsWith("1")
                                                                       && x.Name.EndsWith("1")
                                                                       && x.Name.Contains("1");
                string sql = string.Format("Delete From [{0}] Where {1}"
                    , typeof(People).Name
                    , " [Age]>5 And [ID] > 5");

                ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
                visitor.Visit(lambda);

                Console.WriteLine(visitor.Condition());

            }

            {
                Console.WriteLine("-------------test visitor priority-------------------");
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5 && x.Name == "A" || x.Id > 5;
                ConditionBuilderVisitor visitor1 = new ConditionBuilderVisitor();
                visitor1.Visit(lambda1);
                Console.WriteLine(visitor1.Condition());

                Expression<Func<People, bool>> lambda2 = x => x.Age > 5 && x.Name == "A" || x.Id > 5;
                ConditionBuilderVisitor visitor2 = new ConditionBuilderVisitor();
                visitor2.Visit(lambda2);
                Console.WriteLine(visitor2.Condition());

                Expression<Func<People, bool>> lambda3 = x => x.Age > 5 && x.Name == "A" || x.Id > 5;
                ConditionBuilderVisitor visitor3 = new ConditionBuilderVisitor();
                visitor3.Visit(lambda3);
                Console.WriteLine(visitor3.Condition());
            }
            {
                Console.WriteLine("--------------combine expression ---------------------------");
                Expression<Func<People, bool>> lambda1 = x => x.Age > 5;
                Expression<Func<People, bool>> lambda2 = x => x.Id > 5;
                Expression<Func<People, bool>> lambda3 = lambda1.And(lambda2);
                Expression<Func<People, bool>> lambda4 = lambda1.Or(lambda2);

            }

        }

        private static void Do1(Func<People, bool> func)
        {
            List<People> people = new List<People>();
            people.Where(func);
        }

        private static void Do1(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id = 4, Name = "123",Age = 4},
                new People(){Id = 5,Name = "123", Age = 5},
                new People(){Id = 5, Name = "345", Age = 6}
            };

            List<People> peopleList = people.Where(func.Compile()).ToList();
        }

        private static IQueryable<People> GetQueryable(Expression<Func<People, bool>> func)
        {
            List<People> people = new List<People>()
            {
                new People(){Id = 4, Name = "123", Age = 4},
                new People(){Id = 5, Name = "234", Age = 5},
                new People(){Id = 6, Name = "345", Age = 6}
            };
            return people.AsQueryable<People>().Where(func);
        }

    }
}
