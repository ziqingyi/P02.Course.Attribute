using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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



            }


        }

    }
}
