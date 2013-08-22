using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Configuration;
using PayPal.AdaptivePayments.Model;
using PayPal.AdaptivePayments;

namespace AdaptivePaymentsSampleApp
{
    public partial class RequestResponse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string call = Context.Request.Params["ButtonAdaptivePayments"];

            switch (call)
            {
                case "SimplePayment":
                    SimplePayment(Context);
                    break;
                case "ParallelPayment":
                    ParallelPayment(Context);
                    break;
                case "ChainedPayment":
                    ChainedPayment(Context);
                    break;
                case "DelayedChainedPayment":
                    DelayedChainedPayment(Context);
                    break;
                case "DeferredPayment":
                    DeferredPayment(Context);
                    break;
                case "Preapproval":
                    Preapproval(Context);
                    break;
                case "PreapprovalPayment":
                    PreapprovalPayment(Context);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Handles Simple Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void SimplePayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();
            Receiver receiver1 = new Receiver();
            PayRequest request = new PayRequest();

            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            // (Required) Amount to be paid to the receiver
            if (parameters["amount"] != null && parameters["amount"].Trim() != string.Empty)
            {
                receiver1.amount = Convert.ToDecimal(parameters["amount"]);
            }

            // Receiver's email address. This address can be unregistered with
            // paypal.com. If so, a receiver cannot claim the payment until a PayPal
            // account is linked to the email address. The PayRequest must pass
            // either an email address or a phone number. Maximum length: 127 characters
            if (parameters["mail"] != null && parameters["mail"].Trim() != string.Empty)
            {
                receiver1.email = parameters["mail"];
            }

            receiverList.receiver.Add(receiver1);

            ReceiverList receiverlst = new ReceiverList(receiverList.receiver);
            request.receiverList = receiverlst;

            // (Optional) Sender's email address. Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = parameters["senderEmail"];
            }

