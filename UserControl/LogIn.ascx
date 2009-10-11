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
    <p>
        <label for="username">Username:</label>
        <input type="text" name="username" id="username" />
    </p>
    <p>
        <label for="password">Password:</label>
        <input type="password" name="password" id="password" />
    </p>
    <p>
        <input id="login_submit" type="submit" value="Login" />
        <input id="remember" type="checkbox" value="1" name="remember_me" />
        <label for="remember">Remember me</label>
    </p>
    <br />
    <p>
        <a href="./requestnewpassword.aspx" id="forgot">Forgot your password?</a>
    </p>
    <p>
        <a href="./studentregistration.aspx" id="signup">Sign up now</a>
    </p>
</div>