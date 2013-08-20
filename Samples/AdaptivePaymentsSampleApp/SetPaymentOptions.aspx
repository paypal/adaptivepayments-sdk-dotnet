<%@ Page Language="C#" AutoEventWireup="true" Codebehind="SetPaymentOptions.aspx.cs"
    Inherits="AdaptivePaymentsSampleApp.SetPaymentOptions" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>PayPal Adaptive Payments - Set Payment Options</title>
    <link rel="stylesheet" type="text/css" href="Content/sdk.css" />

    <script type="text/javascript" src="Content/jquery-1.3.2.min.js"></script>

    <script type="text/javascript" src="Content/sdk_functions.js"></script>

</head>
<body>
	<img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <div id="wrapper">
        <div id="header">
            <h3>
                Set Payment Options</h3>
            <div id="apidetails">
                Use the SetPaymentOptions API operation to specify settings for a payment of the
                actionType CREATE. This actionType is specified in the PayRequest message.</div>
        </div>
        <div id="request_form">
            <form id="Form1" method="post" action="AdaptivePaymentsHandler.ashx" runat="server">
                <div class="params">
                    <div class="param_name">
                        Pay key *</div>
                    <div class="param_value">
                        <input name="payKey" id="payKey" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Initiating institution</div>
                <div class="params">
                    <div class="param_name">
                        Institution Id</div>
                    <div class="param_value">
                        <input name="institutionId" id="institutionId" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        First name</div>
                    <div class="param_value">
                        <input name="firstName" id="firstName" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Last name</div>
                    <div class="param_value">
                        <input name="lastName" id="lastName" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Display name</div>
                    <div class="param_value">
                        <input name="displayName" id="displayName" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Institution customer Id</div>
                    <div class="param_value">
                        <input name="institutionCustomerId" id="institutionCustomerId" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Country code</div>
                    <div class="param_value">
                        <input name="countryCode" id="countryCode" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Email</div>
                    <div class="param_value">
                        <input name="email" id="email" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Display options</div>
                <div class="params">
                    <div class="param_name">
                        Email header image Url</div>
                    <div class="param_value">
                        <input name="emailHeaderImageUrl" id="emailHeaderImageUrl" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Email marketing image Url</div>
                    <div class="param_value">
                        <input name="emailMarketingImageUrl" id="emailMarketingImageUrl" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Header image Url</div>
                    <div class="param_value">
                        <input name="headerImageUrl" id="headerImageUrl" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Business name</div>
                    <div class="param_value">
                        <input name="businessName" id="businessName" value="" />
                    </div>
                </div>
                <div class="section_header">
                </div>
                <div class="params">
                    <div class="param_name">
                        Shipping address Id</div>
                    <div class="param_value">
                        <input name="shippingAddressId" id="shippingAddressId" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Sender options</div>
                <div class="params">
                    <div class="param_name">
                        Requires shipping address selection</div>
                    <div class="param_value">
                        <input name="requireShippingAddressSelection" id="requireShippingAddressSelection"
                            value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Referrer code</div>
                    <div class="param_value">
                        <input name="referrerCode" id="referrerCode" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Receiver options</div>
                <div class="params">
                    <div class="param_name">
                        Description</div>
                    <div class="param_value">
                        <input name="description" id="description" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Custom Id</div>
                    <div class="param_value">
                        <input name="customId" id="customId" value="" />
                    </div>
                </div>
                <div class="section_header">
                    Invoice data</div>
                <div class="input_header">
                    Invoice item</div>
                <table id="invoiceItemTable">
                    <tr>
                        <th>
                        </th>
                        <th>
                            Name</th>
                        <th>
                            Identifier</th>
                        <th>
                            Price</th>
                        <th>
                            Item price</th>
                        <th>
                            Item count</th>
                    </tr>
                    <tr id="invoiceItemTable_0">
                        <td align="left">
                            <input type="checkbox" name="invoiceItem" id="invoiceItem_0" /></td>
                        <td>
                            <input type="text" name="name" id="name_0" value="" /></td>
                        <td>
                            <input type="text" name="identifier" id="identifier_0" value="" /></td>
                        <td>
                            <input type="text" name="price" id="price_0" value="" /></td>
                        <td>
                            <input type="text" name="itemPrice" id="itemPrice_0" value="" /></td>
                        <td>
                            <input type="text" name="itemCount" id="itemCount_0" value="" /></td>
                    </tr>
                </table>
                <table align="center">
                    <tr>
                        <td>
                            <a onclick="cloneRow('invoiceItemTable', 10)" id="Submit"><span>Add Item </span></a>
                        </td>
                        <td>
                            <a onclick="deleteRow('invoiceItemTable')" id="A1"><span>Delete Item</span> </a>
                        </td>
                    </tr>
                </table>
                <div class="params">
                    <div class="param_name">
                        Total tax</div>
                    <div class="param_value">
                        <input name="totalTax" id="totalTax" value="" />
                    </div>
                </div>
                <div class="params">
                    <div class="param_name">
                        Total shipping</div>
                    <div class="param_value">
                        <input name="totalShipping" id="totalShipping" value="" />
                    </div>
                </div>
                <div class="input_header">
                    Receiver identifier</div>
                <table class="params">
                    <tr>
                        <th>
                            Email</th>
                        <th>
                            Phone</th>
                    </tr>
                    <tr>
                        <td>
                            <input name="emailIdentifier" id="emailIdentifier" value="" /></td>
                        <td>
                            <input type="text" name="phoneCountry" id="phoneCountry" value="" class="xsmallfield" />
                            -
                            <input type="text" name="phoneNumber" id="phoneNumber" value="" class="xsmallfield" />
                            <input type="text" name="phoneExtn" id="phoneExtn" value="" class="xsmallfield" />
                        </td>
                    </tr>
                </table>
                <div class="params">
                    <div class="param_name">
                        Referrer code</div>
                    <div class="param_value">
                        <input name="receiverReferrerCode" id="receiverReferrerCode" value="" />
                    </div>
                </div>
                <div class="submit">
                    <asp:Button ID="AdaptivePaymentsBtn" Text="SetPaymentOptions" runat="server" PostBackUrl="AdaptivePaymentsHandler.ashx" />
                </div>
            </form>
        </div>
        <a href="Default.aspx">Home</a>
    </div>
</body>
</html>
