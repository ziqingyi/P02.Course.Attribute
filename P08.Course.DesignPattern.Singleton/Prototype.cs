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
    public class Prototype
    {
        //copy object from memory and then return new object, but not created from new()

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

        private static object ShallowClone()
        {
            return _prototype.MemberwiseClone();
        }

        //deep clone with serialize. 
        public Prototype DeepCloneWithSerialize()
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
        public Prototype DeepCloneWithT()
        {
            Type t = _prototype.GetType();
            object o = Activator.CreateInstance(t);
            PropertyInfo[] pi = t.GetProperties();
            for (int i = 0; i < pi.Length; i++)
            {
                PropertyInfo p = pi[i];
                p.SetValue(o,p.GetValue(t));
            }
            return (Prototype)o;
        }




    }
}
