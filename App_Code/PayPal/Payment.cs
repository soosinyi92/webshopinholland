using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Web;

using System.Text;
using System.Security.Cryptography;
using Pkcs = System.Security.Cryptography.Pkcs;
using X509 = System.Security.Cryptography.X509Certificates;
    //<!-- Paypal payment settings -->
    //<add key="PP_HostingPrefix" value="http://studentwebshop.2r.nl"/>
    //<add key="PP_Return" value="pp_return.aspx"/>
    //<add key="PP_Cancel" value="pp_cancel.aspx"/>
    //<add key="PP_MerchantUsername" value="info@institute5.nl"/>
    //<add key="PP_CertID" value="RZCHH977PLRNU"/>
    //<add key="PP_Currency" value="GBP"/>
    //<add key="PP_PaypalCertPath" value="/App_Code/PaymentHandlers/PayPal/paypal_cert_pem.txt" />
    //<add key="PP_SignerPfxPath" value="/App_Code/PaymentHandlers/PayPal/mycert.p12" />
    //<add key="PP_SignerPassword" value="qawsedrf"/>
    //<!-- End of paypal payment settings -->
namespace EventWebShop.Frontend.PaymentHandlers.PayPal
{
    public class Payment
    {
        
        private string PP_myHostingPrefix = ConfigurationManager.AppSettings["PP_HostingPrefix"];
        private string PP_returnURL = ConfigurationManager.AppSettings["PP_Return"];
        private string PP_cancelReturnURL = ConfigurationManager.AppSettings["PP_Cancel"];

        private string PP_MerchantUsername = ConfigurationManager.AppSettings["PP_MerchantUsername"];
        private string PP_signerPfxPassword = ConfigurationManager.AppSettings["PP_SignerPassword"]; // retrieve your password securely here

        private string paypalCertPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PP_PaypalCertPath"]);
        private string signerPfxPath = HttpContext.Current.Server.MapPath(ConfigurationManager.AppSettings["PP_SignerPfxPath"]);
        
        
        public Payment()
                { }
		private string getPPPaymentDataString(ShoppingCart shc) // will be replaced by getPPPaymentDataString(ShoppingCart shCart)
		{
			StringBuilder paymentData = new StringBuilder();
			//Add general PP variables
			//Cart Total: 
            paymentData.Append("cmd=_cart");
            paymentData.Append("\nupload=1");

            paymentData.Append("\nbusiness=" + ConfigurationManager.AppSettings["PP_MerchantUsername"]);
            paymentData.Append("\nreturn=" + PP_returnURL); //return url after payment
            paymentData.Append("\ncancel_return=" + PP_cancelReturnURL); //cancel url in case payment is interrupted
            //paymentData.Append("\nnotify_url=" + PP_ipnNotifyURL); //link of IPN processing handler
            paymentData.Append("\ncert_id=" + ConfigurationManager.AppSettings["PP_CertID"]);
			//paymentData.Append("\ninvoice=invoice_1"); //optional - Passthrough variable you can use to identify your invoice number for this purchase.
            paymentData.Append("\ncharset=UTF-8");
            
            //Shopping cart Data
            
            paymentData.Append("\ncurrency_code=" + ConfigurationManager.AppSettings["PP_Currency"]);
            paymentData.Append("\npaymentaction=sale"); //default is sale (allowed: authorization, order)

            paymentData.Append("\nhandling_cart=10"); // Shipping costs of the cart in Currency specified in the request
			paymentData.Append("\ntax_cart=" + Math.Round(shc.getTotalNetPrice()*(decimal)0.19,2).ToString()); // overwrites tax for individual items in Currency specified in the request
            //paymentData.Append("\ndiscount_amount_cart=0.20") //This variable overrides any individual itemdiscount_amount_x values, if present.

            //Prepopulating payer information
            paymentData.Append("\naddress_override=1"); //overwrite address in registered at paypal with the one provided at the webshop
            paymentData.Append("\naddress1=" + shc.shippingInfo.Address); //address-line 1
            paymentData.Append("\naddress2="); //address-line 2
			paymentData.Append("\ncity=" + shc.shippingInfo.City); //
            paymentData.Append("\ncountry=Nl");
			paymentData.Append("\nemail=" + shc.shippingInfo.Email );
			paymentData.Append("\nfirst_name=" + shc.shippingInfo.FirstName );
			paymentData.Append("\nlast_name=" + shc.shippingInfo.LastName);
            paymentData.Append("\nlc=gb"); //language code for displaying the paypal page

			//paymentData.Append("\nnight_phone_a=" + shc.shippingInfo.Phone );
            //paymentData.Append("\nnight_phone_b=263701066");

            //paymentData.Append("\nnight_phone_c=night_phone_c")
            // paymentData.Append("\nstate=Gelderland")
            paymentData.Append("\nzip=" + shc.shippingInfo.PostCode);
            // paymentData.Append("\n=")
			
			int i = 0;
			foreach(ShoppingCart.Item item in shc.getItems())
			{
				//Shipping --> Added as an item!!!!
				paymentData.Append("\nitem_name_" + i.ToString() + "=" + item.EventName); //name of the product
				paymentData.Append("\nitem_number_" + i.ToString() + "=" + item.EventId.ToString() ); //product id
				paymentData.Append("\nquantity_" + i.ToString() + "=" + item.Quantity ); //nr of ordered pieces per item
				paymentData.Append("\namount_" + i.ToString() + "=" + Math.Round(item.EventPrice,2).ToString()); //price per piece
				//paymentData.Append("\ntax_1=0.20");
				//paymentData.Append("\ndiscount_amount_1=0.20") // = NOT PER INDIVIDUAL ITEM! discount_amount_cart overwrites this if set 
				//paymentData.Append("\ndiscount_rate_1=20"); // PER INDIVIDUAL ITEM! in %. discount_rate_cart overwrites this if set
				//paymentData.Append("\non0_1=color"); //maximum of 7 option field names per item (0-6)
				//paymentData.Append("\nos0_1=brown"); // maximum of 7 option selection names per item (0-6). MAX 64 chars
				//paymentData.Append("\non1_1=size");
				//paymentData.Append("\nos1_1=xxl");
			
			
			}

			////Shipping --> Added as an item!!!!
			//paymentData.Append("\nitem_name_1=product1"); //name of the product
			//paymentData.Append("\nitem_number_1=nr_1"); //product id
			//paymentData.Append("\nquantity_1=2"); //nr of ordered pieces per item
			//paymentData.Append("\namount_1=1.00"); //price per piece
			//paymentData.Append("\ntax_1=0.20");
			////paymentData.Append("\ndiscount_amount_1=0.20") // = NOT PER INDIVIDUAL ITEM! discount_amount_cart overwrites this if set 
			//paymentData.Append("\ndiscount_rate_1=20"); // PER INDIVIDUAL ITEM! in %. discount_rate_cart overwrites this if set
			//paymentData.Append("\non0_1=color"); //maximum of 7 option field names per item (0-6)
			//paymentData.Append("\nos0_1=brown"); // maximum of 7 option selection names per item (0-6). MAX 64 chars
			//paymentData.Append("\non1_1=size");
			//paymentData.Append("\nos1_1=xxl");

			////Adding Items 
			//paymentData.Append("\nitem_name_2=Item_2");
			//paymentData.Append("\nitem_number_2=nr_2");
			//paymentData.Append("\nquantity_2=2");
			//paymentData.Append("\namount_2=2.00");
			//paymentData.Append("\ntax_2=0.20");
			////paymentData.Append("\ndiscount_amount_2=0.20") //= discount_amount_cart overwrites this if set 
			//paymentData.Append("\ndiscount_rate_2=10"); // PER INDIVIDUAL ITEM! in %. discount_rate_cart overwrites this if set

			return paymentData.ToString();
		}

