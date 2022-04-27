<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeRegistration.aspx.cs" Inherits="EmployeeMgmt.EmployeeRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Employee Registration Page</h3>
            Eid : <asp:TextBox runat="server" ID="tbeid" /><br />
            Fname : <asp:TextBox runat="server" ID="tbfname" /><br />
            Lname : <asp:TextBox runat="server" ID="tblname" /><br />
            Doj : <asp:TextBox runat="server" ID="tbdoj" /><br />
            Salary : <asp:TextBox runat="server" ID="tbsal" /><br />
            <asp:Button Text="Register" ID="tbregister" runat="server" OnClick="tbregister_Click" />
        </div>
    </form>
</body>
</html>
