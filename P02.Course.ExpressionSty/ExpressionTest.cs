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
                Console.WriteLine("-------------a more complex cases--------------------");
                Expression<Func<int, int, int>> expression2 = (m, n) => m * n + m + n + 2;
                int iResult2 = expression2.Compile().Invoke(23, 34);

            }
            {
                Console.WriteLine("-------------a more complex cases, compiled by compiler--------------------");
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "m");
                ParameterExpression parameterExpression2 = Expression.Parameter(typeof(int), "n");

                parameterExpression2 = Expression.Parameter(typeof(int), "m");
                parameterExpression = Expression.Parameter(typeof(int), "n");

                Expression<Func<int, int, int>> expression2 = 
                    Expression.Lambda<Func<int, int, int>>(
                        Expression.Add(
                            Expression.Add(
                                Expression.Add(
                                    Expression.Multiply(parameterExpression2, parameterExpression),
                                    parameterExpression2), 
                                parameterExpression), 
                            Expression.Constant(2, typeof(int))
                            ), 
                        new ParameterExpression[2]
                {
                    parameterExpression2,
                    parameterExpression
                });
                int iResult2 = expression2.Compile()(23, 34);

            }
            {
                Console.WriteLine("-------------a more complex cases, assemble by steps--------------------");
                //      m * n + m + n       + 2
                ParameterExpression m = Expression.Parameter(typeof(int),"m");
                ParameterExpression n = Expression.Parameter(typeof(int),"n");
                ConstantExpression constant = Expression.Constant(2);

                //  m*n
                BinaryExpression mul = Expression.Multiply(n, m);

                //  (m*n) + m
                BinaryExpression leftadd = Expression.Add(mul, m);

                //  ( m * n + m ) + n 
                BinaryExpression leftadd2 = Expression.Add(leftadd, n);
                //  (m * n + m + n  )     + 2
                BinaryExpression leftadd3 = Expression.Add(leftadd2, constant);

                Expression<Func<int, int, int>> expression2 =
                    Expression.Lambda<Func<int, int, int>>(
                        leftadd3,
                        new ParameterExpression[2]
                        {
                            n,
                            m
                        });
                int iResult2 = expression2.Compile()(23, 34);

            }
            {
                Expression<Func<People, bool>> lambdaExpression = x => x.Id.ToString().Equals("5");



            }

        }



    }
}
