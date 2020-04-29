using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace P02.Course.Expression
{
    class ExpressionTest
    {
        public static void Show()
        {
            Func<int, int, int> func = new Func<int, int, int>((m, n) => m * n + 2);//lambda

            Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;





        }



    }
}
