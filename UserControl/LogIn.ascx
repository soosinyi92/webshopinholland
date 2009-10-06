<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LogIn.ascx.cs" Inherits="LogInControl" %>

<asp:Login ID="Login1" runat="server">
    <LayoutTemplate>
        <table border="0" cellpadding="1" cellspacing="0" 
            style="border-collapse:collapse;">
            <tr>
                <td>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td align="center" colspan="2">
                                Log In</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False" 
                                    Text="Wrong User Name or Password" Visible="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="2">
                                <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Log In" 
                                    ValidationGroup="ctl00$Login1" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </LayoutTemplate>
</asp:Login>
<br />
<div class="loginforgot">Forgot your password? Click <a href="requestnewpassword.aspx">here</a></div>
<br />
<div class="loginregister">Do not have any account yet? Please <a href="studentregistration.aspx">register</a> if you are a student, or request <a href="instituteregistrationrequest.aspx">registration</a> for institute</div>