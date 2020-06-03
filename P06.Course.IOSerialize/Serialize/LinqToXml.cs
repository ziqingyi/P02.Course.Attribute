using System;
using System.Collections.Generic;
using System.Linq;
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

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //throw;
            }



        }




    }
}
