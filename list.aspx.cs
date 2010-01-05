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

public partial class list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebshopDataContext dc = new WebshopDataContext();

        IEnumerable<Event> eventX = (from ev in dc.Events select ev).DefaultIfEmpty();

        String event_category = Request.QueryString["Category"];

        int category = int.Parse(event_category);
        

        if (eventX == null)
        {
            return;
        }

        IEnumerable<Int64> topEvents = (from ev in eventX select ev.EventID);
        TopEvents.DataSource = topEvents;
        TopEvents.DataBind();
    }

    protected void PopulateTopEvents(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            EventControls.UserControl_EventSummary eventSummary = (EventControls.UserControl_EventSummary)e.Item.FindControl("EventSummary");

            eventSummary.FillEvent((Int64)e.Item.DataItem);
        }
    }
}
