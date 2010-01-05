<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta content="text/html; charset=UTF-8" http-equiv="Content-Type" />
    <meta content="IE=EmulateIE7" http-equiv="X-UA-Compatible" />
    <title>WebShop</title>
    <link media="screen" type="text/css" href="App_Themes/Default/Default.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="page">
        <div id="header">
            <div class="content">
                <a href="./">
                    <img id="logo" src="/img/logo.png" />
                </a>
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div id="body">
            <div id="container">
                <div id="login">
                <asp:Login ID="Login" runat="server">
                <LayoutTemplate>
                    <p>
                        <asp:Label ID="Label1" AssociatedControlID="UserName" runat="server">Username:</asp:Label>
                        <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="Label2" AssociatedControlID="Password" runat="server">Password:</asp:Label>
                        <asp:TextBox ID="Password" TextMode="Password" runat="server"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="LoginButton" runat="server" CommandName="Login" Text="Login" />
                        <asp:CheckBox ID="RememberMe" runat="server" />
                        <asp:Label ID="Label3" AssociatedControlID="RememberMe" runat="server">Remember me</asp:Label>
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
            </div>
        </div>
        <div id="footer">
            <ul>
                <li>Copyright &copy; 2009-<%= System.DateTime.Now.Year %> WebShop</li>
                <li><a href="#">Home</a></li>
                <li><a href="#">About Us</a></li>
                <li><a href="#">Contact</a></li>
                <li><a href="#">Terms of Service</a></li>
                <li><a href="#">Program Policy</a></li>
                <li><a href="#">Privacy Policy</a></li>
            </ul>
        </div>
    </div>
    </form>
</body>
</html>
