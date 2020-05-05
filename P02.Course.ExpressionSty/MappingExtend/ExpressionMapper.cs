using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace P02.Course.ExpressionSty.MappingExtend
{
    public class ExpressionMapper
    {
        // dictionary catch, hash
        private static Dictionary<string,object> _Dic = new Dictionary<string, object>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static TOut Trans<TIn, TOut>(TIn tIn)
        {
            string key = string.Format("funckey_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);






        }

    }
}
