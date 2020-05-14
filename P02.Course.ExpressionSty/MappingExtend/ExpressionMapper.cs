using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace P05.Course.ExpressionSty.MappingExtend
{
    public class ExpressionMapper
    {
        // dictionary cache, stored as hash distribution. find key through hash and search in memory. 
        private static Dictionary<string,object> _Dic = new Dictionary<string, object>();

        /// <summary>
        /// using dictionary
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            string key = string.Format("funckey_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);
            if (!_Dic.ContainsKey(key))
            {
                ParameterExpression parameterExpression = Expression.Parameter(typeof(TIn),"p");
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

                Func<TIn, TOut> func = lambda.Compile();
                _Dic[key] = func;
            }

            return ((Func<TIn,TOut>)_Dic[key]).Invoke(tIn);

        }

    }
}
