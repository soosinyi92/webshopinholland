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

namespace EventControls
{
    public partial class UserControl_EventSummary : System.Web.UI.UserControl
    {
        private Int64 eventID1 = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public bool FillEvent(Int64 eventID)
        {

            eventID1 = eventID;

            if (eventID == -1)
            {
                return false;
            }

            //ImageButton1.ImageUrl = "..\\img\\no_img.jpg";
            //ImageButton1.Width = 100;
            //ImageButton1.Height = 100;

            WebshopDataContext dc = new WebshopDataContext();
            Event eventX = (from ev in dc.Events where ev.EventID == eventID select ev).FirstOrDefault();

            if (eventX == null)
            {
                return false;
            }

            lblName.Text = eventX.Name;
            lblStartTime.Text = eventX.StsrtDateTime.ToShortDateString() +
                                " " + eventX.StsrtDateTime.ToShortTimeString();
            lblEndTime.Text = eventX.EndDateTime.ToShortDateString() +
                                " " + eventX.EndDateTime.ToShortTimeString();

            lblLocation.Text = Utilities.ContinuousString(eventX.Location, 0, 26);
            lblPrice.Text = eventX.Price.ToString();

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

        protected void LinkButton1_Click(object sender, CommandEventArgs e)
        {
            Response.Redirect("./detail.aspx?EventID=" + eventID1.ToString());
        }
    }
}
