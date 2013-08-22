<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="RequestResponse.aspx.cs" Inherits="AdaptivePaymentsSampleApp.RequestResponse" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title runat="server" id="titleName"></title>
</head>
<body>
    <img src="https://devtools-paypal.com/image/bdg_payments_by_pp_2line.png" alt="PAYMENTS BY PayPal" />
    <form id="form1" runat="server">
    <div>
        <br />
        <asp:Label runat="server" ID="LabelName" Font-Bold="true" />
        <br />
        <br />
        <asp:Label runat="server" ID="LabelWebFlow" Font-Italic="true" />
        <asp:HyperLink runat="server" ID="HyperLinkWebFlow" Font-Italic="true" />
        <asp:Label runat="server" ID="LabelWebFlowSuffix" Font-Italic="true" />
        <div>
            <asp:Repeater runat="server" ID="RepeaterError">
                <HeaderTemplate>
                    <b>Error</b>        
                </HeaderTemplate>
                <ItemTemplate>
                    <ul>
                        <li>
                            <i>
                                <%# Eval("message")%>
                            </i>
                        </li>
                    </ul> 
                </ItemTemplate>
                <FooterTemplate>
                    <i>Please refer to the Response object for further Error information.</i>
                    <br />
                    <br />
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <asp:Label runat="server" ID="LabelResponseValues" Text="Response Values" Font-Bold="true" />
        <br />
        <br />
        <div>
            <asp:GridView runat="server" ID="GridViewResponseValues" AutoGenerateColumns="false">
                <RowStyle BackColor="#EFF3FB" />
                <AlternatingRowStyle BackColor="#FFFFFF" />
                <Columns>
                    <asp:BoundField DataField="Key" HeaderText="Key" />
                    <asp:BoundField DataField="Value" HeaderText="Value" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:Label runat="server" ID="LabelConsult" Text="Please refer to the Response object for the complete list of Response Values."
                Font-Italic="true" />
        </div>
        <br />
        <asp:Label runat="server" ID="LabelRequest" Text="Request" Font-Bold="true" />
        <br />
        <br />
        <asp:TextBox runat="server" ID="TextBoxRequest" TextMode="MultiLine" Rows="5" Width="95%" />
        <br />
        <br />
        <asp:Label runat="server" ID="LabelResponse" Text="Response" Font-Bold="true" />
        <br />
        <br />
        <asp:TextBox runat="server" ID="TextBoxResponse" TextMode="MultiLine" Rows="5" Width="95%" />
        <br />
        <br />
        <div>
            <asp:Label runat="server" ID="LabelNotePaymentType" Font-Bold="true" />
            <asp:Label runat="server" ID="LabelPrefixPaymentType" Font-Italic="true" />
            <asp:HyperLink runat="server" ID="HyperLinkPaymentType" Font-Italic="true" />
            <asp:Label runat="server" ID="LabelSuffixPaymentType" Font-Italic="true" />
        </div>
        <div>
            <asp:Label runat="server" ID="LabelNoteTransactionId" Font-Bold="true" />
            <asp:Label runat="server" ID="LabelPrefixTransactionId" Font-Italic="true" />
            <asp:HyperLink runat="server" ID="HyperLinkTransactionId" Font-Italic="true" />
            <asp:Label runat="server" ID="LabelSuffixTransactionId" Font-Italic="true" />
        </div>
        <asp:HyperLink runat="server" ID="HyperLinkHome" NavigateUrl="~/Default.aspx" Text="Home" />
        <br />
        <br />
        <asp:HyperLink ID="HyperLinkBack" runat="server" NavigateUrl="javascript:history.back();" Text="Back" />
    </div>
    </form>
</body>
</html>
