using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------------Expression---------------------");
            {
                Console.WriteLine("-----------Basic Expression---------------");
                ExpressionTest.ShowBasicLambdaToExpressionToDelegate();
                ExpressionTest.ShowTestCaseForExpressionToDelegate();
                ExpressionTreeVisualizer.Show();
            }
            {
                Console.WriteLine("-----------Mapping test---------------");
                ExpressionTest.MapperTest();
            }
            {
                Console.WriteLine("-----------Mapping performance---------------");
                ExpressionTest.TestExpressionPerformance();
            }
            {
                Console.WriteLine("---------Expression Visitor  test ------------------");
                ExpressionVisitorTest.Show();
            }
            {
                Console.WriteLine("---------Expression Visitor  test ------------------");
                ExpressionTreeBlockExpression.Show();


            }

        }
    }
}
