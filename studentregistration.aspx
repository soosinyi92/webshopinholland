<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="studentregistration.aspx.cs" Inherits="studentregistration" Title="Sign Up"
    StylesheetTheme="default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="studentregistration">
        <div>
            <span id="studentregistrationt">Student Registration</span>
            <p id="studentregistrationp">
                Please fill the form below to register as a student. Do you want to request registration
                for institute? Please <a href="instituteregistrationrequest.aspx">click here</a></p>
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
                        <asp:TextBox ID="FirstName" runat="server"></asp:TextBox><asp:Label ID="FirstNameError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Last Name
                    </td>
                    <td>
                        <asp:TextBox ID="LastName" runat="server"></asp:TextBox><asp:Label ID="LastNameError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
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
                        <asp:Label ID="DateOfBirthError" runat="server" CssClass="inputdateerror" Text="*"
                            Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Gender
                    </td>
                    <td>
                        <asp:RadioButton ID="Gender1" runat="server" GroupName="Gender" Text="Male" Checked="true" /><asp:RadioButton
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
                        <asp:TextBox ID="Street" runat="server"></asp:TextBox><asp:Label ID="StreetError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        House Number
                    </td>
                    <td>
                        <asp:TextBox ID="HouseNumber" runat="server"></asp:TextBox><asp:Label ID="HouseNumberError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        City
                    </td>
                    <td>
                        <asp:TextBox ID="City" runat="server"></asp:TextBox><asp:Label ID="CityError" runat="server"
                            CssClass="error" Text="*" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="PostalCode" runat="server"></asp:TextBox><asp:Label ID="PostalCodeError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
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
                        <asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox><asp:Label ID="EmailAddressError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Retype Email Address
                    </td>
                    <td>
                        <asp:TextBox ID="RetypeEmailAddress" runat="server"></asp:TextBox><asp:Label ID="RetypeEmailAddressError"
                            runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Password
                    </td>
                    <td>
                        <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox><asp:Label
                            ID="PasswordError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="label">
                        Retype Password
                    </td>
                    <td>
                        <asp:TextBox ID="RetypePassword" runat="server" TextMode="Password"></asp:TextBox><asp:Label
                            ID="RetypePasswordError" runat="server" CssClass="error" Text="*" Visible="false"></asp:Label>
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
                    <td id="studentregistrationagreement">
                        <asp:CheckBox ID="Agreement" runat="server" /><asp:Label ID="AgreementError" runat="server"
                            CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="Signup" runat="server" Text="Signup" OnClick="Signup_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