		public string getPPEncryptedString(ShoppingCart shc)
		{


			string strPaymentData = getPPPaymentDataString(shc);
			ButtonEncryption ewp = new ButtonEncryption();
			ewp.LoadSignerCredential(signerPfxPath, PP_signerPfxPassword);
			ewp.RecipientPublicCertPath = paypalCertPath;
			ewp.Charset = "UTF-8";

			string encryptedResult = ewp.SignAndEncrypt(strPaymentData);
			return encryptedResult;
		}
	
	    private string getPPPaymentDataString(long _productID) // will be replaced by getPPPaymentDataString(ShoppingCart shCart)
	    {

	        decimal evNetPrice;
	        string evName;
	        long evID = -1;
	        decimal tax = 0;

	        WebshopDataContext dc = new WebshopDataContext();
            
	        Event prod = (from ev in dc.Events
	                         where ev.isMainEvent == true && ev.EventID == _productID 
	                         select ev).SingleOrDefault();
            
            
	        StringBuilder paymentData = new StringBuilder();

	        paymentData.Append("cmd=_xclick");
	        paymentData.Append("\nupload=1");

	        paymentData.Append("\nbusiness=" + ConfigurationManager.AppSettings["PP_MerchantUsername"]);
	        paymentData.Append("\nreturn=" + PP_myHostingPrefix + "/" + PP_cancelReturnURL);
	        paymentData.Append("\ncancel_return=" + PP_myHostingPrefix + "/" + PP_cancelReturnURL);
	        paymentData.Append("\ncert_id=" + ConfigurationManager.AppSettings["PP_CertID"]);

	        //Shopping cart Data
	        //paymentData.Append("\ninvoice=invoice_1"); //optional - Passthrough variable you can use to identify your invoice number for this purchase.
	        paymentData.Append("\ncurrency_code=" + ConfigurationManager.AppSettings["PP_Currency"]);
	        paymentData.Append("\npaymentaction=sale"); //default is sale (allowed: authorization, order)

	        ////Shipping --> Added as an item!!!!
	        //paymentData.Append("\nitem_name_1=Shipping Costs");
	        //paymentData.Append("\nitem_number_1=nr_1");
	        //paymentData.Append("\nquantity_1=1");
	        //paymentData.Append("\namount_1=1.00");

	        if (prod == null)
	        {
	            //No product was found --> handle error
	            throw new Exception("No Product was found!");
	        }
	        else if (prod.Name == null || prod.EventID == null || prod.Price == null)
	        {
	            //No sufficient info about the product --> handle Error
	            throw new Exception("Ambivalent product data was found!");
	        }
	        else
	        {

	            decimal taxRate = (decimal)0.19;
	            evNetPrice = prod.Price * 1 - taxRate;
	            evName = prod.Name;
	            evID = prod.EventID;
	            tax = evNetPrice * (decimal)0.19;
          
	        }
	        //Adding Items 
	        paymentData.Append("\nitem_name=" + evName);
	        paymentData.Append("\nitem_number=" + evID.ToString());
	        paymentData.Append("\nquantity=1");
	        paymentData.Append("\namount=1.00");
	        paymentData.Append("\ntax=0.11");
	        //paymentData.Append("\namount_1=" + evNetPrice.ToString());
	        //paymentData.Append("\ntax_1=" + tax.ToString());
            
	        return paymentData.ToString();
	    }
        
