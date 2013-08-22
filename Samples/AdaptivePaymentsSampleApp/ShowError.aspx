<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ShowError.aspx.cs" Inherits="AdaptivePaymentsSampleApp.ShowError" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Error Page</title>
</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <form id="form1" runat="server">
        <div>
            An error has occurred on the page. Please notify the development team.
            <br />
            <br />
            Thank you.
            <br />
            <br />
            <asp:LinkButton ID="DetailLinkButton" runat="server" OnClick="DetailLinkButton_Click">Show Details</asp:LinkButton>
            <br />
            <br />
            <asp:Panel ID="MessagePanel" runat="server" Height="100%" Visible="False" Width="100%">
                <br />
                <asp:TextBox ID="MessageTextBox" runat="server" Height="307px" ReadOnly="True" TextMode="MultiLine"
                    Width="97%"></asp:TextBox>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
