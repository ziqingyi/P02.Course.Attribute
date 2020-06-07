using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P06.Course.IOSerialize.IO;
using P06.Course.IOSerialize.Serialize;

namespace P06.Course.IOSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            {
                //Console.WriteLine("******************IO Show, file, directory, recursion*************");
                //MyIO.ShowDirectory();
                //MyIO.ShowFile();
                //MyIO.showDrive();
                //MyIO.showPath();
                //MyIO.Log("log ....s.s.s.s..s.s.s");
                //var directoryInfo = Recursion.GetAllDirectory(@"C:\IOSerialize");
            }
            {
                //Console.WriteLine("****************Serialize, Soap, Xml, Json***********");
                //SerializeHelper.BinarySerialize();
                //SerializeHelper.SoapSerialize();
                //SerializeHelper.XmlSerialize();
                //SerializeHelper.Json();
            }


            {
                //Console.WriteLine("******************draw picture*******************************");
                //ImageHelper.Drawing();
                //ImageHelper.CreateCaptcha();
                //ImageHelper.ImageChangeBySize(
                //    Constant.ImagePath+ "pic1.jpg", 
                //    Constant.ImagePathNew + "pic2.jpg", 
                //    100,
                //    200);
                //ImageHelper.CompressPercent(Constant.ImagePath + "pic1.jpg", 
                //    Constant.ImagePathNew + "pic3.jpg", 
                //    200,
                //    300);
            }
            {
                //Console.WriteLine("******************Linq to Xml*******************************");
                //string xmlAddressWithName = Constant.SerializeDataPath + @"\users.xml";
                //LinqToXml.CreateXmlFile(xmlAddressWithName);
                //LinqToXml.GetXmlNodeInformation(xmlAddressWithName);
                //LinqToXml.ModifyXmlNodeInformation(xmlAddressWithName);
                //LinqToXml.AddXmlNodeInformation(xmlAddressWithName);
                //LinqToXml.DeleteXmlNodeInformation(xmlAddressWithName);
            }

            {
                Console.WriteLine("******************Xml Helper*******************************");
                string xml = XmlHelper.ClassToXml<User>(new User());
                
                string xmlForOneObj = Constant.SerializeDataPath + @"\user.xml";
                var result = XmlHelper.FileToOneObject<User>(xmlForOneObj);

                string xmlForObjs = Constant.SerializeDataPath + @"\users.xml";
                var resultArray = XmlHelper.FileToObjects<User>(xmlForObjs);


            }




        }
    }
}
