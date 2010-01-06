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

public partial class UserControl_EventBackEnd : System.Web.UI.UserControl
{
    protected IEnumerable<Event> events;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated || !Page.User.IsInRole("Institute Administrator"))
        {
            return;
        }

        //Participants.Visible = false;

        WebshopDataContext dc = new WebshopDataContext();

        aspnet_User user = (from ev in dc.aspnet_Users where ev.UserName.Equals(Page.User.Identity.Name) select ev).FirstOrDefault();

        // Event eventX = (from ev in dc.Events where ev.EventID == i select ev).FirstOrDefault();

        OrganizationManagement orgman = (from ev in dc.OrganizationManagements
                                         where ev.UserID == user.UserId
                                         select ev).FirstOrDefault();

        IEnumerable<EventOrganization> orgeve = (from ev in dc.EventOrganizations
                                     where ev.OrgainzationID == orgman.OrganizationID
                                     select ev).DefaultIfEmpty();

        List<long> eventIDs = new List<long>();

        foreach (EventOrganization iv in orgeve)
        {
            eventIDs.Add(iv.EventID);
        }
        
        events = (from ev in dc.Events
                                     where eventIDs.Contains(ev.EventID) == true
                                     orderby ev.StsrtDateTime
                                     select ev).DefaultIfEmpty();

        var basicEvents = (from ev in events
                           orderby ev.StsrtDateTime
                           select new {
                                            ev.Name,
                                            ev.StsrtDateTime,
                                            ev.EndDateTime,
                                            ev.Location,
                                            ev.Price
                                      });

        events_list.Items.Add(new ListItem("New Event", "0"));

        int i = 1;

        foreach (var li in basicEvents)
        {
            events_list.Items.Add(new ListItem(li.Name, i.ToString()));

            ++i;
        }

        
        events_list.DataBind();
    }

    protected void BasicEvents_SelectedIndexChanged(Object sender, EventArgs e)
    {
        //int a = BasicEvents.SelectedIndex;

        //var contact = (from ev in events
        //               orderby ev.StsrtDateTime
        //               select new {ev.
    }

    protected void events_list_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (events_list.SelectedItem.Text == "New Event")
        {
        }
        else
        {
            WebshopDataContext dc = new WebshopDataContext();

            Event eventX = (from ev in dc.Events
                            where ev.Name.Equals(events_list.SelectedItem.Text)
                            select ev).FirstOrDefault();


        }
    }
}