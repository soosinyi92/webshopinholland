<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventDetail.ascx.cs" Inherits="UserControl_EventDetail" %>
<div id="event_detail">
    <asp:Label runat="server" ID="lblEventStart" CssClass="event_info_name" /> <br />
    <br />
    
    <div id="subjectwrap">
        <div id="album">
            <%--<img src="./img/no_img.jpg" alt="event picture" />--%>
            <object width="660" height="340"><param name="movie" value="http://www.youtube.com/v/B1jYllE0T-k&hl=en_US&fs=1&"></param><param name="allowFullScreen" value="true"></param><param name="allowscriptaccess" value="always"></param><embed src="http://www.youtube.com/v/B1jYllE0T-k&hl=en_US&fs=1&" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="660" height="340"></embed></object>
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
        
        <div class="info_label">
            Start:
            <br />
            
            End:
            <br />
            
            Location:
            <br />
            
            Price:
            <br />
            
            Discount:
            <br />
            
            <br />Organizer:
            <br />
            
            Organization:
            <br />
        </div>
        
        <div class="info_information">
            <asp:Label runat="server" ID="lblStartTime" /> <br />
            <asp:Label runat="server" ID="lblEndTime" /> <br />
            <asp:Label runat="server" ID="lblLocation" /> <br />
            <asp:Label runat="server" ID="lblPrice" /> Euro <br />
            <asp:Label runat="server" ID="lblDiscount" /> Euro <br />
            <br />
            <div class="info_information_organizer"><asp:Label runat="server" ID="lblOrganizer" /> </div> <br />
            <asp:Label runat="server" ID="lblOrganization" /> <br />
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
</div>