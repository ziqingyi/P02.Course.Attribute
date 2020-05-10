using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.ExpressionSty.Visitor
{
    public class OperationsVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            Expression result =  this.Visit(expression);
            return result;
        }
        // visit is the Entry
        public override Expression Visit(Expression node)
        {
            Console.WriteLine($"visit {node.ToString()}");
            Expression result = base.Visit(node);
            return result;
        }

        protected override Expression VisitBinary(BinaryExpression b)
        {
            Expression left = this.Visit(b.Left);
            Expression right = this.Visit(b.Right);

            if (b.NodeType == ExpressionType.Add)
            {
                
                Expression res = Expression.Subtract(left, right);
                return res;
            }
            else if (b.NodeType == ExpressionType.Multiply)
            {
                Expression res = Expression.Divide(left, right);
                /*Expression res = Expression.Divide(b.Left, b.Right);
                  this way  don't get left/right expression
                  this only do once for multiply to divide, and not work for object. 
                */
                return res;
            }
            Expression result = base.VisitBinary(b);// default binary search
            return result;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.WriteLine("override VisitConstant");
            Expression result = base.VisitConstant(node);
            return result;
        }


    }
}
