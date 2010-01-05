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
    private string search_index;

    protected void Page_Load(object sender, EventArgs e)
    {
        String event_category = Request.QueryString["Category"];

        List<string> data_source = new List<string>();
        Categories.Items.Add(new ListItem("Any", "0"));
       
        //data_source.InsertRange(1, Utilities.GetCategories());

        int i = 1;

        foreach (string it in Utilities.GetCategories())
        {
            Categories.Items.Add(new ListItem(it, i.ToString()));
            ++i;
        }

        //Categories.DataSource = Utilities.GetCategories();
        Categories.DataBind();
    }
    protected void Search_Click(object sender, EventArgs e)
    {
        string item = null;

        foreach (ListItem it in Categories.Items)
        {
            if (it.Text.Equals(Categories.SelectedItem.Text))
            {
                item = it.Text;
                break;
            }
        }

        Response.Redirect("./list.aspx?Category=" + item + "&Text=" + SearchText.Text);
    }
    protected void Category_SelectedIndexChanged(object sender, EventArgs e)
    {
        string item = null;

        foreach (ListItem it in Categories.Items)
        {
            if (it.Selected)
            {
                item = it.Text;
                break;
            }
        }

        search_index = item;
    }
}