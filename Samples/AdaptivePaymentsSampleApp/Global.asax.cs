using System;

namespace AdaptivePaymentsSampleApp
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            log4net.Config.XmlConfigurator.Configure();
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Message.LastException = Server.GetLastError().GetBaseException();
            string message = "Error Caught in Application_Error event\n" +
                "Error in: " + Request.Url.ToString() +
                "\nError Message:" + Message.LastException.Message.ToString() +
                "\nStack Trace:" + Message.LastException.StackTrace.ToString();
        }
    }
}