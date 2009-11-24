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
            //Payment pp_payment = new Payment();
            //string pp_encString = pp_payment.getPPEncryptedString(m_eventID);
            //encrypted.Value = pp_encString;
            //ltlEncrypted.Text = "<input ID='encrypted' type='hidden' name='encrypted' value='" + pp_encString + "'/>";
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
    protected void btnPurchase_Click(object sender, EventArgs e)
    {
	    
        Payment pp_payment = new Payment();
        string pp_encString = pp_payment.getPPEncryptedString(m_eventID);
        
        RemotePost myremotepost = new RemotePost();
        myremotepost.Url = ConfigurationManager.AppSettings["PP_SubmitUrl"];
        myremotepost.Add("encrypted","pp_encString");
        myremotepost.Add("cmd","_s-xclick");
        myremotepost.Post() ;
   

    //    //encrypted.Value = pp_encString;

    //    ASCIIEncoding encoding=new ASCIIEncoding();
    //    string postData=pp_encString;

    //    //
    //    //////postData += ("&username="+strName);
    //    ////byte[]  data = encoding.GetBytes(postData);
    //    byte[]  data = encoding.GetBytes(postData);
    //    Page.Request.
    //    //WebClient myWebClient = new WebClient();
    //    //myWebClient.UploadData(ConfigurationManager.AppSettings["PP_SubmitUrl"], data);


    //    //// Prepare web request...
    //    HttpWebRequest myRequest =
    //      (HttpWebRequest)WebRequest.Create(ConfigurationManager.AppSettings["PP_SubmitUrl"]);
    //    myRequest.Method = "POST";
    //    myRequest.ContentType = "application/x-www-form-urlencoded";
    //    myRequest.ContentLength = data.Length;
    //    Stream newStream = myRequest.GetRequestStream();
    //    // Send the data.
    //    newStream.Write(data, 0, data.Length);
    //    newStream.Close();
    //    //myRequest.AllowAutoRedirect;

    //    Response.Redirect(ConfigurationManager.AppSettings["PP_SubmitUrl"] + "?cmd=_s-xclick&encrypted=" + postData);
    }
    protected void btnPurchase_Click1(object sender, EventArgs e)
    {

    }
    protected void btnAddToCart_Click(object sender, EventArgs e)
    {
        Event eventX = EventFacade.getEventById(Request.QueryString["EventID"]);

        if (eventX == null)
        {
            return;
        }
        Profile.User.ShoppingCart.addOrUpdateItem(eventX.EventID, eventX.Name, eventX.Price, 1);
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
