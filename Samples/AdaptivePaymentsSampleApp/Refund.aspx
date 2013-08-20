<%@ Page Language="C#" AutoEventWireup="true" Codebehind="Refund.aspx.cs" Inherits="AdaptivePaymentsSampleApp.Refund" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Refund</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Refund</h3>
            <div id="apidetails">
                A request to make a refund based on various criteria. A refund can be made against
                the entire payKey, an individual transaction belonging to a payKey, a tracking id,
                or a specific receiver of a payKey.</div>
        </div>
        <div id="request_form">
            <form action="AdaptivePaymentsHandler.ashx" method="post" runat="server">
                <div class="params">
                    <div class="param_name">
                        Currency code</div>
                    <div class="param_value">
                        <input name="currencyCode" id="currencyCode" value="USD" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Pay key</div>
                    <div class="param_value">
                        <input name="payKey" id="payKey" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Transaction Id</div>
                    <div class="param_value">
                        <input name="transactionId" id="transactionId" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Tracking id</div>
                    <div class="param_value">
                        <input name="trackingId" id="trackingId" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Receiver info</div>
                <table class="params" id="receiverTable">
                    <tr>
                        <th>
                        </th>
                        <th>
                            Email *</th>
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
                            <input type="checkbox" name="receiver" id="receiver_0" /></td>
                        <td>
                            <input type="text" name="receiverEmail" id="receiveremail_0" value="platfo_1255612361_per@gmail.com" />
                        </td>
                        <td>
                            <input type="text" name="receiverAmount" id="amount_0" value="1.0" class="smallfield" />
                        </td>
                        <td>
                            <input type="text" name="phoneCountry" id="phoneCountry_0" value="" class="xsmallfield" />
                            <input type="text" name="phoneNumber" id="phoneNumber_0" value="" class="xsmallfield" />
                            <input type="text" name="phoneExtn" id="phoneExtn_0" value="" class="xsmallfield" />
                        </td>
                        <td>
                            <select name="primaryReceiver" id="primaryReceiver_0" class="smallfield">
                                <option value="true">true</option>
                                <option value="false" selected="selected">false</option>
                            </select>
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
                            </select>
                        </td>
                        <td>
                            <input type="text" name="paymentSubType" id="paymentSubType" value="" class="smallfield" />
                        </td>
                    </tr>
                </table>
                <table align="center">
                    <tr>
                        <td>
                            <a onclick="cloneRow('receiverTable', 8)" id="addrow"><span>Add Receiver </span></a>
                        </td>
                        <td>
                            <a onclick="deleteRow('receiverTable')" id="deleterow"><span>Delete Receiver</span>
                            </a>
                        </td>
                    </tr>
                </table>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="Refund" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
