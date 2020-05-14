using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty.Extend
{
    public static class ExpressionExtend
    {
        public static Expression<Func<Type, bool>> And<T>( Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            ParameterExpression newParameter = Expression.Parameter(typeof(T),"c");
            NewExpressionVisitor 

        }




    }
}
