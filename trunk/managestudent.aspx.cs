using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class managestudent : System.Web.UI.Page
{
    private MembershipUserCollection membershipusercollection;
    private string[] dateofbirth;

    protected void Page_Load(object sender, EventArgs e)
    {
        Repeater repeater;
        Panel panel;
        ProfileCommon profilecommon;
        string[] user;
        string operation;

        if (!IsPostBack)
        {
            operation = Request.QueryString["operation"];

            if (operation != null)
            {
                if (operation.Equals("edit"))
                {
                    repeater = (Repeater)LoginView1.FindControl("Repeater1");
                    if (repeater != null)
                    {
                        repeater.Visible = false;
                    }

                    panel = (Panel)LoginView1.FindControl("Panel1");
                    if (panel != null)
                    {
                        panel.Visible = true;
                    }

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

                    profilecommon = Profile.GetProfile(Request.QueryString["username"]);

                    ((TextBox)LoginView1.FindControl("FirstName")).Text = profilecommon.User.FirstName;
                    ((TextBox)LoginView1.FindControl("LastName")).Text = profilecommon.User.LastName;
                    dateofbirth = profilecommon.User.DateOfBirth.Split('/');
                    ((DropDownList)LoginView1.FindControl("DateOfBirth1")).SelectedIndex = Array.IndexOf(GlobalVariable.day, dateofbirth.ElementAt(0));
                    if (dateofbirth.Count() > 1)
                    {
                        ((DropDownList)LoginView1.FindControl("DateOfBirth2")).SelectedIndex = Array.IndexOf(GlobalVariable.month, dateofbirth.ElementAt(1));
                    }
                    if (dateofbirth.Count() > 2)
                    {
                        ((DropDownList)LoginView1.FindControl("DateOfBirth3")).SelectedIndex = Array.IndexOf(GlobalVariable.year, dateofbirth.ElementAt(2));
                    }
                    if (profilecommon.User.Gender.Equals("Male"))
                    {
                        ((RadioButton)LoginView1.FindControl("Gender1")).Checked = true;
                    }
                    else
                    {
                        ((RadioButton)LoginView1.FindControl("Gender2")).Checked = true;
                    }
                    ((DropDownList)LoginView1.FindControl("Nationality")).SelectedIndex = Array.IndexOf(GlobalVariable.nationality, profilecommon.User.Nationality);
                    ((TextBox)LoginView1.FindControl("Street")).Text = profilecommon.User.Street;
                    ((TextBox)LoginView1.FindControl("HouseNumber")).Text = profilecommon.User.HouseNumber;
                    ((TextBox)LoginView1.FindControl("City")).Text = profilecommon.User.City;
                    ((DropDownList)LoginView1.FindControl("Country")).SelectedIndex = Array.IndexOf(GlobalVariable.country, profilecommon.User.Country);
                    ((TextBox)LoginView1.FindControl("PostalCode")).Text = profilecommon.User.PostalCode;
                    ((Label)LoginView1.FindControl("EmailAddress")).Text = Request.QueryString["username"];
                    if (Membership.GetUser(Request.QueryString["username"]).IsApproved)
                    {
                        ((RadioButton)LoginView1.FindControl("Status1")).Checked = true;
                    }
                    else
                    {
                        ((RadioButton)LoginView1.FindControl("Status2")).Checked = true;
                    }
                }
                else if (operation.Equals("delete"))
                {
                    Membership.DeleteUser(Request.QueryString["username"]);

                    Response.Redirect("./managestudent.aspx");
                }
            }
            else
            {
                user = Roles.GetUsersInRole("User");
                membershipusercollection = new MembershipUserCollection();

                foreach (string username in user)
                {
                    membershipusercollection.Add(Membership.GetUser(username));
                }

                repeater = (Repeater)LoginView1.FindControl("Repeater1");
                if (repeater != null)
                {
                    repeater.DataSource = membershipusercollection;
                    repeater.DataBind();
                    repeater.Visible = true;
                }

                panel = (Panel)LoginView1.FindControl("Panel1");
                if (panel != null)
                {
                    panel.Visible = false;
                }
            }
        }
        else
        {
            operation = Request.QueryString["operation"];

            if (operation == null)
            {
                user = Roles.GetUsersInRole("User");
                membershipusercollection = new MembershipUserCollection();

                foreach (string username in user)
                {
                    membershipusercollection.Add(Membership.GetUser(username));
                }

                repeater = (Repeater)LoginView1.FindControl("Repeater1");
                if (repeater != null)
                {
                    repeater.DataSource = membershipusercollection;
                    repeater.DataBind();
                    repeater.Visible = true;
                }

                panel = (Panel)LoginView1.FindControl("Panel1");
                if (panel != null)
                {
                    panel.Visible = false;
                }
            }
        }
    }

    protected void Repeater1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        ProfileCommon profilecommon;
        UserControl_ManageUser manageuser;

        manageuser = (UserControl_ManageUser)e.Item.FindControl("manageuser");
        profilecommon = Profile.GetProfile(((MembershipUser)e.Item.DataItem).UserName);

        manageuser.Name.Text = profilecommon.User.FirstName + " " + profilecommon.User.LastName;
        manageuser.Email.Text = ((MembershipUser)e.Item.DataItem).UserName;
        manageuser.UrlFront = "./managestudent.aspx?operation=";
        manageuser.UrlBack = "&username=" + ((MembershipUser)e.Item.DataItem).UserName;
    }

    protected void SaveChanges_Click(object sender, EventArgs e)
    {
        MembershipUser membershipuser;
        ProfileCommon profilecommon;

        if (ValidateInput())
        {
            profilecommon = (ProfileCommon)ProfileCommon.Create(Request.QueryString["username"], true);
            profilecommon.User.FirstName = ((TextBox)LoginView1.FindControl("FirstName")).Text;
            profilecommon.User.LastName = ((TextBox)LoginView1.FindControl("LastName")).Text;
            profilecommon.User.DateOfBirth = ((DropDownList)LoginView1.FindControl("DateOfBirth1")).Text + "/" + ((DropDownList)LoginView1.FindControl("DateOfBirth2")).Text + "/" + ((DropDownList)LoginView1.FindControl("DateOfBirth3")).Text;
            if (((RadioButton)LoginView1.FindControl("Gender1")).Checked)
            {
                profilecommon.User.Gender = "Male";
            }
            else
            {
                profilecommon.User.Gender = "Female";
            }
            profilecommon.User.Nationality = ((DropDownList)LoginView1.FindControl("Nationality")).Text;
            profilecommon.User.Street = ((TextBox)LoginView1.FindControl("Street")).Text;
            profilecommon.User.HouseNumber = ((TextBox)LoginView1.FindControl("HouseNumber")).Text;
            profilecommon.User.City = ((TextBox)LoginView1.FindControl("City")).Text;
            profilecommon.User.Country = ((DropDownList)LoginView1.FindControl("Country")).Text;
            profilecommon.User.PostalCode = ((TextBox)LoginView1.FindControl("PostalCode")).Text;
            if (!((TextBox)LoginView1.FindControl("Password")).Text.Equals(""))
            {
                membershipuser = Membership.GetUser(Request.QueryString["username"]);
                membershipuser.ChangePassword(membershipuser.ResetPassword("Password Answer"), ((TextBox)LoginView1.FindControl("Password")).Text);
            }

            profilecommon.Save();

            membershipuser = Membership.GetUser(Request.QueryString["username"]);
            if (((RadioButton)LoginView1.FindControl("Status1")).Checked)
            {
                membershipuser.IsApproved = true;
            }
            else
            {
                membershipuser.IsApproved = false;
            }

            Membership.UpdateUser(membershipuser);

            Response.Redirect(Request.Url.ToString());
        }
    }

    protected void Back_Click(object sender, EventArgs e)
    {
        Response.Redirect("./managestudent.aspx");
    }

    private bool ValidateInput()
    {
        bool condition;

        condition = true;

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

        return condition;
    }
}