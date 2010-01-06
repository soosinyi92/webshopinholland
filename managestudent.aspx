<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="managestudent.aspx.cs" Inherits="managestudent" %>

<%@ Register Src="UserControl/ManageUser.ascx" TagName="ManageUser" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div id="managestudent">
                <div>
                    <span id="managestudentt">Manage Student</span>
                    <p id="managestudentp">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                        Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                </div>
            </div>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Super Administrator">
                <ContentTemplate>
                    <div id="managestudent">
                        <div>
                            <span id="managestudentt">Manage Student</span>
                            <p id="managestudentp">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                                Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                        </div>
                        <br />
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <ItemTemplate>
                                <uc1:ManageUser ID="manageuser" runat="server" />
                                <br />
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Panel ID="Panel1" runat="server">
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
                                        <asp:Label ID="FirstNameError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Last Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                                        <asp:Label ID="LastNameError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Date of Birth
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="DateOfBirth1" CssClass="inputdate" runat="server">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DateOfBirth2" CssClass="inputdate" runat="server">
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="DateOfBirth3" CssClass="inputdate" runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="DateOfBirthError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
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
                                        <asp:DropDownList ID="Nationality" runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="NationalityError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
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
                                        <asp:Label ID="StreetError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        House Number
                                    </td>
                                    <td>
                                        <asp:TextBox ID="HouseNumber" runat="server"></asp:TextBox>
                                        <asp:Label ID="HouseNumberError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        City
                                    </td>
                                    <td>
                                        <asp:TextBox ID="City" runat="server"></asp:TextBox>
                                        <asp:Label ID="CityError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Country
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="Country" runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="CountryError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Postal Code
                                    </td>
                                    <td>
                                        <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox>
                                        <asp:Label ID="PostalCodeError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
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
                                    <td class="accountinformationemailaddress">
                                        <asp:Label ID="EmailAddress" runat="server" Text="Label"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Password
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:Label ID="PasswordError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Retype Password
                                    </td>
                                    <td>
                                        <asp:TextBox ID="RetypePassword" runat="server" TextMode="Password"></asp:TextBox>
                                        <asp:Label ID="RetypePasswordError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Status
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="Status1" runat="server" GroupName="Status" Text="Active" /><asp:RadioButton
                                            ID="Status2" runat="server" GroupName="Status" Text="Inactive" />
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
                                        <asp:Button ID="Back" runat="server" Text="Back" OnClick="Back_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </div>
                </ContentTemplate>
            </asp:RoleGroup>
        </RoleGroups>
    </asp:LoginView>
</asp:Content>
