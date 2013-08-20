using System;

namespace AdaptivePaymentsSampleApp.UseCaseSamples
{
    public partial class Preapproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string returnUniformResourceLocator = Request.Url.OriginalString;
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

            // (Required) URL to which the buyer's browser is returned after choosing to pay with PayPal. For digital goods, you must add JavaScript to this page to close the in-context experience.
            // Note:
            // PayPal recommends that the value be the final review page on which the buyer confirms the order and payment or billing agreement.
            UriBuilder uriBuilder = new UriBuilder(returnUniformResourceLocator);
            uriBuilder.Path = Request.ApplicationPath
                + (Request.ApplicationPath.EndsWith("/") ? string.Empty : "/")
                + "UseCaseSamples/PreapprovalPayment.aspx";
            returnUniformResourceLocator = uriBuilder.Uri.ToString();

            // (Required) URL to which the buyer is returned if the buyer does not approve the use of PayPal to pay you. For digital goods, you must add JavaScript to this page to close the in-context experience.
            // Note:
            // PayPal recommends that the value be the original page on which the buyer chose to pay with PayPal or establish a billing agreement.
            uriBuilder = new UriBuilder(cancelUniformResourceLocator);
            uriBuilder.Path = Request.ApplicationPath
                + (Request.ApplicationPath.EndsWith("/") ? string.Empty : "/")
                + "UseCaseSamples/PreapprovalPayment.aspx";
            cancelUniformResourceLocator = uriBuilder.Uri.ToString();

            this.returnURL.Text = returnUniformResourceLocator;
            this.cancelURL.Text = cancelUniformResourceLocator;
            this.startingDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }
    }
}