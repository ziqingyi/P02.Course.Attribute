﻿using System;
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
                //Console.WriteLine("******************Xml Helper, using XmlSerializer*****************");
                //User u1 = new User()
                //{
                //    ID = "5",
                //    Name = "Jack",
                //    Description = "this is jack",
                //    Course = "Finance",
                //    Password = "safd234"
                //};

                //string xml = XmlHelper.ObjToXml<User>(u1);
                //User userFromString = XmlHelper.ToObject<User>(xml);

                ////compare with BinaryFormatter
                //XmlHelper.ObjToXmlUsingBinaryFormatter(u1);


                ////create one obj from the xml file,create first.
                //string xmlForOneObj = Constant.SerializeDataPath + @"\user.xml";
                //LinqToXml.CreateXmlFileOfOneObj(xmlForOneObj);
                //var result = XmlHelper.FileToOneObject<User>(xmlForOneObj);

                ////create an array of objects from the xml file.
                string xmlFileForObjs = Constant.SerializeDataPath + @"\users.xml";
                LinqToXml.CreateXmlFile(xmlFileForObjs);
                var resultArray = XmlHelper.FileToObjects<User>(xmlFileForObjs);

            }
            { //test
                Console.WriteLine("******************Xml Extend method*****************");
                //test one user, obj to xml and then from xml string to obj
                User u1 = new User()
                {
                    ID = "5",
                    Name = "Jack",
                    Description = "this is jack",
                    Course = "Finance",
                    Password = "safd234"
                };
                Type type = typeof(User);
                String xmlContent = u1.ParseToXml(type.Name);

                var ObjFromXmlContent = xmlContent.ParseToModel<User>(type.Name);

                //test a list of users. from string to a list of obj.
                string xmlFileForObjs = Constant.SerializeDataPath + @"\users.xml";
                String xmlForListOfObj = LinqToXml.CreateXmlFile(xmlFileForObjs);
                var resultArray = xmlForListOfObj.XmlToObjList<User>("//Users/"+type.Name);



            }



        }
    }
}
