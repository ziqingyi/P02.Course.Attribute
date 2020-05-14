using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using P05.Course.ExpressionSty.Visitor;

namespace P05.Course.ExpressionSty.DBExtend
{
    public static class ExpressionExtension
    {
        public static void BatchDelete<T>(this IQueryable<T> entities, Expression<Func<T, bool>> expr)
        {
            ConditionBuilderVisitor visitor = new ConditionBuilderVisitor();
            visitor.Visit(expr);
            string condition = visitor.Condition();
            // get by generic type T, condition may use T as well
            string sql = string.Format("DELETE FROM [{0}] WHERE [{1}];",typeof(T).Name,condition);
            // then execute the sql 
        }





    }
}
