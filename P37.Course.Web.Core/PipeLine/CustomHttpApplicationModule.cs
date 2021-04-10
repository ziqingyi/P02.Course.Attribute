using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using P37.Course.Web.Core.Utility;


namespace P37.Course.Web.Core.PipeLine
{
    /*
     * 1 HttpModule is used to register event for HttpApplication(config in Web.config file)
     *
     * 2 ()_() methods in Global file is used for register events, when Module's EventHandler is executed.
     *    if the EventHandler is not executed, the ()_() method in global will not executed.  
     *
     * 3 framework will read web config file, use reflection to check the module and event handler and execute methods in Global.
     *
     *
     */

    public class CustomHttpApplicationModule : IHttpModule
    {
        private Logger logger = new Logger(typeof(CustomHttpApplicationModule));
        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public event EventHandler CustomEventHandler;

        public void Init(HttpApplication application)
        {

            this.CustomEventHandler += (s, e) =>
            {
                this.logger.Info("CustomEventHandler event executed.... ");
            };


            application.BeginRequest += (s, e) =>
            {
                //if (this.CustomEventHandler != null)
                //    this.CustomEventHandler.Invoke(application, e);
                this.CustomEventHandler?.Invoke(application,e);
            };


            #region Register actions for all events

            application.AcquireRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "AcquireRequestState        "));
            application.AuthenticateRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "AuthenticateRequest        "));
            application.AuthorizeRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "AuthorizeRequest           "));
            application.BeginRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "BeginRequest               "));
            application.Disposed += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "Disposed                   "));
            application.EndRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "EndRequest                 "));
            application.Error += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "Error                      "));
            application.LogRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "LogRequest                 "));
            application.MapRequestHandler += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "MapRequestHandler          "));
            application.PostAcquireRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostAcquireRequestState    "));
            application.PostAuthenticateRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostAuthenticateRequest    "));
            application.PostAuthorizeRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostAuthorizeRequest       "));
            application.PostLogRequest += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostLogRequest             "));
            application.PostMapRequestHandler += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostMapRequestHandler      "));
            application.PostReleaseRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostReleaseRequestState    "));
            application.PostRequestHandlerExecute += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostRequestHandlerExecute  "));
            application.PostResolveRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostResolveRequestCache    "));
            application.PostUpdateRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PostUpdateRequestCache     "));
            application.PreRequestHandlerExecute += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PreRequestHandlerExecute   "));
            application.PreSendRequestContent += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PreSendRequestContent      "));
            application.PreSendRequestHeaders += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "PreSendRequestHeaders      "));
            application.ReleaseRequestState += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "ReleaseRequestState        "));
            application.RequestCompleted += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "RequestCompleted           "));
            application.ResolveRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "ResolveRequestCache        "));
            application.UpdateRequestCache += (s, e) => application.Response.Write(string.Format("<h1 style='color:#00f'>Processed by MyCustomModule，{0} request handled by {1}</h1><hr>", DateTime.Now.ToString(), "UpdateRequestCache         "));

            #endregion
        }

        private void Application_BeginRequest(object sender, EventArgs e)
        {

        }




    }
}
