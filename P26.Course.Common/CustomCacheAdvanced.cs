using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P26.Course.Common
{
    public class CustomCacheAdvanced
    {
        private static int CPUNumer = 0;
        private static List<Dictionary<string,object>> dictionaryList = new List<Dictionary<string, object>>();
        private static List<object> LockList = new List<object>();

        static CustomCacheAdvanced()
        {
            CPUNumer = 4;

            //prepare dictionary for storing data and it's corresponding lock
            for (int i = 0; i < CPUNumer; i++)
            {
                dictionaryList.Add(new Dictionary<string, object>());
                LockList.Add(new object());
            }

            Action backgroundCheckUpdateAction= () =>
            {
                while (true)
                {
                    try
                    {
                        for (int i = 0; i < CPUNumer; i++)
                        {
                            List<string> keyToDelList= new List<string>();

                            lock (LockList[i])//only lock one dictionary, lock fewer data when cleaning.
                            {

                                foreach (string key in dictionaryList[i].Keys)
                                {
                                    DataModel model = (DataModel)(dictionaryList[i][key]);
                                    if (model.dataObsoleteType != ObsoleteType.Never && model.DeadLine < DateTime.Now)
                                    {
                                        keyToDelList.Add(key);
                                    }

                                }

                                keyToDelList.ForEach(s=>dictionaryList[i].Remove(s));
                            }



                        }

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    
                }
            };

            Task.Run(backgroundCheckUpdateAction);
        }

        //put key-value to dictionary based on the hash of the key
        public static void Add(string key, object oValue)
        {
            int hash = key.GetHashCode();
            int index = hash % CPUNumer;

            lock (LockList[index])
            {
                if (!dictionaryList[index].ContainsKey(key))
                {

                    dictionaryList[index].Add(key, oValue);

                }
            }
        }

        public static void Remove(string key)
        {
            int hash = key.GetHashCode();
            int index = hash % CPUNumer;
            lock (LockList[index])
            {
                dictionaryList[index].Remove(key);
            }
        }

    }
}
