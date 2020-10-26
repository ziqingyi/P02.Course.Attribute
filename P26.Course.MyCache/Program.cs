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
            Console.WriteLine("***********************************************");
            {
                #region DBHelper query and cache

                Console.WriteLine("******************DBHelper query and cache*****************************");

                //set up test method and params first
                int param = 123;
                string methodName =typeof(DBHelper)+"."+nameof(DBHelper.Query);

                //method 1 : normal way without cache
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"try to get {methodName} in seq: {i} at {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    List<TestClass> programList = DBHelper.Query<TestClass>(param);
                }

                //method 2 : cache to class CustomCache's static field, a dictionary. 
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"try to get {methodName} in seq: {i} at {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    List<TestClass> programList=null;

                    //build key based on T and param, so same T and param will be same result and can get from cache in the following.
                    string key = $"{methodName}_Parameters_{param}";

                    //check cache
                    if (!CustomCache.Exists(key))
                    {
                        programList = DBHelper.Query<TestClass>(param);
                        CustomCache.Add(key,programList);
                    }
                    else
                    {
                        programList = CustomCache.Get<List<TestClass>>(key);
                    }
                }

                //method 3: using cache in DBHelper, encapsulate check existing and generating instance logic inside. 
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine(
                        $"try to get {methodName} in seq: {i} at {DateTime.Now.ToString("yyyyMMdd HHmmss.fff")}");
                    List<TestClass> programList = null;

                    //build key based on T and param, so same T and param will be same result and can get from cache in the following.
                    string key = $"{methodName}_Parameters_{param}";

                    programList = CustomCache.GetT<List<TestClass>>(key, () => DBHelper.Query<TestClass>(param));


                }



                #endregion





            }




        }
    }
}
