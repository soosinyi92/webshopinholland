<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventSummary.ascx.cs" Inherits="EventControls.UserControl_EventSummary" %>
<div class="event_summary">
    <div class="event_img">
        <asp:ImageButton ID="ImageButton1" runat="server" 
            onclick="ImageButton1_Click" />
    </div>
    <div class="event_info">
    

        Name:
        <asp:Label ID="lblName" runat="server" />
        <br />
        
        Start:
        <asp:Label ID="lblStartTime" runat="server" />
        <br />
        
        End:
        <asp:Label ID="lblEndTime" runat="server" />
        <br />
        
        Location:
        <asp:Label ID="lblLocation" runat="server" />
        <br />
        
        Price:
        <asp:Label ID="lblPrice" runat="server" />
        <br />
    </div>
</div>

