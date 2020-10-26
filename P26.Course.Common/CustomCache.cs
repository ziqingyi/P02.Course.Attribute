using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P26.Course.Common
{
    public class CustomCache
    {

        private static readonly object CustomCache_Lock = new object();

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

        //remove by condition
        public static void RemoveCondition(Func<string, bool> func)
        {
            List<string> keyList = new List<string>();
            lock (CustomCache_Lock)
            {
                //get all keys meets the requirements
                foreach (string key in customCacheDictionary.Keys)
                {
                    if (func.Invoke(key))
                    {
                        keyList.Add(key);
                    }
                }

                //remove items in the keys
                keyList.ForEach(s => Remove(s));

            }
        }

        public static void Remove(string key)
        {
            lock (CustomCache_Lock)
            {
                customCacheDictionary.Remove(key);
            }
        }




    }
}
