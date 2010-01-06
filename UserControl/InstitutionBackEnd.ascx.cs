using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class UserControl_InstitutionBackEnd : System.Web.UI.UserControl
{
    WebshopDataContext dc = new WebshopDataContext();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Organization> list = (from org in dc.Organizations select org).ToList<Organization>();
        rptInstitution.DataSource = list;
        rptInstitution.DataBind();
    }

    protected void btnAddInstitution_Click(object sender, EventArgs e)
    {
        string Name = txtName.Text;
        string Email = txtEmail.Text;
        string Password = txtPassword.Text;
        if (Name != "" && Email != "" && Password != "")
        {
            if ((from org in dc.Organizations where org.Name == Name select org).Count() == 0)
            {
                if ((from usr in dc.aspnet_Users where usr.UserName == Email select usr).Count() == 0)
                {
                    try
                    {
                        // add organization
                        Organization org = new Organization();
                        org.Name = Name;
                        org.Description = txtDesc.Text;
                        dc.Organizations.InsertOnSubmit(org);
                        dc.SubmitChanges();
                        // add user
                        MembershipUser newUser = Membership.CreateUser(Email, Password, Email);
                        Roles.AddUserToRole(newUser.UserName, "institute administrator");
                        // get organization ID and user ID
                        long orgID = (from org1 in dc.Organizations where org1.Name == Name select org1).Single().OrganizationID;
                        Guid userID = (from usr in dc.aspnet_Users where usr.UserName == Email select usr).Single().UserId;
                        // create relationship
                        OrganizationManagement relationship = new OrganizationManagement();
                        relationship.OrganizationID = orgID;
                        relationship.UserID = userID;
                        dc.OrganizationManagements.InsertOnSubmit(relationship);
                        dc.SubmitChanges();
                        lbStatus.Text = "Institution successfully added";
                        txtName.Text = txtDesc.Text = txtEmail.Text = "";
                        List<Organization> list = (from org0 in dc.Organizations select org0).ToList<Organization>();
                        rptInstitution.DataSource = list;
                        rptInstitution.DataBind();
                    }
                    catch (Exception ex) 
                    {
                        Organization org = (from org2 in dc.Organizations where org2.Name == Name select org2).SingleOrDefault();
                        aspnet_User user = (from usr1 in dc.aspnet_Users where usr1.UserName == Email select usr1).SingleOrDefault();
                        OrganizationManagement relationship = null;
                        if (org != null && user != null)
                        {
                            relationship = (from rel in dc.OrganizationManagements where rel.UserID == user.UserId && rel.OrganizationID == org.OrganizationID select rel).SingleOrDefault();
                        }
                        if (org != null)
                        {
                            dc.Organizations.DeleteOnSubmit(org);
                        }
                        if (user != null)
                        {
                            Membership.DeleteUser(Email, true);
                        }
                        if (relationship != null)
                        {
                            dc.OrganizationManagements.DeleteOnSubmit(relationship);
                        }
                        dc.SubmitChanges();
                        lbStatus.Text = "Institution not added, an error has occurred";
                    }
                }
                else
                {
                    lbStatus.Text = "A user with the same Email exists already";
                }
            }
            else
            {
                lbStatus.Text = "An institution with the same name exists already";
            }
        }
        else
        {
            lbStatus.Text = "Please complete the form";
        }
    }

    protected void imgbtnDelete_Click(Object sender, CommandEventArgs e)
    {
        string orgID = e.CommandArgument as string;
        if (orgID != null)
        {
            Organization org = (from org3 in dc.Organizations where org3.OrganizationID == long.Parse(orgID) select org3).SingleOrDefault();
            List<OrganizationManagement> list = (from rel1 in dc.OrganizationManagements where rel1.OrganizationID == long.Parse(orgID) select rel1).ToList();
            if (org != null)
            {
                dc.Organizations.DeleteOnSubmit(org);
            }
            if (list.Count != 0)
            {
                dc.OrganizationManagements.DeleteAllOnSubmit(list);
            }
            dc.SubmitChanges();
            Response.Redirect(Request.RawUrl);
        }
    }
}