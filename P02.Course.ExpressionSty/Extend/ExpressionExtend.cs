﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty.Extend
{
    //Combine expression:  expr1 and expr2
    //extend the expression operation: And Or Not
    public static class ExpressionExtend
    {
        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
            {
                return expr2;
            }

            ParameterExpression newParameter = Expression.Parameter(typeof(T),"c");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);

            Expression left = visitor.Replace(expr1.Body);
            Expression right = visitor.Replace(expr2.Body);
            Expression body = Expression.And(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
            Expression<Func<T, bool>> expr2)
        {
            if (expr1 == null)
            {
                return expr2;
            }

            ParameterExpression newParameter = Expression.Parameter(typeof(T), "c");
            NewExpressionVisitor visitor = new NewExpressionVisitor(newParameter);

            Expression left = visitor.Replace(expr1.Body);
            Expression right = visitor.Replace(expr2.Body);
            Expression body = Expression.Or(left, right);
            return Expression.Lambda<Func<T, bool>>(body, newParameter);
        }

        public static Expression<Func<T, bool>> Not<T>(this Expression<Func<T, bool>> expr)
        {
            if (expr == null) throw new Exception("expr is null");

            ParameterExpression candidateExpr = expr.Parameters[0];
            Expression body = Expression.Not(expr.Body);

            return Expression.Lambda<Func<T, bool>>(body, candidateExpr);
        }

    }
}
