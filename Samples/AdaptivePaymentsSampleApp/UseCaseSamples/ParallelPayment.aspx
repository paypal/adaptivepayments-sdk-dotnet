<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ParallelPayment.aspx.cs" Inherits="AdaptivePaymentsSampleApp.UseCaseSamples.ParallelPayment" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdaptivePayments API - Parallel Payment</title>
    <link rel="stylesheet" type="text/css" href="../Content/sdk.css" />
    <script type="text/javascript" src="../Content/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Content/sdk_functions.js"></script>
</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>Parallel Payment</h3>
                <div id="apidetails">
                <p>
                    <i>
                        The Pay API operation is used to transfer funds from a sender's PayPal account to one or more receivers' PayPal accounts. 
                        You can use the Pay API operation to make Simple Payments, Chained Payments, or Parallel Payments; these payments can be explicitly approved, preapproved, or implicitly approved.
				        Parallel Payments are useful in cases when a buyer intends to make a single Payment for items from multiple sellers. 
                        Examples include the following scenarios: 
                        A Single Payment for multiple items from different merchants, such as a combination of items in your inventory and items that partners drop ship for you. 
                        Purchases of items related to an event, such as a trip that requires airfare, car rental, and a hotel booking.
                    </i>
                </p>                
            </div>
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
            <div class="section_header">Receiver list</div>  
            <div class="note">
                <i>Receiver is the party to whom funds are transferred. Each receiver receives a Payment directly from the sender in a Parallel Payment.</i>
            </div>          
            <table>
                <tr>
                    <th class="param_name">Amount*</th>
                    <th class="param_name">Email*</th>
                </tr>
                <tr>
                    <td class="param_value">
                        <asp:TextBox runat="server" ID="amount1" Text="3.00" />
                    </td>
                    <td class="param_value">
                        <asp:TextBox runat="server" ID="mail1" Text="pp15@paypal.com" />
                    </td>
                </tr>
                <tr>
                    <td class="param_value">
                        <asp:TextBox runat="server" ID="amount2" Text="2.00" />
                    </td>
                    <td class="param_value">
                        <asp:TextBox runat="server" ID="mail2" Text="pp14@paypal.com" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="submit">
                <asp:Button ID="ButtonAdaptivePayments" Text="ParallelPayment" runat="server" PostBackUrl="~/UseCaseSamples/RequestResponse.aspx" />
            </div>
            <br />
            <asp:HyperLink runat="server" ID="HyperLinkHome" NavigateUrl="~/Default.aspx" Text="Home" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="javascript:history.back();" Text="Back" />
        </div>
    </form>
</body>
</html>
