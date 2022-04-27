<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeUpdate.aspx.cs" Inherits="EmployeeMgmt.EmployeeUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
                        <h3>Employee Update Page</h3>
            Eid : <asp:TextBox runat="server" ID="tbeid" /><asp:Button Text="Find" ID="btnfetch" runat="server" OnClick="btnfetch_Click" /><br />
            Fname : <asp:TextBox runat="server" ID="tbfname" /><br />
            Lname : <asp:TextBox runat="server" ID="tblname" /><br />
            Doj : <asp:TextBox runat="server" ID="tbdoj" /><br />
            Salary : <asp:TextBox runat="server" ID="tbsal" /><br />
            <asp:Button Text="Update" ID="btnupdate" runat="server" OnClick="btnupdate_Click" />
        </div>
    </form>
</body>
</html>
