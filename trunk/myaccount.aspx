﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="myaccount.aspx.cs" Inherits="myaccount" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div id="myaccount">
                <div>
                    <span id="myaccountt">My Account</span>
                    <p id="myaccountp">Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                </div>
            </div>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="User">
                <ContentTemplate>
                    <div id="myaccount">
                        <div>
                            <span id="myaccountt">My Account</span>
                            <p id="myaccountp">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                                Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                        </div>
                        <br />
                        <div>
                            <table>
                                <tr>
                                    <td class="formpart" colspan="2">
                                        Personal Information
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        First Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Last Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Date of Birth
                                    </td>
                                    <td>
                                        <asp:TextBox ID="DateOfBirth1" CssClass="inputdate" runat="server"></asp:TextBox><asp:TextBox
                                            ID="DateOfBirth2" CssClass="inputdate" runat="server"></asp:TextBox><asp:TextBox
                                                ID="DateOfBirth3" CssClass="inputdate" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Gender
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="Gender1" runat="server" GroupName="Gender" Text="Male" /><asp:RadioButton
                                            ID="Gender2" runat="server" GroupName="Gender" Text="Female" />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Nationality
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Nationality" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formpart" colspan="2">
                                        Address Information
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Street
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Street" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        House Number
                                    </td>
                                    <td>
                                        <asp:TextBox ID="HouseNumber" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        City
                                    </td>
                                    <td>
                                        <asp:TextBox ID="City" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Country
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Country" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Postal Code
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td class="formpart" colspan="2">
                                        Account Information
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Email Address
                                    </td>
                                    <td>
                                        <asp:Label ID="EmailAddress" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Password
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Retype Password
                                    </td>
                                    <td>
                                        <asp:TextBox ID="RetypePassword" runat="server" TextMode="Password"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                    <td>
                                        <asp:Button ID="SaveChanges" runat="server" Text="Save Changes" OnClick="SaveChanges_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>