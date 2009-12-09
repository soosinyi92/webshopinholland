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
        if (!Page.IsPostBack)
        {
            DateOfBirth1.DataSource = GlobalVariable.day;
            DateOfBirth1.DataBind();
            DateOfBirth2.DataSource = GlobalVariable.month;
            DateOfBirth2.DataBind();
            DateOfBirth3.DataSource = GlobalVariable.year;
            DateOfBirth3.DataBind();
            Nationality.DataSource = GlobalVariable.nationality;
            Nationality.DataBind();
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
        MailMessage mailmessage;
        NetworkCredential networkcredential;
        SmtpClient smtpclient;

        if (ValidateInput())
        {
            try
            {
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

                Roles.AddUserToRole(EmailAddress.Text, GlobalVariable.userrolename);

                mailmessage = new MailMessage(GlobalVariable.superadministratoremailaddress, EmailAddress.Text, "Email Subject", GlobalVariable.emailheadertemplate + "<p>Email Body</p><p>Activation Link : <a href=\"" + Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/registrationcomplete.aspx?operation=studentregistrationactivate&username=" + membershipuser.ProviderUserKey.ToString()) + "\">Activate Account</a></p>" + GlobalVariable.emailfootertemplate);
                mailmessage.IsBodyHtml = true;
                networkcredential = new NetworkCredential(GlobalVariable.superadministratoremailaddress, GlobalVariable.superadministratoremailpassword);
                smtpclient = new SmtpClient("smtp.mail.yahoo.com", 587);
                smtpclient.UseDefaultCredentials = false;
                smtpclient.Credentials = networkcredential;
                smtpclient.Send(mailmessage);

                Response.Redirect("registrationcomplete.aspx?operation=studentregistration");
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

        FirstNameError.Visible = false;
        LastNameError.Visible = false;
        DateOfBirthError.Visible = false;
        NationalityError.Visible = false;
        StreetError.Visible = false;
        HouseNumberError.Visible = false;
        CityError.Visible = false;
        CountryError.Visible = false;
        PostalCodeError.Visible = false;
        EmailAddressError.Visible = false;
        RetypeEmailAddressError.Visible = false;
        PasswordError.Visible = false;
        RetypePasswordError.Visible = false;
        AgreementError.Visible = false;
        condition = true;

        if (!Validation.ValidateRegex(FirstName.Text, Validation.generalregex))
        {
            FirstNameError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(LastName.Text, Validation.generalregex))
        {
            LastNameError.Visible = true;
            condition = false;
        }
        if ((!Validation.ValidateRegex(DateOfBirth1.Text, Validation.dateofbirthregex)) ||
            (!Validation.ValidateRegex(DateOfBirth2.Text, Validation.dateofbirthregex)) ||
            (!Validation.ValidateRegex(DateOfBirth3.Text, Validation.dateofbirthregex)))
        {
            DateOfBirthError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateRegex(Nationality.Text, Validation.nationalitycountryregex))
        {
            NationalityError.Visible = true;
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
        if (!Validation.ValidateRegex(Password.Text, Validation.generalregex))
        {
            PasswordError.Visible = true;
            condition = false;
        }
        if (!Validation.ValidateSimilarity(Password.Text, RetypePassword.Text))
        {
            RetypePasswordError.Visible = true;
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
