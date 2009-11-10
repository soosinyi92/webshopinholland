<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="LogInControl" %>
<div id="login_button">
    <a href="./studentregistration.aspx" id="signup">
        <span>Sign up</span>
    </a>
    <a href="#" id="login" >
        <span>Login</span>
    </a>
</div>
<div id="login_panel">
<asp:Login ID="Login" runat="server">
<LayoutTemplate>
    <p>
        <asp:Label AssociatedControlID="UserName" runat="server">Username:</asp:Label>
        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Label AssociatedControlID="Password" runat="server">Password:</asp:Label>
        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
    </p>
    <p>
        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Login" />
        <asp:CheckBox ID="RememberMe" runat="server" />
        <asp:Label AssociatedControlID="RememberMe" runat="server">Remember me</asp:Label>
    </p>
    <br />
    <p>
        <a href="./requestnewpassword.aspx" id="forgot">Forgot your password?</a>
    </p>
    <p>
        <a href="./studentregistration.aspx" id="signup">Sign up now</a>
    </p>
</LayoutTemplate>
</asp:Login>
</div>