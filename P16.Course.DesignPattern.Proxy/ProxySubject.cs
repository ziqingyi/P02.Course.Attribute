using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P16.Course.DesignPattern.Proxy
{
    /// <summary>
    /// Adapter is recognizable by a constructor which takes an instance of a different abstract/interface type.
    /// When the adapter receives a call to any of its methods,
    /// it translates parameters to the appropriate format and then directs the call to one or
    /// several methods of the wrapped object.
    ///
    /// adapter do not extend business logic, it encapsulates the business logic.
    ///
    /// </summary>
    public class ProxySubject : ISubject
    {
        private static ISubject _Subject = new BusinessLogic();// static field for class
        private static Dictionary<string, bool> ProxyResultDic = new Dictionary<string, bool>();

        public bool GetData()
        {
            try
            {
                Console.WriteLine("Proxy Get Data from business logic");
                string key = "Proxy_GetData";
                bool bResult = false;

                //if one instance have get data for the class, do not need to do again. 
                if (ProxyResultDic.ContainsKey(key))
                {
                    bResult= ProxyResultDic[key];
                }
                else
                {
                    bResult = _Subject.GetData();
                    ProxyResultDic.Add(key,bResult);
                }
                return bResult;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public void DoTransaction()
        {
            try
            {
                Console.WriteLine("Proxy do transactions using business logic");
                _Subject.DoTransaction();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
    }





}
