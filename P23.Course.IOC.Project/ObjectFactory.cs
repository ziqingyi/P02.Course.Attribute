using P23.Course.IOC.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Project
{
    public class ObjectFactory
    {
        public static Itelephone CreatePhone()
        {
            string classMode = ConfigurationManager.AppSettings["iPhoneType"];
            Assembly assembly = Assembly.Load(classMode.Split(',')[1]);//get the DLL name, or namespace
            Type type = assembly.GetType(classMode.Split(',')[0]);//get the class name

            Itelephone re = (Itelephone)Activator.CreateInstance(type);//must have parameterless constructor 
            return re;
        }



    }
}
