<%@ Control Language="C#" AutoEventWireup="true" CodeFile="InstitutionBackEnd.ascx.cs" Inherits="UserControl_InstitutionBackEnd" %>
<h1>Add an institution</h1>
<table id="institution-table">
    <tr>
        <th>Name</th>
        <td><asp:TextBox ID="txtName" runat="server" /></td>
    </tr>
    <tr>
        <th>Description</th>
        <td><asp:TextBox ID="txtDesc" TextMode="MultiLine" runat="server" /></td>
    </tr>
    <tr>
        <th>Email</th>
        <td><asp:TextBox ID="txtEmail" runat="server" /></td>
    </tr>
    <tr>
        <th>Password</th>
        <td><asp:TextBox ID="txtPassword" TextMode="Password" runat="server" /></td>
    </tr>
    <tr>
        <td colspan="2"><asp:Button ID="btnAddInstitution" Text="Add" runat="server" OnClick="btnAddInstitution_Click" /></td>
    </tr>
    <tr>
        <td colspan="2"><asp:Label ID="lbStatus" runat="server"></asp:Label></td>
    </tr>
</table>
<br />
<h1>Institution list</h1>
<asp:Repeater ID="rptInstitution" runat="server">
    <HeaderTemplate>
        <ul id="institution-list">
    </HeaderTemplate>
    <ItemTemplate>
        <li><asp:ImageButton ID="imgbtnDelete" ImageUrl="~/img/delete.png" Width="25px" OnCommand="imgbtnDelete_Click" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "OrganizationID") %>' runat="server" /> <%# DataBinder.Eval(Container.DataItem, "Name") %></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>