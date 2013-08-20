<%@ Page Language="C#" AutoEventWireup="true" Codebehind="PreapprovalDetails.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.PreapprovalDetails" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Preapproval Details</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Preapproval Details</h3>
            <div id="apidetails">
                Use the PreapprovalDetails API operation to obtain information about an agreement
                between you and a sender for making payments on the sender’s behalf.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Preapproval Key</div>
                    <div class="param_value">
                        <input type="text" name="preapprovalKey" value="PA-2T305990ET0354039" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Get billing address (Available only to callers with advanced permission levels)</div>
                    <div class="param_value">
                        <select name="getBillingAddress" id="getBillingAddress" class="smallfield">
                            <option value="true">true</option>
                            <option value="false" selected="selected">false</option>
                        </select>
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="PreapprovalDetails" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
