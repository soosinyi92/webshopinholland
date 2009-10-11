<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="studentregistration.aspx.cs" Inherits="studentregistration" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <div id="studentregistration">
        <div>
            <span id="studentregistrationt">Student Registration</span>
            <p id="studentregistrationp">Please fill the form below to register as a student. Do you want to request registration for institute? Please <a href="./instituteregistrationrequest.aspx">click here</a></p>
        </div>
        <br />
        <div>
            <table>
                <tr>
                    <td class="formpart" colspan="2">Personal Information</td>
                </tr>
                <tr>
                    <td class="label">First Name</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">Last Name</td>
                    <td><input type="text" /></td>
                </tr>
                <tr>
                    <td class="label">Date of Birth</td>
                    <td><input class="inputdate" type="text" /><input class="inputdate" type="text" /><input class="inputdate" type="text" /></td>
                </tr>
                <tr>
                    <td class="label">Gender</td>
                    <td><input type="radio" name="gender" value="Male" /> Male <input type="radio" name="gender" value="Female" /> Female</td>
                </tr>
                <tr>
                    <td class="label">Nationality</td>
                    <td><input type="text" /></td>
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
                <tr>
                    <td class="label">Password</td>
                    <td><input type="password" /></td>
                </tr>
                <tr>
                    <td class="label">Retype Password</td>
                    <td><input type="password" /></td>
                </tr>
                <tr><td colspan="2"><br /></td></tr>
                <tr>
                    <td></td>
                    <td id="studentregistrationagreement"><input type="checkbox" /> I agree with <a href="#">terms of service</a>, <a href="#">program policy</a>, and <a href="#">privacy policy</a></td>
                </tr>
                <tr>
                    <td></td>
                    <td><input type="submit" value="Signup" /></td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

