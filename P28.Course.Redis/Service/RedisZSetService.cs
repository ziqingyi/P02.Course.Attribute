using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        /// <summary>
        /// get key list,their scores are  from fromscore to toscore. from high to low. 
        /// </summary>
        public List<string> GetRangeFromSortedSetByHightestScore(string key, double fromscore, double toscore)
        {
            List<string> keyList = base.iClient.GetRangeFromSortedSetByHighestScore(key, fromscore, toscore);
            return keyList;
        }
        /// <summary>
        /// get key list, their scores are from fromscore to toscore. from low to high. 
        /// </summary>
        public List<string> GetRangeFromSortedSetByLowestScore(string key, double fromscore, double toscore)
        {
            List<string> keyList = base.iClient.GetRangeFromSortedSetByLowestScore(key, fromscore, toscore);
            return keyList;
        }

        /// <summary>
        /// get key list,with their scores are from fromscore to toscore. from  high to low. 
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByHighestScore(string key, double fromscore,
            double toscore)
        {
            IDictionary<string, double> keyAndscore =
                base.iClient.GetRangeWithScoresFromSortedSetByHighestScore(key, fromscore, toscore);
            return keyAndscore;
        }
        /// <summary>
        /// get key list,with their scores are from fromscore to toscore. from low to high. 
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetByLowestScore(string key, double fromscore,
            double toscore)
        {
            IDictionary<string, double> keyAndscore=
                base.iClient.GetRangeWithScoresFromSortedSetByLowestScore(key, fromscore, toscore);
            return keyAndscore;
        }
        /// <summary>
        /// get key list,with index from  fromRank to toRank. 
        /// </summary>
        public List<string> GetRangeFromSortedSet(string key, int fromRank, int toRank)
        {
            List<string> keyList = base.iClient.GetRangeFromSortedSet(key, fromRank, toRank);
            return keyList;
        }
        /// <summary>
        /// get key list,with index from  fromRank to toRank. sorted desc
        /// </summary>
        public List<string> GetRangeFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            List<string> keyList = base.iClient.GetRangeFromSortedSetDesc(key, fromRank, toRank);
            return keyList;
        }

        /// <summary>
        /// get key, score ,with index from  fromRank to toRank. 
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSet(string key, int fromRank, int toRank)
        {
            IDictionary<string, double> keyAndscore =
                base.iClient.GetRangeWithScoresFromSortedSet(key, fromRank, toRank);
            return keyAndscore;
        }

        /// <summary>
        /// get key, score,with index from  fromRank to toRank. sorted desc. 
        /// </summary>
        public IDictionary<string, double> GetRangeWithScoresFromSortedSetDesc(string key, int fromRank, int toRank)
        {
            IDictionary<string, double> keyAndscore =
                base.iClient.GetRangeWithScoresFromSortedSetDesc(key, fromRank, toRank);
            return keyAndscore;
        }

        #endregion


        #region delete

        /// <summary>
        /// delete the value of key
        /// </summary>
        public bool RemoveItemFromSortedSet(string key, string value)
        {
            bool delSuccess = base.iClient.RemoveItemFromSortedSet(key, value);
            return delSuccess;
        }
        /// <summary>
        /// remove keys with index from minRank to maxRank
        /// </summary>
        public long RemoveRangeFromSortedSet(string key, int minRank, int maxRank)
        {
            long res = base.iClient.RemoveRangeFromSortedSet(key, minRank, maxRank);
            return res;
        }
        /// <summary>
        /// delete keys with score scope
        /// </summary>
        public long RemoveRangeFromSortedSetByScore(string key, double fromscore, double toscore)
        {
            return base.iClient.RemoveRangeFromSortedSetByScore(key, fromscore, toscore);
        }

        /// <summary>
        /// for key, delete values with largest score.
        /// </summary>
        public string PopItemWithHighestScoreFromSortedSet(string key)
        {
            string res = base.iClient.PopItemWithHighestScoreFromSortedSet(key);
            return res;
        }
        /// <summary>
        /// for key, remove items with lowest score.
        /// </summary>
        public string PopItemWithLowestScoreFromSortedSet(string key)
        {
            string res = base.iClient.PopItemWithLowestScoreFromSortedSet(key);
            return res;
        }

        #endregion


        #region other

        /// <summary>
        /// check whether key has this value.
        /// </summary>
        public bool SortedSetContainsItem(string key, string value)
        {
            bool exists = base.iClient.SortedSetContainsItem(key, value);
            return exists;
        }
        /// <summary>
        /// add scoreBy to the value for the key. 
        /// </summary>
        public double IncrementItemInSortedSet(string key, string value, double scoreBy)
        {
            double addedResult = base.iClient.IncrementItemInSortedSet(key, value, scoreBy);
            return addedResult;
        }



        
        #endregion  




    }
}
