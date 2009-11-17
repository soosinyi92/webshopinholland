using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class studentregistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Agreement.Text = " I agree with <a href=\"#\">terms of service</a>, <a href=\"#\">program policy</a>, and <a href=\"#\">privacy policy</a>";
    }

    protected void Signup_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;
        MembershipCreateStatus membershipcreatestatus;
        ProfileCommon profilecommon;
        MailMessage mailmessage;
        NetworkCredential networkcredential;
        SmtpClient smtpclient;
        
        try
        {
            //Membership.CreateUser(EmailAddress.Text, Password.Text, EmailAddress.Text, "Password Question", "Password Answer", true, out membershipcreatestatus);
            membershipuser = Membership.CreateUser(EmailAddress.Text, Password.Text, EmailAddress.Text, "Password Question", "Password Answer", false, out membershipcreatestatus);

            profilecommon = (ProfileCommon)ProfileCommon.Create(EmailAddress.Text, true);
            profilecommon.User.FirstName = FirstName.Text;
            profilecommon.User.LastName = LastName.Text;
            profilecommon.User.DateOfBirth = DateOfBirth1.Text + "/" + DateOfBirth2.Text + "/" + DateOfBirth3.Text;
            if (Gender1.Checked)
            {
                profilecommon.User.Gender = "Male";
            }
            else
            {
                profilecommon.User.Gender = "Female";
            }
            profilecommon.User.Nationality = Nationality.Text;
            profilecommon.User.Street = Street.Text;
            profilecommon.User.HouseNumber = HouseNumber.Text;
            profilecommon.User.City = City.Text;
            profilecommon.User.Country = Country.Text;
            profilecommon.User.PostalCode = PostalCode.Text;

            profilecommon.Save();

            Roles.AddUserToRole(EmailAddress.Text, "User");
            
            mailmessage = new MailMessage("tempe_kecap@yahoo.co.id", EmailAddress.Text, "Email Subject", "<p>Email Body</p><p>Activation Link : <a href=\"" + Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/registrationcomplete.aspx?operation=studentregistrationactivate&username=" + membershipuser.ProviderUserKey.ToString()) + "\">Activate Account</a></p>");
            mailmessage.IsBodyHtml = true;
            networkcredential = new NetworkCredential("tempe_kecap@yahoo.co.id", "m3m0r13s");
            smtpclient = new SmtpClient("smtp.mail.yahoo.com", 587);
            smtpclient.UseDefaultCredentials = false;
            smtpclient.Credentials = networkcredential;
            smtpclient.Send(mailmessage);

            Response.Redirect("registrationcomplete.aspx?operation=studentregistration");
        }
        catch(Exception exception)
        {
            
        }
    }
}
