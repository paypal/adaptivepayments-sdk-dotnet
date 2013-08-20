<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Preapproval.aspx.cs" Inherits="AdaptivePaymentsSampleApp.Preapproval" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Preapproval</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Preapproval</h3>
            <div id="apidetails">
                Use the Preapproval API operation to set up an agreement between yourself and a
                sender for making payments on the sender’s behalf.<br />
                You set up a preapprovals for a specific maximum amount over a specific period of
                time and, optionally, by any of the following constraints: the number of payments,
                a maximum perpayment amount, a specific day of the week or the month, and whether
                or not a PIN is required for each payment request.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Cancel Url *</div>
                    <div class="param_value">
                        <input name="cancelUrl" id="cancelUrl" value="" runat="server" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Currency code *</div>
                    <div class="param_value">
                        <input name="currencyCode" value="USD" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Payment date - Date of month</div>
                    <div class="param_value">
                        <input name="dateOfMonth" id="dateOfMonth" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Payment date - Day of week</div>
                    <div class="param_value">
                        <select name="dayOfWeek" id="dayOfWeek">
                            <option value="">- Select -</option>
                            <option>NO_DAY_SPECIFIED</option>
                            <option>SUNDAY</option>
                            <option>MONDAY</option>
                            <option>TUESDAY</option>
                            <option>WEDNESDAY</option>
                            <option>THURSDAY</option>
                            <option>FRIDAY</option>
                            <option>SATURDAY</option>
                        </select>
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Payment end date</div>
                    <div class="param_value">
                        <input name="endingDate" id="endingDate" value="" runat="server" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Maximum amount per payment</div>
                    <div class="param_value">
                        <input name="maxAmountPerPayment" id="maxAmountPerPayment" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Maximum number of payments</div>
                    <div class="param_value">
                        <input name="maxNumberOfPayments" id="maxNumberOfPayments" value="10" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Maximum number of payments per period</div>
                    <div class="param_value">
                        <input name="maxNumberOfPaymentsPerPeriod" id="maxNumberOfPaymentsPerPeriod" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Maximum total amount of all payments</div>
                    <div class="param_value">
                        <input name="maxTotalAmountOfAllPayments" id="maxTotalAmountOfAllPayments" value="50.0" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Payment period</div>
                    <div class="param_value">
                        <select name="paymentPeriod" id="paymentPeriod">
                            <option value="">- Select -</option>
                            <option>NO_PERIOD_SPECIFIED</option>
                            <option>DAILY</option>
                            <option>WEEKLY</option>
                            <option>BIWEEKLY</option>
                            <option>SEMIMONTHLY</option>
                            <option>MONTHLY</option>
                            <option>ANNUALLY</option>
                        </select>
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Return URL *</div>
                    <div class="param_value">
                        <input name="returnUrl" id="returnUrl" value="" runat="server" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Memo</div>
                    <div class="param_value">
                        <input name="memo" id="memo" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        IPN Notification URL</div>
                    <div class="param_value">
                        <input name="ipnNotificationUrl" id="ipnNotificationUrl" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Sender email</div>
                    <div class="param_value">
                        <input name="senderEmail" id="senderEmail" runat="server" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Starting date *</div>
                    <div class="param_value">
                        <input name="startingDate" id="startingDate" runat="server" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Is PIN type required</div>
                    <div class="param_value">
                        <select name="pinType" id="pinType">
                            <option value="">- Select -</option>
                            <option>NOT_REQUIRED</option>
                            <option>REQUIRED</option>
                        </select>
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Fees payer</div>
                    <div class="param_value">
                        <select name="feesPayer">
                            <option value="EACHRECEIVER">EACHRECEIVER</option>
                            <option value="PRIMARYRECEIVER">PRIMARYRECEIVER</option>
                            <option value="SENDER" selected="selected">SENDER</option>
                            <option value="SECONDARYONLY">SECONDARYONLY</option>
                        </select>
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Display maximum total amount</div>
                    <div class="param_value">
                        <input name="displayMaxTotalAmount" id="displayMaxTotalAmount" value="" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="Preapproval" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
