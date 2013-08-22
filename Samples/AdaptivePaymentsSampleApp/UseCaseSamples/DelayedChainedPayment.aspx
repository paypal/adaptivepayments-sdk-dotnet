<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DelayedChainedPayment.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.UseCaseSamples.DelayedChainedPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdaptivePayments API - Delayed Chained Payment</title>
    <link rel="stylesheet" type="text/css" href="../Content/sdk.css" />
    <script type="text/javascript" src="../Content/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Content/sdk_functions.js"></script>
</head>
<body>
    <img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Delayed Chained Payment</h3>
            <div id="apidetails">
                <p>
                    <i>By default, payments to all receivers in a chained payment are immediate. However,
                        you can choose to delay a payment to a secondary receiver. For example, as primary
                        receiver, you may require secondary receivers to perform some action, such as shipping
                        goods or waiting for expiration of a return period, before making payment. To complete
                        the payment, you must explicitly execute a payment to secondary receivers after
                        the sender pays you. The payment must occur within 90 days, after which you cannot
                        complete the payment as part of the original chained payment. </i>
                </p>
            </div>
        </div>
    </div>
    <form id="form1" runat="server">
        <div id="request_form">
            <div class="params">
                <div class="param_name">
                    Currency Code*
                </div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="currencyCode" Text="USD" />
                </div>
                <div class="param_name">
                    Action Type*</div>
                <div class="param_value">
                    <asp:DropDownList runat="server" ID="actionType">
                        <asp:ListItem Text="Pay" Value="PAY" Enabled="false" />
                        <asp:ListItem Text="Pay Primary" Value="PAY_PRIMARY" Selected="True" />
                        <asp:ListItem Text="Create" Value="CREATE" Enabled="false" />
                    </asp:DropDownList>
                </div>
                <div class="param_name">
                    Cancel URL*
                </div>
                <div class="param_value">
                   
                    <asp:TextBox runat="server" ID="cancelURL" />
                </div>
                <div class="param_name">
                    Return URL*
                </div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="returnURL" />
                </div>
                <div class="param_name">
                    IPN Notification URL (For receiving IPN call back from PayPal)
                </div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="ipnNotificationURL" />
                </div>
                <div class="param_name">
                    Sender Email (Email other than API caller)</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="senderEmail" Text="jb-us-seller2@paypal.com" />
                </div>
                <div class="section_header">
                    Receiver
                </div>
                <div class="note">
                    <i>Receiver is the party where funds are transferred to. A Primary Receiver receives
                        a Payment directly from the sender in a Chained Split Payment. A Primary Receiver
                        should not be specified when making a single or Parallel Split Payment. At most
                        one Receiver can be set as Primary Receiver.
                    </i>
                </div>
                <table>
                    <tr>
                        <th class="param_name">
                            Amount*
                        </th>
                        <th class="param_name">
                            Email*<br />(Primary Receiver should be the API caller)
                        </th>
                        <th>
                            Primary Receiver
                        </th>
                    </tr>
                    <tr>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="amount1" Text="3.00" />
                        </td>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="mail1" Text="jb-us-seller@paypal.com" Columns="50" />
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="primaryReceiver1">
                                <asp:ListItem Text="True" Value="true" Selected="True" />
                                <asp:ListItem Text="False" Value="false" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="amount2" Text="2.00" />
                        </td>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="mail2" Text="platfo_1255612361_per@gmail.com" Columns="50" />
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="primaryReceiver2">
                                <asp:ListItem Text="True" Value="true" />
                                <asp:ListItem Text="False" Value="false" Selected="True" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
            <br />
            <div class="submit">
                <asp:Button ID="ButtonAdaptivePayments" Text="DelayedChainedPayment" runat="server"
                    PostBackUrl="~/UseCaseSamples/RequestResponse.aspx" />
            </div>
            <br />
            <asp:HyperLink runat="server" ID="HyperLinkHome" NavigateUrl="~/Default.aspx" Text="Home" />
            <br />
            <br />
            <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="javascript:history.back();"
                Text="Back" />
        </div>
    </form>
</body>
</html>
