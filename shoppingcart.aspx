<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shoppingcart.aspx.cs" Inherits="shoppingcart" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Repeater ID="rptShoppingCart" runat="server">
        <ItemTemplate>
            <asp:Label runat="server" Text=<%# Eval("EventId") %>></asp:Label>
            <asp:Label ID="Label1" runat="server" Text=<%# Eval("EventName") %>></asp:Label>
            <asp:Label ID="Label2" runat="server" Text=<%# Eval("EventPrice") %>></asp:Label>
            <asp:Label ID="Label3" runat="server" Text=<%# Eval("Quantity") %>></asp:Label>
            <br />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>

