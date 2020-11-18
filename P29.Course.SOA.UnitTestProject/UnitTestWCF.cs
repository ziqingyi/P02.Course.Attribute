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
            using (MyWCFTest.CustomServiceClient client = new MyWCFTest.CustomServiceClient())
            {
                client.DoWork();
                int iresult1 = client.Get();

                UserInfo u = client.GetUser();


            }

        }
    }
}
