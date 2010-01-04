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
using EventControls;

public partial class _default : System.Web.UI.Page
{
    protected void PopulateTopEvents(Object Sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            EventControls.UserControl_EventSummary eventSummary = (EventControls.UserControl_EventSummary)e.Item.FindControl("EventSummary");

            eventSummary.FillEvent((Int64)e.Item.DataItem);
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        WebshopDataContext dc = new WebshopDataContext();

        IEnumerable<Event> eventX = (from ev in dc.Events select ev).Take(10).DefaultIfEmpty();

        if (eventX == null)
        {
            return;
        }

        IEnumerable<Int64> topEvents = (from ev in eventX select ev.EventID);
        TopEvents.DataSource = topEvents;
        TopEvents.DataBind();
        
        //EventSummary1.FillEvent(7);
        //EventSummary2.FillEvent(8);
        //EventSummary3.FillEvent(9);
        //EventSummary4.FillEvent(10);
        //EventSummary5.FillEvent(11);
        //EventSummary6.FillEvent(12);
        //EventSummary7.FillEvent(13);tem.
        //EventSummary8.FillEvent(14);
        //EventSummary9.FillEvent(15);
        //EventSummary10.FillEvent(16);
    }
}
