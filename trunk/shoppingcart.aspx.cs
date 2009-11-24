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
        List<ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();
        if (cart.Count == 0)
        {
            rptShoppingCart.Visible = false;
        }
        else
        {
            rptShoppingCart.DataSource = cart;
            rptShoppingCart.DataBind();
        }
    }

    protected void lbtnDelete_Click(object sender, CommandEventArgs e)
    {
        Profile.User.ShoppingCart.removeItem(Int64.Parse(e.CommandArgument.ToString()));
        List<ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();
        rptShoppingCart.DataSource = cart;
        rptShoppingCart.DataBind();
    }
}
