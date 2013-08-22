<%@ Page Language="C#" AutoEventWireup="true" Codebehind="CancelPreapproval.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.CancelPreapproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Cancel Preapproval</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Cancel Preapproval</h3>
            <div id="apidetails">
                Use the CancelPreapproval API operation to handle the canceling of preapprovals.
                Preapprovals can be canceled regardless of the state they are in, such as active,
                expired, deactivated, and previously canceled.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Preapproval key *</div>
                    <div class="param_value">
                        <input name="preapprovalKey" id="preapprovalKey" value="PA-9T9024308L745562T" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="CancelPreapproval" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
