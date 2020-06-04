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
        public static string ToXml<T>(T t) where T : new()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            Stream stream = new MemoryStream();
            xmlSerializer.Serialize(stream, t);
            stream.Position = 0;
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
        }
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
        public static T FileToObject<T>(string fileName) where T : new()
        {
            string CurrentXMLPath = Constant.SerializeDataPath;
            fileName = Path.Combine(CurrentXMLPath, @"users.xml");
            using (Stream fStream = new FileStream(fileName,FileMode.Open,FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T) xmlFormat.Deserialize(fStream);
            }



        }












    }
}
