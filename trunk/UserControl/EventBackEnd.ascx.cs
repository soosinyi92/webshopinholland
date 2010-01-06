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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated || !Page.User.IsInRole("Institute Administrator"))
        {
            return;
        }

        if (!Page.IsPostBack)
        {

            Add.Visible = false;
            Update.Visible = false;
            Delete.Visible = false;
            lblProgram.Visible = false;

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

            IEnumerable<Event> events = (from ev in dc.Events
                                         where eventIDs.Contains(ev.EventID) == true
                                         orderby ev.StsrtDateTime
                                         select ev).DefaultIfEmpty();

            var basicEvents = (from ev in events
                               orderby ev.StsrtDateTime
                               select new
                               {
                                   ev.Name,
                                   ev.StsrtDateTime,
                                   ev.EndDateTime,
                                   ev.Location,
                                   ev.Price
                               });

            events_list.Items.Add(new ListItem("New Event", "0"));
            ddltIsMainEvent.Items.Add(new ListItem("<Main Event>", "0"));

            int i = 1;

            foreach (var li in basicEvents)
            {
                events_list.Items.Add(new ListItem(li.Name, i.ToString()));
                ddltIsMainEvent.Items.Add(new ListItem(li.Name, i.ToString()));

                ++i;
            }


            events_list.DataBind();
        }
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
            txtName.Text = "";
            txtStartDateTime.Text = "";
            txtEndDateTime.Text = "";
            txtNoOfMin.Text = "";
            txtNoOfMax.Text = "";
            txtConditions.Text = "";
            txtLocation.Text = "";
            txtPrice.Text = "";
            txtDescription.Text = "";
            

            Add.Visible = true;
            Update.Visible = false;
            Delete.Visible = false;
            lblProgram.Visible = false;

            events_program.DataSource = null;
            events_program.DataBind();
        }
        else
        {
            WebshopDataContext dc = new WebshopDataContext();

            Event eventX = (from ev in dc.Events
                            where ev.Name.Equals(events_list.SelectedItem.Text)
                            select ev).FirstOrDefault();

            txtName.Text = eventX.Name.ToString();
            txtStartDateTime.Text = eventX.StsrtDateTime.ToString();
            txtEndDateTime.Text = eventX.EndDateTime.ToString();
            txtNoOfMin.Text = eventX.NOfMinimum.ToString();
            txtNoOfMax.Text = eventX.NOfMaximum.ToString();
            txtConditions.Text = eventX.Conditions.ToString();
            txtLocation.Text = eventX.Location.ToString();
            txtPrice.Text = eventX.Price.ToString();
            txtDescription.Text = eventX.Description.ToString();
            Event main_event = (from ev in dc.Events
                                where ev.EventID == eventX.ParentEventID
                                select ev).FirstOrDefault();
            
            if (main_event != null)
            {
                ddltIsMainEvent.SelectedItem.Selected = false;
                ddltIsMainEvent.Items.FindByText(main_event.Name).Selected = true;
            }
            else
            {
                ddltIsMainEvent.SelectedIndex = 0;
            }

            Update.Visible = true;
            Delete.Visible = true;
            lblProgram.Visible = true;
            Add.Visible = false;

            var events_programs = (from ev in dc.Events
                                                   where ev.ParentEventID == eventX.EventID
                                                   select new
                                                   {
                                                       ev.Name,
                                                       ev.StsrtDateTime,
                                                       ev.EndDateTime,
                                                       ev.Price
                                                   });

            events_program.DataSource = events_programs;
            events_program.DataBind();
        }
    }
    protected void Delete_Click(object sender, EventArgs e)
    {
        WebshopDataContext dc = new WebshopDataContext();

        Event event_x = ( from ev in dc.Events
                         where ev.Name.Equals(events_list.SelectedItem.Text)
                         select ev).FirstOrDefault();

        IEnumerable<EventOrganization> event_organizations = ( from ev in dc.EventOrganizations
                                       where ev.EventID == event_x.EventID
                                       select ev);

        IEnumerable<EventPlacesToMeet> event_places_to_meet = (from ev in dc.EventPlacesToMeets
                                                               where ev.EventID == event_x.EventID
                                                               select ev);

        dc.Events.DeleteOnSubmit(event_x);
        dc.EventOrganizations.DeleteAllOnSubmit(event_organizations);
        dc.EventPlacesToMeets.DeleteAllOnSubmit(event_places_to_meet);
        dc.SubmitChanges();
        Response.Redirect(Request.RawUrl);
    }
    protected void Add_Click(object sender, EventArgs e)
    {
        WebshopDataContext dc = new WebshopDataContext();

        aspnet_User user = (from ev in dc.aspnet_Users where ev.UserName.Equals(Page.User.Identity.Name) select ev).FirstOrDefault();

        OrganizationManagement orgman = (from ev in dc.OrganizationManagements
                                         where ev.UserID == user.UserId
                                         select ev).FirstOrDefault();

        Event event_x = new Event
        {
            Name = txtName.Text,
            StsrtDateTime = DateTime.Parse(txtEndDateTime.Text),
            EndDateTime = DateTime.Parse(txtEndDateTime.Text),
            NOfMinimum = int.Parse(txtNoOfMin.Text),
            NOfMaximum = int.Parse(txtNoOfMax.Text),
            Conditions = txtConditions.Text,
            Location = txtLocation.Text,
            Price = decimal.Parse(txtPrice.Text),
            Description = txtDescription.Text,
            //isMainEvent = btnIsMainEvent.Checked
        };

        if (ddltIsMainEvent.SelectedIndex == 0)
        {
            event_x.isMainEvent = true;
        }
        else
        {
            event_x.isMainEvent = false;
            event_x.ParentEventID = (from ev in dc.Events
                                     where ev.Name.Equals(ddltIsMainEvent.SelectedItem.Text)
                                     select ev.EventID).FirstOrDefault();
        }

        Image img = new Image
        {
            URL = txtPicture.Text
        };

        dc.Events.InsertOnSubmit(event_x);
        dc.Images.InsertOnSubmit(img);
        dc.SubmitChanges();
        
        EventImage eveimg = new EventImage
        {
            EventID = event_x.EventID,
            ImageID = img.ImageID
        };

        EventOrganization event_orgainzation = new EventOrganization
        {
            EventID = event_x.EventID,
            OrgainzationID = orgman.OrganizationID
        };

        dc.EventImages.InsertOnSubmit(eveimg);
        dc.EventOrganizations.InsertOnSubmit(event_orgainzation);
        dc.SubmitChanges();
        Response.Redirect(Request.RawUrl);
    }
    protected void Update_Click(object sender, EventArgs e)
    {
        WebshopDataContext dc = new WebshopDataContext();

        Event event_x = ( from ev in dc.Events
                          where ev.Name.Equals(ddltIsMainEvent.SelectedItem.Text)
                          select ev).FirstOrDefault();

            event_x.Name = txtName.Text;
            event_x.StsrtDateTime = DateTime.Parse(txtEndDateTime.Text);
            event_x.EndDateTime = DateTime.Parse(txtEndDateTime.Text);
            event_x.NOfMinimum = int.Parse(txtNoOfMin.Text);
            event_x.NOfMaximum = int.Parse(txtNoOfMax.Text);
            event_x.Conditions = txtConditions.Text;
            event_x.Location = txtLocation.Text;
            event_x.Price = decimal.Parse(txtPrice.Text);
            event_x.Description = txtDescription.Text;

            if (ddltIsMainEvent.SelectedIndex == 0)
            {
                event_x.isMainEvent = true;
            }
            else
            {
                event_x.isMainEvent = false;
                event_x.ParentEventID = (from ev in dc.Events
                                         where ev.Name.Equals(events_list.SelectedItem.Text)
                                         select ev.EventID).FirstOrDefault();
            }

            Image img = new Image
            {
                URL = txtPicture.Text
            };

            dc.Images.InsertOnSubmit(img);
            dc.SubmitChanges();

            EventImage eveimg = new EventImage
            {
                EventID = event_x.EventID,
                ImageID = img.ImageID
            };

            dc.EventImages.InsertOnSubmit(eveimg);

        dc.SubmitChanges();
    }
}