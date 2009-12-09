<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="resetpassword.aspx.cs" Inherits="resetpassword" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="resetpassword">
        <div>
            <span id="resetpasswordt">Reset Password</span>
            <p id="resetpasswordp">
                <asp:Label ID="ResetPasswordLabel" runat="server" Text="Label"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>
