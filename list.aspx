<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" Title="Event List" %>

<%@ Register src="UserControl/SearchBar.ascx" tagname="SearchBar" tagprefix="uc1" %>

<%@ Register src="UserControl/EventList.ascx" tagname="EventList" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <uc1:SearchBar ID="SearchBar1" runat="server" />
    
    <uc1:EventList ID="EventList1" runat="server" />
    <div id="pagewrap">
        <div id="page">
            <ul>
                <li><a href="#">&lt;</a></li>
                <li><a href="#">1</a></li>
                <li><a href="#">2</a></li>
                <li><a href="#">3</a></li>
                <li><a href="#">4</a></li>
                <li><a href="#">&gt;</a></li>
            </ul>
        </div>
    </div>
    
</asp:Content>

