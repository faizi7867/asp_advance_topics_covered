<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MARS.aspx.cs" Inherits="EmployeeMgmt.MARS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            state  : <asp:TextBox ID="tbstate" runat="server" /><br />
            country  : <asp:TextBox ID="tbcountry" runat="server" /><br />
            <asp:Button Text="Submit" ID="btnadd" runat="server" Height="49px" OnClick="btnadd_Click1" Width="133px" />
        </div>
    </form>
</body>
</html>
