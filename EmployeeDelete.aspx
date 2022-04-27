<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDelete.aspx.cs" Inherits="EmployeeMgmt.EmployeeDelete" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Employee Delete Page</h3>
           Enter Employee ID : <asp:TextBox runat="server" ID="tbeid" /><br />
            <asp:Button Text="Delete" ID="btndelete" runat="server" OnClick="btndelete_Click" style="height: 26px" />
        </div>
    </form>
</body>
</html>
