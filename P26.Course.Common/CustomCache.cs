using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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

        static CustomCache()
        {

            Action removeExpiredData = () =>
            {
                while (true)
                {

                    try
                    {
                        //list to store the keys need to be deleted. 
                        List<string> keyList = new List<string>();

                        lock (CustomCache_Lock)
                        {
                            foreach (string key in customCacheDictionary.Keys)
                            {
                                DataModel model = (DataModel) customCacheDictionary[key];

                                //check whether key-value should be deleted. 
                                if (model.dataObsoleteType != ObsoleteType.Never && model.DeadLine < DateTime.Now)
                                {
                                    keyList.Add(key);
                                }
                            }
                            //note: remove method use lock as well, but in same thread, so will not lock

                            //must remove outside of foreach, otherwise it will have issue when iterating. 
                            //for same reason, using lock in case other threads modify it.
                            keyList.ForEach(s=>Remove(s));
                        }

                        Thread.Sleep(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            };


            Task.Run(removeExpiredData);
        }


        #region add new value to Cache Dictionary
        //Add value with no expiry time
        public static void Add(string key, object oValue)
        {
            lock (CustomCache_Lock)
            {
                //build DataModel with obsolete type
                DataModel valueModel = new DataModel()
                {
                    Value = oValue,
                    dataObsoleteType = ObsoleteType.Never
                };

                //if still not have this key(in case other threads already added)
                if (!customCacheDictionary.ContainsKey(key))
                {
                    customCacheDictionary.Add(key, valueModel);
                }
                
            }

        }

        //Add value with absolute expiry time
        public static void Add(string key, object oValue, int timeOutInSeconds)
        {
            lock (CustomCache_Lock)
            {
                //build DataModel
                DataModel valueModel = new DataModel()
                {
                    Value = oValue,
                    dataObsoleteType = ObsoleteType.Absolutely,
                    DeadLine = DateTime.Now.AddSeconds(timeOutInSeconds)
                };

                customCacheDictionary.Add(key, valueModel);
            }


        }
        //Add value with relative expiry time
        public static void Add(string key, object oValue, TimeSpan duration)
        {
            lock (CustomCache_Lock)
            {
                //build DataModel
                DataModel valueModel = new DataModel()
                {
                    Value = oValue,
                    dataObsoleteType = ObsoleteType.Relative,
                    DeadLine = DateTime.Now.Add(duration),
                    Duration = duration
                };

                customCacheDictionary.Add(key, valueModel);
            }
        }

        #endregion


        #region GET value 

        //GET value through key
        public static T Get<T>(string key)
        {
            if (Exists(key))
            {
                DataModel model = (DataModel)customCacheDictionary[key];
                T res = (T)(model.Value);
                return res;
            }
            else
            {
                return default(T);
            }
        }

        //Get value with key and Func which can generate T. 
        public static T GetT<T>(string key, Func<T> func)
        {
            T t = default(T);

            lock (CustomCache_Lock)
            {
                //lock and then check exists and if not there, create one and add(this add method has lock).
                if (!Exists(key))
                {
                    t = func.Invoke();
                    Add(key, t);
                }
                else
                {
                    t = Get<T>(key);
                }
            }


            return t;
        }

        public static List<string> GetAllKeys()
        {
            List<string> keys = new List<string>();

            lock (CustomCache_Lock)
            {
                //lock, in case other threads modify it. 
                foreach (string key in customCacheDictionary.Keys)
                {
                    keys.Add(key);
                }
            }

            return keys;
        }


        #endregion





        #region remove value

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
                //if key is not null, remove will return true or false
                customCacheDictionary.Remove(key);
            }
        }

        public static void RemoveAll()
        {
            lock (CustomCache_Lock)
            {
                customCacheDictionary.Clear();
            }
        }

        #endregion


        #region check Exists

        public static bool Exists(string key)
        {

            if (customCacheDictionary.ContainsKey(key))
            {

                DataModel model = (DataModel)customCacheDictionary[key];
                if (model.dataObsoleteType == ObsoleteType.Never) //never expire
                {
                    return true;
                }

                if (model.DeadLine < DateTime.Now) // exceed the expiry time
                {
                    lock (CustomCache_Lock)
                    {
                        customCacheDictionary.Remove(key);
                    }

                    return false;
                }

                if (model.dataObsoleteType == ObsoleteType.Relative)//relative expiry
                {
                    model.DeadLine = DateTime.Now.Add(model.Duration);
                    return true;
                }

            }
        
            return false;
            
        }       

        #endregion


 


    }


    internal class DataModel
    {
        public object Value { get; set; }

        public ObsoleteType dataObsoleteType { get; set; }

        public DateTime DeadLine { get; set; }

        public TimeSpan Duration { get; set; }


        public event Action DataClearEvent;

    }



    public enum ObsoleteType
    {
        Never,
        Absolutely,
        Relative
    }





}
