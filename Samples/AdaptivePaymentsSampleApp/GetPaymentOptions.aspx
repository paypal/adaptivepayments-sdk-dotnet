<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GetPaymentOptions.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.GetPaymentOptions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Get Payment Options</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Get Payment Options</h3>
            <div id="apidetails">
                Use the GetPaymentOptions API operation to retrieve the payment options passed with
                the SetPaymentOptionsRequest.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Pay key</div>
                    <div class="param_value">
                        <input name="payKey" id="payKey" value="AP-5S482348KH512131U" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="GetPaymentOptions" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
