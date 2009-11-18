<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GoToPaypal.aspx.cs" Inherits="GoToPaypal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   <p>Click the button below to proceed with payments at your Paypal Account.</p>
   <form id="form1" runat="server" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="POST">
        
        <div>
              <input type="hidden" name="cmd" value="_s-xclick" />
              <input ID="encrypted" runat="server" type="hidden" name="encrypted"/>
              <input type="submit" name="submit" value="Pay Now" />
        </div>
  </form>
</body>
</html>
