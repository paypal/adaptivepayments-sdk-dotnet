<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SimplePayment.aspx.cs" Inherits="AdaptivePaymentsSampleApp.UseCaseSamples.SimplePayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdaptivePayments API - Simple Payment</title>
    <link rel="stylesheet" type="text/css" href="../Content/sdk.css" />
    <script type="text/javascript" src="../Content/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Content/sdk_functions.js"></script>
</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>Simple Payment</h3>
            <div id="apidetails">
                <p>
                    <i>
                        The Pay API operation is used to transfer funds from a sender's PayPal account to one or more receivers' PayPal accounts.
                    </i>
                </p>
            </div>
        </div>
        <form id="form1" runat="server">
            <div class="params">
                <div class="param_name">Currency Code*</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="currencyCode" Text="USD" />
                </div>
                <div class="param_name">Action Type*</div>
                <div class="param_value">
                    <asp:DropDownList runat="server" ID="actionType">
                        <asp:ListItem Text="Pay" Value="PAY" Selected="True" />
                        <asp:ListItem Text="Pay Primary" Value="PAY_PRIMARY" Enabled="false" />
                        <asp:ListItem Text="Create" Value="CREATE" Enabled="false" />
                    </asp:DropDownList>
                </div>
                <div class="param_name">Cancel URL*</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="cancelURL" />
                </div>
                <div class="param_name">Return URL*</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="returnURL" />
                </div>
                <div class="param_name">IPN Notification URL (For receiving IPN call back from PayPal)</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="ipnNotificationURL" />
                </div>
                <div class="param_name">Sender Email</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="senderEmail" Text="jb-us-seller2@paypal.com" />
                </div>
                <div class="section_header">Receiver</div>
                <div class="note">
                    <i>Receiver is the party to whom funds are transferred.</i>
                </div>
                <table>
                    <tr>
                        <th class="param_name">Amount*</th>
                        <th class="param_name">Email</th>
                    </tr>
                    <tr>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="amount" Text="1.00" />
                        </td>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="mail" Text="pp15@paypal.com" />
                        </td>
                    </tr>
                </table>
                <br />
                <div class="submit">
                    <asp:Button ID="ButtonAdaptivePayments" Text="SimplePayment" runat="server" PostBackUrl="~/UseCaseSamples/RequestResponse.aspx" />
                </div>
                <br />
                <asp:HyperLink runat="server" ID="HyperLinkHome" NavigateUrl="~/Default.aspx" Text="Home" />
                <br />
                <br />
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="javascript:history.back();" Text="Back" />
            </div>
        </form>
    </div>
</body>
</html>
