using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using P05.Course.ExpressionSty.DBExtend;

namespace P05.Course.ExpressionSty.Visitor
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

        public override Expression Visit(Expression node)
        {
            Console.WriteLine($"now we start visit Expression: {node.ToString()}"+ Environment.NewLine);
            Expression result =  base.Visit(node);
            return result;
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Console.WriteLine($"now we start visit Binary Expression: {node.ToString()}" + Environment.NewLine);
            if (node == null)
            {
                throw new ArgumentNullException("BinaryExpression");
            }
            this._StringStack.Push(")");
            Console.WriteLine("                         show stack: "+  string.Concat(this._StringStack.ToArray()) + Environment.NewLine);
            base.Visit(node.Right);
            this._StringStack.Push( " " + node.NodeType.ToSqlOperator() + " ");
            Console.WriteLine("                         show stack: " + string.Concat(this._StringStack.ToArray()) + Environment.NewLine);
            base.Visit(node.Left);
            this._StringStack.Push("(");
            Console.WriteLine("                         show stack: " + string.Concat(this._StringStack.ToArray()) + Environment.NewLine);
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Console.WriteLine($"now we start visit Member Expression: {node.ToString()}" + Environment.NewLine);
            if (node == null)
            {
                throw new ArgumentNullException("MemberExpression");
            }
            this._StringStack.Push(" [" + node.Member.Name + "] ");
            Console.WriteLine("                         show stack: " + string.Concat(this._StringStack.ToArray()) + Environment.NewLine);
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.WriteLine($"now we start visit Constant: {node.ToString()}" + Environment.NewLine);
            if (node == null)
            {
                throw new ArgumentNullException("ConstantExpression");
            }
            this._StringStack.Push(" '"+node.Value+"' ");
            Console.WriteLine("                         show stack: " + string.Concat(this._StringStack.ToArray()) + Environment.NewLine);
            return node;
        }

        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            Console.WriteLine($"now we start visit method: {m}" + Environment.NewLine);
            if (m == null)
            {
                throw new ArgumentNullException("MethodCallExpression");
            }

            string format;
            switch (m.Method.Name)
            {
                case "StartsWith":
                    format = "({0} LIKE {1}+'%')";
                    break;
                case "Contains":
                    format = "({0} LIKE {1}+'%')";
                    break;
                case "EndsWith":
                    format = "({0} LIKE '%'+{1})";
                    break;
                default:
                    throw new NotSupportedException(m.NodeType + " is not supported!");
            }

            this.Visit(m.Object);
            this.Visit(m.Arguments[0]);
            string right = this._StringStack.Pop();
            string left = this._StringStack.Pop();
            this._StringStack.Push(string.Format(format,left,right));
            Console.WriteLine("                         show stack: " + string.Concat(this._StringStack.ToArray()) + Environment.NewLine);
            return m;
        }
    }
}
