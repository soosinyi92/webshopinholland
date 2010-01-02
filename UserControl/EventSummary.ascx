<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventSummary.ascx.cs" Inherits="EventControls.UserControl_EventSummary" %>
<div class="event_summary">
    <div class="event_preview">
        <%--<asp:ImageButton ID="ImageButton1" runat="server" 
            onclick="ImageButton1_Click" />--%>
        <object width="100" height="100"><param name="movie" value="http://www.youtube.com/v/B1jYllE0T-k&hl=en_US&fs=1&"></param><param name="allowFullScreen" value="true"></param><param name="allowscriptaccess" value="always"></param><embed src="http://www.youtube.com/v/B1jYllE0T-k&hl=en_US&fs=1&" type="application/x-shockwave-flash" allowscriptaccess="always" allowfullscreen="true" width="100" height="100"></embed></object>

    </div>
    
    <div class="event_info">
        <span class="event_info_label">
            Name:
        </span>
        <span class="event_info_information">
            <asp:LinkButton ID="lblName" runat="server" CssClass="event_info_event_name" OnCommand="LinkButton1_Click" />
            <br />
        </span>
        
        <span class="event_info_label">
            Start:
        </span>
        <span class="event_info_information">
        
            <asp:Label ID="lblStartTime" runat="server" />
            <br />
        </span>
        
        <span class="event_info_label">
            End:
        </span>
        <span class="event_info_information">
            <asp:Label ID="lblEndTime" runat="server" />
            <br />
        </span>
        
        <span class="event_info_label">
            Location:
        </span>
        <span class="event_info_information">
            <asp:Label ID="lblLocation" runat="server" />
            <br />
        </span>
        
        <span class="event_info_label">
            Price:
        </span>
        <span class="event_info_information">
            <asp:Label ID="lblPrice" runat="server" />
            <br />
        </span>
    </div>
</div>

