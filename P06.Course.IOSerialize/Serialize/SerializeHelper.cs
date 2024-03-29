﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P06.Course.IOSerialize.Serialize
{
    public class SerializeHelper
    {
        public static void BinarySerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, @"BinarySerialize.txt");
            using (FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.list;
                BinaryFormatter binFormat = new BinaryFormatter();
                binFormat.Serialize(fStream, pList);
            }

            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                BinaryFormatter binFormat = new BinaryFormatter();
                fStream.Position = 0;//reset stream position.
                object temp =  binFormat.Deserialize(fStream);
                List<Programmer> pList = (List<Programmer>)temp;
            }
        }

        public static void SoapSerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, @"SoapSerialize.txt");
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.list;
                SoapFormatter soapFormat = new SoapFormatter();
                //must ToArray, Soap cannot serialize generic object
                soapFormat.Serialize(fStream,pList.ToArray());
            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                SoapFormatter soapFormat = new SoapFormatter();
                fStream.Position = 0; //reset stream position.
                object temp1 = soapFormat.Deserialize(fStream);
                Programmer[] temp2 = (Programmer[]) temp1;
                List <Programmer> pList = temp2.ToList();
            }
        }
        /*some classes use the [Serializable] attribute, note below:
         *
         * Serialization is the process of converting an object into a stream of bytes
         * in order to store the object or transmit it to memory, a database, or a file.
         *
         *It has NOTHING to do with XML or JSON serialization.
         *Used with the SerializableAttribute are the ISerializable Interface and SerializationInfo Class.
         * These are also only used with the BinaryFormatter or SoapFormatter.
         * Unless you intend to serialize your class using Binary or Soap,
         * do not bother marking your class as [Serializable].
         * XML and JSON serializers are not even aware of its existence.
         *
         */

        public static void XmlSerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, @"XmlSerialize.xml");
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.list;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));//note: this have type
                xmlFormat.Serialize(fStream,pList);
            }

            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));
                fStream.Position = 0;//reset stream position.
                object temp = xmlFormat.Deserialize(fStream);
                List<Programmer> pList = (List<Programmer>)temp;
            }
        }
        public static void Json()
        {
            List<Programmer> pList = DataFactory.list;
            string result = JsonHelper.ObjectToString<List<Programmer>>(pList);// convert T to string
            List<Programmer> pList1 = JsonHelper.StringToObject<List<Programmer>>(result);//convert string to T
        }

    }
}
