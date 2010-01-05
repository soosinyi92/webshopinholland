<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" Title="Event List" StylesheetTheme="default" %>

<%@ Register src="UserControl/SearchBar.ascx" tagname="SearchBar" tagprefix="uc2" %>

<%@ Register src="UserControl/EventSummary.ascx" tagname="EventSummary" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <uc2:SearchBar ID="SearchBar1" runat="server" />
    
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
    
</asp:Content>

