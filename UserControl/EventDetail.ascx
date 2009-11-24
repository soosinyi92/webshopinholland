<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventDetail.ascx.cs" Inherits="UserControl_EventDetail" %>
<div id="event_detail">
    <h1>Event Title</h1>
    <div id="subjectwrap">
        <div id="buttons">
            <a class="redbutton" rel="nofollow" href="#">
                <span>Interested</span>
            </a>
            <br class="clear"/>
<%--            <asp:HyperLink ID="btnPurchase" runat="server" CssClass="redbutton" Text="Purchase"/>
--%>            <asp:Button ID="btnPurchase" runat="server" Text="Button" 
                onclick="btnPurchase_Click"/>
        
                <%--<form id="form1" runat="server" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="POST">
          </form><input type="submit" name="submit" value="Pay Now" />--%>
<%--        <div>
              <input type="hidden" name="cmd" value="_s-xclick" />
              <input ID="encrypted" runat="server" type="hidden" name="encrypted"/>
              
            
            <br class="clear"/>
            <a class="redbutton" rel="nofollow" href="#">
                <span>Purchase</span>
            </a>
        </div>

            </a>--%>
            
        <asp:LinkButton ID="btnAddToCart" CssClass="redbutton" runat="server" onclick="btnAddToCart_Click">
            <span>Add to Cart</span>
        </asp:LinkButton>
        
        </div>
        <div id="album">
            <img src="./img/no_img.jpg" alt="event picture" />
        </div>
        <div id="info">
            <span class="label">Start:</span> <asp:Label runat="server" ID="lblStartTime" /> <br />
            <span class="label">End:</span> <asp:Label runat="server" ID="lblEndTime" /> <br />
            <span class="label">Location:</span> <asp:Label runat="server" ID="lblLocation" /> <br />
            <span class="label">Price:</span> <asp:Label runat="server" ID="lblPrice" /> Euro <br />
             <span class="label">Discount:</span> <asp:Label runat="server" ID="lblDiscount" /> Euro <br />
            <br /> <span class="label">Organizer:</span> <asp:Label runat="server" ID="lblOrganizer" /> <br />
            <span class="label">Organization:</span> <asp:Label runat="server" ID="lblOrganization" /> <br />         
        </div>
    </div>
    <div class="clear"></div>
    <div id="related_info">
        <h2>Description</h2>
        <p id="desc">
            <asp:Label runat="server" ID="lblDescription" />
        </p>
        
        <br/>
        <h2>Conditions</h2>
        <p id="P1">
            <asp:Label runat="server" ID="lblConditions" />
        </p>
    </div>
    
</div>