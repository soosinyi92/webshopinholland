using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using EventWebShop.Frontend.PaymentHandlers.PayPal;

public partial class checkout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.User.Identity.IsAuthenticated && Page.User.IsInRole("User"))
        {
            txtFirstName.Text = Profile.User.FirstName;
            txtLastName.Text = Profile.User.LastName;
            txtAddress.Text = Profile.User.Street + " " + Profile.User.HouseNumber;
            txtPostalCode.Text = Profile.User.PostalCode;
            txtCity.Text = Profile.User.City;
            txtCountry.Text = Profile.User.Country;
            //txtEmail.Text = Profile.User.Email;
            //txtPhone.Text = Profile.User.Phone;
        }
    }


    protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
    {
        ShoppingCart.ShippingInfo shippingInfo = new ShoppingCart.ShippingInfo();
        shippingInfo.FirstName = txtFirstName.Text;
        shippingInfo.LastName = txtLastName.Text;
        shippingInfo.Address = txtAddress.Text;
        shippingInfo.PostCode = txtPostalCode.Text;
        shippingInfo.City = txtCity.Text;
        shippingInfo.Country = txtCountry.Text;
        shippingInfo.Email = txtEmail.Text;
        shippingInfo.Phone = txtPhone.Text;

        Profile.ShoppingCart.setShippingInfo(shippingInfo);
		Payment pp_payment = new Payment();
		string pp_encString = pp_payment.getPPEncryptedString(Profile.ShoppingCart);
		
		
		String testStop = "Stop Here";
    }
}
