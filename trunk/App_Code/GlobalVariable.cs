﻿using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public static class GlobalVariable
{
    public static string superadministratoremailaddress = "tempe_kecap@yahoo.co.id",
        superadministratoremailpassword = "m3m0r13s", 
        superadministratorrolename = "Super Administrator", 
        instituteadministratorrolename = "Institute Administrator", userrolename = "User";
    public static string emailheadertemplate = "<div style=\"font-family: Verdana,\"BitStream vera Sans\",Arial,Helvetica,sans-serif;margin: auto;width: 500px\"><p style=\"-moz-border-radius:4px;-webkit-border-radius: 4px;background:#88BBD4;display: block;font-size:30px;margin-bottom: 20px;padding: 10px 0px 10px 10px;width:500px\">WebShop</p>";
    public static string emailfootertemplate = "<p style=\"-moz-border-radius:4px;-webkit-border-radius: 4px;background:#88BBD4;display: block;font-size:12px;margin-top: 20px;padding: 10px 10px 10px 0px;text-align: right;width:500px\">Copyright &copy; 2009 WebShop</p></div>";
    public static string[] day = { "-", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31" };
    public static string[] month = { "-", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
    public static string[] year = { "-", "1980", "1981", "1982", "1983", "1984", "1985", "1986", "1987", "1988", "1989", "1990", "1991", "1992", "1993", "1994", "1995", "1996", "1997", "1998", "1999", "2000" };
    public static string[] nationality = {"-", 
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
    public static string[] country = {"-", 
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
}
