<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompleteCitiesList.aspx.cs" Inherits="EmployeeMgmt.CompleteCitiesList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h3>Search District</h3>
            Select Country <asp:DropDownList AutoPostBack="true" ID ="ddlcountries" runat="server">
                           </asp:DropDownList>
            <asp:Button Text="states"  ID="btnstates" runat="server" OnClick="btnstates_Click" />
            
            <br />
            select State <asp:DropDownList  runat="server" ID="ddlstates">
            </asp:DropDownList>
            <asp:Button Text="cities"  ID="btncities" runat="server" OnClick="btncities_Click" />

            <br />  
            select city <asp:DropDownList runat="server" ID="ddlcities">
            </asp:DropDownList>

            <br />  
        </div>
    </form>
</body>
</html>
