using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace P02.Course.ExpressionSty
{
    class ExpressionTest
    {
        public static void Show()
        {
            {
                Console.WriteLine("---------compare-----------");
                Func<int, int, int> func = new Func<int, int, int>((m, n) => m * n + 2);//lambda

                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;//fast way
            }


            {
                Console.WriteLine("-------------simple one--------------------");
                //assemble to Expression
                Expression<Func<int>> expre = () => 123 + 234;
                expre.Compile().Invoke();
            }

            {
                Expression<Func<int, int, int>> expression2 = (m, n) => m * n + m + n + 2;
                int iResult2 = expression2.Compile().Invoke(23, 34);

            }
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");

                parameterExpression2 = Expression.Parameter(typeof(int), "m");
                parameterExpression = Expression.Parameter(typeof(int), "n");



                Expression<Func<int, int, int>> expression2 = Expression.Lambda<Func<int, int, int>>(Expression.Add(Expression.Add(Expression.Add(Expression.Multiply(parameterExpression2, parameterExpression), parameterExpression2), parameterExpression), Expression.Constant(2, typeof(int))), new ParameterExpression[2]
                {
                    parameterExpression2,
                    parameterExpression
                });
                int iResult2 = expression2.Compile()(23, 34);

            }



        }



    }
}
