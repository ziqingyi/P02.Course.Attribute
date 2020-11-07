using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Interface;
using ServiceStack.Redis;

namespace P28.Course.Redis.Service
{
    /// <summary>
    /// Redis list is a doubly linked list, more efficient in search, but cost more memory. used in Redis for blocking queue.
    /// The two node links allow traversal of the list in either direction.
    /// While adding or removing a node in a doubly linked list requires changing more links than the same operations on a singly linked list,
    /// the operations are simpler and potentially more efficient (for nodes other than first nodes)
    /// because there is no need to keep track of the previous node during traversal or no need to traverse the list to find the previous node,
    /// so that its link can be modified.
    /// </summary>
    public class RedisListService :RedisBase
    {
        #region assign value

        /// <summary>
        /// add value from left
        /// </summary>
        public void LPush(string key, string value)
        {
            base.iClient.PushItemToList(key,value);
        }
        /// <summary>
        /// add value from left, set expiry time
        /// </summary>
        public void LPush(string key, string value, DateTime dt)
        {
            base.iClient.PushItemToList(key, value);
            base.iClient.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// add value from left, set expiry time interval.
        /// </summary>
        public void LPush(string key, string value, TimeSpan sp)
        {
            base.iClient.PushItemToList(key,value);
            base.iClient.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// add value from right side
        /// </summary>
        public void RPush(string key, string value)
        {
            base.iClient.PrependItemToList(key,value);
        }
        /// <summary>
        /// add value from right side, and set expiry time. 
        /// </summary>
        public void RPush(string key, string value, DateTime dt)
        {
            base.iClient.PrependItemToList(key,value);
            base.iClient.ExpireEntryAt(key, dt);
        }
        /// <summary>
        /// add value from right side, and set expiry time span. 
        /// </summary>
        public void RPush(string key, string value, TimeSpan sp)
        {
            base.iClient.PrependItemToList(key,value);
            base.iClient.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// add key value
        /// </summary>
        public void Add(string key, string value)
        {
            base.iClient.AddItemToList(key, value);
        }
        public void Add(string key, string value, DateTime dt)
        {
            base.iClient.AddItemToList(key,value);
            base.iClient.ExpireEntryAt(key, dt);
        }
        public void Add(string key, string value, TimeSpan sp)
        {
            base.iClient.AddItemToList(key,value);
            base.iClient.ExpireEntryIn(key, sp);
        }

        /// <summary>
        /// add multiple values
        /// </summary>
        public void Add(string key, List<string> values)
        {
            base.iClient.AddRangeToList(key,values);
        }
        public void Add(string key, List<string> values, DateTime dt)
        {
            base.iClient.AddRangeToList(key, values);
            base.iClient.ExpireEntryAt(key, dt);
        }
        public void Add(string key, List<string> values, TimeSpan sp)
        {
            base.iClient.AddRangeToList(key, values);
            base.iClient.ExpireEntryIn(key, sp);
        }

        #endregion

        #region get values
        /// <summary>
        /// get number of values in the key.
        /// </summary>
        public long Count(string key)
        {
            return base.iClient.GetListCount(key);
        }

        /// <summary>
        /// Get all values based on key
        /// </summary>
        public List<string> Get(string key)
        {
            return base.iClient.GetAllItemsFromList(key);
        }
        /// <summary>
        /// get values from key, value with from start to end
        /// </summary>
        public List<string> Get(string key, int start, int end)
        {
            return base.iClient.GetRangeFromList(key, start, end);
        }

        #endregion


        #region blocking

        /// <summary>
        /// remove a value from the end of the list of values. blocking time is sp.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public string BlockingPopItemFromList(string key, TimeSpan? sp)
        {
            string res =  base.iClient.BlockingPopItemFromList(key, sp);
            return res;
        }

        public ItemRef BlockingPopItemFromLists(string[] keys, TimeSpan? sp)
        {
            ItemRef res = base.iClient.BlockingPopItemFromLists(keys, sp);
            return res;
        }







        
        #endregion












    }
}
