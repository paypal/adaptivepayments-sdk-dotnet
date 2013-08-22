using System;

namespace AdaptivePaymentsSampleApp
{
    public partial class ShowError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DetailLinkButton_Click(object sender, EventArgs e)
        {
            if (this.MessagePanel.Visible)
            {
                this.MessagePanel.Visible = false;
                this.DetailLinkButton.Text = "Show Details";
            }
            else
            {
                if (Message.LastException != null)
                {
                    this.MessageTextBox.Text = "Error Caught in Application_Error event\n" +
                        "Error in: " + Request.Url.ToString() +
                        "\n\nError Message:" + Message.LastException.Message.ToString() +
                        "\n\nStack Trace:" + Message.LastException.StackTrace.ToString();
                }
                this.MessagePanel.Visible = true;
                this.DetailLinkButton.Text = "Hide Details";
            }
        }
    }
}
