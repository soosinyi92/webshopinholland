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

// PayPal
using EventWebShop.Frontend.PaymentHandlers.PayPal;
using System.Text;
using System.Net;
using System.IO;

public partial class UserControl_EventDetail : System.Web.UI.UserControl
{
    private Int64 m_eventID;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.User.Identity.IsAuthenticated || !Page.User.IsInRole("User"))
        {
            btnInterested.Visible = false;
        }

        String eventID = Request.QueryString["EventID"];

            if (eventID == null)
            {
                return;
            }

            Int64 i = new Int64();
            i = Int64.Parse(eventID);

            m_eventID = i;

        if (!IsPostBack)
        {
            

            WebshopDataContext dc = new WebshopDataContext();

            Event eventX = (from ev in dc.Events where ev.EventID == i select ev).FirstOrDefault();

            if (eventX == null)
            {
                return;
            }

            lblEventStart.Text = eventX.Name;
            
            lblStartTime.Text = eventX.StsrtDateTime.ToString();
            lblEndTime.Text = eventX.EndDateTime.ToString(); ;
            lblLocation.Text = eventX.Location;
            lblPrice.Text = eventX.Price.ToString();

            IEnumerable<EventOrganization> organizations = (from o in dc.EventOrganizations
                                                  join ev in dc.Events on o.EventID equals ev.EventID
                                                  where ev.EventID == i
                                                  orderby ev.EventID
                                                  select o);

            IEnumerable<EventOrganizer> organizers = (from o in dc.EventOrganizers
                                                         join ev in dc.Events on o.EventID equals ev.EventID
                                                         join user in dc.aspnet_Users on o.UserID equals user.UserId
                                                         where o.EventID == i
                                                         orderby o.EventID
                                                         select o);

            foreach (EventOrganizer organizer in organizers)
            {
                lblOrganizer.Text += organizer.aspnet_User.UserName + "<br />";
            }

            foreach (EventOrganization organization in organizations)
            {
                lblOrganization.Text += organization.Organization.Name + "\n";
            }

            lblDescription.Text = eventX.Description;
            lblConditions.Text = eventX.Conditions;

            //Payment pp_payment = new Payment();
            //string pp_encString = pp_payment.getPPEncryptedString(m_eventID);
            //encrypted.Value = pp_encString;
            //ltlEncrypted.Text = "<input ID='encrypted' type='hidden' name='encrypted' value='" + pp_encString + "'/>";
        }
    }

    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        Event eventX = EventFacade.getEventById(Request.QueryString["EventID"]);

        if (eventX == null)
        {
            return;
        }
        Profile.ShoppingCart.addItem(eventX.EventID, eventX.Name, eventX.Price, 1);
    }

    protected void btnInterested_Click(object sender, EventArgs e)
    {
        if (!Page.User.Identity.IsAuthenticated)
        {
            Response.Redirect("./login.aspx");
        }
        WebshopDataContext dc = new WebshopDataContext();
        aspnet_User user = (from ev in dc.aspnet_Users where ev.UserName.Equals(Page.User.Identity.Name) select ev).FirstOrDefault();
        ListsOfParticipant lists = (from ev in dc.ListsOfParticipants where ev.EventID == m_eventID && ev.UserID == user.UserId select ev).FirstOrDefault();

        if (lists == null)
        {
            ListsOfParticipant newLists = new ListsOfParticipant
            {
                UserID = user.UserId,
                EventID = m_eventID,
                Interested = true
            };

            dc.ListsOfParticipants.InsertOnSubmit(newLists);
            dc.SubmitChanges();
            dc.Dispose();
        }
        else if (lists.Interested == false)
        {
            //ListsOfParticipant newLists = new ListsOfParticipant
            //{
            //    lists.Interested = true
            //};
            lists.Interested = true;

            dc.ListsOfParticipants.Attach(lists, true);
            dc.SubmitChanges();
            
            
            dc.Dispose();
        }
    }
}
public class RemotePost
{
    private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();
    public string Url = "";
    public string Method = "post";
    public string FormName = "form1";
    public void Add(string name, string value)
    {
        Inputs.Add(name, value);
    }
    public void Post()
    {
        System.Web.HttpContext.Current.Response.Clear();
        System.Web.HttpContext.Current.Response.Write("");
        System.Web.HttpContext.Current.Response.Write(string.Format("",FormName));
        System.Web.HttpContext.Current.Response.Write(string.Format("", FormName, Method, Url));
        for(int i=0;i< Inputs.Keys.Count;i++)
        {
        System.Web.HttpContext.Current.Response.Write(string.Format("",Inputs.Keys[i],Inputs[Inputs.Keys[i]]));
        }
        System.Web.HttpContext.Current.Response.Write("");
        System.Web.HttpContext.Current.Response.Write("");
        System.Web.HttpContext.Current.Response.End();
    }
}
