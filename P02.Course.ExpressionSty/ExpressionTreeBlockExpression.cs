using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty
{
    class ExpressionTreeBlockExpression
    {
        public static void Show()
        {
            //Represents a block that contains a sequence of expressions where variables can be defined.

            MethodCallExpression mce = Expression.Call(
                null,
                typeof(Console).GetMethod("Write", new[] {typeof(string)}),
                Expression.Constant("helloWorld!"));

            ConstantExpression ce = Expression.Constant(42);

            BlockExpression blockExpr = Expression.Block(mce,ce);

            var lambdaExp = Expression.Lambda<Func<int>>(blockExpr);

            //two ways to call
            lambdaExp.Compile().Invoke();
            lambdaExp.Compile()();

        }


    }
}
