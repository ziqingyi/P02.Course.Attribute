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
        [TestMethod]
        public void TestMethod1()
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
    }
}
