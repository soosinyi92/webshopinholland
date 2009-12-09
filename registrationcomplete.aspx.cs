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

public partial class registrationcomplete : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Guid guid;
        MembershipUser membershipuser;
        string operation, username;

        operation = Page.Request.QueryString["operation"];
        if (operation != null)
        {
            if (operation.Equals("studentregistration"))
            {
                RegistrationCompleteLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna.";
            }
            else if (operation.Equals("instituteregistrationrequest"))
            {
                RegistrationCompleteLabel.Text = "Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit.";
            }
            else if (operation.Equals("studentregistrationactivate"))
            {
                username = Page.Request.QueryString["username"];

                guid = new Guid(username);
                membershipuser = Membership.GetUser(guid);
                membershipuser.IsApproved = true;
                Membership.UpdateUser(membershipuser);

                RegistrationCompleteLabel.Text = "Sed erat est, pharetra sed mollis in, viverra ut magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.";
            }
            else if (operation.Equals("instituteregistrationrequestactivate"))
            {
                username = Page.Request.QueryString["username"];

                guid = new Guid(username);
                membershipuser = Membership.GetUser(guid);
                membershipuser.IsApproved = true;
                Membership.UpdateUser(membershipuser);

                RegistrationCompleteLabel.Text = "Sed erat est, pharetra sed mollis in, viverra ut magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.";
            }
            else if (operation.Equals("instituteregistrationrequestapprove"))
            {
                username = Page.Request.QueryString["username"];

                guid = new Guid(username);
                membershipuser = Membership.GetUser(guid);

                System.Net.Mail.MailMessage mailmessage = new System.Net.Mail.MailMessage(GlobalVariable.superadministratoremailaddress, membershipuser.UserName, "Email Subject", GlobalVariable.emailheadertemplate + "<p>Email Body</p><p>Activation Link : <a href=\"" + Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/registrationcomplete.aspx?operation=instituteregistrationrequestactivate&username=" + membershipuser.ProviderUserKey.ToString()) + "\">Activate Account</a></p>" + GlobalVariable.emailfootertemplate);
                mailmessage.IsBodyHtml = true;
                System.Net.NetworkCredential networkcredential = new System.Net.NetworkCredential(GlobalVariable.superadministratoremailaddress, GlobalVariable.superadministratoremailpassword);
                System.Net.Mail.SmtpClient smtpclient = new System.Net.Mail.SmtpClient("smtp.mail.yahoo.com", 587);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = networkcredential;
                smtpclient.Send(mailmessage);

                RegistrationCompleteLabel.Text = "Sed erat est, pharetra sed mollis in, viverra ut magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.";
            }
            else
            {
                RegistrationCompleteLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna.";
            }
        }
        else
        {
            RegistrationCompleteLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna.";
        }
    }
}
