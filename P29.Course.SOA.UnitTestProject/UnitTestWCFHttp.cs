using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P29.Course.SOA.UnitTestProject.MyConsoleWCFHttpTest;
using P29.Course.SOA.UnitTestProject.MyWCFTest;
using P29.Course.SOA.UnitTestProject.MyWebServiceTest;
using UserInfo = P29.Course.SOA.UnitTestProject.MyWCFTest.UserInfo;

namespace P29.Course.SOA.UnitTestProject
{
    [TestClass]
    public class UnitTestHttp
    {
        [TestMethod]
        public void TestMethod1()
        {
            //using (MyWCFTest.CustomServiceClient client = new MyWCFTest.CustomServiceClient())
            //when network disconnected, using will not free connection probably. 
            MyConsoleWCFHttpTest.MathServiceClient client = null;
            try
            {
                client = new MyConsoleWCFHttpTest.MathServiceClient();

                WCFUser user = client.GetUser(11, 22);

                int res1 = client.PlusInt(222, 555);


                client.Close();
            }
            catch (Exception e)
            {
                if (client != null)
                {
                    client.Abort();
                }
                Console.WriteLine(e.Message);
            }

        }
    }
}
