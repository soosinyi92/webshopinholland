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
    string[] country = {"-", 
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
            Country.DataSource = country;
            Country.DataBind();
            Agreement.Text = " I agree with <a href=\"#\">terms of service</a>, <a href=\"#\">program policy</a>, and <a href=\"#\">privacy policy</a>";
        }
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
