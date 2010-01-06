using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_ManageUser : System.Web.UI.UserControl
{
    private string urlfront, urlback;

    public Label Name
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }

    public Label Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }

    public string UrlFront
    {
        get
        {
            return urlfront;
        }
        set
        {
            urlfront = value;
        }
    }

    public string UrlBack
    {
        get
        {
            return urlback;
        }
        set
        {
            urlback = value;
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Edit_Click(Object sender, EventArgs e)
    {
        Response.Redirect(urlfront + "edit" + urlback);
    }

    protected void Delete_Click(Object sender, EventArgs e)
    {
        Response.Redirect(urlfront + "delete" + urlback);
    }
}
