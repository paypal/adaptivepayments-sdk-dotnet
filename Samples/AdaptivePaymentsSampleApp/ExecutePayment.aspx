<%@ Page Language="C#" AutoEventWireup="true" Codebehind="ExecutePayment.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.ExecutePayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Execute Payment</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Execute Payment</h3>
            <div id="apidetails">
                The ExecutePayment API operation lets you execute a payment set up with the Pay
                API operation with the actionType CREATE. To pay receivers identified in the Pay
                call, set the pay key from the PayResponse message in the ExecutePaymentRequest
                message.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Pay key *</div>
                    <div class="param_value">
                        <input name="payKey" id="payKey" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Funding plan Id *</div>
                    <div class="param_value">
                        <input name="fundingPlanId" id="fundingPlanId" value="" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="ExecutePayment" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
