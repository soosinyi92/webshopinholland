<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="requestnewpassword.aspx.cs" Inherits="requestnewpassword" Title="Untitled Page"
    StylesheetTheme="default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="requestnewpassword">
        <div>
            <span id="requestnewpasswordt">Request New Password</span>
            <p id="requestnewpasswordp">
                Instruction on how to set your new password will be sent to email address associated
                with your account.</p>
        </div>
        <div>
            <div id="requestnewpasswordimg">
                <img src="./img/requestnewpassword.jpg" alt="" />
            </div>
            <div id="requestnewpasswordform">
                <div>
                    <span id="requestnewpasswordemailt">Email</span>
                    <p id="requestnewpasswordemailp">
                        Please type your email address below.</p>
                </div>
                <div>
                    <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox><asp:Label ID="EmailAddressError"
                        runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                </div>
                <div>
                    <asp:Button ID="Submit" runat="server" Text="Request New Password" OnClick="Submit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
