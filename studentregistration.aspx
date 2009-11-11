<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"
                        AutoEventWireup="true" 
                        CodeFile="studentregistration.aspx.cs" 
                        Inherits="studentregistration" 
                        Title="Untitled Page" 
                        StylesheetTheme="default"%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div id="studentregistration">
        <div>
            <span id="studentregistrationt">Student Registration</span>
            <p id="studentregistrationp">Please fill the form below to register as a student. Do you want to request registration for institute? Please <a href="instituteregistrationrequest.aspx">click here</a></p>
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td class="formpart" colspan="2">Personal Information</td>
                </tr>
                <tr>
                    <td class="label">First Name</td>
                    <td><asp:TextBox ID="FirstName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Last Name</td>
                    <td><asp:TextBox ID="LastName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Date of Birth</td>
                    <td><asp:TextBox ID="DateOfBirth1" CssClass="inputdate" runat="server"></asp:TextBox><asp:TextBox ID="DateOfBirth2" CssClass="inputdate" runat="server"></asp:TextBox><asp:TextBox ID="DateOfBirth3" CssClass="inputdate" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Gender</td>
                    <td><asp:RadioButton ID="Gender1" runat="server" GroupName="Gender" Text="Male" Checked="true" /><asp:RadioButton ID="Gender2" runat="server" GroupName="Gender" Text="Female" /></td>
                </tr>
                <tr>
                    <td class="label">Nationality</td>
                    <td><asp:TextBox ID="Nationality" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td class="formpart" colspan="2">Address Information</td>
                </tr>
                <tr>
                    <td class="label">Street</td>
                    <td><asp:TextBox ID="Street" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">House Number</td>
                    <td><asp:TextBox ID="HouseNumber" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">City</td>
                    <td><asp:TextBox ID="City" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Country</td>
                    <td><asp:TextBox ID="Country" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Postal Code</td>
                    <td><asp:TextBox ID="PostalCode" runat="server"></asp:TextBox></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td class="formpart" colspan="2">Account Information</td>
                </tr>
                <tr>
                    <td class="label">Email Address</td>
                    <td><asp:TextBox ID="EmailAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Retype Email Address</td>
                    <td><asp:TextBox ID="RetypeEmailAddress" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Password</td>
                    <td><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="label">Retype Password</td>
                    <td><asp:TextBox ID="RetypePassword" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td></td>
                    <td id="studentregistrationagreement"><input type="checkbox" /> I agree with <a href="#">terms of service</a>, <a href="#">program policy</a>, and <a href="#">privacy policy</a></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="Signup" runat="server" Text="Signup" onclick="Signup_Click" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

