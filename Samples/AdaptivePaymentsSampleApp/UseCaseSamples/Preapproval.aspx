<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Preapproval.aspx.cs" Inherits="AdaptivePaymentsSampleApp.UseCaseSamples.Preapproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdaptivePayments API - Preapproval</title>
    <link rel="stylesheet" type="text/css" href="../Content/sdk.css" />
    <script type="text/javascript" src="../Content/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" src="../Content/sdk_functions.js"></script>
</head>
<body>
    <img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>Preapproval</h3>
            <div id="apidetails">
                <i>Preapproval API operation is used to set up an agreement between yourself and a sender
                    for making payments on the sender's behalf. You set up Preapprovals for a specific
                    maximum amount over a specific period of time and, optionally, by any of the following
                    constraints: Number of Payments, Maximum Per-Payment Amount, Specific Day of the
                    Week or Month, and If a PIN is required for each Payment request. 
                </i>
            </div>
        </div>
        <form id="form1" runat="server">
        <ajaxToolkit:ToolkitScriptManager runat="Server" EnableScriptGlobalization="true"
            EnableScriptLocalization="true" ID="ScriptManagerPreapprovalPayment" />
        <div>
            <div id="request_form">
                <div class="params">
                    <div class="param_name">
                        Currency Code*
                    </div>
                    <div class="param_value">
                        <asp:TextBox runat="server" ID="currencyCode" Text="USD" />
                    </div>
                    <table>
                        <tr>
                            <th class="param_name">
                                Starting Date*
                            </th>
                            <th class="param_name">
                                Ending Date
                            </th>
                        </tr>
                        <tr>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="startingDate" />
                                <asp:ImageButton runat="Server" ID="ImageButtonStartingDate" ImageUrl="~/Images/Calendar.png"
                                    AlternateText="Click to show calendar" /><br />
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtenderStartingDate" TargetControlID="startingDate"
                                    Format="yyyy-MM-dd" PopupButtonID="ImageButtonStartingDate" />
                            </td>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="endingDate" />
                                <asp:ImageButton runat="Server" ID="ImageButtonEndingDate" ImageUrl="~/Images/Calendar.png"
                                    AlternateText="Click to show calendar" /><br />
                                <ajaxToolkit:CalendarExtender runat="server" ID="CalendarExtenderEndingDate" TargetControlID="endingDate"
                                    Format="yyyy-MM-dd" PopupButtonID="ImageButtonEndingDate" />
                            </td>
                        </tr>
                    </table>
                    <div class="input_header">
                        URLs</div>
                    <table>
                        <tr>
                            <th class="param_name">
                                Cancel URL*
                            </th>
                            <th class="param_name">
                                Return URL*
                            </th>
                            <th class="param_name">
                                IPN Notification URL (For receiving IPN call back from PayPal)
                            </th>
                        </tr>
                        <tr>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="cancelURL" />
                            </td>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="returnURL" />
                            </td>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="ipnNotificationURL" />
                            </td>
                        </tr>
                    </table>
                    <div class="param_name">
                        Sender Email</div>
                    <div class="param_value">
                        <asp:TextBox runat="server" ID="senderEmail" Text="jb-us-seller2@paypal.com" />
                    </div>
                    <table>
                        <tr>
                            <th class="param_name">
                                Date Of Month
                            </th>
                            <th class="param_name">
                                Day Of Week
                            </th>
                        </tr>
                        <tr>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="dateOfMonth" Text="1" />
                            </td>
                            <td class="param_value">
                                <asp:DropDownList runat="server" ID="dayOfWeek">
                                    <asp:ListItem Text="No Day Specified" Value="NODAYSPECIFIED" />
                                    <asp:ListItem Text="Sunday" Value="SUNDAY" />
                                    <asp:ListItem Text="Monday" Value="MONDAY" />
                                    <asp:ListItem Text="Tuesday" Value="TUESDAY" />
                                    <asp:ListItem Text="Wednesday" Value="WEDNESDAY" />
                                    <asp:ListItem Text="Thursday" Value="THURSDAY" />
                                    <asp:ListItem Text="Friday" Value="FRIDAY" />
                                    <asp:ListItem Text="Saturday" Value="SATURDAY" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <div class="input_header">
                        Payment Details</div>
                    <table>
                        <tr>
                            <th class="param_name">
                                Maximum Amount<br />
                                Per Payment
                            </th>
                            <th class="param_name">
                                Maximum Number<br />
                                Of Payments
                            </th>
                            <th class="param_name">
                                Maximum Number<br />
                                Of Payments Per Period
                            </th>
                            <th class="param_name">
                                Total Amount<br />
                                Of All Payments
                            </th>
                            <th class="param_name">
                                Payment<br />
                                Period
                            </th>
                            <th class="param_name">
                                Display Maximum<br />
                                Total Amount
                            </th>
                        </tr>
                        <tr>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="maxAmountPerPayment" Text="1.00" />
                            </td>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="maxNumberOfPayments" Text="2" />
                            </td>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="maxNumberOfPaymentsPerPeriod" Text="2" />
                            </td>
                            <td class="param_value">
                                <asp:TextBox runat="server" ID="totalAmountOfAllPayments" Text="10.00" />
                            </td>
                            <td class="param_value">
                                <asp:DropDownList runat="server" ID="paymentPeriod">
                                    <asp:ListItem Text="No Period Specified" Value="NO_PERIOD_SPECIFIED" />
                                    <asp:ListItem Text="Daily" Value="DAILY" />
                                    <asp:ListItem Text="Weekly" Value="WEEKLY" />
                                    <asp:ListItem Text="Biweekly" Value="BIWEEKLY" />
                                    <asp:ListItem Text="Semi-Monthly" Value="SEMIMONTHLY" />
                                    <asp:ListItem Text="Monthly" Value="MONTHLY" />
                                    <asp:ListItem Text="Annually" Value="ANNUALLY" />
                                </asp:DropDownList>
                            </td>
                            <td class="param_value">
                                <asp:DropDownList runat="server" ID="displayMaxTotalAmount">
                                    <asp:ListItem Text="True" Value="true" Selected="True" />
                                    <asp:ListItem Text="False" Value="false" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
                <div class="submit">
                    <asp:Button ID="ButtonAdaptivePayments" Text="Preapproval" runat="server"
                        PostBackUrl="~/UseCaseSamples/RequestResponse.aspx" />
                </div>
                <br />
                <asp:HyperLink runat="server" ID="HyperLinkHome" NavigateUrl="~/Default.aspx" Text="Home" />
                <br />
                <br />
                <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="javascript:history.back();"
                    Text="Back" />
            </div>
        </div>
        </form>
    </div>
</body>
</html>
