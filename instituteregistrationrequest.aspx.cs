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
        if (!Page.IsPostBack)
        {
            Country.DataSource = GlobalVariable.country;
            Country.DataBind();
            Agreement.Text = " I agree with <a href=\"#\">terms of service</a>, <a href=\"#\">program policy</a>, and <a href=\"#\">privacy policy</a>";
        }
    }

    protected void Signup_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;
        MembershipCreateStatus membershipcreatestatus;
        ProfileCommon profilecommon;
        MailMessage mailmessagetouser, mailmessagetoadministrator;
        NetworkCredential networkcredential;
        SmtpClient smtpclient;

        if (ValidateInput())
        {
            try
            {
                membershipuser = Membership.CreateUser(EmailAddress.Text, "user@pass", EmailAddress.Text, "Password Question", "Password Answer", false, out membershipcreatestatus);

                profilecommon = (ProfileCommon)ProfileCommon.Create(EmailAddress.Text, true);
                profilecommon.InstituteAdministrator.Name = Name.Text;
                profilecommon.InstituteAdministrator.Description = Description.Text;
                profilecommon.InstituteAdministrator.Street = Street.Text;
                profilecommon.InstituteAdministrator.HouseNumber = HouseNumber.Text;
                profilecommon.InstituteAdministrator.City = City.Text;
                profilecommon.InstituteAdministrator.Country = Country.Text;
                profilecommon.InstituteAdministrator.PostalCode = PostalCode.Text;

                profilecommon.Save();

                Roles.AddUserToRole(EmailAddress.Text, GlobalVariable.instituteadministratorrolename);

                mailmessagetouser = new MailMessage(GlobalVariable.superadministratoremailaddress, EmailAddress.Text, "Email Subject", GlobalVariable.emailheadertemplate + "<p>Email Body</p>" + GlobalVariable.emailfootertemplate);
                mailmessagetouser.IsBodyHtml = true;
                mailmessagetoadministrator = new MailMessage(GlobalVariable.superadministratoremailaddress, GlobalVariable.superadministratoremailaddress, "Email Subject", GlobalVariable.emailheadertemplate + "<p>Email Body</p><p>Approval Link : <a href=\"" + Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/registrationcomplete.aspx?operation=instituteregistrationrequestapprove&username=" + membershipuser.ProviderUserKey.ToString()) + "\">Approve Account</a></p>" + GlobalVariable.emailfootertemplate);
                mailmessagetoadministrator.IsBodyHtml = true;
                networkcredential = new NetworkCredential(GlobalVariable.superadministratoremailaddress, GlobalVariable.superadministratoremailpassword);
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
        else
        {

        }
    }

    private bool ValidateInput()
    {
        bool condition;

        NameError.Visible = false;
        DescriptionError.Visible = false;
        StreetError.Visible = false;
        HouseNumberError.Visible = false;
        CityError.Visible = false;
        CountryError.Visible = false;
        PostalCodeError.Visible = false;
        EmailAddressError.Visible = false;
        RetypeEmailAddressError.Visible = false;
        AgreementError.Visible = false;
        condition = true;

        if (!Validation.ValidateRegex(Name.Text, Validation.generalregex))
        {
            NameError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(Description.Text, Validation.generalregex))
        {
            DescriptionError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(Street.Text, Validation.generalregex))
        {
            StreetError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(HouseNumber.Text, Validation.generalregex))
        {
            HouseNumberError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(City.Text, Validation.generalregex))
        {
            CityError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(Country.Text, Validation.nationalitycountryregex))
        {
            CountryError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(PostalCode.Text, Validation.generalregex))
        {
            PostalCodeError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(EmailAddress.Text, Validation.emailregex))
        {
            EmailAddressError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateSimilarity(EmailAddress.Text, RetypeEmailAddress.Text))
        {
            RetypeEmailAddressError.Visible = true;
            condition = false;
        }
        if (!Agreement.Checked)
        {
            AgreementError.Visible = true;
            condition = false;
        }

        return condition;
    }
}
