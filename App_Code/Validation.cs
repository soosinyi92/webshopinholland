using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public static class Validation
{
    public static string dateofbirthregex = "[a-zA-Z0-9]+",
        nationalitycountryregex = "[a-zA-Z0-9Å()\\s]+",
        emailregex = "[a-zA-Z0-9.-_]+@[a-zA-Z0-9.-]+\\.[a-zA-Z0-9.-]+",
        emptypasswordregex = "[a-zA-Z0-9!@#$%^&*()-_+=\\s]*", 
        generalregex = "[a-zA-Z0-9!@#$%^&*()-_+=\\s]+";

    public static bool ValidateRegex(string text, string stringregex)
    {
        Regex regex;

        regex = new Regex(stringregex);

        return regex.IsMatch(text);
    }

    public static bool ValidateSimilarity(string text1, string text2)
    {
        return text1.Equals(text2);
    }
}
