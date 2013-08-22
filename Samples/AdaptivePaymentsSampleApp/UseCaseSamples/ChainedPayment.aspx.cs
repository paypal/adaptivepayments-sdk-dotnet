using System;
using System.Web;

namespace AdaptivePaymentsSampleApp.UseCaseSamples
{
    public partial class ChainedPayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            string returnUniformResourceLocator  = Request.Url.OriginalString;
            string returnAuthority = Request.Url.Authority;
            string returnDnsSafeHost = Request.Url.DnsSafeHost;

            if (Request.UrlReferrer != null && Request.UrlReferrer.Scheme == "https")
            {
                returnUniformResourceLocator = returnUniformResourceLocator.Replace("http://", "https://");
                returnUniformResourceLocator = returnUniformResourceLocator.Replace(returnAuthority, returnDnsSafeHost);
            }

            string cancelUniformResourceLocator = Request.Url.OriginalString;
            string cancelAuthority = Request.Url.Authority;
            string cancelDnsSafeHost = Request.Url.DnsSafeHost;

            if (Request.UrlReferrer != null && Request.UrlReferrer.Scheme == "https")
            {
                cancelUniformResourceLocator = cancelUniformResourceLocator.Replace("http://", "https://");
                cancelUniformResourceLocator = cancelUniformResourceLocator.Replace(cancelAuthority, cancelDnsSafeHost);
            }

            this.returnURL.Text = returnUniformResourceLocator;
            this.cancelURL.Text = cancelUniformResourceLocator;
        }
    }
}