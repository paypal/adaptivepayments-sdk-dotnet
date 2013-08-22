<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Default.aspx.cs" Inherits="AdaptivePaymentsSampleApp._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdaptivePayments API Sample App</title>
</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />    
    <form id="form1" runat="server">
        <div>
            <br />
            <h2>AdaptivePayments API UseCase Samples</h2>
            <div>
                <asp:BulletedList runat="server" ID="BulletedListUseCaseSamples" DisplayMode="HyperLink"> 
                    <asp:ListItem Value="~/UseCaseSamples/SimplePayment.aspx" Text="SimplePayment" />
                    <asp:ListItem Value="~/UseCaseSamples/ParallelPayment.aspx" Text="ParallelPayment" />
                    <asp:ListItem Value="~/UseCaseSamples/ChainedPayment.aspx" Text="ChainedPayment" />
                    <asp:ListItem Value="~/UseCaseSamples/DelayedChainedPayment.aspx" Text="DelayedChainedPayment" />
                    <asp:ListItem Value="~/UseCaseSamples/DeferredPayment.aspx" Text="DeferredPayment" /> 
                    <asp:ListItem Value="~/UseCaseSamples/Preapproval.aspx" Text="PreapprovalPayment" />
                </asp:BulletedList>
            </div>
            <br />
            <h2>AdaptivePayments API Samples</h2>
            <div>              
                <a href="Pay.aspx">Pay</a>
                <br />
                <a href="PaymentDetails.aspx">Payment Details</a>
                <br />
                <a href="Preapproval.aspx">Preapproval</a>
                <br />
                <a href="PreapprovalDetails.aspx">PreapprovalDetails</a>
                <br />
                <a href="ConfirmPreapproval.aspx">ConfirmPreapproval</a>
                <br />
                <a href="CancelPreapproval.aspx">CancelPreapproval</a>
                <br />
                <a href="Refund.aspx">Refund</a>
                <br />
                <a href="ConvertCurrency.aspx">ConvertCurrency</a>
                <br />
                <a href="GetPaymentOptions.aspx">GetPaymentOptions</a>
                <br />
                <a href="SetPaymentOptions.aspx">SetPaymentOptions</a>
                <br />
                <a href="ExecutePayment.aspx">ExecutePayment</a>
                <br />
                <a href="GetAllowedFundingSources.aspx">GetAllowedFundingSources</a>
                <br />
                <a href="GetFundingPlans.aspx">GetFundingPlans</a>
                <br />
                <a href="GetAvailableShippingAddresses.aspx">GetAvailableShippingAddresses</a>
                <br />
                <a href="GetShippingAddresses.aspx">GetShippingAddresses</a>
                <br />
                <a href="GetUserLimits.aspx">GetUserLimits</a>   
            </div>            
        </div>
    </form>
</body>
</html>
