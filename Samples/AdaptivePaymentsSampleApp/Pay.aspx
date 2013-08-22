<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Pay.aspx.cs" Inherits="AdaptivePaymentsSampleApp.Pay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Pay</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Pay</h3>
            <div id="apidetails">
                Use the Pay API operation to transfer funds from a sender’s PayPal account to one
                or more receivers’ PayPal accounts. You can use the Pay API operation to make simple
                payments, chained payments, or parallel payments.</div>
        </div>
        <div id="request_form">
            <form action="AdaptivePaymentsHandler.ashx" method="post" runat="server">
                <div class="params">
                    <div class="param_name">
                        Action type *</div>
                    <div class="param_value">
                        <select name="actionType" id="actionType">
                            <option value="PAY">PAY</option>
                            <option value="CREATE">CREATE</option>
                            <option value="PAY_PRIMARY">PAY_PRIMARY</option>
                        </select>
                    </div>
                </div>
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
                        IPN Notification Url</div>
                    <div class="param_value">
                        <input name="ipnNotificationUrl" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Memo</div>
                    <div class="param_value">
                        <input name="memo" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        PIN</div>
                    <div class="param_value">
                        <input name="pin" id="pin" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Preapproval key</div>
                    <div class="param_value">
                        <input name="preapprovalKey" id="preapprovalKey" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Receiver info</div>
                <table class="params" id="receiverTable">
                    <tr>
                        <th>
                        </th>
                        <th>
                            Email</th>
                        <th>
                            Amount *</th>
                        <th>
                            Phone number</th>
                        <th>
                            Primary receiver</th>
                        <th>
                            Invoice Id</th>
                        <th>
                            Payment type</th>
                        <th>
                            Payment subtype</th>
                    </tr>
                    <tr id="receiverTable_0">
                        <td align="left">
                            <input type="checkbox" name="receiver" id="receiver_0" disabled="disabled" /></td>
                        <td>
                            <input type="text" name="receiverEmail" id="receiveremail_0" value="platfo_1255612361_per@gmail.com" />
                        </td>
                        <td>
                            <input type="text" name="receiverAmount" id="amount_0" value="1.0" class="smallfield" />
                        </td>
                        <td>
                            <input type="text" name="phoneCountry" id="phoneCountry_0" value="" class="xsmallfield" />
                            -
                            <input type="text" name="phoneNumber" id="phoneNumber_0" value="" class="xsmallfield" />
                            <input type="text" name="phoneExtn" id="phoneExtn_0" value="" class="xsmallfield" />
                        </td>
                        <td>
                            <select name="primaryReceiver" id="primaryReceiver_0" class="smallfield">
                                <option value="true">true</option>
                                <option value="false" selected="selected">false</option>
                            </select>
                            <asp:DropDownList runat="server" ID="primaryReceiver1">
                                <asp:ListItem Text="True" Value="true" Selected="True" />
                                <asp:ListItem Text="False" Value="false" />
                            </asp:DropDownList>
                        </td>
                        <td>
                            <input type="text" name="invoiceId" id="invoiceid_0" value="" class="smallfield" />
                        </td>
                        <td>
                            <select name="paymentType" id="paymentType_0" class="smallfield">
                                <option value="">- Select -</option>
                                <option>GOODS</option>
                                <option>SERVICE</option>
                                <option>PERSONAL</option>
                                <option>CASHADVANCE</option>
                                <option>DIGITALGOODS</option>
                                <option>BANK_MANAGED_WITHDRAWAL</option>
                            </select>
                        </td>
                        <td>
                            <input type="text" name="paymentSubType" id="paymentSubType_0" value="" class="smallfield" />
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td>
                            <a onclick="cloneRow('receiverTable', 8)" id="Submit"><span>Add Receiver </span></a>
                        </td>
                        <td>
                            <a onclick="deleteRow('receiverTable')" id="A1"><span>Delete Receiver</span> </a>
                        </td>
                    </tr>
                </table>
                <div class="params">
                    <div class="param_name">
                        Reverse all parallel payments on error</div>
                    <div class="param_value">
                        <input name="reverseAllParallelPaymentsOnError" id="reverseAllParallelPaymentsOnError"
                            value="false" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Sender email (Optional for Guest Payment)</div>
                    <div class="param_value">
                        <input name="senderEmail" id="senderEmail" value="platfo_1255077030_biz@gmail.com" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Return Url</div>
                    <div class="param_value">
                        <input name="returnUrl" id="returnUrl" value="" runat="server" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Tracking Id</div>
                    <div class="param_value">
                        <input name="trackingId" id="trackingId" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Funding constraint (Requires advanced permission levels)</div>
                    <div class="param_value">
                        <select name="fundingConstraint" id="fundingConstraint">
                            <option value="">- Select -</option>
                            <option>ECHECK</option>
                            <option>BALANCE</option>
                            <option>CREDITCARD</option>
                        </select>
                    </div>
                </div>
                <div class="input_header">
                    Sender Identifier</div>
                <table class="params">
                    <tr>
                        <th>
                            Email</th>
                        <th>
                            Phone</th>
                        <th>
                            Use Credentials</th>
                    </tr>
                    <tr>
                        <td>
                            <input name="emailIdentifier" id="emailIdentifier" value="" /></td>
                        <td>
                            <input type="text" name="senderPhoneCountry" id="senderPhoneCountry" value="" class="xsmallfield" />
                            -
                            <input type="text" name="senderPhoneNumber" id="5 minutes" value="" class="xsmallfield" />
                            <input type="text" name="senderPhoneExtn" id="senderPhoneExtn" value="" class="xsmallfield" />
                        </td>
                        <td>
                            <input name="useCredentials" id="useCredentials" value="" /></td>
                    </tr>
                </table>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="Pay" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
