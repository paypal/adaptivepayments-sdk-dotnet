<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GetFundingPlans.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.GetFundingPlans" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Get Funding Plans</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Get Funding Plans</h3>
            <div id="apidetails">
                Use the GetFundingPlans API operation to determine the funding sources that are
                available for a specified payment, identified by its key, which takes into account
                the preferences and country of the receiver as well as the payment amount. You must
                be both the sender of the payment and the caller of this API operation.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Pay key *</div>
                    <div class="param_value">
                        <input name="payKey" id="payKey" value="AP-23119815K9918782X" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="GetFundingPlans" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
