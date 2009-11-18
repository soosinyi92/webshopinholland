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

public partial class myaccount : System.Web.UI.Page
{
    private string[] dateofbirth;
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
            if (User.IsInRole("Super Administrator"))
            {
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataSource = day;
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataSource = month;
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataSource = year;
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataBind();
                ((DropDownList)LoginView1.FindControl("Nationality")).DataSource = nationality;
                ((DropDownList)LoginView1.FindControl("Nationality")).DataBind();
                ((DropDownList)LoginView1.FindControl("Country")).DataSource = country;
                ((DropDownList)LoginView1.FindControl("Country")).DataBind();

                ((TextBox)LoginView1.FindControl("FirstName")).Text = Profile.SuperAdministrator.FirstName;
                ((TextBox)LoginView1.FindControl("LastName")).Text = Profile.SuperAdministrator.LastName;
                dateofbirth = Profile.SuperAdministrator.DateOfBirth.Split('/');
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).SelectedIndex = Array.IndexOf(day, dateofbirth.ElementAt(0));
                if (dateofbirth.Count() > 1)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth2")).SelectedIndex = Array.IndexOf(month, dateofbirth.ElementAt(1));
                }
                if (dateofbirth.Count() > 2)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth3")).SelectedIndex = Array.IndexOf(year, dateofbirth.ElementAt(2));
                }
                if (Profile.SuperAdministrator.Gender.Equals("Male"))
                {
                    ((RadioButton)LoginView1.FindControl("Gender1")).Checked = true;
                }
                else
                {
                    ((RadioButton)LoginView1.FindControl("Gender2")).Checked = true;
                }
                ((DropDownList)LoginView1.FindControl("Nationality")).SelectedIndex = Array.IndexOf(nationality, Profile.SuperAdministrator.Nationality);
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.SuperAdministrator.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.SuperAdministrator.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.SuperAdministrator.City;
                ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(country, Profile.SuperAdministrator.Country);
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.SuperAdministrator.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
            else if (User.IsInRole("Institute Administrator"))
            {
                ((DropDownList)LoginView1.FindControl("Country")).DataSource = country;
                ((DropDownList)LoginView1.FindControl("Country")).DataBind();

                ((TextBox)LoginView1.FindControl("Name")).Text = Profile.InstituteAdministrator.Name;
                ((TextBox)LoginView1.FindControl("Description")).Text = Profile.InstituteAdministrator.Description;
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.InstituteAdministrator.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.InstituteAdministrator.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.InstituteAdministrator.City;
                ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(country, Profile.InstituteAdministrator.Country);
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.InstituteAdministrator.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
            else if (User.IsInRole("User"))
            {
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataSource = day;
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataSource = month;
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataSource = year;
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataBind();
                ((DropDownList)LoginView1.FindControl("Nationality")).DataSource = nationality;
                ((DropDownList)LoginView1.FindControl("Nationality")).DataBind();
                ((DropDownList)LoginView1.FindControl("Country")).DataSource = country;
                ((DropDownList)LoginView1.FindControl("Country")).DataBind();

                ((TextBox)LoginView1.FindControl("FirstName")).Text = Profile.User.FirstName;
                ((TextBox)LoginView1.FindControl("LastName")).Text = Profile.User.LastName;
                dateofbirth = Profile.User.DateOfBirth.Split('/');
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).SelectedIndex = Array.IndexOf(day, dateofbirth.ElementAt(0));
                if (dateofbirth.Count() > 1)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth2")).SelectedIndex = Array.IndexOf(month, dateofbirth.ElementAt(1));
                }
                if (dateofbirth.Count() > 2)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth3")).SelectedIndex = Array.IndexOf(year, dateofbirth.ElementAt(2));
                }
                if (Profile.User.Gender.Equals("Male"))
                {
                    ((RadioButton)LoginView1.FindControl("Gender1")).Checked = true;
                }
                else
                {
                    ((RadioButton)LoginView1.FindControl("Gender2")).Checked = true;
                }
                ((DropDownList)LoginView1.FindControl("Nationality")).SelectedIndex = Array.IndexOf(nationality, Profile.User.Nationality);
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.User.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.User.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.User.City;
                ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(country, Profile.User.Country);
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.User.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
        }
    }

    protected void SaveChanges_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;

        if (User.IsInRole("Super Administrator"))
        {
            Profile.SuperAdministrator.FirstName = ((TextBox)LoginView1.FindControl("FirstName")).Text;
            Profile.SuperAdministrator.LastName = ((TextBox)LoginView1.FindControl("LastName")).Text;
            Profile.SuperAdministrator.DateOfBirth = ((DropDownList)LoginView1.FindControl("DateOfBirth1")).Text + "/" + ((DropDownList)LoginView1.FindControl("DateOfBirth2")).Text + "/" + ((DropDownList)LoginView1.FindControl("DateOfBirth3")).Text;
            if (((RadioButton)LoginView1.FindControl("Gender1")).Checked)
            {
                Profile.SuperAdministrator.Gender = "Male";
            }
            else
            {
                Profile.SuperAdministrator.Gender = "Female";
            }
            Profile.SuperAdministrator.Nationality = ((DropDownList)LoginView1.FindControl("Nationality")).Text;
            Profile.SuperAdministrator.Street = ((TextBox)LoginView1.FindControl("Street")).Text;
            Profile.SuperAdministrator.HouseNumber = ((TextBox)LoginView1.FindControl("HouseNumber")).Text;
            Profile.SuperAdministrator.City = ((TextBox)LoginView1.FindControl("City")).Text;
            Profile.SuperAdministrator.Country = ((DropDownList)LoginView1.FindControl("Country")).Text;
            Profile.SuperAdministrator.PostalCode = ((TextBox)LoginView1.FindControl("PostalCode")).Text;
            if (!((TextBox)LoginView1.FindControl("Password")).Text.Equals(""))
            {
                membershipuser = Membership.GetUser(User.Identity.Name);
                membershipuser.ChangePassword(membershipuser.ResetPassword("Password Answer"), ((TextBox)LoginView1.FindControl("Password")).Text);
            }

            Response.Redirect(Request.Url.ToString());
        }
        else if (User.IsInRole("Institute Administration"))
        {
            Profile.InstituteAdministrator.Name = ((TextBox)LoginView1.FindControl("Name")).Text;
            Profile.InstituteAdministrator.Description = ((TextBox)LoginView1.FindControl("Description")).Text;
            Profile.InstituteAdministrator.Street = ((TextBox)LoginView1.FindControl("Street")).Text;
            Profile.InstituteAdministrator.HouseNumber = ((TextBox)LoginView1.FindControl("HouseNumber")).Text;
            Profile.InstituteAdministrator.City = ((TextBox)LoginView1.FindControl("City")).Text;
            Profile.InstituteAdministrator.Country = ((DropDownList)LoginView1.FindControl("Country")).Text;
            Profile.InstituteAdministrator.PostalCode = ((TextBox)LoginView1.FindControl("PostalCode")).Text;
            if (!((TextBox)LoginView1.FindControl("Password")).Text.Equals(""))
            {
                membershipuser = Membership.GetUser(User.Identity.Name);
                membershipuser.ChangePassword(membershipuser.ResetPassword("Password Answer"), ((TextBox)LoginView1.FindControl("Password")).Text);
            }

            Response.Redirect(Request.Url.ToString());
        }
        else if (User.IsInRole("User"))
        {
            Profile.User.FirstName = ((TextBox)LoginView1.FindControl("FirstName")).Text;
            Profile.User.LastName = ((TextBox)LoginView1.FindControl("LastName")).Text;
            Profile.User.DateOfBirth = ((DropDownList)LoginView1.FindControl("DateOfBirth1")).Text + "/" + ((DropDownList)LoginView1.FindControl("DateOfBirth2")).Text + "/" + ((DropDownList)LoginView1.FindControl("DateOfBirth3")).Text;
            if (((RadioButton)LoginView1.FindControl("Gender1")).Checked)
            {
                Profile.User.Gender = "Male";
            }
            else
            {
                Profile.User.Gender = "Female";
            }
            Profile.User.Nationality = ((DropDownList)LoginView1.FindControl("Nationality")).Text;
            Profile.User.Street = ((TextBox)LoginView1.FindControl("Street")).Text;
            Profile.User.HouseNumber = ((TextBox)LoginView1.FindControl("HouseNumber")).Text;
            Profile.User.City = ((TextBox)LoginView1.FindControl("City")).Text;
            Profile.User.Country = ((DropDownList)LoginView1.FindControl("Country")).Text;
            Profile.User.PostalCode = ((TextBox)LoginView1.FindControl("PostalCode")).Text;
            if (!((TextBox)LoginView1.FindControl("Password")).Text.Equals(""))
            {
                membershipuser = Membership.GetUser(User.Identity.Name);
                membershipuser.ChangePassword(membershipuser.ResetPassword("Password Answer"), ((TextBox)LoginView1.FindControl("Password")).Text);
            }

            Response.Redirect(Request.Url.ToString());
        }
    }
}
