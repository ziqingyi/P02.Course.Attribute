using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace P23.Course.IOC.Framework.DIOC
{
    public class XxContainer:IXxContainer
    {
        //xxContainerDictionary used for keep the type info, the type need to create instance. 
        private Dictionary<string, RegisterInfo> xxContainerDictionary = new Dictionary<string, RegisterInfo>();

        //cache instance used for create singleton instance. 
        private Dictionary<Type, object> TypeObjectDictionary = new Dictionary<Type, object>();

        //cache thread ids in which the container works on
        public HashSet<string> threadIds= new HashSet<string>();

        //lock used in creating singleton
        private static readonly object Singleton_Lock = new object();
        private static readonly object Singleton_Lock_param = new object();

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
            threadIds.Add(Thread.CurrentThread.ManagedThreadId.ToString());
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
                        lock (Singleton_Lock)
                        {
                            if (!this.TypeObjectDictionary.ContainsKey(type))
                            { 
                                result = (T) this.CreateObject(type);
                                this.TypeObjectDictionary.Add(type,result);
                            }
                        }
                    }
                    break;

                case LifeTimeType.PerThread:
                {
                    //use thread slot rather than thread id
                    string key = type.FullName;
                    object oValue = CallContext.GetData(key);
                    if (oValue == null)
                    {
                        result = (T)this.CreateObject(type);
                        CallContext.SetData(key,result);
                    }
                    else
                    {
                        result = (T) oValue;
                    }
                } 
                    break;
                default:
                    throw new Exception("wrong lifetime");



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
                RegisterInfo regInfo = xxContainerDictionary[paraType.FullName];
                Type targetType = regInfo.TargetType;

                //param may not have parameterless ctor, so must check ctors to create param
                //paraList.Add(Activator.CreateInstance(targetType));
                //loop termination criteria is when the Parameters are none, then target type could be create without params. 
                object para = null;

                #region create object based on different lifetime
                {
                    switch (regInfo.LifeTime)
                    {
                        case LifeTimeType.Transient:
                            para = this.CreateObject(targetType);
                            break;

                        //dictionary.add() will have multi-thread issue, if there is same key then throw error, 
                        //dictionary[key]="value" will assign value or override existing value, so no error pop out. best way is to use if check twice and lock
                        case LifeTimeType.Singletone:
                        {
                            if (this.TypeObjectDictionary.ContainsKey(targetType))
                            {
                                para = this.TypeObjectDictionary[targetType];
                            }
                            else
                            {
                                lock (Singleton_Lock_param)
                                {
                                    if (!this.TypeObjectDictionary.ContainsKey(targetType))
                                    {
                                        para = this.CreateObject(targetType);
                                        this.TypeObjectDictionary.Add(targetType,para);
                                    }
                                }
                            }
                        }
                            break;
                        case LifeTimeType.PerThread:
                        {
                            string key = targetType.FullName;
                            object oValue = CallContext.GetData(key);
                            if (oValue == null)
                            {
                                para = this.CreateObject(targetType);
                                CallContext.SetData(key,para);
                            }
                            else
                            {
                                para = oValue;
                            }
                        }
                            break;
                        default:
                            throw new Exception("wrong lifetime");

                    }

                }
                #endregion

                paraList.Add(para);
            }
            //then need to check fields and other methods...


            object t = (object)Activator.CreateInstance(type, paraList.ToArray());
            return t;
        }


    }
}
