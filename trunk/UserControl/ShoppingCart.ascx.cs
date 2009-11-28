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

public partial class UserControl_ShoppingCart : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated || !Page.User.IsInRole("User"))
        {
            Response.Redirect("./");
        }
        List<ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();
        if (cart.Count == 0)
        {
            rptShoppingCart.Visible = false;
            lbtnCheckOut.Visible = false;
            lbEmptyCart.Visible = true;
        }
        else
        {
            rptShoppingCart.DataSource = cart;
            rptShoppingCart.DataBind();
            decimal total = 0;
            foreach (ShoppingCart.Item item in cart)
            {
                total += item.EventPrice * item.Quantity;
            }
            if (total > 0)
            {
                Label lblTotal = rptShoppingCart.Controls[rptShoppingCart.Controls.Count - 1].FindControl("lblTotal") as Label;
                lblTotal.Text = total.ToString();
            }
        }
    }

    protected void lbtnDelete_Click(object sender, CommandEventArgs e)
    {
        Profile.User.ShoppingCart.removeItem(Int64.Parse(e.CommandArgument.ToString()));
        List<ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();
        rptShoppingCart.DataSource = cart;
        Response.Redirect(Request.RawUrl);
        //rptShoppingCart.DataBind();
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        List<ShoppingCart.Item> cart = Profile.User.ShoppingCart.getItems();
        int quantity = int.Parse(Request.Form.Get("hfUpdateQuantity"));
        LinkButton btnUpdate = sender as LinkButton;
        RepeaterItem item = btnUpdate.Parent as RepeaterItem;
        if (quantity == 0)
        {
            Profile.User.ShoppingCart.removeItem(cart[item.ItemIndex].EventId);
        }
        else if (quantity != cart[item.ItemIndex].Quantity)
        {
            Profile.User.ShoppingCart.updateItem(cart[item.ItemIndex].EventId, quantity);
        }
        else
        {
            return;
        }
        Response.Redirect(Request.RawUrl);
    }

    protected void lbtnDeleteAll_Click(object sender, EventArgs e)
    {
        Profile.User.ShoppingCart.removeAllItems();
        Response.Redirect(Request.RawUrl);
    }
}
