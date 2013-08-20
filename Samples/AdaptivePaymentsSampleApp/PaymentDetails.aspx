<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PaymentDetails.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.PaymentDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Payment Details</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Payment Details</h3>
            <div id="apidetails">
                Use the PaymentDetails API operation to obtain information about a payment. You
                can identify the payment by your tracking ID, the PayPal transaction ID in an IPN
                message, or the pay key associated with the payment.</div>
        </div>
        <div id="request_form">
            <form method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Pay key</div>
                    <div class="param_value">
                        <input name="payKey" id="payKey" value="AP-5S482348KH512131U" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Transaction Id</div>
                    <div class="param_value">
                        <input name="transactionId" id="transactionId" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Tracking Id</div>
                    <div class="param_value">
                        <input name="trackingId" id="trackingId" value="" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="PaymentDetails" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
