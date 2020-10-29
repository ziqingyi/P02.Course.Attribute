using P26.Course.BLL;
using P26.Course.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P26.Course.MyCache
{
    class Program
    {
        static void Main(string[] args)
        {
            
            {
                #region DBHelper query and cache

                //TestDBHelperQueryAndCache();
                
                #endregion
            }
            {
                #region if updates in value happens, how to update cache? 

                string KeyWillUpdate = "Menu_Permision";
                List<string> menu = new List<string>(){"menu1", "menu2", "menu3", "menu4", "menu5" };

                if (!CustomCache.Exists(KeyWillUpdate))
                {
                    CustomCache.Add(KeyWillUpdate,menu);
                }
                else
                {
                    menu = CustomCache.Get<List<string>>(KeyWillUpdate);
                }

                List<string> menu2 = new List<string>() { "menu1", "menu2", "menu3", "menu4", "menu5" , "menu5" };

                //when value changes, remove by key name accordingly. 

                CustomCache.RemoveCondition(s=>s.Contains("Menu_Permision"));


                #endregion
            }

            {
                #region Cache with multi-thread
                List<Task> taskList = new List<Task>();

                //one task start thread of adding
                for (int i = 0; i < 1_000_000; i++)
                {
                    int k = i;

                    taskList.Add(Task.Run(()=>
                    {
                        CustomCache.Add($"TestKey_{k}", $"TestKey_{k}", 10);
                    })
                    );
                }

                //one task start thread of deleting
                for (int i = 0; i < 1_000_000; i++)
                {
                    int k = i;

                    taskList.Add(Task.Run(() =>
                        {
                            CustomCache.Remove($"TestKey_{k}");
                        })
                    );
                }

                //one task start thread of checking existing
                for (int i = 0; i < 1_000_000; i++)
                {
                    int k = i;

                    taskList.Add(Task.Run(() =>
                        {
                            CustomCache.Exists($"TestKey_{k}");
                        })
                    );
                }
                #endregion

                Task.WaitAll(taskList.ToArray());


            }






        }


        private static void TestDBHelperQueryAndCache()
        {
            #region DBHelper query and cache

            Console.WriteLine("******************DBHelper query and cache*****************************");

            //set up test method and params first
            int param = 123;
            string methodName = typeof(DBHelper) + "." + nameof(DBHelper.Query);

            Console.WriteLine("******************method 1 : normal way without cache*****************************");
            //method 1 : normal way without cache
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"try to get {methodName} in seq: {i} at {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                List<TestClass> programList = DBHelper.Query<TestClass>(param);
            }

            Console.WriteLine("******************method 2 : cache to class CustomCache's static field, a dictionary. *****************************");

            //method 2 : cache to class CustomCache's static field, a dictionary. 
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"try to get {methodName} in seq: {i} at {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                List<TestClass> programList = null;

                //build key based on T and param, so same T and param will be same result and can get from cache in the following.
                string key = $"{methodName}_Parameters_{param}";

                //check cache
                if (!CustomCache.Exists(key))
                {
                    programList = DBHelper.Query<TestClass>(param);
                    CustomCache.Add(key, programList);
                }
                else
                {
                    programList = CustomCache.Get<List<TestClass>>(key);
                }
            }

            Console.WriteLine("********************method 3: using cache in DBHelper***************************");
            //method 3: using cache in DBHelper, encapsulate check existing and generating instance logic inside. 
            int param2 = 222;
            string methodName2 = typeof(DBHelper) + "." + nameof(DBHelper.Query);


            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine(
                    $"try to get {methodName} in seq: {i} at {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                List<TestClass> programList = null;

                //build key based on T and param, so same T and param will be same result and can get from cache in the following.
                string key = $"{methodName2}_Parameters_{param2}";

                programList = CustomCache.GetT<List<TestClass>>(key, () => DBHelper.Query<TestClass>(param));


            }

            #endregion



        }
















    }
}
