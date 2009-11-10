<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
                        AutoEventWireup="true" 
                        CodeFile="default.aspx.cs" 
                        Inherits="_default" 
                        StylesheetTheme="default" %>

<%@ Register src="UserControl/SearchBar.ascx" tagname="SearchBar" tagprefix="uc1" %>
<%@ Register src="UserControl/EventSummary.ascx" tagname="EventSummary" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <uc1:SearchBar ID="SearchBar1" runat="server" />
    
    <ul class="event_top10">
        <li class="left">
            <uc1:EventSummary ID="EventSummary1" runat="server" />
        </li>
        <li>
            <uc1:EventSummary ID="EventSummary2" runat="server" />
        </li>
        <li class="left">
            <uc1:EventSummary ID="EventSummary3" runat="server" />
        </li>
        <li>
            <uc1:EventSummary ID="EventSummary4" runat="server" />
        </li>
        <li class="left">
            <uc1:EventSummary ID="EventSummary5" runat="server" />
        </li>
        <li>
            <uc1:EventSummary ID="EventSummary6" runat="server" />
        </li>
        <li class="left">
            <uc1:EventSummary ID="EventSummary7" runat="server" />
        </li>
        <li>
            <uc1:EventSummary ID="EventSummary8" runat="server" />
        </li>
        <li class="left">
            <uc1:EventSummary ID="EventSummary9" runat="server" />
        </li>
        <li>
            <uc1:EventSummary ID="EventSummary10" runat="server" />
        </li>
    </ul>
    <a href="/list.aspx" id="more">more...</a>
</asp:Content>

