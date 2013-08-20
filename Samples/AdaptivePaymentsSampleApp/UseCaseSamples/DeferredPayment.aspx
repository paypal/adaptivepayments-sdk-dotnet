<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeferredPayment.aspx.cs" Inherits="AdaptivePaymentsSampleApp.UseCaseSamples.DeferredPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdaptivePayments API - Deferred Payment</title>
    <link rel="stylesheet" type="text/css" href="../Content/sdk.css" />
    <script type="text/javascript" src="../Content/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Content/sdk_functions.js"></script>
</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>Deferred Payment</h3>
            <div id="apidetails">
                <p>
                    <i>                    
                        Deferred Payment is about  Creating a Payment (Using  Pay API with [actionType:create]) 
                        and Executing a Payment later (using ExecutingPayment API). 
                        Here the sender Email should be the Email of API caller (whose credential are used for the API call), 
                        the Payment needs to be approved for a deferred payment.
                    </i>
                </p>
            </div>
        </div>
    </div>
    <br />
    <form id="form1" runat="server">
        <div id="request_form">
            <div class="params">
                <div class="param_name">Currency Code*</div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="currencyCode" Text="USD" />
                </div>
                <div class="param_name">Action Type*</div>
                <div class="param_value">
                <asp:DropDownList runat="server" ID="actionType">
                    <asp:ListItem Text="Pay" Value="PAY" Enabled="false" />
                    <asp:ListItem Text="Pay Primary" Value="PAY_PRIMARY" Enabled="false" />
                    <asp:ListItem Text="Create" Value="CREATE" Selected="True" />
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
                <div class="param_name">
                    IPN Notification URL (For receiving IPN call back from PayPal)
                </div>
                <div class="param_value">
                    <asp:TextBox runat="server" ID="ipnNotificationURL" />
                </div>
                <div class="param_name">Sender Email*</div>
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
                        <th class="param_name">Email*</th>
                    </tr>
                    <tr>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="amount" Text="1.00" />
                        </td>
                        <td class="param_value">
                            <asp:TextBox runat="server" ID="mail" Text="platfo_1255612361_per@gmail.com" Columns="35" />
                        </td>
                    </tr>

                </table>
                <br />
                <div class="submit">
                    <asp:Button ID="ButtonAdaptivePayments" Text="DeferredPayment" runat="server" PostBackUrl="~/UseCaseSamples/RequestResponse.aspx" />
                </div>
                <br />
                <b>Please Note</b>
                <div id="relatedcalls">
                    <p>
                        <i>
                            The Payment will be created with <b>Pay</b> API request, with the request parameter Action Type as CREATE. To complete the 
		                    Payment at a later date, you have to execute the payment using <b>ExecutePayment</b> API. If you have to set the Payment Option, 
		                    you need to call the optional <b>SetPaymentOptions</b> API before calling the <b>ExecutePayment</b> API.	    
                        </i>
                    </p>       	
                </div>
                <br />
                <asp:HyperLink runat="server" ID="HyperLinkHome" NavigateUrl="~/Default.aspx" Text="Home" />
                <br />
                <br />
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="javascript:history.back();" Text="Back" />
            </div>
        </div>
    </form>    
</body>
</html>
