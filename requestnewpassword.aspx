<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="requestnewpassword.aspx.cs" Inherits="requestnewpassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div>Request New Password</div>
    <div>
        <table>
            <tr>
                <td>Email</td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Button ID="Button1" runat="server" Text="Request New Password" /></td>
            </tr>
        </table>
    </div>
</asp:Content>

