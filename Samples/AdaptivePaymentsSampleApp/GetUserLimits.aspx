<%@ Page Language="C#" AutoEventWireup="true" Codebehind="GetUserLimits.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.GetUserLimits" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Get User Limits</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Get User Limits</h3>
            <div id="apidetails">
                Use the GetUserLimits API operation to get the remaining limits for a user.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="input_header">
                    Account identifier (Provide email or phone)</div>
                <table>
                    <tr>
                        <th>
                            Email</th>
                        <th>
                            Phone</th>
                    </tr>
                    <tr>
                        <td>
                            <input name="email" id="email" value="platfo_1255077030_biz@gmail.com" />
                        </td>
                        <td>
                            <input name="phoneCountry" id="phoneCountry" value="" class="xsmallfield" />
                            -
                            <input name="phoneNumber" id="phoneNumber" value="" class="xsmallfield" />
                            <input name="phoneExtension" id="phoneExtension" value="" class="xsmallfield" />
                        </td>
                    </tr>
                </table>
                <div class="params">
                    <div class="param_name">
                        Country *</div>
                    <div class="param_value">
                        <input name="country" id="country" value="US" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Currency Code *</div>
                    <div class="param_value">
                        <input name="currencyCode" id="currencyCode" value="USD" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Limit type</div>
                    <div class="param_value">
                        <input name="limitType" id="limitType" value="" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="GetUserLimits" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
