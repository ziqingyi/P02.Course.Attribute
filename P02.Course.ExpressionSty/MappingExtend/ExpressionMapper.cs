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
            //string key = string.Format("funcky_{0}_{1}", typeof(TIn).FullName, typeof(TOut).FullName);
            //if (!_Dic.ContainsKey(key))
            //{
            //}
            TOut tOut = Activator.CreateInstance<TOut>();
            foreach (var itemOut in tOut.GetType().GetProperties())
            {
                PropertyInfo propIn = tIn.GetType().GetProperty(itemOut.Name);
                itemOut.SetValue(tOut,propIn.GetValue(tIn));
            }

            foreach (var itemOut in tOut.GetType().GetFields())
            {
                FieldInfo fieldIn = tIn.GetType().GetField(itemOut.Name);
                itemOut.SetValue(tOut,fieldIn.GetValue(tIn));
            }

            return tOut;

        }

    }
}
