<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" 
                        AutoEventWireup="true" 
                        CodeFile="checkout.aspx.cs" 
                        Inherits="checkout"
                        StylesheetTheme="default" 
                        Title="Untitled Page" %>


<asp:Content ID="Content2" ContentPlaceHolderID="Content" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <div id="checkOut">
    <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0"  
            onfinishbuttonclick="Wizard1_FinishButtonClick">
        <WizardSteps>
            <asp:WizardStep ID="WizardStep1" runat="server" title="Personal Info">
                <table id="personal-info">
                    <tr><td colspan="2">Please fill in your shipping data:</td></tr>
                    <tr>
                        <td>
                            First Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtFirstName" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Last Name
                        </td>
                        <td>
                            <asp:TextBox ID="txtLastName" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Address
                        </td>
                        <td>
                            <asp:TextBox ID="txtAddress" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Postal Code
                        </td>
                        <td>
                            <asp:TextBox ID="txtPostalCode" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            City
                        </td>
                        <td>
                            <asp:TextBox ID="txtCity" class="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Country
                        </td>
                        <td>
                            <asp:TextBox ID="txtCountry" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Email
                        </td>
                        <td>
                            <asp:TextBox ID="txtEmail" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phone
                        </td>
                        <td>
                            <asp:TextBox ID="txtPhone" CssClass="txtbox" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <a href="./shoppingcart.aspx" id="backCart">Back to cart</a>
                        </td>
                    </tr>
                </table>
            </asp:WizardStep>
            <asp:WizardStep ID="WizardStep2" runat="server" title="Payment">
                <input type="radio" name="paymentMethod" value="paypal" />
                Paypal</asp:WizardStep>
            <asp:WizardStep ID="WizardStep3" runat="server" Title="Confirm">
                Are you sure you want to proceed this order?</asp:WizardStep>
        </WizardSteps>
    </asp:Wizard>
    </div>
</asp:Content>

