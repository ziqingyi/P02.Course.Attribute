using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.ExpressionSty.Visitor
{
    public class ConditionBuilderVisitor: ExpressionVisitor
    {
        private Stack<string> _StringStack = new Stack<string>();

        public string Condition()
        {
            string condition = string.Concat(this._StringStack.ToArray());
            this._StringStack.Clear();
            return condition;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if(node == null)
                throw new ArgumentNullException("BinaryExpression");
            this._StringStack.Push(")");
            base.Visit(node.Right);
            this._StringStack.Push( " " + node.NodeType.ToSqlOperator() + " ");
            base.Visit(node.Left);
            this._StringStack.Push("(");

            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            if (node == null)
                throw new ArgumentNullException("MemberExpression");
            this._StringStack.Push(" [" + node.Member.Name + "] ");
            return node;
        }




    }
}
