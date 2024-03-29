﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using P05.Course.ExpressionSty.MappingExtend;

namespace P05.Course.ExpressionSty
{
    class ExpressionTest
    {
        public static void ShowBasicLambdaToExpressionToDelegate()
        {
            {
                Console.WriteLine("---------compare-----------");
                //lambda is a method
                Func<int, int, int> func1 = new Func<int, int, int>((m, n) => m * n + 2);//lambda to delegate

                //lambda is a data structure
                Expression<Func<int, int, int>> exp = (m, n) => m * n + 2;//lambda to expression tree to delegate

                Func<int, int, int> func2 = exp.Compile();

                int result1 = func1(1, 2);
                int result2 = func2(1, 2);
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
        public static void ShowTestCaseForExpressionToDelegate()
        {
            {
                Console.WriteLine("-------------1  assemble sql with user input, old way----------------------");
                string sql = @"SELECT * FROM USER WHERE 1=1";
                Console.WriteLine("please type in user name: ");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    sql += $" and name like '%{name}%'";
                }

                Console.WriteLine("please fill in account : ");
                string account = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(account))
                {
                    sql += $" and account like '%{account}%'";
                }
            }
            {
                Console.WriteLine("-------------2  assemble sql with linq , not reflect all the possible combination----------");
                var dbSet = new List<People>().AsQueryable();
                dbSet.Where(p => p.Id > 10 & p.Name.Contains("name1"));
                Console.WriteLine("please type in user name: ");
                string name = Console.ReadLine();

                Expression<Func<People, bool>> exp;

                if (!string.IsNullOrWhiteSpace(name))
                {
                     exp= p => p.Name.Contains(name);
                }

                Console.WriteLine("please fill in age : ");
                string age = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(age) && int.TryParse(age,out int iAge))
                {
                    exp = p => p.Age > iAge;
                }
            }
            {

                Console.WriteLine("-------3 expression lambda 2,simplify the possible input combination from users-----------------------");
                Expression<Func<People, bool>> lambdaExample = p => p.Name.Contains("Tom") && p.Age > 5;

                //Example: use type in different fields in the program: 

                 // 1 paramter p
                ParameterExpression pe = Expression.Parameter(typeof(People), "p");

                #region if the user type in name field

                // 2 get property Name and assemble with p
                //compiler:  MethodBase name2 = (MethodInfo) MethodBase.GetMethodFromHandle((RuntimeMethodHandle))  /*OpCode not supported: LdMemberToken*/
                PropertyInfo name = typeof(People).GetProperty("Name");
                MemberExpression nameExp = Expression.Property(pe, name);

                //3 Get the method name Contains, assemble with expression, add with parameter Tom.
                     //compiler: (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)), /*OpCode not supported: LdMemberToken*/
                MethodInfo contains = typeof(string).GetMethod("Contains", new Type[] { typeof(string)});
                ConstantExpression tom = Expression.Constant("Tom", typeof(string));
                MethodCallExpression containsExp = Expression.Call(nameExp, contains, tom);

                #endregion

                #region if the user type in Age field

                //4  get property Age and ssemble with p
                //(MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle))/*OpCode not supported: LdMemberToken*/
                PropertyInfo age = typeof(People).GetProperty("Age");
                MemberExpression ageExp = Expression.Property(pe, age);

                //5 compare with constant 5 and get binary expression 
                ConstantExpression constant5 = Expression.Constant(5, typeof(int));
                BinaryExpression greaterThan = Expression.GreaterThan(ageExp, constant5);

                #endregion


                #region Combine and build Expression tree

                //6 Binary
                BinaryExpression body = Expression.AndAlso(containsExp, greaterThan);

                // 7 assemble labmda
                Expression<Func<People, bool>> assembledExpression = Expression.Lambda<Func<People, bool>>(
                    body, 
                    new ParameterExpression[1] {pe}
                    );

                #endregion

                Func<People, bool> funcResult = assembledExpression.Compile();

                var test = assembledExpression.Compile().Invoke(new People()
                {
                    Id=10,
                    Age = 10,
                    Name ="Tom123"
                });

            }

        }

        public static void MapperTest()
        {
            {
                Console.WriteLine("--------------how to map different class------------------------");
                People people = new People()
                {
                    Id = 11,
                    Name = "jack",
                    Age = 31
                };
                PeopleCopy peopleCopy = new PeopleCopy()
                {
                    Id = people.Id,
                    Name = people.Name,
                    Age = people.Age
                };
                // copy 

                //method 1  reflection
                object o1 =  ReflectionMapper.Trans<People, PeopleCopy>(people);

                //method 2 serialize and deserialize, also use reflection, so not so fast as well.
                object o2 = SerializeMapper.Trans<People, PeopleCopy>(people);

                //method 3, for efficiency, use delegate. 
                Func<People, PeopleCopy> func = p =>
                {
                    //Console.WriteLine(p.Name);
                    return new PeopleCopy()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Age = p.Age
                    };
                };
                
                PeopleCopy p3 = func.Invoke(people);

                //method 4, using expression tree
                Console.WriteLine("--Map with dictionary------------------------");
                PeopleCopy p4 = ExpressionMapper.Trans<People, PeopleCopy>(people); //1st time create lambda
                PeopleCopy p5 = ExpressionMapper.Trans<People, PeopleCopy>(people);//will use cached lambda

                Console.WriteLine("--Map with generic cache, better than AutoMapper------------------------");
                PeopleCopy p6 = ExpressionGenericMapper<People, PeopleCopy>.Trans(people);
                PeopleCopy p7 = ExpressionGenericMapper<People, PeopleCopy>.Trans(people);

            }
            
        }

        public static void TestExpressionPerformance()
        {
            People people = new People()
            {
                Id = 11,
                Name = "jack",
                Age = 31
            };
            long common = 0;
            long generic = 0;
            long cache = 0;
            long reflection = 0;
            long serialize = 0;

            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = new PeopleCopy()
                    {
                        Id= people.Id,
                        Name =  people.Name,
                        Age =  people.Age
                    };
                }
                watch.Stop();
                common = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = ReflectionMapper.Trans<People, PeopleCopy>(people);
                }
                watch.Stop();
                reflection = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = SerializeMapper.Trans<People, PeopleCopy>(people);
                }
                watch.Stop();
                serialize = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = ExpressionMapper.Trans<People, PeopleCopy>(people);
                }

                watch.Stop();
                cache = watch.ElapsedMilliseconds;
            }
            {
                Stopwatch watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < 1_000_000; i++)
                {
                    PeopleCopy peopleCopy = ExpressionGenericMapper<People,PeopleCopy>.Trans(people);
                }
                watch.Stop();

                generic = watch.ElapsedMilliseconds;
            }

            Console.WriteLine($"common = { common} ms");
            Console.WriteLine($"reflection = { reflection} ms");
            Console.WriteLine($"serialize = { serialize} ms");
            Console.WriteLine($"cache = { cache} ms");
            Console.WriteLine($"generic = { generic} ms");//better than automapper
            Console.ReadKey();
        }


    }
}
