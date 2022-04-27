<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionsComplete.aspx.cs" Inherits="EmployeeMgmt.TransactionsComplete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Transfer Amount</h3>
            From : <asp:TextBox runat="server" ID="tbfrom" /><br />
            To : <asp:TextBox runat="server" ID="tbto" /><br />
            Amount : <asp:TextBox runat="server" ID="tbamount" /><br />
            <asp:Button Text="Transfer" runat="server" ID ="btntransfer" OnClick="btntransfer_Click" />
            <br />
            <br />
            <asp:GridView ID="gvaccounts" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="603px">
                <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
                <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
                <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
                <RowStyle BackColor="White" ForeColor="#003399" />
                <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
                <SortedAscendingCellStyle BackColor="#EDF6F6" />
                <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
                <SortedDescendingCellStyle BackColor="#D6DFDF" />
                <SortedDescendingHeaderStyle BackColor="#002876" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
