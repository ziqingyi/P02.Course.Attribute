using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P29.Course.SOA.UnitTestProject.MyWebServiceTest;

namespace P29.Course.SOA.UnitTestProject
{
    [TestClass]
    public class UnitTestWebService
    {
        /// <summary>
        /// svcUtil.exe ServiceModel Metadata Utility Tool.
        /// used to generate service model code from metadata documents, and metadata documents from service model code.
        /// 
        /// notes: this tool will create agent class based on wsdl. (MyWebServiceSoapClient)
        /// when client use service on server, need to start/end connection, http protocol, soap, ip,
        /// resolve message from server, etc. So use agent class to hide the complexity of call the service. 
        /// </summary>
        private int param1;
        private int param2;
        private int result1;

        static UnitTestWebService()
        {
            Console.WriteLine("static ctor, can initialise parameters.");
        }
        [TestInitialize]
        public void InitParameters()
        {
            param1 = 8;
            param2 = 10;
            result1 = 18;
        }



        [TestMethod]
        public void TestMethod()
        {
            //this is http protocol, connection is a socket, so must free up. 
            using (MyWebServiceTest.MyWebServiceSoapClient client = new MyWebServiceSoapClient())
            {
                int iresult = client.Plus(1, 2);

                MyWebServiceTest.UserInfo userInfo = client.GetUserObjById(1);

                //MyWebServiceTest.UserInfo[] userlist = client.GetuserList();//if service reference is Array

                List<MyWebServiceTest.UserInfo> userlist2 = client.GetuserList();//if service reference is List

            }
        }


        [TestMethod]
        public void TestMethodAssert()
        {
            //this is http protocol, connection is a socket, so must free up. 
            using (MyWebServiceTest.MyWebServiceSoapClient client = new MyWebServiceSoapClient())
            {

                Assert.AreEqual(client.Plus(1, 2),3);
                Assert.AreEqual(client.Plus(2, 2), 4);
                Assert.AreEqual(client.Plus(11,22), 33);
                Assert.AreEqual(param1,param2,result1);

                Assert.AreEqual(client.Plus(16,2), 3);// test error


                MyWebServiceTest.UserInfo userInfo = client.GetUserObjById(1);

                //MyWebServiceTest.UserInfo[] userlist = client.GetuserList();//if service reference is Array

                List<MyWebServiceTest.UserInfo> userlist2 = client.GetuserList();//if service reference is List

            }
        }




    }
}
