using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P29.Course.SOA.UnitTestProject.MyWCFTest;
using P29.Course.SOA.UnitTestProject.MyWebServiceTest;
using UserInfo = P29.Course.SOA.UnitTestProject.MyWCFTest.UserInfo;

namespace P29.Course.SOA.UnitTestProject
{
    [TestClass]
    public class UnitTestWCF
    {
        [TestMethod]
        public void TestMethod1()
        {
            //using (MyWCFTest.CustomServiceClient client = new MyWCFTest.CustomServiceClient())
            //when network disconnected, using will not free connection probably. 
            MyWCFTest.CustomServiceClient client = null;
            try
            {
                client.DoWork();
                int iresult1 = client.Get();
                UserInfo u = client.GetUser();
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
