using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace P06.Course.IOSerialize.Serialize
{
    public class LinqToXml
    {
        public static void CreateXmlFile(string xmlPath)
        {
            try
            {
                //define a XDocument structure
                XElement user1 = new XElement("User",
                    new XAttribute("ID","1"),
                    new XElement("Name","Eric"),
                    new XElement("Password","123123"),
                    new XElement("Description","This is user Eric"), 
                    new XElement("Course", "Law")
                    );
                XElement user2 = new XElement("User",
                    new XAttribute("ID", "2"),
                    new XElement("Name", "Ray"),
                    new XElement("Password", "2342342"),
                    new XElement("Description", "This is user Ray"),
                    new XElement("Course", "IT"));
                XElement user3 = new XElement("User",
                    new XAttribute("ID", "3"),
                    new XElement("Name", "Joy"),
                    new XElement("Password", "asfdafa"),
                    new XElement("Description", "This is user Joy"),
                    new XElement("Course", "Physics"));

                XElement userArray = new XElement("Users", user1,user2,user3);

                XDocument myXDoc = new XDocument(userArray);

                //save this structure
                myXDoc.Save(xmlPath);
                string test = myXDoc.ToString();
                XElement rootNode2 = XElement.Parse(test);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //throw;
            }
        }
        public static void CreateXmlFileOfOneObj(string xmlPath)
        {
            try
            {
                //define a XDocument structure
                XElement user1 = new XElement("User",
                    new XAttribute("ID", "1"),
                    new XElement("Name", "Eric"),
                    new XElement("Password", "123123"),
                    new XElement("Description", "This is user Eric"),
                    new XElement("Course", "Law")
                );
                
                XDocument myXDoc = new XDocument(user1);

                //save this structure
                myXDoc.Save(xmlPath);
                string test = myXDoc.ToString();
                XElement rootNode2 = XElement.Parse(test);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //throw;
            }
        }


        public static void GetXmlNodeInformation(string xmlPath)
        {
            try
            {
                //load root node
                XElement rootNode = XElement.Load(xmlPath);
                //XElement rootNode2 = XElement.Parse(xmlPath);

                //search the child nodes
                Console.WriteLine("****************show Names of all descendants*****************************");
                IEnumerable<XElement> targetNodes = from target in rootNode.Descendants("Name")
                    select target;
                foreach (XElement node in targetNodes)
                {
                    Console.WriteLine("name = {0} ", node.Value);
                }
                Console.WriteLine("****************show info of all descendants with id = 1******************");
                //search user by id
                IEnumerable<XElement> myTargetNodes = from myTarget in rootNode.Descendants("User")
                    where myTarget.Attribute("ID").Value.Equals("1")
                          && myTarget.HasElements
                    select myTarget;
                foreach (XElement node in myTargetNodes)
                {
                    Console.WriteLine("name = {0} ", node.Element("Name").Value);
                    Console.WriteLine("Password = {0} ", node.Element("Password").Value);
                    Console.WriteLine("Description = {0}", node.Element("Description").Value);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public static void ModifyXmlNodeInformation(string xmlPath)
        {
            try
            {
                //load root node
                XElement rootNode = XElement.Load(xmlPath);
                // search user by id
                IEnumerable<XElement> targetNodes = from target in rootNode.Descendants("User")
                                                    where target.Attribute("ID").Value =="2"
                                                          || target.Attribute("ID").Value.Equals("3") 
                                                    select target;
                //iterate all targets
                foreach (XElement node in targetNodes)
                {
                    node.Element("Course").SetValue("History");
                }
                rootNode.Save(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        }

        public static void AddXmlNodeInformation(string xmlPath)
        {
            try
            {
                //load xml root node from xml file
                XElement rootNode = XElement.Load(xmlPath);
                //create a new node 
                XElement newNode = new XElement("User", new XAttribute("ID","4"),
                    new XElement("Name", "Tom"),
                    new XElement("Password", "3weafa"),
                    new XElement("Description", "This is user Tom"),
                    new XElement("Course", "IT"));

                // add to root node
                rootNode.Add(newNode);
                rootNode.Save(xmlPath);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }

        public static void DeleteXmlNodeInformation(string xmlPath)
        {
            try
            {
                //load root node from file
                XElement rootNode = XElement.Load(xmlPath);
                //search user
                IEnumerable<XElement> targetUser = from target in rootNode.Descendants("User")
                    where target.Attribute("ID").Value.Equals("4")
                    select target;

                targetUser.Remove();
                rootNode.Save(xmlPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }

        }

    }
}
