<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ManageUser.ascx.cs" Inherits="UserControl_ManageUser" %>
<div id="manageusercontrol">
    <div id="data">
        <span class="label">Name : </span><asp:Label ID="name" runat="server" Text=""></asp:Label><br />
        <span class="label">Email : </span><asp:Label ID="email" runat="server" Text=""></asp:Label>
    </div>
    <div id="link">
        <asp:LinkButton ID="edit" runat="server" OnClick="Edit_Click">Edit</asp:LinkButton>
        <asp:LinkButton ID="delete" runat="server" OnClick="Delete_Click">Delete</asp:LinkButton>
    </div>
</div>