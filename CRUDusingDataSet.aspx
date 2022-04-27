<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDusingDataSet.aspx.cs" Inherits="EmployeeMgmt.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous">

</head>
<body>
    <form id="form1" runat="server">
        <div class ="container  pt-2 py-5  my-5 mx-5 border ">
           <div class=" align-self-lg-center"><h3>CRUD operations using DataSet</h3></div> 
            Id : <asp:TextBox runat="server" ID="tbsid" /> <asp:Button Text="Find"  ID="btnfind" runat="server" OnClick="btnfind_Click"  /><br />
            FName : <asp:TextBox runat="server" ID="tbfname" /><br />
            LName : <asp:TextBox runat="server" ID="tblname" /><br />
            Class :<asp:TextBox runat="server"  ID="tbclass"/><br />
            <br />
            <asp:Button CssClass=" btn-outline-success btn-lg " Text="Add in Ds" ID="btnaddinds" runat="server" OnClick="btnaddinds_Click" /> &nbsp&nbsp&nbsp
            <asp:Button CssClass="btn-outline-danger btn-lg" Text="Update in Ds" ID="btnupdateinds" runat="server" OnClick="btnupdateinds_Click" />&nbsp&nbsp&nbsp
            <asp:Button CssClass="btn-outline-secondary btn-lg" Text="Delete in Ds" ID="btndeleteinds" runat="server" OnClick="btndeleteinds_Click" />&nbsp&nbsp&nbsp
            <br/>
            <br/>
            <asp:Button Text="Add in DB" ID="AddinDB" runat="server" OnClick="AddinDB_Click" /> &nbsp&nbsp&nbsp
            <asp:Button Text="Update in DB" ID="updateinDB" runat="server" OnClick="updateinDB_Click" />&nbsp&nbsp&nbsp
            <asp:Button Text="Delete in DB" ID="deleteinBD" runat="server" OnClick="deleteinBD_Click" />&nbsp&nbsp&nbsp
            <br    />  
                <br />
            <br />
            </div>
        <div>
            <asp:GridView runat="server" ID="gvstudents" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="879px">
                <AlternatingRowStyle BackColor="White" />
                <FooterStyle BackColor="#CCCC99" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <RowStyle BackColor="#F7F7DE" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#FBFBF2" />
                <SortedAscendingHeaderStyle BackColor="#848384" />
                <SortedDescendingCellStyle BackColor="#EAEAD3" />
                <SortedDescendingHeaderStyle BackColor="#575357" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
