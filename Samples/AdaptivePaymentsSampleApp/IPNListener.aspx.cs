using System;
using System.Web;
using System.Collections.Specialized;
using log4net;
using PayPal;
using System.Collections.Generic;

namespace AdaptivePaymentsSampleApp
{
    public partial class IPNListener : System.Web.UI.Page
    {
        /// <summary>
        /// Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(IPNListener));

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                byte[] parameters = Request.BinaryRead(HttpContext.Current.Request.ContentLength);

                if (parameters.Length > 0)
                {
                    // Configuration map containing signature credentials and other required configuration.
                    // For a full list of configuration parameters refer at 
                    // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                    Dictionary<string, string> configurationMap = Configuration.GetConfig();

                    IPNMessage ipn = new IPNMessage(configurationMap, parameters);
                    bool isIpnValidated = ipn.Validate();
                    string transactionType = ipn.TransactionType;
                    NameValueCollection map = ipn.IpnMap;

                    logger.Info("----------Type-------------------" + this.GetType().Name + "\n"
                               + "*********IPN Name Value Pair****" + map + "\n"
                               + "#########IPN Transaction Type###" + transactionType + "\n"
                               + "=========IPN Validation=========" + isIpnValidated);
                }
            }
            catch (System.Exception ex)
            {
                logger.Debug("Exception in class " + this.GetType().Name + ": " + ex.Message);
                return;
            }
        }
    }
}
