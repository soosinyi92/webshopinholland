using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EventWebShop.Frontend.PaymentHandlers.PayPal;
public partial class GoToPaypal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
            String eventID = Request.QueryString["EventID"];

            if (eventID == null)
            {
                return;
            }

            Int64 i = new Int64();
            i = Int64.Parse(eventID);

			//Payment pp_payment = new Payment();
			//string pp_encString = pp_payment.getPPEncryptedString(i);

			//encrypted.Value = pp_encString;


			string breakhere = "";
        
        //}
    }
}
