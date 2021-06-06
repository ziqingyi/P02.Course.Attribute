using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace P39.Course.dotnetCoreLib.Authentications
{
    public class MyAuthenticationHandler : IAuthenticationHandler, IAuthenticationSignInHandler, IAuthenticationSignOutHandler
    {
        /*  Sign in and Sign out will not be used if
         *
         *  Handler provide authentication center.
         *
         */
        public AuthenticationScheme Scheme
        {
            get; private set;
        }

        protected HttpContext Context
        {
            get;
            private set;
        }


        public Task InitializeAsync(AuthenticationScheme scheme, HttpContext context)
        {
            Scheme = scheme;
            Context = context;
            return Task.CompletedTask;
        }

        public async Task<AuthenticateResult> AuthenticateAsync()
        {
            var cookie = Context.Request.Cookies["myCookie"];
            if (string.IsNullOrEmpty(cookie))
            {
                return AuthenticateResult.NoResult();
            }
            return  AuthenticateResult.Success(this.Deserialize(cookie));
        }

        public Task ChallengeAsync(AuthenticationProperties properties)
        {
            Context.Response.Redirect("/DFourth/login");
            return Task.CompletedTask;
        }

        public Task ForbidAsync(AuthenticationProperties properties)
        {
            Context.Response.StatusCode = 403;
            return Task.CompletedTask;
        }

        public Task SignInAsync(ClaimsPrincipal user, AuthenticationProperties properties)
        {
            var ticket = new AuthenticationTicket(user, properties, Scheme.Name);
            Context.Response.Cookies.Append("myCookie", this.Serialize(ticket));
            return Task.CompletedTask;
        }

        public Task SignOutAsync(AuthenticationProperties properties)
        {
            Context.Response.Cookies.Delete("myCookie");
            return Task.CompletedTask;
        }


        #region Serialize and Deserialize
        private AuthenticationTicket Deserialize(string context)
        {
            byte[] byteTicket = System.Text.Encoding.Default.GetBytes(context);
            AuthenticationTicket tResult = TicketSerializer.Default.Deserialize(byteTicket);
            return tResult;
        }
        private string Serialize(AuthenticationTicket ticket)
        {
            byte[] byteTicket = TicketSerializer.Default.Serialize(ticket);
            string result = Encoding.Default.GetString(byteTicket);
            return result;
        }

        #endregion


    }


}
