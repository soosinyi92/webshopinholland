<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="list.aspx.cs" Inherits="list" Title="Event List" %>

<%@ Register src="UserControl/SearchBar.ascx" tagname="SearchBar" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <uc1:SearchBar ID="SearchBar1" runat="server" />
</asp:Content>

