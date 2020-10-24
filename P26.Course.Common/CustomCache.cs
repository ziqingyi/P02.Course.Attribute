using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P26.Course.Common
{
    public class CustomCache
    {

        //1 private: safe for data 
        //2 static: not be GC
        //3 dictionary is efficient. 

        private static Dictionary<string,object> customCacheDictionary = new Dictionary<string, object>();

        public static void Add(string key, object oValue)
        {
            if (!customCacheDictionary.ContainsKey(key))
            { 
                customCacheDictionary.Add(key,oValue);
            }
            else
            {
                customCacheDictionary[key] = oValue;
            }
            
        }

        //GET value through key
        public static T Get<T>(string key)
        {
            if (Exists(key))
            {
                T res = (T)customCacheDictionary[key];
                return res;
            }
            else
            {
                return default(T);
            }
        }

        public static bool Exists(string key)
        {
            bool res = customCacheDictionary.ContainsKey(key);
            return res;
        }

        //Get value with key and Func which can generate T. 
        public static T GetT<T>(string key, Func<T> func)
        {
            T t = default(T);
            if (!Exists(key))
            {
                t = func.Invoke();
                customCacheDictionary.Add(key,t);
            }
            else
            {
                t = Get<T>(key);
            }
            return t;
        }


    }
}
