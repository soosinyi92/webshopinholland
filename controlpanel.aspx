﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="controlpanel.aspx.cs" Inherits="controlpanel" Title="Control Panel" EnableEventValidation="false" %>

<%@ Register src="UserControl/EventBackEnd.ascx" tagname="EventBackEnd" tagprefix="uc1" %>
<%@ Register src="UserControl/InstitutionBackEnd.ascx" tagname="InstitutionBackEnd" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div id="controlpanel">
                <div>
                    <span id="controlpanelt">Control Panel</span>
                    <p id="controlpanelp">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                        Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                </div>
            </div>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Super Administrator">
                <ContentTemplate>
                    <div id="controlpanel">
                        <div>
                            <uc1:InstitutionBackEnd ID="InstitutionBackEnd" runat="server" />
                        </div>
                        <br />
                        <asp:Button ID="ManageStudent" runat="server" Text="Manage Student" OnClick="ManageStudent_Click" />
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Institute Administrator">
                <ContentTemplate>
                    <div id="controlpanel">
                        <div>
                            <uc1:EventBackEnd ID="EventBackEnd" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Institute Management">
                <ContentTemplate>
                    <div id="controlpanel">
                        <div>
                            <span id="controlpanelt">Control Panel</span>
                            <p id="controlpanelp">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                                Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="Event Organizer">
                <ContentTemplate>
                    <div id="controlpanel">
                        <div>
                            <span id="controlpanelt">Control Panel</span>
                            <p id="controlpanelp">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                                Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
            <asp:RoleGroup Roles="User">
                <ContentTemplate>
                    <div id="controlpanel">
                        <div>
                            <span id="controlpanelt">Control Panel</span>
                            <p id="controlpanelp">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                                Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
