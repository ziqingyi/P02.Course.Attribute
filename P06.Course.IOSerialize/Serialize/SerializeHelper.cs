using System;
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
                fStream.Position = 0;
                List<Programmer> pList = (List<Programmer>) binFormat.Deserialize(fStream);
            }
        }

        public static void SoapSerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, @"SoapSerialize.txt");
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.list;
                SoapFormatter soapFormat = new SoapFormatter();
                soapFormat.Serialize(fStream,pList.ToArray());
            }
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                SoapFormatter soapFormat = new SoapFormatter();
                fStream.Position = 0;
                List<Programmer> pList = (List<Programmer>) soapFormat.Deserialize(fStream);
            }
        }

        public static void XmlSerialize()
        {
            string fileName = Path.Combine(Constant.SerializeDataPath, @"Student.xml");
            using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                List<Programmer> pList = DataFactory.list;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));
                xmlFormat.Serialize(fStream,pList);
            }

            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Programmer>));
                fStream.Position = 0;
                List<Programmer> pList = (List<Programmer>)xmlFormat.Deserialize(fStream);
            }
        }
        public static void Json()
        {
            List<Programmer> pList = DataFactory.list;
            string result = JsonHelper.ObjectToString<List<Programmer>>(pList);
            List<Programmer> pList1 = JsonHelper.StringToObject<List<Programmer>>(result);
        }

    }
}
