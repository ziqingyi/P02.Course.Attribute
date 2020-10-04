using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.DIOC
{
    public interface IXContainer
    {
         void RegisterType<TFrom, TTo>();
         T Resolve<T>();
    }


    /// <summary>
    /// container   like factory
    /// </summary>
    public class XContainer : IXContainer
    {
        private Dictionary<string, Type> xContainerDictionary = new Dictionary<string, Type>();

        public void RegisterType<TFrom, TTo>()
        {
            xContainerDictionary.Add(typeof(TFrom).FullName, typeof(TTo));
        }

        public T Resolve<T>()
        {
            //Get the type need to be created. 
            Type type = xContainerDictionary[typeof(T).FullName];
            //Get all the ctors in this type
            ConstructorInfo[] ctorArray = type.GetConstructors();

            //Get ctor with this attribute, if not, get the one with Max of params. 
            ConstructorInfo ctor;
            int numOfCtorWithThisAttr = ctorArray.Count(c => c.IsDefined(typeof(XInjectionConstructorAttribute), true));
            if (numOfCtorWithThisAttr> 0)
            {
                ctor = ctorArray.FirstOrDefault(c => c.IsDefined(typeof(XInjectionConstructorAttribute), true));

            }
            else
            {
                ctor = ctorArray.OrderByDescending(c => c.GetParameters().Length).FirstOrDefault();
            }

            //Get all Parameters in this ctor, and get param type, and then create instance Based on Register dictionary
            List<object> paraList = new List<object>();
            foreach (ParameterInfo parameter in ctor.GetParameters())
            {
                Type paraType = parameter.ParameterType;
                Type targetType = xContainerDictionary[paraType.FullName];

                paraList.Add(Activator.CreateInstance(targetType));
            }


            T t = (T)Activator.CreateInstance(type,paraList.ToArray());
            return t;
        }

    }
}
