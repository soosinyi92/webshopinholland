<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shoppingcart.aspx.cs" Inherits="shoppingcart" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Repeater ID="rptShoppingCart" runat="server">
        <HeaderTemplate>
            <table id="shoppingcart">
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Quantity</th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text=<%# Eval("EventName") %>></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text=<%# Eval("EventPrice") %>></asp:Label>
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text=<%# Eval("Quantity") %>></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" OnCommand="lbtnDelete_Click" CommandArgument=<%# Eval("EventId") %>></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>