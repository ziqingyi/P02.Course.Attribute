using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Interface;

namespace P28.Course.Redis.Service
{

    /// <summary>
    /// Hash: similar to dictionary, get value by index. 
    /// </summary>
    public class RedisHashService : RedisBase
    {
        #region
        /// <summary>
        /// add key/value to hash id. 
        /// </summary>
        public bool SetEntryInHash(string hashid, string key, string value)
        {
            bool setSuccess = base.iClient.SetEntryInHash(hashid, key, value);
            return setSuccess;
        }
        /// <summary>
        /// add key/value if not exists, return true
        /// if key/value exists, not add, return false,
        /// </summary>
        public bool SetEntryInHashIfNotExists(string hashid, string key, string value)
        {
            bool res = base.iClient.SetEntryInHashIfNotExists(hashid, key, value);
            return res;
        }
        /// <summary>
        /// store t into hash.
        /// </summary>
        public void StoreAsHash<T>(T t)
        {
            base.iClient.StoreAsHash<T>(t);
        }
        #endregion


        #region Get
        /// <summary>
        /// Get T object with ID is id
        /// </summary>
        public T GetFromHash<T>(object id)
        {
            return base.iClient.GetFromHash<T>(id);
        }
        /// <summary>
        /// Get all hash id's key/value set
        /// </summary>
        public Dictionary<string, string> GetAllEntriesFromHash(string hashid)
        {
            Dictionary<string, string> keyValuePairs = base.iClient.GetAllEntriesFromHash(hashid);
            return keyValuePairs;
        }
        /// <summary>
        /// get nums of key value pairs in the hash id
        /// </summary>
        public long GetHashCount(string hashid)
        {
            return base.iClient.GetHashCount(hashid);
        }

        /// <summary>
        /// get all keys in the hash id
        /// </summary>
        public List<string> GetHashKeys(string hashid)
        {
            List<string> keylist = base.iClient.GetHashKeys(hashid);
            return keylist;
        }
        /// <summary>
        /// get all values in the hash id
        /// </summary>
        public List<string> GetHashValues(string hashid)
        {
            List<string> valueList = base.iClient.GetHashValues(hashid);
            return valueList;
        }
        /// <summary>
        /// get the value in the hash id's key. 
        /// </summary>
        public string GetValueFromHash(string hashid, string key)
        {
            string value = base.iClient.GetValueFromHash(hashid, key);
            return value;
        }
        /// <summary>
        /// in the hashid, get multi values based on several keys.
        /// </summary>

        public List<string> GetValuesFromHash(string hashid, string[] keys)
        {
            List<string> values = base.iClient.GetValuesFromHash(hashid, keys);
            return values;
        }
        #endregion

        #region delete
        /// <summary>
        /// in the hash id, remove the value of key. 
        /// </summary>
        public bool RemoveEntryFromHash(string hashid, string key)
        {
            bool res = base.iClient.RemoveEntryFromHash(hashid, key);
            return res;
        }
        #endregion

        #region other
        /// <summary>
        /// check whether in hashid, there is a value for Key: key. 
        /// </summary>
        public bool HashContainsEntry(string hashid, string key)
        {
            bool containsValueOfKey = base.iClient.HashContainsEntry(hashid, key);
            return containsValueOfKey;
        }
        /// <summary>
        /// add countBy to the value of key in the hash id. 
        /// </summary>
        public double IncrementValueInHash(string hashid, string key, double countBy)
        {
            double newValue = base.iClient.IncrementValueInHash(hashid, key, countBy);
            return newValue;
        }
        #endregion









    }
}
