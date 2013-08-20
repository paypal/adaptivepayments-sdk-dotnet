using System;

namespace AdaptivePaymentsSampleApp
{
    public partial class Preapproval : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentPath = System.Web.HttpContext.Current.Request.Url.OriginalString;
            this.returnUrl.Value = currentPath;
            this.cancelUrl.Value = currentPath;
            this.startingDate.Value = DateTime.Now.ToString("yyyy-MM-dd");
            this.endingDate.Value = DateTime.Now.AddDays(60).ToString("yyyy-MM-dd");
        }
    }
}
