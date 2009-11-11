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
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] dateofbirth;

        if (!Page.IsPostBack)
        {
            if (User.IsInRole("User"))
            {
                ((TextBox)LoginView1.FindControl("FirstName")).Text = Profile.User.FirstName;
                ((TextBox)LoginView1.FindControl("LastName")).Text = Profile.User.LastName;
                dateofbirth = Profile.User.DateOfBirth.Split('/');
                ((TextBox)LoginView1.FindControl("DateOfBirth1")).Text = dateofbirth.ElementAt(0);
                if (dateofbirth.Count() > 1)
                {
                    ((TextBox)LoginView1.FindControl("DateOfBirth2")).Text = dateofbirth.ElementAt(1);
                }
                if (dateofbirth.Count() > 2)
                {
                    ((TextBox)LoginView1.FindControl("DateOfBirth3")).Text = dateofbirth.ElementAt(2);
                }
                if (Profile.User.Gender.Equals("Male"))
                {
                    ((RadioButton)LoginView1.FindControl("Gender1")).Checked = true;
                }
                else
                {
                    ((RadioButton)LoginView1.FindControl("Gender2")).Checked = true;
                }
                ((TextBox)LoginView1.FindControl("Nationality")).Text = Profile.User.Nationality;
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.User.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.User.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.User.City;
                ((TextBox)LoginView1.FindControl("Country")).Text = Profile.User.Country;
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.User.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
        }
    }

    protected void SaveChanges_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;
        
        Profile.User.FirstName = ((TextBox)LoginView1.FindControl("FirstName")).Text;
        Profile.User.LastName = ((TextBox)LoginView1.FindControl("LastName")).Text;
        Profile.User.DateOfBirth = ((TextBox)LoginView1.FindControl("DateOfBirth1")).Text + "/" + ((TextBox)LoginView1.FindControl("DateOfBirth2")).Text + "/" + ((TextBox)LoginView1.FindControl("DateOfBirth3")).Text;
        if (((RadioButton)LoginView1.FindControl("Gender1")).Checked)
        {
            Profile.User.Gender = "Male";
        }
        else
        {
            Profile.User.Gender = "Female";
        }
        Profile.User.Nationality = ((TextBox)LoginView1.FindControl("Nationality")).Text;
        Profile.User.Street = ((TextBox)LoginView1.FindControl("Street")).Text;
        Profile.User.HouseNumber = ((TextBox)LoginView1.FindControl("HouseNumber")).Text;
        Profile.User.City = ((TextBox)LoginView1.FindControl("City")).Text;
        Profile.User.Country = ((TextBox)LoginView1.FindControl("Country")).Text;
        Profile.User.PostalCode = ((TextBox)LoginView1.FindControl("PostalCode")).Text;
        if (!((TextBox)LoginView1.FindControl("Password")).Text.Equals(""))
        {
            membershipuser = Membership.GetUser(User.Identity.Name);
            membershipuser.ChangePassword(membershipuser.ResetPassword("Password Answer"), ((TextBox)LoginView1.FindControl("Password")).Text);
        }

        Response.Redirect(Request.Url.ToString());
    }
}
