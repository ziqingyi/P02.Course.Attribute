using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace P02.Course.ExpressionSty
{
    public class ExpressionTreeVisualizer
    {
        public static void Show()
        {
            {
                Console.WriteLine("--------------Expression initialization -----------------------");
                Expression<Func<int,int>> expression = (n) => n + 234 + 156;
            }

            {
                Console.WriteLine("--------------compiler explain-----------------------");
                ParameterExpression parameterExpression = Expression.Parameter(typeof(int), "n");
                Expression<Func<int, int>> expressionBeingCompiled =
                    Expression.Lambda<Func<int, int>>(
                        Expression.Add(
                             Expression.Add(parameterExpression, Expression.Constant(234, typeof(int))),
                            Expression.Constant(156, typeof(int))),
                        new ParameterExpression[1]
                        {
                            parameterExpression
                        }
                        );
            }
            {
                Console.WriteLine("--------------parts analysis-----------------------");
                ParameterExpression parameterLeft = Expression.Parameter(typeof(int), "n");
                ConstantExpression leftRight = Expression.Constant(234);
                BinaryExpression left = Expression.Add(parameterLeft, leftRight);

                ConstantExpression right = Expression.Constant(156);
                BinaryExpression plus = Expression.Add(left, right);

                Expression<Func<int,int>> expressionCombine = Expression.Lambda<Func<int,int>>(plus, new ParameterExpression[1] { parameterLeft });

                int iResult = expressionCombine.Compile().Invoke(12);

            }
            {
                Console.WriteLine("--------------expression lambda-----------------------");
                //compile and find the compiler version
                Expression<Func<People, bool>> lambda = x => x.Id.ToString().Equals("5");
            }
            {
                Console.WriteLine("--------------expression lambda 2-----------------------");
                //compile and find the compiler version
                Expression<Func<People, bool>> lambda = p => p.Name.Contains("Tom") && p.Age > 5;
            }
            {
                Console.WriteLine("--------------expression lambda 3-----------------------");
                //compile and find the compiler version
                Func<People, PeopleCopy> lambda = p =>
                {
                    //Console.WriteLine(p.Name);
                    return new PeopleCopy()
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Age = p.Age
                    };
                };
            }
        }


    }
}
