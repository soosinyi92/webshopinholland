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

public partial class requestnewpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Submit_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;
        MailMessage mailmessage;
        NetworkCredential networkcredential;
        SmtpClient smtpclient;

        if (ValidateInput())
        {
            membershipuser = Membership.GetUser(EmailAddress.Text);
            if (membershipuser != null)
            {
                mailmessage = new MailMessage(GlobalVariable.superadministratoremailaddress, EmailAddress.Text, "Email Subject", GlobalVariable.emailheadertemplate + "<p>Email Body</p><p>Reset Password Link : <a href=\"" + Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/resetpassword.aspx?operation=resetpassword&username=" + membershipuser.ProviderUserKey.ToString()) + "\">Reset Password</a></p>" + GlobalVariable.emailfootertemplate);
                mailmessage.IsBodyHtml = true;
                networkcredential = new NetworkCredential(GlobalVariable.superadministratoremailaddress, GlobalVariable.superadministratoremailpassword);
                smtpclient = new SmtpClient("smtp.mail.yahoo.com", 587);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = networkcredential;
                smtpclient.Send(mailmessage);

                Response.Redirect("resetpassword.aspx?operation=resetpasswordinstruction");
            }
            else
            {
                EmailAddressError.Visible = true;
            }
        }
        else
        {

        }
    }

    private bool ValidateInput()
    {
        bool condition;

        condition = true;

        if (!Validation.ValidateRegex(EmailAddress.Text, Validation.emailregex))
        {
            EmailAddressError.Visible = true;
            condition = false;
        }

        return condition;
    }
}
