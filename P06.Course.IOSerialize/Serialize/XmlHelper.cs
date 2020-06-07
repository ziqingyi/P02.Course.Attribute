using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace P06.Course.IOSerialize.Serialize
{
    public class XmlHelper
    {
        //xmlserializer: from class type to string
        public static string ClassToXml<T>(T t) where T : new()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            Stream stream = new MemoryStream();
            xmlSerializer.Serialize(stream, t);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string OutputText = reader.ReadToEnd();

            if (!Directory.Exists(Constant.SerializeDataPath))
            {
                Directory.CreateDirectory(Constant.SerializeDataPath);
            }

            //output result to file
            string outputFile = Path.Combine(Constant.SerializeDataPath + "ClassToXml.xml");
            using (FileStream file = File.Create(outputFile))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(OutputText);
                file.Write(bytes, 0,bytes.Length);
                file.Flush();
            }

            return OutputText;
        }



        /*
         * <?xml version="1.0"?>
           <User xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" />
         */
        // string to xml
        public static T ToObject<T>(string content) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(content)))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(stream);
            }
        }

        //file being deserialized to object
        public static T FileToOneObject<T>(string fileName) where T : new()
        {
            //string CurrentXMLPath = Constant.SerializeDataPath;
            //fileName = Path.Combine(CurrentXMLPath, @"users.xml");
            using (Stream fStream = new FileStream(fileName,FileMode.Open,FileAccess.ReadWrite))
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "User";
                xRoot.IsNullable = true;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T),xRoot);
                return (T) xmlFormat.Deserialize(fStream);
            }
        }

        //file being deserialized to an array of object
        public static T[] FileToObjects<T>(string fileName) where T : new()
        {
            //string CurrentXMLPath = Constant.SerializeDataPath;
            //fileName = Path.Combine(CurrentXMLPath, @"users.xml");
            using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlRootAttribute xRoot = new XmlRootAttribute();
                xRoot.ElementName = "Users";
                xRoot.IsNullable = true;
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T[]),xRoot);
                return (T[])xmlFormat.Deserialize(fStream);
            }
        }










    }
}
