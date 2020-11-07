using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Interface;

namespace P28.Course.Redis.Service
{
    public class RedisStringService :RedisBase
    {
        #region set value

        /// <summary>
        /// set key and value
        /// </summary>
        public bool Set<T>(string key, T value)
        {
            return base.iClient.Set<T>(key, value);
        }
        /// <summary>
        /// set key and value, and expiry time. 
        /// </summary>
        public bool Set<T>(string key, T value, DateTime dt)
        {
            return base.iClient.Set<T>(key, value, dt);
        }
        /// <summary>
        /// set key, value, and expiry time span.
        /// </summary>
        public bool Set<T>(string key, T value, TimeSpan sp)
        {
            return base.iClient.Set<T>(key, value, sp);
        }

        /// <summary>
        /// set multiple key and value
        /// </summary>
        public void Set(Dictionary<string, string> dic)
        {
            base.iClient.SetAll(dic);
        }
        #endregion

        #region append
        /// <summary>
        /// append value to existing key, if not there, then add
        /// </summary>
        public long Append(string key, string value)
        {
            return base.iClient.AppendToValue(key, value);
        }
        #endregion

        #region get value 
        /// <summary>
        /// get value for one key
        /// </summary>
        public string Get(string key)
        {
            return base.iClient.GetValue(key);
        }
        /// <summary>
        /// get string values for one list of string keys 
        /// </summary>
        public List<string> Get(List<string> keys)
        {
            return base.iClient.GetValues(keys);
        }

        /// <summary>
        /// get T values for one list of string keys
        /// </summary>
        public List<T> Get<T>(List<string> keys)
        {
            return base.iClient.GetValues<T>(keys);
        }
        #endregion

        #region  update old value to new value

        public string GetAndSetValue(string key, string newvalue)
        {
            string oldValue = base.iClient.GetAndSetValue(key, newvalue);
            return oldValue;
        }

        #endregion


        #region other methods

        /// <summary>
        /// get the length of the value
        /// </summary>
        public long GetLength(string key)
        {
            return base.iClient.GetStringCount(key);
        }
        /// <summary>
        /// increase key value, return key 
        /// </summary>
        public long Incr(string key)
        {
            return base.iClient.IncrementValue(key);
        }

        public long IncrBy(string key, int count)
        {
            return base.iClient.IncrementValueBy(key, count);
        }

        public long Decr(string key)
        {
            return base.iClient.DecrementValue(key);
        }

        public long DecrBy(string key, int count)
        {
            return base.iClient.DecrementValueBy(key, count);
        }

        #endregion



    }
}
