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