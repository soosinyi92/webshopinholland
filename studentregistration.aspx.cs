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

public partial class studentregistration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Signup_Click(object sender, EventArgs e)
    {
        MembershipCreateStatus membershipcreatestatus;
        ProfileCommon profilecommon;

        Membership.CreateUser(EmailAddress.Text, Password.Text, EmailAddress.Text, "Password Question", "Password Answer", true, out membershipcreatestatus);

        profilecommon = (ProfileCommon)ProfileCommon.Create(EmailAddress.Text, true);
        profilecommon.User.FirstName = FirstName.Text;
        profilecommon.User.LastName = LastName.Text;
        profilecommon.User.DateOfBirth = DateOfBirth1.Text + "/" + DateOfBirth2.Text + "/" + DateOfBirth3.Text;
        if(Gender1.Checked)
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

        Roles.AddUserToRole(EmailAddress.Text, "User");

        Response.Redirect("registrationcomplete.aspx");
    }
}
