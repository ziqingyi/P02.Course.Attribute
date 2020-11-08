using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Interface;
using ServiceStack;

namespace P28.Course.Redis.Service
{
    public class RedisSetService:RedisBase
    {
        #region add
        /// <summary>
        /// add value to key set
        /// </summary>
        public void Add(string key, string value)
        {
            base.iClient.AddItemToSet(key,value);
        }

        /// <summary>
        /// add list to key set
        /// </summary>
        public void Add(string key, List<string> list)
        {
            base.iClient.AddRangeToSet(key,list);
        }
        #endregion

        #region Get value
        /// <summary>
        /// get random item from set of values
        /// </summary>
        public string GetRandomItemFromSet(string key)
        {
            return base.iClient.GetRandomItemFromSet(key);
        }
        /// <summary>
        /// get num of values belongs to the key
        /// </summary>
        public long GetCount(string key)
        {
            return base.iClient.GetSetCount(key);
        }
        /// <summary>
        /// get all items from value set of the key. 
        /// </summary>
        public HashSet<string> GetAllItemsFromSet(string key)
        {
            return base.iClient.GetAllItemsFromSet(key);
        }
        #endregion

        #region delete
        /// <summary>
        /// delete one of the values randomly. 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string RandomRemoveItemFromSet(string key)
        {
            return base.iClient.PopItemFromSet(key);
        }
        /// <summary>
        /// remove all items from the key. 
        /// </summary>
        public void RemoveItemFromSet(string key, string value)
        {
            base.iClient.RemoveItemFromSet(key, value);
        }

        #endregion


        #region other

        /// <summary>
        /// move the value from values in fromkey, to the value set of tokey. 
        /// </summary>
        public void MoveBetweenSets(string fromkey, string tokey, string value)
        {
            base.iClient.MoveBetweenSets(fromkey, tokey, value);
        }

        /// <summary>
        /// get unions of values from different keys
        /// </summary>
        public HashSet<string> GetUnionFromSets(params string[] keys)
        {
            return base.iClient.GetUnionFromSets(keys);
        }
        /// <summary>
        /// get intersect from value sets of different keys
        /// </summary>
        public HashSet<string> GetIntersectFromSets(params string[] keys)
        {
            return base.iClient.GetIntersectFromSets(keys);
        }
        /// <summary>
        /// get values in fromKey's value set, but not in tokeys' value set
        /// </summary>
        /// <param name="fromKey">original value set</param>
        /// <param name="tokeys">other value sets</param>
        /// <returns></returns>
        public HashSet<string> GetDifferencesFromSet(string fromKey, params string[] tokeys)
        {
            return base.iClient.GetDifferencesFromSet(fromKey, tokeys);
        }
        /// <summary>
        /// combine/ union all values of keys and put into newkey's value set. 
        /// </summary>
        public void StoreUnionFromSets(string newkey, string[] keys)
        {
            base.iClient.StoreUnionFromSets(newkey,keys);
        }
        /// <summary>
        /// compare the values in fromkey and keys, put all values in fromkey but not in keys' value set, into newkey's value set. 
        /// </summary>
        public void StoreDifferencesFromSet(string newkey, string fromkey, string[] keys)
        {
            base.iClient.StoreDifferencesFromSet(newkey, fromkey,keys);
        }

        #endregion





    }
}
