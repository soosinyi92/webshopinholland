<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeFile="SearchBar.ascx.cs" Inherits="UserControl_SearchBar" %>
<div id="searchbar">
    <div class="category">
            
    </div>
    <div class="content">
        <asp:DropDownList ID="Categories" CssClass="category" runat="server"
            onselectedindexchanged="Category_SelectedIndexChanged" >
            </asp:DropDownList>
        <asp:TextBox ID="SearchText" runat="server"></asp:TextBox>
        <asp:Button ID="Search" runat="server" Text="Button" onclick="Search_Click" />
    </div>
</div>