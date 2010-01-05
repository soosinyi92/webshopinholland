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
        
        List<ShoppingCart.Item> cart = Profile.ShoppingCart.getItems();
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
            decimal total = Profile.ShoppingCart.getTotalNetPrice();
            
            if (total > 0)
            {
                Label lblTotal = rptShoppingCart.Controls[rptShoppingCart.Controls.Count - 1].FindControl("lblTotal") as Label;
                lblTotal.Text = Math.Round(total,2).ToString();
            }
        }
    }

    protected void lbtnDelete_Click(object sender, CommandEventArgs e)
    {
        Profile.ShoppingCart.removeItem(Int64.Parse(e.CommandArgument.ToString()));
        List<ShoppingCart.Item> cart = Profile.ShoppingCart.getItems();
        rptShoppingCart.DataSource = cart;
        Response.Redirect(Request.RawUrl);
    }

    protected void lbtnUpdate_Click(object sender, EventArgs e)
    {
        List<ShoppingCart.Item> cart = Profile.ShoppingCart.getItems();
        int quantity = int.Parse(Request.Form.Get("hfUpdateQuantity"));
        LinkButton btnUpdate = sender as LinkButton;
        RepeaterItem item = btnUpdate.Parent as RepeaterItem;
        if (quantity == 0)
        {
            Profile.ShoppingCart.removeItem(cart[item.ItemIndex].EventId);
        }
        else if (quantity != cart[item.ItemIndex].Quantity)
        {
            Profile.ShoppingCart.updateItem(cart[item.ItemIndex].EventId, quantity);
        }
        else
        {
            return;
        }
        Response.Redirect(Request.RawUrl);
    }

    protected void lbtnDeleteAll_Click(object sender, EventArgs e)
    {
        Profile.ShoppingCart.removeAllItems();
        Response.Redirect(Request.RawUrl);
    }
	protected void lbtnCheckOut_Click(object sender, EventArgs e)
	{

	}
}
