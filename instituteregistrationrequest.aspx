<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="instituteregistrationrequest.aspx.cs" Inherits="instituteregistrationrequest"
    Title="Untitled Page" StylesheetTheme="default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="Server">
    <div id="instituteregistrationrequest">
        <div>
            <span id="instituteregistrationrequestt">Institute Registration Request</span>
            <p id="instituteregistrationrequestp">
                Please fill the form below to request registration for institute. Do you want to
                register as a student? Please <a href="studentregistration.aspx">click here</a></p>
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
                        <asp:TextBox ID="Name" runat="server"></asp:TextBox><asp:Label ID="NameError" runat="server"
                            CssClass="error" Text="*" Visible="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="labeltextarea">
                        Description
                    </td>
                    <td>
                        <asp:TextBox ID="Description" runat="server" TextMode="MultiLine" Rows="5"></asp:TextBox><asp:Label
                            ID="DescriptionError" runat="server" CssClass="descriptionerror" Text="*" Visible="false"></asp:Label>
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
                    <td colspan="2">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td id="instituteregistrationrequestagreement">
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
