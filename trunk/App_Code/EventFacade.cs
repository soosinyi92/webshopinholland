using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for EventFacade
/// </summary>
public class EventFacade
{
	public static Event getEventById(Int64 eventId)
    {
        WebshopDataContext dc = new WebshopDataContext();
        return (from ev in dc.Events where ev.EventID == eventId select ev).FirstOrDefault();
    }

    public static Event getEventById(String eventId)
    {
        if (eventId == null)
        {
            return null;
        }

        Int64 i = new Int64();
        i = Int64.Parse(eventId);

        WebshopDataContext dc = new WebshopDataContext();
        return (from ev in dc.Events where ev.EventID == i select ev).FirstOrDefault();
    }
}
