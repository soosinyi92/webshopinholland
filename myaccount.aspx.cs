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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (User.IsInRole(GlobalVariable.superadministratorrolename))
            {
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataSource = GlobalVariable.day;
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataSource = GlobalVariable.month;
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataSource = GlobalVariable.year;
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataBind();
                ((DropDownList)LoginView1.FindControl("Nationality")).DataSource = GlobalVariable.nationality;
                ((DropDownList)LoginView1.FindControl("Nationality")).DataBind();
                ((DropDownList)LoginView1.FindControl("Country")).DataSource = GlobalVariable.country;
                ((DropDownList)LoginView1.FindControl("Country")).DataBind();

                ((TextBox)LoginView1.FindControl("FirstName")).Text = Profile.SuperAdministrator.FirstName;
                ((TextBox)LoginView1.FindControl("LastName")).Text = Profile.SuperAdministrator.LastName;
                dateofbirth = Profile.SuperAdministrator.DateOfBirth.Split('/');
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).SelectedIndex = Array.IndexOf(GlobalVariable.day, dateofbirth.ElementAt(0));
                if (dateofbirth.Count() > 1)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth2")).SelectedIndex = Array.IndexOf(GlobalVariable.month, dateofbirth.ElementAt(1));
                }
                if (dateofbirth.Count() > 2)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth3")).SelectedIndex = Array.IndexOf(GlobalVariable.year, dateofbirth.ElementAt(2));
                }
                if (Profile.SuperAdministrator.Gender.Equals("Male"))
                {
                    ((RadioButton)LoginView1.FindControl("Gender1")).Checked = true;
                }
                else
                {
                    ((RadioButton)LoginView1.FindControl("Gender2")).Checked = true;
                }
                ((DropDownList)LoginView1.FindControl("Nationality")).SelectedIndex = Array.IndexOf(GlobalVariable.nationality, Profile.SuperAdministrator.Nationality);
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.SuperAdministrator.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.SuperAdministrator.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.SuperAdministrator.City;
                ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(GlobalVariable.country, Profile.SuperAdministrator.Country);
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.SuperAdministrator.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
            else if (User.IsInRole(GlobalVariable.instituteadministratorrolename))
            {
                ((DropDownList)LoginView1.FindControl("Country")).DataSource = GlobalVariable.country;
                ((DropDownList)LoginView1.FindControl("Country")).DataBind();

                ((TextBox)LoginView1.FindControl("Name")).Text = Profile.InstituteAdministrator.Name;
                ((TextBox)LoginView1.FindControl("Description")).Text = Profile.InstituteAdministrator.Description;
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.InstituteAdministrator.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.InstituteAdministrator.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.InstituteAdministrator.City;
                ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(GlobalVariable.country, Profile.InstituteAdministrator.Country);
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.InstituteAdministrator.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
            else if (User.IsInRole(GlobalVariable.userrolename))
            {
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataSource = GlobalVariable.day;
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataSource = GlobalVariable.month;
                ((DropDownList)LoginView1.FindControl("DateOfBirth2")).DataBind();
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataSource = GlobalVariable.year;
                ((DropDownList)LoginView1.FindControl("DateOfBirth3")).DataBind();
                ((DropDownList)LoginView1.FindControl("Nationality")).DataSource = GlobalVariable.nationality;
                ((DropDownList)LoginView1.FindControl("Nationality")).DataBind();
                ((DropDownList)LoginView1.FindControl("Country")).DataSource = GlobalVariable.country;
                ((DropDownList)LoginView1.FindControl("Country")).DataBind();

                ((TextBox)LoginView1.FindControl("FirstName")).Text = Profile.User.FirstName;
                ((TextBox)LoginView1.FindControl("LastName")).Text = Profile.User.LastName;
                dateofbirth = Profile.User.DateOfBirth.Split('/');
                ((DropDownList)LoginView1.FindControl("DateOfBirth1")).SelectedIndex = Array.IndexOf(GlobalVariable.day, dateofbirth.ElementAt(0));
                if (dateofbirth.Count() > 1)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth2")).SelectedIndex = Array.IndexOf(GlobalVariable.month, dateofbirth.ElementAt(1));
                }
                if (dateofbirth.Count() > 2)
                {
                    ((DropDownList)LoginView1.FindControl("DateOfBirth3")).SelectedIndex = Array.IndexOf(GlobalVariable.year, dateofbirth.ElementAt(2));
                }
                if (Profile.User.Gender.Equals("Male"))
                {
                    ((RadioButton)LoginView1.FindControl("Gender1")).Checked = true;
                }
                else
                {
                    ((RadioButton)LoginView1.FindControl("Gender2")).Checked = true;
                }
                ((DropDownList)LoginView1.FindControl("Nationality")).SelectedIndex = Array.IndexOf(GlobalVariable.nationality, Profile.User.Nationality);
                ((TextBox)LoginView1.FindControl("Street")).Text = Profile.User.Street;
                ((TextBox)LoginView1.FindControl("HouseNumber")).Text = Profile.User.HouseNumber;
                ((TextBox)LoginView1.FindControl("City")).Text = Profile.User.City;
                ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(GlobalVariable.country, Profile.User.Country);
                ((TextBox)LoginView1.FindControl("PostalCode")).Text = Profile.User.PostalCode;
                ((Label)LoginView1.FindControl("EmailAddress")).Text = User.Identity.Name;
            }
        }
    }

    protected void SaveChanges_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;

        if (User.IsInRole(GlobalVariable.superadministratorrolename))
        {
            if (ValidateInput())
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
        }
        else if (User.IsInRole(GlobalVariable.instituteadministratorrolename))
        {
            if (ValidateInput())
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
        }
        else if (User.IsInRole(GlobalVariable.userrolename))
        {
            if (ValidateInput())
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

    private bool ValidateInput()
    {
        bool condition;

        condition = true;

        if (User.IsInRole(GlobalVariable.superadministratorrolename))
        {
            ((Label)LoginView1.FindControl("FirstNameError")).Visible = false;
            ((Label)LoginView1.FindControl("LastNameError")).Visible = false;
            ((Label)LoginView1.FindControl("DateOfBirthError")).Visible = false;
            ((Label)LoginView1.FindControl("NationalityError")).Visible = false;
            ((Label)LoginView1.FindControl("StreetError")).Visible = false;
            ((Label)LoginView1.FindControl("HouseNumberError")).Visible = false;
            ((Label)LoginView1.FindControl("CityError")).Visible = false;
            ((Label)LoginView1.FindControl("CountryError")).Visible = false;
            ((Label)LoginView1.FindControl("PostalCodeError")).Visible = false;
            ((Label)LoginView1.FindControl("PasswordError")).Visible = false;
            ((Label)LoginView1.FindControl("RetypePasswordError")).Visible = false;

            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("FirstName")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("FirstNameError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("LastName")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("LastNameError")).Visible = true;
                condition = false;
            }
            if ((!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("DateOfBirth1")).Text, Validation.dateofbirthregex)) ||
                (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("DateOfBirth2")).Text, Validation.dateofbirthregex)) ||
                (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("DateOfBirth3")).Text, Validation.dateofbirthregex)))
            {
                ((Label)LoginView1.FindControl("DateOfBirthError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("Nationality")).Text, Validation.nationalitycountryregex))
            {
                ((Label)LoginView1.FindControl("NationalityError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Street")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("StreetError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("HouseNumber")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("HouseNumberError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("City")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("CityError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("Country")).Text, Validation.nationalitycountryregex))
            {
                ((Label)LoginView1.FindControl("CountryError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("PostalCode")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("PostalCodeError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Password")).Text, Validation.emptypasswordregex))
            {
                ((Label)LoginView1.FindControl("PasswordError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateSimilarity(((TextBox)LoginView1.FindControl("Password")).Text, ((TextBox)LoginView1.FindControl("RetypePassword")).Text))
            {
                ((Label)LoginView1.FindControl("RetypePasswordError")).Visible = true;
                condition = false;
            }
        }
        else if (User.IsInRole(GlobalVariable.instituteadministratorrolename))
        {
            ((Label)LoginView1.FindControl("NameError")).Visible = false;
            ((Label)LoginView1.FindControl("DescriptionError")).Visible = false;
            ((Label)LoginView1.FindControl("StreetError")).Visible = false;
            ((Label)LoginView1.FindControl("HouseNumberError")).Visible = false;
            ((Label)LoginView1.FindControl("CityError")).Visible = false;
            ((Label)LoginView1.FindControl("CountryError")).Visible = false;
            ((Label)LoginView1.FindControl("PostalCodeError")).Visible = false;
            ((Label)LoginView1.FindControl("PasswordError")).Visible = false;
            ((Label)LoginView1.FindControl("RetypePasswordError")).Visible = false;

            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Name")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("NameError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Description")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("DescriptionError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Street")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("StreetError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("HouseNumber")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("HouseNumberError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("City")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("CityError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("Country")).Text, Validation.nationalitycountryregex))
            {
                ((Label)LoginView1.FindControl("CountryError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("PostalCode")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("PostalCodeError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Password")).Text, Validation.emptypasswordregex))
            {
                ((Label)LoginView1.FindControl("PasswordError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateSimilarity(((TextBox)LoginView1.FindControl("Password")).Text, ((TextBox)LoginView1.FindControl("RetypePassword")).Text))
            {
                ((Label)LoginView1.FindControl("RetypePasswordError")).Visible = true;
                condition = false;
            }
        }
        else if (User.IsInRole(GlobalVariable.userrolename))
        {
            ((Label)LoginView1.FindControl("FirstNameError")).Visible = false;
            ((Label)LoginView1.FindControl("LastNameError")).Visible = false;
            ((Label)LoginView1.FindControl("DateOfBirthError")).Visible = false;
            ((Label)LoginView1.FindControl("NationalityError")).Visible = false;
            ((Label)LoginView1.FindControl("StreetError")).Visible = false;
            ((Label)LoginView1.FindControl("HouseNumberError")).Visible = false;
            ((Label)LoginView1.FindControl("CityError")).Visible = false;
            ((Label)LoginView1.FindControl("CountryError")).Visible = false;
            ((Label)LoginView1.FindControl("PostalCodeError")).Visible = false;
            ((Label)LoginView1.FindControl("PasswordError")).Visible = false;
            ((Label)LoginView1.FindControl("RetypePasswordError")).Visible = false;

            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("FirstName")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("FirstNameError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("LastName")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("LastNameError")).Visible = true;
                condition = false;
            }
            if ((!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("DateOfBirth1")).Text, Validation.dateofbirthregex)) ||
                (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("DateOfBirth2")).Text, Validation.dateofbirthregex)) ||
                (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("DateOfBirth3")).Text, Validation.dateofbirthregex)))
            {
                ((Label)LoginView1.FindControl("DateOfBirthError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("Nationality")).Text, Validation.nationalitycountryregex))
            {
                ((Label)LoginView1.FindControl("NationalityError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Street")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("StreetError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("HouseNumber")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("HouseNumberError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("City")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("CityError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((DropDownList)LoginView1.FindControl("Country")).Text, Validation.nationalitycountryregex))
            {
                ((Label)LoginView1.FindControl("CountryError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("PostalCode")).Text, Validation.generalregex))
            {
                ((Label)LoginView1.FindControl("PostalCodeError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateRegex(((TextBox)LoginView1.FindControl("Password")).Text, Validation.emptypasswordregex))
            {
                ((Label)LoginView1.FindControl("PasswordError")).Visible = true;
                condition = false;
            }
            if (!Validation.ValidateSimilarity(((TextBox)LoginView1.FindControl("Password")).Text, ((TextBox)LoginView1.FindControl("RetypePassword")).Text))
            {
                ((Label)LoginView1.FindControl("RetypePasswordError")).Visible = true;
                condition = false;
            }
        }

        return condition;
    }
}
