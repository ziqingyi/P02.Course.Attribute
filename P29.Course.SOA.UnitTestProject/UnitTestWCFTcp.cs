using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P29.Course.SOA.UnitTestProject.MyConsoleWCFTcpTest;

namespace P29.Course.SOA.UnitTestProject
{
    [TestClass]
    public class UnitTestWCFTcp
    {
        [TestMethod]
        public void TestMethod1()
        {
            MyConsoleWCFTcpTest.MathServiceClient client = null;
            try
            {
                client = new MathServiceClient();

                WCFUser wcfUser = client.GetUser(222, 666);



            }
            catch (Exception ex)
            {
                if (client != null)
                {
                    client.Abort();
                }

                Console.WriteLine(ex.Message);
            }



        }



    }
}