            // The action for this request. Possible values are: PAY – Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE – Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY – For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            if (parameters["actionType"] != null && parameters["actionType"].Trim() != string.Empty)
            {
                request.actionType = parameters["actionType"];
            }
                       
            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }

            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }

            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }

            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }
                
            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);

                response = service.Pay(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;

            if (!response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILURE.ToString()) && !response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"] + "_ap-payment&paykey=" + response.payKey;

                // The pay key, which is a token you use in other Adaptive Payment APIs 
                // (such as the Refund Method) to identify this payment. 
                // The pay key is valid for 3 hours; the payment must be approved while the 
                // pay key is valid. 
                responseValues.Add("Pay Key", response.payKey);

                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment Execution Status", response.paymentExecStatus);

                if (response.defaultFundingPlan != null && response.defaultFundingPlan.senderFees != null)
                {
                    //Fees to be paid by the sender.
                    responseValues.Add("Sender Fees", response.defaultFundingPlan.senderFees.amount +
                                                response.defaultFundingPlan.senderFees.code);
                }
            }

            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());

            Display(contextHttp, "SimplePayment", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handles Parallel Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void ParallelPayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();

            PayRequest request = new PayRequest();
            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            Receiver receiver1 = new Receiver();

            if (parameters["amount1"] != null && parameters["amount1"].Trim() != string.Empty)
            {
                // (Required) Amount to be paid to the receiver
                receiver1.amount = Convert.ToDecimal(parameters["amount1"]);
            }

            if (parameters["mail1"] != null && parameters["mail1"].Trim() != string.Empty)
            {
                // Receiver's email address. This address can be unregistered with
                // paypal.com. If so, a receiver cannot claim the payment until a PayPal
                // account is linked to the email address. The PayRequest must pass
                // either an email address or a phone number. Maximum length: 127 characters
                receiver1.email = parameters["mail1"];
            }
            receiverList.receiver.Add(receiver1);

            Receiver receiver2 = new Receiver();

            if (parameters["amount2"] != null && parameters["amount2"].Trim() != string.Empty)
            {
                // (Required) Amount to be paid to the receiver
                receiver2.amount = Convert.ToDecimal(parameters["amount2"]);
            }

            if (parameters["mail2"] != null && parameters["mail2"].Trim() != string.Empty)
            {
                // Receiver's email address. This address can be unregistered with
                // paypal.com. If so, a receiver cannot claim the payment until a PayPal
                // account is linked to the email address. The PayRequest must pass
                // either an email address or a phone number. Maximum length: 127 characters
                receiver2.email = parameters["mail2"];
            }
            receiverList.receiver.Add(receiver2);

            ReceiverList receiverlst = new ReceiverList(receiverList.receiver);
            request.receiverList = receiverlst;

            // (Optional) Sender's email address. Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = parameters["senderEmail"];
            }

            // The action for this request. Possible values are: PAY – Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE – Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY – For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            if (parameters["actionType"] != null && parameters["actionType"].Trim() != string.Empty)
            {
                request.actionType = parameters["actionType"];
            }

            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }

            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }
            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }

            request.requestEnvelope = requestEnvelope;
            
            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }
         
            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);

                response = service.Pay(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;

            if (!response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILURE.ToString()) && !response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"] + "_ap-payment&paykey=" + response.payKey;
                // The pay key, which is a token you use in other Adaptive Payment APIs 
                // (such as the Refund Method) to identify this payment. 
                // The pay key is valid for 3 hours; the payment must be approved while the 
                // pay key is valid. 
                responseValues.Add("Pay Key", response.payKey);

                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment Execution Status", response.paymentExecStatus);

                if (response.defaultFundingPlan != null && response.defaultFundingPlan.senderFees != null)
                {
                    // Fees to be paid by the sender
                    responseValues.Add("Sender Fees", response.defaultFundingPlan.senderFees.amount + response.defaultFundingPlan.senderFees.code);
                }
            }

            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());

            Display(contextHttp, "ParallelPayment", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handles Chained Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void ChainedPayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();

            PayRequest request = new PayRequest();
            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            Receiver receiver1 = new Receiver();

            if (parameters["amount1"] != null && parameters["amount1"].Trim() != string.Empty)
            {
                // Required) Amount to be paid to the receiver
                receiver1.amount = Convert.ToDecimal(parameters["amount1"]);               
            }

            if (parameters["mail1"] != null && parameters["mail1"].Trim() != string.Empty)
            {
                // Receiver's email address. This address can be unregistered with
                // paypal.com. If so, a receiver cannot claim the payment until a PayPal
                // account is linked to the email address. The PayRequest must pass
                // either an email address or a phone number. Maximum length: 127 characters
                receiver1.email = parameters["mail1"];
            }

            if (parameters["primaryReceiver1"] != null && parameters["primaryReceiver1"].Trim() != string.Empty)
            {
                receiver1.primary = Convert.ToBoolean(parameters["primaryReceiver1"]);
            }

            receiverList.receiver.Add(receiver1);

            Receiver receiver2 = new Receiver();

            if (parameters["amount2"] != null && parameters["amount2"].Trim() != string.Empty)
            {
                // (Required) Amount to be paid to the receiver
                receiver2.amount = Convert.ToDecimal(parameters["amount2"]);
            }

            if (parameters["mail2"] != null && parameters["mail2"].Trim() != string.Empty)
            {
                // Receiver's email address. This address can be unregistered with
                // paypal.com. If so, a receiver cannot claim the payment until a PayPal
                // account is linked to the email address. The PayRequest must pass
                // either an email address or a phone number. Maximum length: 127 characters
                receiver2.email = parameters["mail2"];                
            }

            if (parameters["primaryReceiver2"] != null && parameters["primaryReceiver2"].Trim() != string.Empty)
            {
                receiver2.primary = Convert.ToBoolean(parameters["primaryReceiver2"]);
            }

            receiverList.receiver.Add(receiver2);

            ReceiverList receiverlst = new ReceiverList(receiverList.receiver);
            request.receiverList = receiverlst;

            // (Optional) Sender's email address. Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = parameters["senderEmail"];
            }

            // The action for this request. Possible values are: PAY – Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE – Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY – For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            if (parameters["actionType"] != null && parameters["actionType"].Trim() != string.Empty)
            {
                request.actionType = parameters["actionType"];
            }

            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }

            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }

            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }

            request.requestEnvelope = requestEnvelope;
            
            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)            
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }

            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);

                response = service.Pay(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;

            if (!response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILURE.ToString()) && !response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"] + "_ap-payment&paykey=" + response.payKey;

                // The pay key, which is a token you use in other Adaptive Payment APIs 
                // (such as the Refund Method) to identify this payment. 
                // The pay key is valid for 3 hours; the payment must be approved while the 
                // pay key is valid. 
                responseValues.Add("Pay Key", response.payKey);

                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment Execution Status", response.paymentExecStatus);

                if (response.defaultFundingPlan != null && response.defaultFundingPlan.senderFees != null)
                {
                    // Fees to be paid by the sender
                    responseValues.Add("Sender Fees", response.defaultFundingPlan.senderFees.amount + response.defaultFundingPlan.senderFees.code);
                }
            }

            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());

            Display(contextHttp, "ChainedPayment", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handles Delayed Chained Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void DelayedChainedPayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();

            PayRequest request = new PayRequest();
            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            Receiver receiver1 = new Receiver();

            if (parameters["amount1"] != null && parameters["amount1"].Trim() != string.Empty)
            {
                // Required) Amount to be paid to the receiver
                receiver1.amount = Convert.ToDecimal(parameters["amount1"]);
            }

            if (parameters["mail1"] != null && parameters["mail1"].Trim() != string.Empty)
            {
                // Receiver's email address. This address can be unregistered with
                // paypal.com. If so, a receiver cannot claim the payment until a PayPal
                // account is linked to the email address. The PayRequest must pass
                // either an email address or a phone number. Maximum length: 127 characters
                receiver1.email = parameters["mail1"];
            }

            if (parameters["primaryReceiver1"] != null && parameters["primaryReceiver1"].Trim() != string.Empty)
            {
                receiver1.primary = Convert.ToBoolean(parameters["primaryReceiver1"]);
            }

            receiverList.receiver.Add(receiver1);

            Receiver receiver2 = new Receiver();

            if (parameters["amount2"] != null && parameters["amount2"].Trim() != string.Empty)
            {
                // (Required) Amount to be paid to the receiver
                receiver2.amount = Convert.ToDecimal(parameters["amount2"]);
            }

            if (parameters["mail2"] != null && parameters["mail2"].Trim() != string.Empty)
            {
                // Receiver's email address. This address can be unregistered with
                // paypal.com. If so, a receiver cannot claim the payment until a PayPal
                // account is linked to the email address. The PayRequest must pass
                // either an email address or a phone number. Maximum length: 127 characters
                receiver2.email = parameters["mail2"];
            }

            if (parameters["primaryReceiver2"] != null && parameters["primaryReceiver2"].Trim() != string.Empty)
            {
                receiver2.primary = Convert.ToBoolean(parameters["primaryReceiver2"]);
            }

            receiverList.receiver.Add(receiver2);

            ReceiverList receiverlst = new ReceiverList(receiverList.receiver);
            request.receiverList = receiverlst;

            // (Optional) Sender's email address. Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = parameters["senderEmail"];
            }

            // The action for this request. Possible values are: PAY – Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE – Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY – For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            if (parameters["actionType"] != null && parameters["actionType"].Trim() != string.Empty)
            {
                request.actionType = parameters["actionType"];
            }

            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }

            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }

            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }

            request.requestEnvelope = requestEnvelope;

            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }

            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);

                response = service.Pay(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;

            if (!response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILURE.ToString()) && !response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"] + "_ap-payment&paykey=" + response.payKey;

                // The pay key, which is a token you use in other Adaptive Payment APIs 
                // (such as the Refund Method) to identify this payment. 
                // The pay key is valid for 3 hours; the payment must be approved while the 
                // pay key is valid. 
                responseValues.Add("Pay Key", response.payKey);

                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment Execution Status", response.paymentExecStatus);

                if (response.defaultFundingPlan != null && response.defaultFundingPlan.senderFees != null)
                {
                    //Fees to be paid by the sender.
                    responseValues.Add("Sender Fees", response.defaultFundingPlan.senderFees.amount + response.defaultFundingPlan.senderFees.code);
                }
            }

            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());

            Display(contextHttp, "ChainedPayment", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handles Deferred Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void DeferredPayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();
            PayRequest request = new PayRequest();
            Receiver rec = new Receiver();

            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            // (Required) Amount to be paid to the receiver
            if (parameters["amount"] != null && parameters["amount"].Trim() != string.Empty)
            {
                rec.amount = Convert.ToDecimal(parameters["amount"]);
            }
            
            // Receiver's email address. This address can be unregistered with
            // paypal.com. If so, a receiver cannot claim the payment until a PayPal
            // account is linked to the email address. The PayRequest must pass
            // either an email address or a phone number. Maximum length: 127 characters
            if (parameters["mail"] != null && parameters["mail"].Trim() != string.Empty)
            {
                rec.email = parameters["mail"];
            }

            receiverList.receiver.Add(rec);

            ReceiverList receiverlst = new ReceiverList(receiverList.receiver);
            request.receiverList = receiverlst;

            // (Optional) Sender's email address. Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = parameters["senderEmail"];
            }
            
            // The action for this request. Possible values are: PAY – Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE – Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY – For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            if (parameters["actionType"] != null && parameters["actionType"].Trim() != string.Empty)
            {
                request.actionType = parameters["actionType"];
            }
            
            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }

            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }

            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }

            request.requestEnvelope = requestEnvelope;
            
            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }

            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);

                response = service.Pay(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;

            if (!response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILURE.ToString()) && !response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"] + "_ap-payment&paykey=" + response.payKey;

                // The pay key, which is a token you use in other Adaptive Payment APIs 
                // (such as the Refund Method) to identify this payment. 
                // The pay key is valid for 3 hours; the payment must be approved while the 
                // pay key is valid. 
                responseValues.Add("Pay Key", response.payKey);

                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment Execution Status", response.paymentExecStatus);

                if (response.defaultFundingPlan != null && response.defaultFundingPlan.senderFees != null)
                {
                    //Fees to be paid by the sender.
                    responseValues.Add("Sender Fees", response.defaultFundingPlan.senderFees.amount + response.defaultFundingPlan.senderFees.code);
                }
            }

            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());

            Display(contextHttp, "DeferredPayment", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handles Preapproval API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void Preapproval(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            PreapprovalRequest request = new PreapprovalRequest();

            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            // (Optional) Sender's email address. Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = "jb-us-seller2@paypal.com";
            }

            // (Optional) The day of the month on which a monthly payment is to be made.
            // Allowable values are numbers between 0 and 31.
            // A number between 1 and 31 indicates the date of the month.
            // Specifying 0 indicates that payment can be made on any day of the month. 
            if (parameters["dateOfMonth"] != null && parameters["dateOfMonth"].Trim() != string.Empty)
            {
                request.dateOfMonth = Convert.ToInt32(parameters["dateOfMonth"]);
            }

            // (Optional) The day of the week that a weekly payment is to be made. Allowable values are: 
            // NO_DAY_SPECIFIED
            // SUNDAY
            // MONDAY
            // TUESDAY
            // WEDNESDAY
            // THURSDAY
            // FRIDAY
            // SATURDAY
            if (parameters["dayOfWeek"] != null && parameters["dayOfWeek"].Trim() != string.Empty)
            {
                request.dayOfWeek = (PayPal.AdaptivePayments.Model.DayOfWeek)
                        Enum.Parse(typeof(PayPal.AdaptivePayments.Model.DayOfWeek), parameters["dayOfWeek"]);
            }

            // (Optional) Whether to display the maximum total amount of this preapproval. It is one of the following values:
            // TRUE – Display the amount
            // FALSE – Do not display the amount (default)
            if (parameters["displayMaxTotalAmount"] != null && parameters["displayMaxTotalAmount"].Trim() != string.Empty)
            {
                request.displayMaxTotalAmount = Convert.ToBoolean(parameters["displayMaxTotalAmount"]);
            }

            // (Optional) The URL to which you want all IPN messages for this preapproval to be sent.
            // This URL supersedes the IPN notification URL in your profile.
            // Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }

            // (Optional) The preapproved maximum amount per payment.
            // It cannot exceed the preapproved maximum total amount of all payments. 
            if (parameters["maxAmountPerPayment"] != null && parameters["maxAmountPerPayment"].Trim() != string.Empty)
            {
                request.maxAmountPerPayment = Convert.ToDecimal(parameters["maxAmountPerPayment"]);
            }

            // (Optional) The preapproved maximum number of payments.
            // It cannot exceed the preapproved maximum total number of all payments. 
            if (parameters["maxNumberOfPayments"] != null && parameters["maxNumberOfPayments"].Trim() != string.Empty)
            {
                request.maxNumberOfPayments = Convert.ToInt32(parameters["maxNumberOfPayments"]);
            }
            
            // (Optional) The preapproved maximum number of all payments per period. 
            // You must specify a value unless you have specific permission from PayPal.
            if (parameters["maxNumberOfPaymentsPerPeriod"] != null && parameters["maxNumberOfPaymentsPerPeriod"].Trim() != string.Empty)
            {
                request.maxNumberOfPaymentsPerPeriod = Convert.ToInt32(parameters["maxNumberOfPaymentsPerPeriod"]);
            }

            // (Optional) The preapproved maximum total amount of all payments.
            // It cannot exceed $2,000 USD or its equivalent in other currencies.
            if (parameters["totalAmountOfAllPayments"] != null && parameters["totalAmountOfAllPayments"].Trim() != string.Empty)
            {
                request.maxTotalAmountOfAllPayments = Convert.ToDecimal(parameters["totalAmountOfAllPayments"]);
            }

            // (Optional) The payment period. It is one of the following values:
            // NO_PERIOD_SPECIFIED
            // DAILY – Each day
            // WEEKLY – Each week
            // BIWEEKLY – Every other week
            // SEMIMONTHLY – Twice a month
            // MONTHLY – Each month
            // ANNUALLY – Each year
            if (parameters["paymentPeriod"] != null && parameters["paymentPeriod"].Trim() != string.Empty)
            {
                request.paymentPeriod = parameters["paymentPeriod"];
            }

            // (Optional) Sender's email address. If not specified,
            // the email address of the sender who logs in to approve
            // the request becomes the email address associated with the preapproval key.
            // Maximum length: 127 characters
            if (parameters["senderEmail"] != null && parameters["senderEmail"].Trim() != string.Empty)
            {
                request.senderEmail = parameters["senderEmail"];
            }

            // The code for the currency in which the payment is made; 
            // you can specify only one currency, regardless of the number of receivers.
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }

            // URL to redirect the sender's browser to after canceling the preapproval 
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }
            
            // URL to redirect the sender's browser
            // to after the sender has logged into PayPal and confirmed the preapproval.
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }

            request.requestEnvelope = requestEnvelope;

            // First date for which the preapproval is valid. 
            // It cannot be before today's date or after the ending date.
            if (parameters["startingDate"] != null && parameters["startingDate"].Trim() != string.Empty)
            {
                request.startingDate = parameters["startingDate"];
            }

            // Last date for which the preapproval is valid. 
            // It cannot be later than one year from the starting date. 
            // Contact PayPal if you do not want to specify an ending date.
            if (parameters["endingDate"] != null && parameters["endingDate"].Trim() != string.Empty)
            {
                request.endingDate = parameters["endingDate"];
            }

            AdaptivePaymentsService service = null;
            PreapprovalResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.Preapproval(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;

            if (!response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILURE.ToString()) && !response.responseEnvelope.ack.ToString().Trim().ToUpper().Equals(AckCode.FAILUREWITHWARNING.ToString()))
            {
                // A preapproval key that identifies the preapproval requested.
                responseValues.Add("Preapproval Key", response.preapprovalKey);
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"] + "_ap-preapproval&preapprovalkey=" + response.preapprovalKey;
                Session["preapprovalKey"] = response.preapprovalKey;
            }

            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());

            Display(contextHttp, "Preapproval", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handles Preapproval Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void PreapprovalPayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            PayRequest request = new PayRequest();
            RequestEnvelope requestEnvelope = new RequestEnvelope("en_US");
            request.requestEnvelope = requestEnvelope;

            List<Receiver> receiverList = new List<Receiver>();
            Receiver sampleReceiver = new Receiver();

            // (Required) Amount to be paid to the receiver
            if (parameters["amount"] != null && parameters["amount"].Trim() != string.Empty)
            {
                sampleReceiver.amount = Convert.ToDecimal(parameters["amount"]);
            }           
            
            // Receiver's email address. This address can be unregistered with
            // paypal.com. If so, a receiver cannot claim the payment until a PayPal
            // account is linked to the email address. The PayRequest must pass
            // either an email address or a phone number. Maximum length: 127 characters
            if (parameters["mail"] != null && parameters["mail"].Trim() != string.Empty)
            {
                sampleReceiver.email = parameters["mail"];
            }   

            receiverList.Add(sampleReceiver);

            ReceiverList receiverlst = new ReceiverList(receiverList);
            request.receiverList = receiverlst;

            // Preapproval key for the approval set up between you and the sender
            if (parameters["preapprovalKey"] != null && parameters["preapprovalKey"].Trim() != string.Empty)
            {
                request.preapprovalKey = parameters["preapprovalKey"];
            } 
                       
            // The action for this request. Possible values are: PAY – Use this
            // option if you are not using the Pay request in combination with
            // ExecutePayment. CREATE – Use this option to set up the payment
            // instructions with SetPaymentOptions and then execute the payment at a
            // later time with the ExecutePayment. PAY_PRIMARY – For chained
            // payments only, specify this value to delay payments to the secondary
            // receivers; only the payment to the primary receiver is processed.
            if (parameters["actionType"] != null && parameters["actionType"].Trim() != string.Empty)
            {
                request.actionType = parameters["actionType"];
            }

            // URL to redirect the sender's browser to after canceling the approval
            // for a payment; it is always required but only used for payments that
            // require approval (explicit payments)            
            if (parameters["cancelURL"] != null && parameters["cancelURL"].Trim() != string.Empty)
            {
                request.cancelUrl = parameters["cancelURL"];
            }
            
            // The code for the currency in which the payment is made; you can
            // specify only one currency, regardless of the number of receivers
            if (parameters["currencyCode"] != null && parameters["currencyCode"].Trim() != string.Empty)
            {
                request.currencyCode = parameters["currencyCode"];
            }
               
            // URL to redirect the sender's browser to after the sender has logged
            // into PayPal and approved a payment; it is always required but only
            // used if a payment requires explicit approval
            if (parameters["returnURL"] != null && parameters["returnURL"].Trim() != string.Empty)
            {
                request.returnUrl = parameters["returnURL"];
            }
            
            // (Optional) The URL to which you want all IPN messages for this
            // payment to be sent. Maximum length: 1024 characters
            if (parameters["ipnNotificationURL"] != null && parameters["ipnNotificationURL"].Trim() != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationURL"];
            }
           
            AdaptivePaymentsService service = null;
            PayResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.Pay(request);
            }
            catch (System.Exception ex)
            {
                contextHttp.Response.Write(ex.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString().Trim().ToUpper());
   
            Display(contextHttp, "PreapprovalPayment", "AdaptivePayments", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        private void Display(HttpContext contextHttp, string method, string api, Dictionary<string, string> responseValues, string requestPayload, string responsePayload, List<ErrorData> errorMessages, string redirectUrl)
        {
            titleName.Text = "PayPal Adaptive Payments - " + api;
            LabelName.Text = api;

            GridViewResponseValues.DataSource = responseValues;
            GridViewResponseValues.DataBind();
            if (errorMessages != null && errorMessages.Count > 0)
            {
                RepeaterError.DataSource = errorMessages;
                RepeaterError.DataBind();
                GridViewResponseValues.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 0, 0);                
            }
            else
            {
                if (responseValues["Acknowledgement"].Equals(AckCode.SUCCESS.ToString()))
                {
                    GridViewResponseValues.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(0, 200, 100);
                }
                else
                {
                    GridViewResponseValues.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                }
                if (redirectUrl != null)
                {
                    LabelWebFlow.Text = "This API has Web Flow to redirect the user to complete the API call, please click the hyperlink to redirect the user to ";
                    HyperLinkWebFlow.Text = redirectUrl;
                    HyperLinkWebFlow.NavigateUrl = redirectUrl;
                    LabelWebFlowSuffix.Text = ".<br/><br/>";
                }
            }

            requestPayload = HttpUtility.UrlDecode(requestPayload);
            responsePayload = HttpUtility.UrlDecode(responsePayload);

            TextBoxRequest.Text = requestPayload;            
            TextBoxResponse.Text = responsePayload;            
        }
    }
}