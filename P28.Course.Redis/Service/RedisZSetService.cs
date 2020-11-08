using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P28.Course.Redis.Interface;

namespace P28.Course.Redis.Service
{
    /// <summary>
    /// Sorted Sets: add a score to each element, to make the elements sorted in set.
    /// 1 in game, some sore has weight. 
    /// </summary>
    public class RedisZSetService : RedisBase
    {
        #region add
        /// <summary>
        /// add key value
        /// </summary>
        public bool Add(string key, string value)
        {
            bool addSuccess = base.iClient.AddItemToSortedSet(key, value);
            return addSuccess;
        }
        /// <summary>
        /// add key / value, and set the score of the value.
        /// </summary>
        public bool AddItemToSortedSet(string key, string value, double score)
        {
            bool addSuccess = base.iClient.AddItemToSortedSet(key, value, score);
            return addSuccess;
        }
        /// <summary>
        /// add values to key, every value has score
        /// </summary>
        public bool AddRangeToSortedSet(string key, List<string> values, double score)
        {
            bool addSuccess = base.iClient.AddRangeToSortedSet(key, values, score);
            return addSuccess;
        }

        public bool AddRangeToSortedSet(string key, List<string> values, long score)
        {
            bool addSuccess = base.iClient.AddRangeToSortedSet(key, values, score);
            return addSuccess;
        }

        #endregion

        #region Get
        /// <summary>
        /// get all values of the key
        /// </summary>
        public List<string> GetAll(string key)
        {
            List<string> values = base.iClient.GetAllItemsFromSortedSet(key);
            return values;
        }

        public List<string> GetAllDesc(string key)
        {
            List<string> valuesDesc = base.iClient.GetAllItemsFromSortedSetDesc(key);
            return valuesDesc;
        }
        /// <summary>
        /// get all values with scores  belongs to the key. 
        /// </summary>
        public IDictionary<string, double> GetAllWithScoresFromSortedSet(string key)
        {
            IDictionary<string, double> valueWithScore = base.iClient.GetAllWithScoresFromSortedSet(key);
            return valueWithScore;
        }
        /// <summary>
        /// get the value's index belongs to the key. 
        /// </summary>
        public long GetItemIndexInSortedSet(string key, string value)
        {
            long index = base.iClient.GetItemIndexInSortedSet(key, value);
            return index;
        }
        /// <summary>
        /// get the value's index belongs to the key. in descending sequence. 
        /// </summary>
        public long GetItemIndexInSortedSetDesc(string key, string value)
        {
            long index = base.iClient.GetItemIndexInSortedSetDesc(key, value);
            return index;
        }
        /// <summary>
        /// get score for values in key. 
        /// </summary>
        public double GetItemScoreInSortedSet(string key, string value)
        {
            double score = base.iClient.GetItemScoreInSortedSet(key, value);
            return score;
        }
        /// <summary>
        /// get key's number of sorted set
        /// </summary>
        public long GetSortedSetCount(string key)
        {
            long count = base.iClient.GetSortedSetCount(key);
            return count;
        }




        #endregion





    }
}
