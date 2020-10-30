using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P26.Course.Common
{
    public class CacheManager
    {
        private CacheManager()
        {

        }

        private static ICache cache = null;

        static CacheManager()
        {
            Console.WriteLine("CacheManager is initializing.....");

            cache = (ICache) Activator.CreateInstance(typeof(MyMemoryCache));

        }

        public static int Count
        {
            get
            {
                return cache.Count;

            }
        }

        public static bool Contains(string key)
        {
            return cache.Contains(key);
        }

        public static T GetData<T>(string key)
        {
            return cache.Get<T>(key);
        }

        //if there is no such key-value, create one using Func<T> acquire.
        public static T Get<T>(string key, Func<T> acquire, int cacheTime = 30)
        {
            if (!cache.Contains(key))
            {
                T result = acquire.Invoke();
                cache.Add(key,result,cacheTime);
            }

            return GetData<T>(key);
        }

        public static void Add(string key, object value, int expiryTime = 30)
        {
            if (Contains(key))
            {
                cache.Remove(key);
            }
            cache.Add(key,value,expiryTime);
        }

        public static void Remove(string key)
        {
            cache.Remove(key);
        }

        public static void RemoveAll()
        {
            cache.RemoveAll();
        }

    }
}
