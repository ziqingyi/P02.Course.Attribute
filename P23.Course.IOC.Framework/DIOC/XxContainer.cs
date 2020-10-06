using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace P23.Course.IOC.Framework.DIOC
{
    public class XxContainer:IXxContainer
    {
        //xxContainerDictionary used for keep the type info, the type need to create instance. 
        private Dictionary<string, RegisterInfo> xxContainerDictionary = new Dictionary<string, RegisterInfo>();

        //cache instance used for create singleton instance. 
        private Dictionary<Type, object> TypeObjectDictionary = new Dictionary<Type, object>();


        public void RegisterType<TFrom, TTo>(LifeTimeType lifeTimeType = LifeTimeType.Transient)
        {
            xxContainerDictionary.Add(typeof(TFrom).FullName, new RegisterInfo()
            {
                TargetType = typeof(TTo),
                LifeTime = lifeTimeType
            });
        }

        public T Resolve<T>()
        {
            //Get the type need to be created. 
            Type type = xxContainerDictionary[typeof(T).FullName].TargetType;

            //get the RegisterInfo, containing the type info and lifetime info
            RegisterInfo info = xxContainerDictionary[typeof(T).FullName];
            
            T result = default(T);

            switch (info.LifeTime)
            {
                case LifeTimeType.Transient:
                    result = (T) CreateObject(type);
                    break;

                case LifeTimeType.Singletone:
                    if (this.TypeObjectDictionary.ContainsKey(type))
                    {
                        result = (T) this.TypeObjectDictionary[type];
                    }
                    else
                    {
                        result = (T) this.CreateObject(type);
                        this.TypeObjectDictionary[type] = result;
                    }

                    break;

                case LifeTimeType.PerThread:
                    result = (T)CreateObject(type);
                    break;
            }
            return result;
        }

        private object CreateObject(Type type)
        {
            //Get all the ctors in this type
            ConstructorInfo[] ctorArray = type.GetConstructors();

            //Get ctor with this attribute, if not, get the one with Max of params. 
            ConstructorInfo ctor;
            int numOfCtorWithThisAttr = ctorArray.Count(c => c.IsDefined(typeof(XInjectionConstructorAttribute), true));
            if (numOfCtorWithThisAttr > 0)
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
                Type targetType = xxContainerDictionary[paraType.FullName].TargetType;

                //param may not have parameterless ctor, so must check ctors to create param
                //paraList.Add(Activator.CreateInstance(targetType));
                //loop termination criteria is when the Parameters are none, then target type could be create without params. 
                object para = this.CreateObject(targetType);
                paraList.Add(para);
            }
            //then need to check fields and other methods...




            object t = (object)Activator.CreateInstance(type, paraList.ToArray());
            return t;
        }


    }
}