	    public string getPPEncryptedString(long longProdID)
	    {


	        string strPaymentData = getPPPaymentDataString(longProdID);
	        ButtonEncryption ewp = new ButtonEncryption();
	        ewp.LoadSignerCredential(signerPfxPath, PP_signerPfxPassword);
	        ewp.RecipientPublicCertPath = paypalCertPath;
	        ewp.Charset = "UTF-8";

	        string encryptedResult = ewp.SignAndEncrypt(strPaymentData);
	        return encryptedResult;
	    }
	}
    public class ButtonEncryption
    {
        private Encoding _encoding = Encoding.Default;
        private string _recipientPublicCertPath;

        private X509.X509Certificate2 _signerCert;
        private X509.X509Certificate2 _recipientCert;

        public ButtonEncryption()
        {
        }

        #region Properties

        /// <summary>
        /// Character encoding, e.g. UTF-8, Windows-1252
        /// </summary>
        public string Charset
        {
            get { return _encoding.WebName; }
            set
            {
                if (value != null && value != "")
                {
                    _encoding = Encoding.GetEncoding(value);
                }
            }
        }

        /// <summary>
        /// Path to the recipient's public certificate in PEM format
        /// </summary>
        public string RecipientPublicCertPath
        {
            get { return _recipientPublicCertPath; }
            set
            {
                _recipientPublicCertPath = value;
                _recipientCert = new X509.X509Certificate2(_recipientPublicCertPath);
            }
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="signerPfxCertPath">File path to the signer's public certificate plus private key in PKCS#12 format</param>
        /// <param name="signerPfxCertPassword">Password for signer's private key</param>
        public void LoadSignerCredential(string signerPfxCertPath, string signerPfxCertPassword)
        {
            _signerCert = new X509.X509Certificate2(signerPfxCertPath, signerPfxCertPassword);
        }

        /// <summary>
        /// Sign a message and encrypt it for the recipient.
        /// </summary>
        /// <param name="clearText">Name value pairs must be separated by \n (vbLf or Chr(10)), for example "cmd=_xclick\nbusiness=..."</param>
        /// <returns></returns>
        public string SignAndEncrypt(string clearText)
        {
            string result = null;

            byte[] messageBytes = _encoding.GetBytes(clearText);
            byte[] signedBytes = Sign(messageBytes);
            byte[] encryptedBytes = Envelope(signedBytes);

            result = Base64Encode(encryptedBytes);

            return result;
        }

        private byte[] Sign(byte[] messageBytes)
        {
            Pkcs.ContentInfo content = new Pkcs.ContentInfo(messageBytes);
            Pkcs.SignedCms signed = new Pkcs.SignedCms(content);
            Pkcs.CmsSigner signer = new Pkcs.CmsSigner(_signerCert);
            signed.ComputeSignature(signer);
            byte[] signedBytes = signed.Encode();

            return signedBytes;
        }

        private byte[] Envelope(byte[] contentBytes)
        {
            Pkcs.ContentInfo content = new Pkcs.ContentInfo(contentBytes);
            Pkcs.EnvelopedCms envMsg = new Pkcs.EnvelopedCms(content);
            Pkcs.CmsRecipient recipient = new Pkcs.CmsRecipient(Pkcs.SubjectIdentifierType.IssuerAndSerialNumber, _recipientCert);
            envMsg.Encrypt(recipient);
            byte[] encryptedBytes = envMsg.Encode();

            return encryptedBytes;
        }

        private string Base64Encode(byte[] encoded)
        {
            const string PKCS7_HEADER = "-----BEGIN PKCS7-----";
            const string PKCS7_FOOTER = "-----END PKCS7-----";

            string base64 = Convert.ToBase64String(encoded);
            StringBuilder formatted = new StringBuilder();
            formatted.Append(PKCS7_HEADER);
            formatted.Append(base64);
            formatted.Append(PKCS7_FOOTER);

            return formatted.ToString();
        }
    }
}