<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientWithBloodgroups.aspx.cs" Inherits="EmployeeMgmt.PatientWithBloodgroups" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Patient Form</h3>
            Id <asp:TextBox runat="server" ID="tbpatid" />  <asp:Button Text="Find" ID="btnfind" runat="server" OnClick="btnfind_Click" /> <br />
            Name <asp:TextBox runat="server" ID="tbpatname" /> <br />
            Age : <asp:DropDownList runat="server" ID="ddlage">
            </asp:DropDownList>    <br />
            Blood Group : <asp:DropDownList runat="server" ID="ddlbg">
                            </asp:DropDownList><br />
            <asp:Button Text="Add Patient" runat="server" ID="btnadd" OnClick="btnadd_Click" />&nbsp&nbsp
            <asp:Button Text="Update Patient" runat="server" ID="btnupdate" OnClick="btnupdate_Click" />&nbsp&nbsp
            <asp:Button Text="Delete" runat="server" ID="btndelete" OnClick="btndelete_Click" />&nbsp&nbsp
            <asp:Button Text="List" ID="btnlistallpatients" runat="server" OnClick="btnlistallpatients_Click" /><br />
            <br />

            <asp:GridView runat="server" ID="gridpatients" CellPadding="4" ForeColor="#333333" GridLines="None" Width="796px" Visible="false">
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Left" />
                <RowStyle BackColor="#E3EAEB" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            
        </div>
    </form>
</body>
</html>
