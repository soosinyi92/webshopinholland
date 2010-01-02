<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventDetail.ascx.cs" Inherits="UserControl_EventDetail" %>
<div id="event_detail">
    <h1><span class="label"></span> <asp:Label runat="server" ID="lblEventStart" /> <br /></h1>
    <div id="subjectwrap">
        
        <div id="album">
            <%--<img src="./img/no_img.jpg" alt="event picture" />--%>
            <object width="560" height="340"><param name="movie" value="http://www.youtube.com/v/B1jYllE0T-k&hl=en_US&fs=1&"></param><param name="allowFullScreen" value="true"></param><param name="allowscriptaccess" value="always"></param><embed src="http://www.youtube.com/v/B1jYllE0T-k&hl=en_US&fs=1&" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="560" height="340"></embed></object>
        </div>
        <div id="buttons">
            <a class="redbutton" rel="nofollow" href="#">
                <span>Interested</span>
            </a>
        
            <br class="clear"/>

            <asp:LinkButton ID="btnAddToCart" CssClass="redbutton" runat="server" onclick="btnAddToCart_Click">
                <span>Add to Cart</span>
            </asp:LinkButton>
            
            </div>
        
        <div id="info">
            <span class="label">Start:</span> <asp:Label runat="server" ID="lblStartTime" /> <br />
            <span class="label">End:</span> <asp:Label runat="server" ID="lblEndTime" /> <br />
            <span class="label">Location:</span> <asp:Label runat="server" ID="lblLocation" /> <br />
            <span class="label">Price:</span> <asp:Label runat="server" ID="lblPrice" /> Euro <br />
             <span class="label">Discount:</span> <asp:Label runat="server" ID="lblDiscount" /> Euro <br />
            <br /> <span class="label">Organizer:</span> <asp:Label runat="server" ID="lblOrganizer"/> <br />
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