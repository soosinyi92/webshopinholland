using System;
using System.Collections;
using System.Collections.Generic;
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

public partial class shoppingcart : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Dictionary<Int64, ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();
        rptShoppingCart.DataSource = cart;
        rptShoppingCart.DataBind();
    }

    protected void lbtnDelete_Click(object sender, CommandEventArgs e)
    {
        Dictionary<Int64, ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();

        LinkButton lnk = sender as LinkButton;

        int index = ((RepeaterItem)lnk.NamingContainer).ItemIndex;

        cart.Remove(Int64.Parse(e.CommandArgument.ToString()));

        rptShoppingCart.DataBind();
    }
}
