<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="instituteregistrationrequest.aspx.cs" Inherits="instituteregistrationrequest" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div id="instituteregistrationrequest">
        <div>
            <span id="instituteregistrationrequestt">Institute Registration Request</span>
            <p id="instituteregistrationrequestp">Please fill the form below to request registration for institute. Do you want to register as a student? Please <a href="./studentregistration.aspx">click here</a></p>
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td class="formpart" colspan="2">Insitute Information</td>
                </tr>
                <tr>
                    <td class="label">Name</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="labeltextarea">Description</td>
                    <td><textarea rows="4" cols="20"></textarea></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td class="formpart" colspan="2">Address Information</td>
                </tr>
                <tr>
                    <td class="label">Street</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">House Number</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">City</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">Country</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">Postal Code</td>
                    <td><input type="text" /></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td class="formpart" colspan="2">Account Information</td>
                </tr>
                <tr>
                    <td class="label">Email Address</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">Retype Email Address</td>
                    <td><input type="text" /></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td></td>
                    <td id="instituteregistrationrequestagreement"><input type="checkbox" /> I agree with <a href="#">terms of service</a>, <a href="#">program policy</a>, and <a href="#">privacy policy</a></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="Signup" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

