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
using System.Collections.Generic;

public partial class UserControl_SearchBar : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<string> data_source = new List<string>();
        data_source.Add("Any");
        data_source.InsertRange(1, Utilities.GetCategories());
        Category.DataSource = data_source;
        Category.DataBind();
    }
    protected void Search_Click(object sender, EventArgs e)
    {

    }
}
