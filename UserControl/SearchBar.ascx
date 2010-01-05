<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SearchBar.ascx.cs" Inherits="UserControl_SearchBar" %>
<div id="searchbar">
    <div class="category">
            
    </div>
    <div class="content">
        <asp:DropDownList ID="Category" CssClass="category" runat="server">
            </asp:DropDownList>
        <asp:TextBox ID="SearchText" runat="server"></asp:TextBox>
        <asp:Button ID="Search" runat="server" Text="Button" onclick="Search_Click" />
    </div>
</div>