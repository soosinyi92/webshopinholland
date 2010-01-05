<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventList.ascx.cs" Inherits="UserControl_EventList" %>

<%--<%@ Register src="UserControl/EventSummary.ascx" tagname="EventSummary" tagprefix="uc1" %>

<asp:Repeater ID="TopEvents" OnItemDataBound="PopulateTopEvents" runat="server">
        <HeaderTemplate>
            <ul class="event_top10">
        </HeaderTemplate>
        
        <ItemTemplate>
            <li class="left">
                <uc1:EventSummary ID="EventSummary" runat="server" />
            </li>
        </ItemTemplate>
        
        <AlternatingItemTemplate>
            <li class ="right">
                <uc1:EventSummary ID="EventSummary" runat="server" />
            </li>
        </AlternatingItemTemplate>
        
        <FooterTemplate>
            </ ul>
        </FooterTemplate>
    </asp:Repeater>
    <a href="./list.aspx" id="more">more...</a>
    <div class="clear">
    </div>--%>