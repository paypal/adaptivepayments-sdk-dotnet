using System;

namespace AdaptivePaymentsSampleApp
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            string currentPath = System.Web.HttpContext.Current.Request.Url.OriginalString;
            this.returnUrl.Value = currentPath;
            this.cancelUrl.Value = currentPath;
        }
    }
}
