﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty.Extend
{
    //create new expression
    internal class NewExpressionVisitor : ExpressionVisitor
    {
        public ParameterExpression _NewParameter { get; private set; }

        public NewExpressionVisitor(ParameterExpression param)
        {
            this._NewParameter = param;
        }

        public Expression Relace(Expression exp)
        {
            return this.Visit(exp);
        }

        protected override Expression VisitParameter(ParameterExpression node)
        {
            return this._NewParameter;
        }
    }
}
