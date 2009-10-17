<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
                        AutoEventWireup="true" 
                        CodeFile="checkout.aspx.cs" 
                        Inherits="checkout"
                        StylesheetTheme="default" 
                        Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:Wizard ID="Wizard1" runat="server">
        <WizardSteps>
            <asp:WizardStep runat="server" title="Personal Info">
                <table id="personal-info">
                    <tr>
                        <td>
                            First Name
                        </td>
                        <td>
                            <input type="text" name="txtFirstName" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name
                        </td>
                        <td>
                            <input type="text" name="txtLastName" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address
                        </td>
                        <td>
                            <input type="text" name="txtAddress" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City
                        </td>
                        <td>
                            <input type="text" name="txtCity" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Province
                        </td>
                        <td>
                            <input type="text" name="txtProvince" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Postal Code
                        </td>
                        <td>
                            <input type="text" name="txtPostalCode" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <input type="text" name="txtEmail" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone
                        </td>
                        <td>
                            <input type="text" name="txtPhone" class="txtbox" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <a href="#" id="backCart">Back to cart</a>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep runat="server" title="Payment">
                <input type="radio" name="paymentMethod" value="paypal" />
                Paypal</asp:WizardStep>
            <asp:WizardStep runat="server" Title="Confirm">
                Are you sure you want to proceed this order?</asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
</asp:Content>

