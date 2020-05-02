using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
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
                Console.WriteLine("-------------Expression with labmda--------------------");
                //Expression<Func<People, bool>> lambdaExpression = x => x.Id.ToString().Equals("5");
                // 1 part:  x
                ParameterExpression x = Expression.Parameter(typeof(People), "x");

                // 2 part: x.Id
                FieldInfo field = typeof(People).GetField("Id");
                //FieldInfo.GetFieldFromHandle((RuntimeFieldHandle))/*OpCode not supported: LdMemberToken*/
                MemberExpression fieldExp = Expression.Field(x, field);

                //3 part: int's method ToString
                MethodInfo toString = typeof(int).GetMethod("ToString",new Type[]{ });/*OpCode not supported: LdMemberToken*/

                //4 part: string's method: Equals()
                //(MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle))/*OpCode not supported: LdMemberToken*/
                MethodInfo equals = typeof(string).GetMethod("Equals",new Type[] {typeof(string)});

                //5 part: constant number : 5
                ConstantExpression c = Expression.Constant("5", typeof(string));

                //6
                MethodCallExpression me1 = Expression.Call(fieldExp, toString, new Expression[0]);//or Array.Empty<Expression>()

                //7 
                MethodCallExpression me2 = Expression.Call(me1, equals, c);

                //8
                ParameterExpression[] xarray = new ParameterExpression[1]{x};
                Expression<Func<People, bool>> expression = Expression.Lambda<Func<People, bool>>(me2, xarray);

                //test result 
                bool bResult =  expression.Compile().Invoke(  //note: can remove invoke
                        new People()
                    {
                        Id = 5,
                        Name = "Mick",
                        Age = 28
                    }
                        );

                //compiler version
                Expression<Func<People, bool>> lambdaExpression =
                    Expression.Lambda<Func<People, bool>>(
                        Expression.Call(
                            me1,
                            equals,
                            c
                            ),
                        new ParameterExpression[1]
                        {
                            x
                        });

            }
            {
                Console.WriteLine("-------------Expression with Action--------------------");
                //Expression<Func<People, bool>> lambdaExpression = x => x.Id.ToString().Equals("5");
                // 1 part:  x
                ParameterExpression x = Expression.Parameter(typeof(People), "x");

                // 2 part: x.Id
                FieldInfo field = typeof(People).GetField("Id");
                //FieldInfo.GetFieldFromHandle((RuntimeFieldHandle))/*OpCode not supported: LdMemberToken*/
                MemberExpression fieldExp = Expression.Field(x, field);

                //3 part: int's method ToString
                MethodInfo toString = typeof(int).GetMethod("ToString", new Type[] { });/*OpCode not supported: LdMemberToken*/

                //4 part: string's method: Equals()
                //(MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle))/*OpCode not supported: LdMemberToken*/
                MethodInfo equals = typeof(string).GetMethod("Equals", new Type[] { typeof(string) });

                //5 part: constant number : 5
                ConstantExpression c = Expression.Constant("5", typeof(string));

                //6
                MethodCallExpression me1 = Expression.Call(fieldExp, toString, new Expression[0]);//or Array.Empty<Expression>()

                //7 
                MethodCallExpression me2 = Expression.Call(me1, equals, c);

                //8
                ParameterExpression[] xarray = new ParameterExpression[1] { x };
                Expression<Action<People>> expression = Expression.Lambda<Action<People>>(me2, xarray);

                //test result 
                expression.Compile()(
                    new People()
                    {
                        Id = 5,
                        Name = "Mick",
                        Age = 28
                    }
                );

            }

        }



    }
}
