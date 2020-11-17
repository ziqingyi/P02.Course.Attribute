using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Protocols;

namespace P29.Course.SOA.Web.Remote
{
    public class CustomSoapHeader:SoapHeader
    {

        private string userName = string.Empty;
        private string passWord = string.Empty;

        //must have a parameterless constructor
        public CustomSoapHeader() { }



        public CustomSoapHeader(string username, string password)
        {
            this.userName = username;
            this.passWord = password;
        }

        public string UserName
        {
            get { return userName;}
            set { userName = value; }
        }

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }


        public bool Validate()
        {
            bool result = this.userName.Equals("Admin") && this.PassWord.Equals("password123");
            return result;
        }

    }
}