<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="empSearchWithSPoutParameter.aspx.cs" Inherits="EmployeeMgmt.empSearchWithSPoutParameter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Eid : <asp:TextBox runat="server" ID="tbeid" /><asp:Button Text="Find" ID="btnfind" runat="server" OnClick="btnfind_Click" /><br />
            Fname : <asp:TextBox runat="server" ID="tbfname" /><br />
            Lname : <asp:TextBox runat="server" ID="tblname" /><br />
            Doj : <asp:TextBox runat="server" ID="tbdoj" /><br />
            Salary : <asp:TextBox runat="server" ID="tbsal" /><br />
        </div>
    </form>
</body>
</html>
