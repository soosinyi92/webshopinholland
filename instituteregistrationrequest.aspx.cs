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

public partial class instituteregistrationrequest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Agreement.Text = " I agree with <a href=\"#\">terms of service</a>, <a href=\"#\">program policy</a>, and <a href=\"#\">privacy policy</a>";
    }

    protected void Signup_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus membershipcreatestatus;
        ProfileCommon profilecommon;
        MailMessage mailmessagetouser, mailmessagetoadministrator;
        NetworkCredential networkcredential;
        SmtpClient smtpclient;

        try
        {
            Membership.CreateUser(EmailAddress.Text, "user@pass", EmailAddress.Text, "Password Question", "Password Answer", false, out membershipcreatestatus);

            profilecommon = (ProfileCommon)ProfileCommon.Create(EmailAddress.Text, true);
            profilecommon.InstituteAdministrator.Name = Name.Text;
            profilecommon.InstituteAdministrator.Description = Description.Text;
            profilecommon.InstituteAdministrator.Street = Street.Text;
            profilecommon.InstituteAdministrator.HouseNumber = HouseNumber.Text;
            profilecommon.InstituteAdministrator.City = City.Text;
            profilecommon.InstituteAdministrator.Country = Country.Text;
            profilecommon.InstituteAdministrator.PostalCode = PostalCode.Text;

            profilecommon.Save();

            Roles.AddUserToRole(EmailAddress.Text, "Institute Administrator");

            mailmessagetouser = new MailMessage("tempe_kecap@yahoo.co.id", EmailAddress.Text, "Email Subject", "<p>Email Body</p>");
            mailmessagetouser.IsBodyHtml = true;
            mailmessagetoadministrator = new MailMessage("tempe_kecap@yahoo.co.id", "tempe_kecap@yahoo.co.id", "Email Subject", "<p>Email Body</p>");
            mailmessagetoadministrator.IsBodyHtml = true;
            networkcredential = new NetworkCredential("tempe_kecap@yahoo.co.id", "m3m0r13s");
            smtpclient = new SmtpClient("smtp.mail.yahoo.com", 587);
            smtpclient.UseDefaultCredentials = false;
            smtpclient.Credentials = networkcredential;
            smtpclient.Send(mailmessagetouser);
            smtpclient.Send(mailmessagetoadministrator);

            Response.Redirect("registrationcomplete.aspx?operation=instituteregistrationrequest");
        }
        catch (Exception exception)
        {
            
        }
    }
}
