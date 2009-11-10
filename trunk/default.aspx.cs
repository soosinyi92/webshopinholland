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

public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        EventSummary1.FillEvent(7);
        EventSummary2.FillEvent(8);
        EventSummary3.FillEvent(9);
        EventSummary4.FillEvent(10);
        EventSummary5.FillEvent(11);
        EventSummary6.FillEvent(12);
        EventSummary7.FillEvent(13);
        EventSummary8.FillEvent(14);
        EventSummary9.FillEvent(15);
        EventSummary10.FillEvent(16);
    }
}
