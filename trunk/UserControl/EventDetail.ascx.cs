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

public partial class UserControl_EventDetail : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            String eventID = Request.QueryString["EventID"];

            if (eventID == null)
            {
                return;
            }

            Int64 i = new Int64();
            i = Int64.Parse(eventID);

            WebshopDataContext dc = new WebshopDataContext();

            Event eventX = (from ev in dc.Events where ev.EventID == i select ev).FirstOrDefault();

            if (eventX == null)
            {
                return;
            }

            lblStartTime.Text = eventX.StsrtDateTime.ToString();
            lblEndTime.Text = eventX.EndDateTime.ToString(); ;
            lblLocation.Text = eventX.Location;
            lblPrice.Text = eventX.Price.ToString();

            //lblOrganizer.Text = eventX.EventOrganizers.ToString();
            lblOrganization.Text = eventX.EventOrganizations.ToString();

            lblDescription.Text = eventX.Description;
            lblConditions.Text = eventX.Conditions;
        }
    }
}
