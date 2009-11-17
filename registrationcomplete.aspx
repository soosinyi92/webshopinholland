<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="registrationcomplete.aspx.cs" Inherits="registrationcomplete" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div id="registrationcomplete">
        <div>
            <span id="registrationcompletet">Registration Complete</span>
            <p id="registrationcompletep">
                <asp:Label ID="RegistrationCompleteLabel" runat="server" Text="Label"></asp:Label>
            </p>
        </div>
    </div>
</asp:Content>