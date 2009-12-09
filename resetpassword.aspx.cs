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

public partial class resetpassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Guid guid;
        MembershipUser membershipuser;
        string operation, username;

        operation = Page.Request.QueryString["operation"];
        if (operation != null)
        {
            if (operation.Equals("resetpassword"))
            {
                username = Page.Request.QueryString["username"];

                guid = new Guid(username);
                membershipuser = Membership.GetUser(guid);
                membershipuser.ChangePassword(membershipuser.ResetPassword("Password Answer"), "user@pass");

                MailMessage mailmessage = new MailMessage(GlobalVariable.superadministratoremailaddress, membershipuser.UserName, "Email Subject", GlobalVariable.emailheadertemplate + "<p>Email Body</p><p>New Password : user@pass</p>" + GlobalVariable.emailfootertemplate);
                mailmessage.IsBodyHtml = true;
                NetworkCredential networkcredential = new NetworkCredential(GlobalVariable.superadministratoremailaddress, GlobalVariable.superadministratoremailpassword);
                SmtpClient smtpclient = new SmtpClient("smtp.mail.yahoo.com", 587);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = networkcredential;
                smtpclient.Send(mailmessage);

                ResetPasswordLabel.Text = "Sed erat est, pharetra sed mollis in, viverra ut magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna.";
            }
            else if (operation.Equals("resetpasswordinstruction"))
            {

            }
            else
            {
                ResetPasswordLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna.";
            }
        }
        else
        {
            ResetPasswordLabel.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum non tortor urna. Sed erat est, pharetra sed mollis in, viverra ut magna.";
        }
    }
}
