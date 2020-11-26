using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace P31.Course.SOA.WebAPI.Utility.Filters
{
    public class CustomBasicAuthorizeAttribute:AuthorizeAttribute
    {
        //before go to action, authorization start here.

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            //get auth info from header, then you can decrypt it and check info inside. 
            //actionContext.Request.Headers["Authorization"];
            var authorization = actionContext.Request.Headers.Authorization;//same to getting through array.
            //base.OnAuthorization(actionContext);

            if (this.ValidateTicket(authorization.Parameter))
            {
                return;//continue
            }
            else
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.Unauthorized);
            }


        }



        private bool ValidateTicket(string encryptTicket)
        {
            string strTicket = FormsAuthentication.Decrypt(encryptTicket).UserData;

            string CorrectUserData = string.Format("{0}&{1}", "Admin", "password213");

            bool result = string.Equals(strTicket, CorrectUserData);

            return result;
        }

    }
}