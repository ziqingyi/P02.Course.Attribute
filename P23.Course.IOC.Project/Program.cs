using P23.Course.IOC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            //Inversion of Control (IoC), Dependency Inversion Principle (DIP), Dependency Injection (DI)
            {
                #region create type using reflection
                //do not need to refer Service project, just refer ServiceInterface is enough
                //just update App.Config, then any class in new DLL which implement the ServiceInterface can be used.
                
                Itelephone phone = ObjectFactory.CreatePhone();



                #endregion
            }


            Console.ReadKey();
        }
    }
}
