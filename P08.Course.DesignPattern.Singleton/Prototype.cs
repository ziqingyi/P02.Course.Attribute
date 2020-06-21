using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P08.Course.DesignPattern.Singleton
{
    [Serializable]
    public class Prototype
    {
        //copy object from memory and then return new object, but not created from new()

        public Person p = new Person();

        //private constructor, consume resource when creating
        private Prototype()
        {
            long iResult = 0;
            for (int i = 0; i < 1_000_000; i++)
            {
                iResult += 1;
            }
            Thread.Sleep(2000);
            Console.WriteLine("private constructor is being called for {0}, iResult is: {1}",
                this.GetType().Name, iResult);
        }

        // unique static instance
        private static volatile Prototype _prototype = new Prototype();

        //public method to provide new obj based on one obj, shallow clone.
        //only copy reference of reference type, copy value of value type 
        public static Prototype CreateInstance()
        {
            Prototype prototype = (Prototype)(ShallowClone());
            return prototype;
        }

        public static object ShallowClone()
        {
            return _prototype.MemberwiseClone();//different obj of _prototype
        }

        //deep clone with serialize. 
        public static Prototype DeepCloneWithSerialize()
        {
            using (Stream os = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(os,_prototype);
                os.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(os) as Prototype;
            }
        }

        //deep clone with generic and reflection
        public static Prototype DeepCloneWithT()
        {
            Type t = _prototype.GetType();
            object o = Activator.CreateInstance(t,true);
            PropertyInfo[] pi = t.GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                PropertyInfo p = pi[i];
                p.SetValue(o,p.GetValue(t));
            }

            FieldInfo[] fi = t.GetFields();
            for (int i = 0; i < fi.Length; i++)
            {
                FieldInfo f = fi[i];
                f.SetValue(o, f.GetValue(_prototype));
            }

            return (Prototype)o;
        }




    }
}
