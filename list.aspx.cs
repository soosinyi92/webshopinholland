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

        String event_category = Request.QueryString["Category"];
        String event_text = Request.QueryString["Text"];
        
        if (event_category == "Any")
        {
            if (event_text != "")
            {
                IEnumerable<Int64> topEvents = (from ev in dc.Events
                                                where ev.Name.Contains(event_text)
                                                select ev.EventID);
                TopEvents.DataSource = topEvents;
            }
            else
            {
                IEnumerable<Int64> topEvents = (from ev in dc.Events
                                                select ev.EventID);
                TopEvents.DataSource = topEvents;
            }
        }
        else
        {
            Category category = (from ca in dc.Categories
                                              where ca.CategoryName.Equals(event_category)
                                              select ca).FirstOrDefault();

            IEnumerable<Int64> event_categories = ( from ev in dc.EventCategories
                                                    where ev.CategoryID == category.CategoryID
                                                    select ev.EventID);

            if (event_text != "")
            {
                IEnumerable<Int64> events = (from ev in dc.Events
                                             where event_categories.Contains(ev.EventID) &&
                                                   ev.Name.Contains(event_text)
                                             select ev.EventID);

                TopEvents.DataSource = events;
            }
            else
            {
                TopEvents.DataSource = event_categories;
            }
        }
        
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
