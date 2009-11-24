<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="myaccount.aspx.cs" Inherits="myaccount" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <asp:LoginView ID="LoginView1" runat="server">
        <LoggedInTemplate>
        </LoggedInTemplate>
        <AnonymousTemplate>
            <div id="myaccount">
                <div>
                    <span id="myaccountt">My Account</span>
                    <p id="myaccountp">
                        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.
                        Sed erat est, pharetra sed mollis in, viverra ut magna.</p>
                </div>
            </div>
        </AnonymousTemplate>
        <RoleGroups>
            <asp:RoleGroup Roles="Super Administrator">
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
            <asp:RoleGroup Roles="Institute Administrator">
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
                                        Insitute Information
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Name
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Name" runat="server"></asp:TextBox>
                                        <asp:Label ID="NameError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="label">
                                        Description
                                    </td>
                                    <td>
                                        <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                        <asp:Label ID="DescriptionError" runat="server" CssClass="descriptionerror" Text="*" Visible="false"></asp:Label>
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
