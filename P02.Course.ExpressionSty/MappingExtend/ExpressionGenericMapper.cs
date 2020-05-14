﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty.MappingExtend
{
    public class ExpressionGenericMapper<TIn, TOut>
    {
        private static Func<TIn, TOut> _FUNC = null;
        static ExpressionGenericMapper()
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn), "p");
            List<MemberBinding> memberBindingList = new List<MemberBinding>();
            foreach (PropertyInfo item in typeof(TOut).GetProperties())
            {
                MemberExpression property =
                    Expression.Property(parameterExpression, typeof(TIn).GetProperty(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            foreach (FieldInfo item in typeof(TOut).GetFields())
            {
                MemberExpression property = Expression.Field(parameterExpression, typeof(TIn).GetField(item.Name));
                MemberBinding memberBinding = Expression.Bind(item, property);
                memberBindingList.Add(memberBinding);
            }

            MemberInitExpression memberInitExpression =
                Expression.MemberInit(Expression.New(typeof(TOut)), memberBindingList.ToArray());

            Expression<Func<TIn, TOut>> lambda = Expression.Lambda<Func<TIn, TOut>>(memberInitExpression,
                new ParameterExpression[]
                {
                    parameterExpression
                });

            _FUNC = lambda.Compile();
        }

        public static TOut Trans(TIn t)
        {
            return _FUNC(t);
        }


    }
}
