<%@ Language="C#" MasterPageFile="~/MasterPage.master" 
                        AutoEventWireup="true" 
                        CodeFile="detail.aspx.cs" 
                        Inherits="detail" 
                        Title="Untitled Page" 
                        StylesheetTheme="default"%>                        

<%@ Register src="~/UserControl/SearchBar.ascx" tagname="SearchBar" tagprefix="uc1" %>
<%@ Register Src="~/UserControl/EventDetail.ascx" tagname="EventDetail" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <uc1:SearchBar ID="SearchBar1" runat="server" />
    <uc1:EventDetail ID="EventDetail" runat="server" />
</asp:Content>