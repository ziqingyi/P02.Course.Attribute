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

            Action backgroundCheckUpdateDic= () =>
            {
                while (true)
                {
                    try
                    {
                        for (int i = 0; i < CPUNumer; i++)
                        {
                            List<string> keyToDelList= new List<string>();

                            lock (LockList[i])
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












        }







    }
}
