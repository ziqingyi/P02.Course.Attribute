using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using P02.Course.ExpressionSty.Visitor;

namespace P02.Course.ExpressionSty
{
    public class ExpressionVisitorTest
    {
        public static void Show()
        {
            {
                Console.WriteLine("---------modify expression tree---------------");
                Expression<Func<int,int,int>> exp = (m,n) =>n* m * n * n + 2;
                OperationsVisitor visitor = new OperationsVisitor();

                Expression expNew = visitor.Modify(exp);

                double result = ((Expression<Func<int, int, int>>)expNew).Compile().Invoke(2,3);
                Console.WriteLine(result);
            }
            {
                Expression<Func<People, bool >> lambda = x => x.Age > 5 && x.Id > 5;
                new List<People>().AsQueryable().Where(lambda);
                // select * from people where age > 5 and id > 5

                



            }


        }

    }
}
