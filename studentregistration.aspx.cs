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
    private string[] day = { "-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
    private string[] month = { "-", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    private string[] year = { "-", "1980", "1981", "1982", "1983", "1984", "1985", "1986", "1987", "1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997", "1998", "1999", "2000" };
    private string[] nationality = {"-", 
                            "Afghan", 
                            "Albanian", 
                            "Algerian", 
                            "American", 
                            "Andorran", 
                            "Angolan", 
                            "Antiguans", 
                            "Argentinean", 
                            "Armenian", 
                            "Australian", 
                            "Austrian", 
                            "Azerbaijani", 
                            "Bahamian", 
                            "Bahraini", 
                            "Bangladeshi", 
                            "Barbadian", 
                            "Barbudans", 
                            "Batswana", 
                            "Belarusian", 
                            "Belgian", 
                            "Belizean", 
                            "Beninese", 
                            "Bhutanese", 
                            "Bolivian", 
                            "Bosnian", 
                            "Brazilian", 
                            "British", 
                            "Bruneian", 
                            "Bulgarian", 
                            "Burkinabe", 
                            "Burmese", 
                            "Burundian", 
                            "Cambodian", 
                            "Cameroonian", 
                            "Canadian", 
                            "Cape Verdean", 
                            "Central African", 
                            "Chadian", 
                            "Chilean", 
                            "Chinese", 
                            "Colombian", 
                            "Comoran", 
                            "Congolese", 
                            "Congolese", 
                            "Costa Rican", 
                            "Croatian", 
                            "Cuban", 
                            "Cypriot", 
                            "Czech", 
                            "Danish", 
                            "Djibouti", 
                            "Dominican", 
                            "Dominican", 
                            "Dutch", 
                            "Dutchman", 
                            "Dutchwoman", 
                            "East Timorese", 
                            "Ecuadorean", 
                            "Egyptian", 
                            "Emirian", 
                            "Equatorial Guinean", 
                            "Eritrean", 
                            "Estonian", 
                            "Ethiopian", 
                            "Fijian", 
                            "Filipino", 
                            "Finnish", 
                            "French", 
                            "Gabonese", 
                            "Gambian", 
                            "Georgian", 
                            "German", 
                            "Ghanaian", 
                            "Greek", 
                            "Grenadian", 
                            "Guatemalan", 
                            "Guinea-Bissauan", 
                            "Guinean", 
                            "Guyanese", 
                            "Haitian", 
                            "Herzegovinian", 
                            "Honduran", 
                            "Hungarian", 
                            "I-Kiribati", 
                            "Icelander", 
                            "Indian", 
                            "Indonesian", 
                            "Iranian", 
                            "Iraqi", 
                            "Irish", 
                            "Irish", 
                            "Israeli", 
                            "Italian", 
                            "Ivorian", 
                            "Jamaican", 
                            "Japanese", 
                            "Jordanian", 
                            "Kazakhstani", 
                            "Kenyan", 
                            "Kittian and Nevisian", 
                            "Kuwaiti", 
                            "Kyrgyz", 
                            "Laotian", 
                            "Latvian", 
                            "Lebanese", 
                            "Liberian", 
                            "Libyan", 
                            "Liechtensteiner", 
                            "Lithuanian", 
                            "Luxembourger", 
                            "Macedonian", 
                            "Malagasy", 
                            "Malawian", 
                            "Malaysian", 
                            "Maldivan", 
                            "Malian", 
                            "Maltese", 
                            "Marshallese", 
                            "Mauritanian", 
                            "Mauritian", 
                            "Mexican", 
                            "Micronesian", 
                            "Moldovan", 
                            "Monacan", 
                            "Mongolian", 
                            "Moroccan", 
                            "Mosotho", 
                            "Motswana", 
                            "Mozambican", 
                            "Namibian", 
                            "Nauruan", 
                            "Nepalese", 
                            "Netherlander", 
                            "New Zealander", 
                            "Ni-Vanuatu", 
                            "Nicaraguan", 
                            "Nigerian", 
                            "Nigerien", 
                            "North Korean", 
                            "Northern Irish", 
                            "Norwegian", 
                            "Omani", 
                            "Pakistani", 
                            "Palauan", 
                            "Panamanian", 
                            "Papua New Guinean", 
                            "Paraguayan", 
                            "Peruvian", 
                            "Polish", 
                            "Portuguese", 
                            "Qatari", 
                            "Romanian", 
                            "Russian", 
                            "Rwandan", 
                            "Saint Lucian", 
                            "Salvadoran", 
                            "Samoan", 
                            "San Marinese", 
                            "Sao Tomean", 
                            "Saudi", 
                            "Scottish", 
                            "Senegalese", 
                            "Serbian", 
                            "Seychellois", 
                            "Sierra Leonean", 
                            "Singaporean", 
                            "Slovakian", 
                            "Slovenian", 
                            "Solomon Islander", 
                            "Somali", 
                            "South African", 
                            "South Korean", 
                            "Spanish", 
                            "Sri Lankan", 
                            "Sudanese", 
                            "Surinamer", 
                            "Swazi", 
                            "Swedish", 
                            "Swiss", 
                            "Syrian", 
                            "Taiwanese", 
                            "Tajik", 
                            "Tanzanian", 
                            "Thai", 
                            "Togolese", 
                            "Tongan", 
                            "Trinidadian or Tobagonian", 
                            "Tunisian", 
                            "Turkish", 
                            "Tuvaluan", 
                            "Ugandan", 
                            "Ukrainian", 
                            "Uruguayan", 
                            "Uzbekistani", 
                            "Venezuelan", 
                            "Vietnamese", 
                            "Welsh", 
                            "Welsh", 
                            "Yemenite", 
                            "Zambian", 
                            "Zimbabwean"};
    private string[] country = {"-", 
                        "Afghanistan", 
                        "Åland Islands", 
                        "Albania", 
                        "Algeria", 
                        "American Samoa", 
                        "Andorra", 
                        "Angola", 
                        "Anguilla", 
                        "Antarctica", 
                        "Antigua and Barbuda", 
                        "Argentina", 
                        "Armenia", 
                        "Aruba", 
                        "Australia", 
                        "Austria", 
                        "Azerbaijan", 
                        "Bahamas", 
                        "Bahrain", 
                        "Bangladesh", 
                        "Barbados", 
                        "Belarus", 
                        "Belgium", 
                        "Belize", 
                        "Benin", 
                        "Bermuda", 
                        "Bhutan", 
                        "Bolivia", 
                        "Bosnia and Herzegovina", 
                        "Botswana", 
                        "Bouvet Island", 
                        "Brazil", 
                        "British Indian Ocean territory", 
                        "Brunei Darussalam", 
                        "Bulgaria", 
                        "Burkina Faso", 
                        "Burundi", 
                        "Cambodia", 
                        "Cameroon", 
                        "Canada", 
                        "Cape Verde", 
                        "Cayman Islands", 
                        "Central African Republic", 
                        "Chad", 
                        "Chile", 
                        "China", 
                        "Christmas Island", 
                        "Cocos (Keeling) Islands", 
                        "Colombia", 
                        "Comoros", 
                        "Congo", 
                        "Congo, Democratic Republic", 
                        "Cook Islands", 
                        "Costa Rica", 
                        "C&ocirc;te d'Ivoire (Ivory Coast)", 
                        "Croatia (Hrvatska)", 
                        "Cuba", 
                        "Cyprus", 
                        "Czech Republic", 
                        "Denmark", 
                        "Djibouti", 
                        "Dominica", 
                        "Dominican Republic", 
                        "East Timor", 
                        "Ecuador", 
                        "Egypt", 
                        "El Salvador", 
                        "Equatorial Guinea", 
                        "Eritrea", 
                        "Estonia", 
                        "Ethiopia", 
                        "Falkland Islands", 
                        "Faroe Islands", 
                        "Fiji", 
                        "Finland", 
                        "France", 
                        "French Guiana", 
                        "French Polynesia", 
                        "French Southern Territories", 
                        "Gabon", 
                        "Gambia", 
                        "Georgia", 
                        "Germany", 
                        "Ghana", 
                        "Gibraltar", 
                        "Greece", 
                        "Greenland", 
                        "Grenada", 
                        "Guadeloupe", 
                        "Guam", 
                        "Guatemala", 
                        "Guinea", 
                        "Guinea-Bissau", 
                        "Guyana", 
                        "Haiti", 
                        "Heard and McDonald Islands", 
                        "Honduras", 
                        "Hong Kong", 
                        "Hungary", 
                        "Iceland", 
                        "India", 
                        "Indonesia", 
                        "Iran", 
                        "Iraq", 
                        "Ireland", 
                        "Israel", 
                        "Italy", 
                        "Jamaica", 
                        "Japan", 
                        "Jordan", 
                        "Kazakhstan", 
                        "Kenya", 
                        "Kiribati", 
                        "Korea (north)", 
                        "Korea (south)", 
                        "Kuwait", 
                        "Kyrgyzstan", 
                        "Lao People's Democratic Republic", 
                        "Latvia", 
                        "Lebanon", 
                        "Lesotho", 
                        "Liberia", 
                        "Libyan Arab Jamahiriya", 
                        "Liechtenstein", 
                        "Lithuania", 
                        "Luxembourg", 
                        "Macao", 
                        "Macedonia, Former Yugoslav Republic Of", 
                        "Madagascar", 
                        "Malawi", 
                        "Malaysia", 
                        "Maldives", 
                        "Mali", 
                        "Malta", 
                        "Marshall Islands", 
                        "Martinique", 
                        "Mauritania", 
                        "Mauritius", 
                        "Mayotte", 
                        "Mexico", 
                        "Micronesia", 
                        "Moldova", 
                        "Monaco", 
                        "Mongolia", 
                        "Montenegro", 
                        "Montserrat", 
                        "Morocco", 
                        "Mozambique", 
                        "Myanmar", 
                        "Namibia", 
                        "Nauru", 
                        "Nepal", 
                        "Netherlands", 
                        "Netherlands Antilles", 
                        "New Caledonia", 
                        "New Zealand", 
                        "Nicaragua", 
                        "Niger", 
                        "Nigeria", 
                        "Niue", 
                        "Norfolk Island", 
                        "Northern Mariana Islands", 
                        "Norway", 
                        "Oman", 
                        "Pakistan", 
                        "Palau", 
                        "Palestinian Territories", 
                        "Panama", 
                        "Papua New Guinea", 
                        "Paraguay", 
                        "Peru", 
                        "Philippines", 
                        "Pitcairn", 
                        "Poland", 
                        "Portugal", 
                        "Puerto Rico", 
                        "Qatar", 
                        "R&eacute;union", 
                        "Romania", 
                        "Russian Federation", 
                        "Rwanda", 
                        "Saint Helena", 
                        "Saint Kitts and Nevis", 
                        "Saint Lucia", 
                        "Saint Pierre and Miquelon", 
                        "Saint Vincent and the Grenadines", 
                        "Samoa", 
                        "San Marino", 
                        "Sao Tome and Principe", 
                        "Saudi Arabia", 
                        "Senegal", 
                        "Serbia", 
                        "Seychelles", 
                        "Sierra Leone", 
                        "Singapore", 
                        "Slovakia", 
                        "Slovenia", 
                        "Solomon Islands", 
                        "Somalia", 
                        "South Africa", 
                        "South Georgia and the South Sandwich Islands", 
                        "Spain", 
                        "Sri Lanka", 
                        "Sudan", 
                        "Suriname", 
                        "Svalbard and Jan Mayen Islands", 
                        "Swaziland", 
                        "Sweden", 
                        "Switzerland", 
                        "Syria", 
                        "Taiwan", 
                        "Tajikistan", 
                        "Tanzania", 
                        "Thailand", 
                        "Togo", 
                        "Tokelau", 
                        "Tonga", 
                        "Trinidad and Tobago", 
                        "Tunisia", 
                        "Turkey", 
                        "Turkmenistan", 
                        "Turks and Caicos Islands", 
                        "Tuvalu", 
                        "Uganda", 
                        "Ukraine", 
                        "United Arab Emirates", 
                        "United Kingdom", 
                        "United States of America", 
                        "Uruguay", 
                        "Uzbekistan", 
                        "Vanuatu", 
                        "Vatican City", 
                        "Venezuela", 
                        "Vietnam", 
                        "Virgin Islands (British)", 
                        "Virgin Islands (US)", 
                        "Wallis and Futuna Islands", 
                        "Western Sahara", 
                        "Yemen", 
                        "Zaire", 
                        "Zambia", 
                        "Zimbabwe"};

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DateOfBirth1.DataSource = day;
            DateOfBirth1.DataBind();
            DateOfBirth2.DataSource = month;
            DateOfBirth2.DataBind();
            DateOfBirth3.DataSource = year;
            DateOfBirth3.DataBind();
            Nationality.DataSource = nationality;
            Nationality.DataBind();
            Country.DataSource = country;
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

                mailmessage = new MailMessage(GlobalVariable.superadministratoremailaddress, EmailAddress.Text, "Email Subject", "<p>Email Body</p><p>Activation Link : <a href=\"" + Request.Url.GetLeftPart(UriPartial.Authority) + Page.ResolveUrl("~/registrationcomplete.aspx?operation=studentregistrationactivate&username=" + membershipuser.ProviderUserKey.ToString()) + "\">Activate Account</a></p>");
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
