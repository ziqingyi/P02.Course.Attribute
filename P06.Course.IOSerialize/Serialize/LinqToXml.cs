using System;
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
                    new XElement("Description"," This is user Eric"));
                XElement user2 = new XElement("User",
                    new XAttribute("ID", "2"),
                    new XElement("Name", "Ray"),
                    new XElement("Password", "2342342"),
                    new XElement("Description", " This is user Ray"));

                XElement userArray = new XElement("users", user1,user2);

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

        public static void GetXmlNodeInformation(string xmlPath)
        {
            try
            {
                //load root node
                XElement rootNode = XElement.Load(xmlPath);
                //XElement rootNode2 = XElement.Parse(xmlPath);


                //search the child nodes
                IEnumerable<XElement> targetNodes = from target in rootNode.Descendants("Name")
                    select target;
                foreach (XElement node in targetNodes)
                {
                    Console.WriteLine("name = {0} ", node.Value);
                }

                //search user by id
                IEnumerable<XElement> myTargetNodes = from myTarget in rootNode.Descendants("User")
                    where myTarget.Attribute("ID").Value.Equals("1")
                          && myTarget.HasElements
                    select myTarget;
                foreach (XElement node in myTargetNodes)
                {
                    Console.WriteLine("name = {0} ", node.Element("Name").Value);
                    Console.WriteLine("password = {0} ", node.Element("Password").Value);
                    Console.WriteLine("password = {0}", node.Element("Description").Value);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }


        }








    }
}
