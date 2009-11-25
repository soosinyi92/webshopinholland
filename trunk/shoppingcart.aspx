<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="shoppingcart.aspx.cs" Inherits="shoppingcart" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Repeater ID="rptShoppingCart" runat="server">
        <HeaderTemplate>
            <div id="shoppingcartwrap">
            <table id="shoppingcart">
                <tr>
                    <th>Name</th>
                    <th>Price</th>
                    <th>Quantity</th>
                    <th>Subtotal</th>
                    <th></th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr class="row">
                <td class="name">
                    <asp:Label ID="Label1" runat="server" Text=<%# Eval("EventName") %>></asp:Label>
                </td>
                <td class="price">
                    <asp:Label ID="Label2" runat="server" Text=<%# Eval("EventPrice") %>></asp:Label>
                </td>
                <td class="quantity">
                    <asp:Label ID="Label3" runat="server" Text=<%# Eval("Quantity") %> CssClass="quantity_label"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Text=<%# Eval("Quantity")%> CssClass="quantity_box"></asp:TextBox>
                </td>
                <td class="subtotal">
                    <asp:Label ID="Label4" runat="server" Text=<%# (Eval("Quantity") as int?) * (Eval("EventPrice") as decimal?) %>></asp:Label>
                </td>
                <td class="action">
                    <asp:LinkButton ID="lbtnUpdate" runat="server" Text="Update" OnClick="lbtnUpdate_Click" ToolTip="Update" CssClass="update"></asp:LinkButton>
                    <asp:LinkButton ID="lbtnDelete" runat="server" Text="Delete" OnCommand="lbtnDelete_Click" CommandArgument=<%# Eval("EventId") %> ToolTip="Delete"></asp:LinkButton>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            <tr>
                <td colspan="3">Total</td>
                <td>
                    <asp:Label ID="lblTotal" runat="server" Text=""></asp:Label>
                </td>
                <td>
                    <asp:LinkButton ID="lbtnDeleteAll" runat="server" Text="Delete All" OnClick="lbtnDeleteAll_Click" ToolTip="Delete All"></asp:LinkButton>
                </td>
            </tr>
            </table>
            <input type="hidden" id="hfUpdateQuantity" name="hfUpdateQuantity" />
            </div>
        </FooterTemplate>
    </asp:Repeater>
    <asp:Label ID="lbEmptyCart" CssClass="empty_cart" Text="The shopping cart is empty." runat="server" Visible="False"></asp:Label>
    <asp:LinkButton ID="lbtnContinue" runat="server" Text="Continue shopping" PostBackUrl="~/default.aspx"></asp:LinkButton>
    <asp:LinkButton ID="lbtnCheckOut" runat="server" Text="Check out" PostBackUrl="~/checkout.aspx"></asp:LinkButton>
</asp:Content>