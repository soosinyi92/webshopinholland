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

public partial class UserControl_EventSummary : System.Web.UI.UserControl
{
    private Int64 eventID1 = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public bool FillEvent(Int64 eventID)
    {
        ImageButton1.ImageUrl = "..\\img\\no_img.jpg";
        ImageButton1.Width = 100;
        ImageButton1.Height = 100;
        LinqDataSource1.Where = "ID = " + eventID.ToString();

        eventID1 = eventID;

        return true;
    }

    public Int64 EventID
    {
        get
        {
            return eventID1;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("./detail.aspx?EventID=" + eventID1.ToString());
    }
}
