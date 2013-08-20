using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using PayPal.AdaptivePayments;
using PayPal.AdaptivePayments.Model;

namespace AdaptivePaymentsSampleApp
{
    /// <summary>
    /// Summary description for codebehindclassname
    /// </summary>
    public class AdaptivePaymentsHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext contextHttp)
        {
            contextHttp.Response.ContentType = "text/html";
            string call = contextHttp.Request.Params["AdaptivePaymentsBtn"];

            switch (call)
            {
                case "Pay":
                    Pay(contextHttp);
                    break;
                case "PaymentDetails":
                    PaymentDetails(contextHttp);
                    break;
                case "Preapproval":
                    Preapproval(contextHttp);
                    break;
                case "PreapprovalDetails":
                    PreapprovalDetails(contextHttp);
                    break;
                case "CancelPreapproval":
                    CancelPreapproval(contextHttp);
                    break;
                case "ConfirmPreapproval":
                    ConfirmPreapproval(contextHttp);
                    break;
                case "Refund":
                    Refund(contextHttp);
                    break;
                case "ConvertCurrency":
                    ConvertCurrency(contextHttp);
                    break;
                case "GetAllowedFundingSources":
                    GetAllowedFundingSources(contextHttp);
                    break;
                case "GetFundingPlans":
                    GetFundingPlans(contextHttp);
                    break;
                case "GetShippingAddresses":
                    GetShippingAddresses(contextHttp);
                    break;
                case "GetAvailableShippingAddresses":
                    GetAvailableShippingAddresses(contextHttp);
                    break;
                case "SetPaymentOptions":
                    SetPaymentOptions(contextHttp);
                    break;
                case "GetPaymentOptions":
                    GetPaymentOptions(contextHttp);
                    break;
                case "ExecutePayment":
                    ExecutePayment(contextHttp);
                    break;
                case "GetUserLimits":
                    GetUserLimits(contextHttp);
                    break;                    
                default:
                    break;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// Handle Pay API calls
        /// </summary>
        /// <param name="contextHttp"></param>
        private void Pay(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();
            //(Required) Amount to be paid to the receiver
            string[] amt = contextHttp.Request.Form.GetValues("receiverAmount");
            // Receiver's email address. This address can be unregistered with paypal.com.
		    // If so, a receiver cannot claim the payment until a PayPal account is linked
		    // to the email address. The PayRequest must pass either an email address or a phone number. 
		    // Maximum length: 127 characters 
            string[] receiverEmail = contextHttp.Request.Form.GetValues("receiverEmail");
            //Telephone country code 
            string[] phoneCountry = contextHttp.Request.Form.GetValues("phoneCountry");
            // A type to specify the receiver's phone number.
		    // The PayRequest must pass either an email address or a phone number as the payment receiver. 
            string[] phoneNumber = contextHttp.Request.Form.GetValues("phoneNumber");
            //Telephone extension
            string[] phoneExtn = contextHttp.Request.Form.GetValues("phoneExtn");
            // (Optional) Whether this receiver is the primary receiver, 
		    // which makes the payment a chained payment.You can specify at most one primary receiver. 
		    // Omit this field for simple and parallel payments. Allowable values are:
		    //  true – Primary receiver
		    //  false – Secondary receiver (default)
		    string[] primaryReceiver = contextHttp.Request.Form.GetValues("primaryReceiver");
            //  (Optional) The invoice number for the payment. 
            //  This data in this field shows on the Transaction Details report. 
            //  Maximum length: 127 characters
            string[] invoiceId = contextHttp.Request.Form.GetValues("invoiceId");
            
		    // (Optional) The transaction type for the payment. Allowable values are:
		    // GOODS – This is a payment for non-digital goods
		    // SERVICE – This is a payment for services (default)
		    // PERSONAL – This is a person-to-person payment
		    // CASHADVANCE – This is a person-to-person payment for a cash advance
		    // DIGITALGOODS – This is a payment for digital goods
		    // BANK_MANAGED_WITHDRAWAL – This is a person-to-person payment for bank withdrawals, available only with special permission.
		    string[] paymentType = contextHttp.Request.Form.GetValues("paymentType");
            //(Optional) The transaction subtype for the payment. 
            string[] paymentSubType = contextHttp.Request.Form.GetValues("paymentSubType");
            for (int i = 0; i < amt.Length; i++)
            {
                Receiver rec = new Receiver(Convert.ToDecimal(amt[i]));
                if(receiverEmail[i] != string.Empty)
                    rec.email = receiverEmail[i];
                if (phoneCountry[i] != string.Empty && phoneNumber[i] != string.Empty)
                {
                    rec.phone = new PhoneNumberType(phoneCountry[i], phoneNumber[i]);
                    if (phoneExtn[i] != string.Empty)
                    {
                        rec.phone.extension = phoneExtn[i];
                    }
                }
                if (primaryReceiver[i] != string.Empty)
                    rec.primary = Convert.ToBoolean(primaryReceiver[i]);
                if (invoiceId[i] != string.Empty)
                    rec.invoiceId = invoiceId[i];
                if (paymentType[i] != string.Empty)
                    rec.paymentType = paymentType[i];
                if (paymentSubType[i] != string.Empty)
                    rec.paymentSubType = paymentSubType[i];
                receiverList.receiver.Add(rec);
            }  
          
            PayRequest request = new PayRequest(new RequestEnvelope("en_US"), parameters["actionType"], 
                                parameters["cancelUrl"], parameters["currencyCode"], 
                                receiverList, parameters["returnUrl"]);

            //Fix for release
            if (parameters["ipnNotificationUrl"] != string.Empty)
            {
                request.ipnNotificationUrl = parameters["ipnNotificationUrl"];
            }
            //(Optional) A note associated with the payment (text, not HTML). 
            // Maximum length: 1000 characters, including newline characters 
            if (parameters["memo"] != string.Empty)
            {
                request.memo = parameters["memo"];
            }
            //The sender's personal identification number, which was specified 
            //when the sender signed up for a preapproval. 
            if (parameters["pin"] != string.Empty)
            {
                request.pin = parameters["pin"];
            }
            // (Optional) The key associated with a preapproval for this payment. 
            // The preapproval key is required if this is a preapproved payment.
            // Note: The Preapproval API is unavailable to API callers with Standard permission levels.
            if (parameters["preapprovalKey"] != string.Empty)
            {
                request.preapprovalKey = parameters["preapprovalKey"];
            }

            // set optional parameters
            //(Optional) Whether to reverse parallel payments if an error occurs with a payment. 
            //Allowable values are:
            //true – Each parallel payment is reversed if an error occurs
            //false – Only incomplete payments are reversed (default)
            if (parameters["reverseAllParallelPaymentsOnError"] != string.Empty)
                request.reverseAllParallelPaymentsOnError = 
                 Convert.ToBoolean(parameters["reverseAllParallelPaymentsOnError"]);

            // Sender's email address 
            if (parameters["senderEmail"] != string.Empty)
                request.senderEmail = parameters["senderEmail"];

            //(Optional) A unique ID that you specify to track the payment.
            //Note: You are responsible for ensuring that the ID is unique.
            //Maximum length: 127 characters 
            if (parameters["trackingId"] != string.Empty)
                request.trackingId = parameters["trackingId"];

            // (Optional) Specifies a list of allowed funding types for the payment. 
            // This is a list of funding selections that can be combined in any order 
            // to allow payments to use the indicated funding type. If this Parameter is omitted, 
            // the payment can be funded by any funding type that is supported for Adaptive Payments.
            // Note: FundingConstraint is unavailable to API callers with standard permission levels; 
            // for more information, refer to the section Adaptive Payments Permission Levels.
            if (parameters["fundingConstraint"] != string.Empty)
            {
                request.fundingConstraint = new FundingConstraint();
                request.fundingConstraint.allowedFundingType = new FundingTypeList();
                request.fundingConstraint.allowedFundingType.fundingTypeInfo.Add(
                    new FundingTypeInfo(parameters["fundingConstraint"]));
            }

            if (parameters["emailIdentifier"] != string.Empty
                || (parameters["senderPhoneCountry"] != string.Empty && parameters["senderPhoneNumber"] != string.Empty)
                || parameters["useCredentials"] != string.Empty)
            {
                request.sender = new SenderIdentifier();
                //  (Optional) Sender's email address. Maximum length: 127 characters 
                if (parameters["emailIdentifier"] != string.Empty)
                    request.sender.email = parameters["emailIdentifier"];

                 // Sender Telephone country code
                 // Sender Telephone number
                 // Sender Telephone extension
                if (parameters["senderPhoneCountry"] != string.Empty && parameters["senderPhoneNumber"] != string.Empty)
                {
                    request.sender.phone = new PhoneNumberType(parameters["senderPhoneCountry"], parameters["senderPhoneNumber"]);
                    if (parameters["senderPhoneExtn"] != string.Empty)
                        request.sender.phone.extension = parameters["senderPhoneExtn"];
                }

                // (Optional) If true, use credentials to identify the sender; default is false. 
                if (parameters["useCredentials"] != string.Empty)
                    request.sender.useCredentials = Convert.ToBoolean(parameters["useCredentials"]);
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
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if ( !(response.responseEnvelope.ack == AckCode.FAILURE) && 
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING) )
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"]
                                     + "_ap-payment&paykey=" + response.payKey;
                // The pay key, which is a token you use in other Adaptive Payment APIs 
				// (such as the Refund Method) to identify this payment. 
				// The pay key is valid for 3 hours; the payment must be approved while the 
				// pay key is valid. 
				responseValues.Add("Pay key", response.payKey);
                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment execution status", response.paymentExecStatus);
                if (response.defaultFundingPlan != null && response.defaultFundingPlan.senderFees != null)
                {
                    //Fees to be paid by the sender.
                    responseValues.Add("Sender fees", response.defaultFundingPlan.senderFees.amount +
                                                response.defaultFundingPlan.senderFees.code);
                }

                
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }
            Display(contextHttp, "Pay", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);            
        }

        /// <summary>
        /// Handle PaymentDetails API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void PaymentDetails(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            PaymentDetailsRequest request = new PaymentDetailsRequest(new RequestEnvelope("en_US")); 
            // set optional parameters
            //(Optional) The pay key that identifies the payment for which 
            // you want to retrieve details. This is the pay key returned in the PayResponse message. 
            if (parameters["payKey"] != string.Empty)
                request.payKey = parameters["payKey"];
            // (Optional) The PayPal transaction ID associated with the payment. 
            // The IPN message associated with the payment contains the transaction ID. 
            if (parameters["transactionId"] != string.Empty)
                request.transactionId = parameters["transactionId"];
            // (Optional) The tracking ID that was specified for this payment 
            // in the PayRequest message. Maximum length: 127 characters 
            if (parameters["trackingId"] != string.Empty)
                request.trackingId = parameters["trackingId"];
          
            AdaptivePaymentsService service = null;
            PaymentDetailsResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.PaymentDetails(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //(Optional) The pay key that identifies the payment 
                responseValues.Add("Pay key", response.payKey);
                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                responseValues.Add("Payment execution status", response.status);

                // The sender's email address. 
                responseValues.Add("Sender email", response.senderEmail);

                //Acknowledgement code. It is one of the following values:
                // Success – The operation completed successfully.
                // Failure – The operation failed.
                // SuccessWithWarning – The operation completed successfully; however, there is a warning message.
                // FailureWithWarning – The operation failed with a warning message.
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());

                // Whether the Pay request is set up to create a payment request with the SetPaymentOptions 
                // request, and then fulfill the payment with the ExecutePayment request. 
                // Possible values are:
                // PAY – Use this option if you are not using the Pay request in combination with ExecutePayment.
                // CREATE – Use this option to set up the payment instructions with SetPaymentOptions and then execute the payment at a later time with the ExecutePayment.
                // PAY_PRIMARY – For chained payments only, specify this value to delay payments to the secondary receivers; only the payment to the primary receiver is processed.
                responseValues.Add("Action Type", response.actionType);
            }
            Display(contextHttp, "PaymentDetails", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle Preapproval API
        /// </summary>
        /// <param name="contextHttp"></param>
        private void Preapproval(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // cancel url : URL to redirect the sender's browser to after canceling the preapproval 
            // currency code : The code for the currency in which the payment is made; you can specify only one currency, regardless of the number of receivers 
            // return url : URL to redirect the sender's browser to after the sender has logged into PayPal and confirmed the preapproval 
            // starting date : First date for which the preapproval is valid. It cannot be before today's date or after the ending date. 
            PreapprovalRequest request = new PreapprovalRequest(new RequestEnvelope("en_US"), parameters["cancelUrl"], 
                    parameters["currencyCode"], parameters["returnUrl"], parameters["startingDate"]);
            
            // (Optional) The day of the month on which a monthly payment is to be made. 
            // Allowable values are numbers between 0 and 31. A number between 1 and 31 
            // indicates the date of the month. Specifying 0 indicates that payment can be 
            // made on any day of the month. 
            if(parameters["dateOfMonth"] != string.Empty) 
            {
	            request.dateOfMonth = Convert.ToInt32(parameters["dateOfMonth"]);
            }

            // (Optional) The day of the week that a weekly payment is to be made. 
            // Allowable values are:
            //   NO_DAY_SPECIFIED
            //   SUNDAY
            //   MONDAY
            //   TUESDAY
            //   WEDNESDAY
            //   THURSDAY
            //   FRIDAY
            //   SATURDAY

            if(parameters["dayOfWeek"] != string.Empty && parameters["dayOfWeek"] != string.Empty) 
            {
                request.dayOfWeek = (PayPal.AdaptivePayments.Model.DayOfWeek)
                        Enum.Parse(typeof(PayPal.AdaptivePayments.Model.DayOfWeek), parameters["dayOfWeek"]);
            }

            //(Optional) The day of the month on which a monthly payment is to be made. 
            // Allowable values are numbers between 0 and 31. A number between 1 and 31 
            // indicates the date of the month. Specifying 0 indicates that payment 
            // can be made on any day of the month. 
            if(parameters["dateOfMonth"] != string.Empty) 
            {
	            request.dateOfMonth = Convert.ToInt32(parameters["dateOfMonth"]);
            }

            // xs:dateTime (Optional) Last date for which the preapproval is valid. 
            // It cannot be later than one year from the starting date.
            // Note: You must specify a value unless you have specific permission 
            // from PayPal to omit this value. 
            if(parameters["endingDate"] != string.Empty) 
            {
	            request.endingDate = parameters["endingDate"];
            }

            // (Optional) The preapproved maximum amount per payment. 
            // It cannot exceed the preapproved maximum total amount of all payments. 
            if(parameters["maxAmountPerPayment"] != string.Empty) 
            {
	            request.maxAmountPerPayment = Convert.ToDecimal(parameters["maxAmountPerPayment"]);
            }

            // (Optional) The preapproved maximum number of payments. 
            // It cannot exceed the preapproved maximum total number of all payments. 
            if(parameters["maxNumberOfPayments"] != string.Empty ) 
            {
	            request.maxNumberOfPayments = Convert.ToInt32(parameters["maxNumberOfPayments"]);
            }

            //(Optional) The preapproved maximum number of all payments per period. 
            // You must specify a value unless you have specific permission from PayPal. 
            if(parameters["maxNumberOfPaymentsPerPeriod"] != string.Empty) 
            {
	            request.maxNumberOfPaymentsPerPeriod = Convert.ToInt32(parameters["maxNumberOfPaymentsPerPeriod"]);
            }

            // The preapproved maximum total amount of all payments. 
            // It cannot exceed $2,000 USD or its equivalent in other currencies. 
            // Contact PayPal if you do not want to specify a maximum amount. 
            if(parameters["maxTotalAmountOfAllPayments"] != string.Empty) 
            {
	            request.maxTotalAmountOfAllPayments = Convert.ToDecimal(parameters["maxTotalAmountOfAllPayments"]);
            }

            //(Optional) The payment period. It is one of the following values:
            //    NO_PERIOD_SPECIFIED
            //    DAILY – Each day
            //    WEEKLY – Each week
            //    BIWEEKLY – Every other week
            //    SEMIMONTHLY – Twice a month
            //    MONTHLY – Each month
            //    ANNUALLY – Each year
            if(parameters["paymentPeriod"] != string.Empty && parameters["paymentPeriod"] != string.Empty) 
            {
	            request.paymentPeriod = parameters["paymentPeriod"];
            }

            // (Optional) A note about the preapproval. 
            // Maximum length: 1000 characters, including newline characters 
            if(parameters["memo"] != string.Empty) 
            {
	            request.memo = parameters["memo"];
            }

            // Optional) The URL to which you want all IPN messages for 
            // this preapproval to be sent. This URL supersedes the 
            // IPN notification URL in your profile. Maximum length: 1024 characters 
            if(parameters["ipnNotificationUrl"] != string.Empty) 
            {
	            request.ipnNotificationUrl = parameters["ipnNotificationUrl"];
            }

            // (Optional) Sender's email address. If not specified, the email address 
            // of the sender who logs in to approve the request becomes the email address 
            // associated with the preapproval key. Maximum length: 127 characters 
            if(parameters["senderEmail"] != string.Empty) 
            {
	            request.senderEmail = parameters["senderEmail"];
            }

            // (Optional) Whether a personal identification number (PIN) is required. 
            // It is one of the following values:

            //    NOT_REQUIRED – A PIN is not required (default)
            //    REQUIRED – A PIN is required; the sender must specify a PIN when setting up the preapproval on PayPal
            if(parameters["pinType"] != string.Empty && parameters["pinType"] != string.Empty) 
            {
	            request.pinType = parameters["pinType"];
            }

            // (Optional) The payer of PayPal fees. Allowable values are:
            //    SENDER – Sender pays all fees (for personal, implicit simple/parallel payments; do not use for chained or unilateral payments)
            //    PRIMARYRECEIVER – Primary receiver pays all fees (chained payments only)
            //    EACHRECEIVER – Each receiver pays their own fee (default, personal and unilateral payments)
            //    SECONDARYONLY – Secondary receivers pay all fees (use only for chained payments with one secondary receiver)
            if(parameters["feesPayer"] != string.Empty) 
            {
	            request.feesPayer = parameters["feesPayer"];
            }

            //(Optional) Whether to display the maximum total amount of this preapproval. It is one of the following values:
            // TRUE – Display the amount
            // FALSE – Do not display the amount (default)
            if (parameters["displayMaxTotalAmount"] != string.Empty)
            {
                request.displayMaxTotalAmount = Convert.ToBoolean(parameters["displayMaxTotalAmount"]);
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
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //  A preapproval key that identifies the preapproval requested.
                responseValues.Add("Preapproval key", response.preapprovalKey);

                
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"]
                                     + "_ap-preapproval&preapprovalkey=" + response.preapprovalKey;
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
                responseValues.Add("Redirect To PayPal", redirectUrl);
            }
            Display(contextHttp, "Preapproval", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }
        
        /// <summary>
        /// Handle PreapprovalDetails API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void PreapprovalDetails(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // preapproval key : (Required) A preapproval key that identifies the preapproval for which you want to retrieve details. The preapproval key is returned in the PreapprovalResponse message
            PreapprovalDetailsRequest request = new PreapprovalDetailsRequest(new RequestEnvelope("en_US"), 
                parameters["preapprovalKey"]);
            
            //  (Optional) An option that lets you retrieve a list of billing addresses for the sender.
            //     true – Includes the billing address in the response
            //     false – Omits the billing address from the response (default)
            // Note:
            // This field is available only to API callers with advanced permission levels. For information, refer to the section Adaptive Payments Permission Levels.
            if (parameters["getBillingAddress"] != string.Empty)
                request.getBillingAddress = Convert.ToBoolean(parameters["getBillingAddress"]);
           
            AdaptivePaymentsService service = null;
            PreapprovalDetailsResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.PreapprovalDetails(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //Whether this preapproval is active, represented by the following values:
                //  ACTIVE – The preapproval is active
                //  CANCELED – The preapproval was explicitly canceled by the sender or by PayPal
                //  DEACTIVATED – The preapproval is not active; you can reactivate it by resetting the personal identification number (PIN) or by contacting PayPal
                responseValues.Add("Status", response.status);

                // First date for which the preapproval is valid.
                responseValues.Add("Starting date", response.startingDate);
                
                // Last date for which the preapproval is valid. Time is currently not supported.
                // Note:
                // You must specify a value unless you have specific permission from PayPal to 
                // omit this value.
                responseValues.Add("Ending date", response.endingDate);

                // Sender’s email address. If not specified, the email address of 
                // the sender who logs in to approve the request becomes the email 
                // address associated with the preapproval key.
                responseValues.Add("Sender email", response.senderEmail);

                responseValues.Add("Currency code", response.currencyCode);

                // The preapproved maximum total amount of all payments.
                // Note:
                // You must specify a value unless you have specific permission from PayPal to omit this value.
                responseValues.Add("Maximum amount (across all payments)", response.maxTotalAmountOfAllPayments.ToString());

                
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }
            Display(contextHttp, "PreapprovalDetails", responseValues, service.getLastRequest(), service.getLastResponse(),
                response.error, redirectUrl);
        }

        /// <summary>
        /// Handle CancelPreapproval API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void CancelPreapproval(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // preapproval key : (Required) A preapproval key that identifies the preapproval for which you want to retrieve details. The preapproval key is returned in the PreapprovalResponse message
            CancelPreapprovalRequest request = new CancelPreapprovalRequest(new RequestEnvelope("en_US"),
                parameters["preapprovalKey"]);
           
            AdaptivePaymentsService service = null;
            CancelPreapprovalResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.CancelPreapproval(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }
            Display(contextHttp, "CancelPreapproval", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle ConfirmPreapproval API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void ConfirmPreapproval(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // preapproval key : (Required) A preapproval key that identifies the preapproval for which you want to retrieve details. The preapproval key is returned in the PreapprovalResponse message
            ConfirmPreapprovalRequest request = new ConfirmPreapprovalRequest(new RequestEnvelope("en_US"),
                parameters["preapprovalKey"]);

            // Set optional parameters
            //The sender's personal identification number, which was specified 
            //when the sender signed up for a preapproval.
            if (parameters["pin"] != string.Empty)
                request.pin = parameters["pin"];

            //Funding source ID.
            if (parameters["fundingSourceId"] != string.Empty)
                request.fundingSourceId = parameters["fundingSourceId"];
       
            AdaptivePaymentsService service = null;
            ConfirmPreapprovalResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.ConfirmPreapproval(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //nothing to add
            }
            Display(contextHttp, "ConfirmPreapproval", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }
        
        /// <summary>
        /// Handle Refund API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void Refund(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;

            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            RefundRequest request = new RefundRequest(new RequestEnvelope("en_US"));

            // Set optional parameters
            if(parameters["receiverEmail"].Length > 0) 
            {
                //(Required) Amount to be paid to the receiver
                string[] amt = contextHttp.Request.Form.GetValues("receiverAmount");

                // Receiver's email address. This address can be unregistered with paypal.com.
                // If so, a receiver cannot claim the payment until a PayPal account is linked
                // to the email address. The PayRequest must pass either an email address or a phone number. 
                // Maximum length: 127 characters
                string[] receiverEmail = contextHttp.Request.Form.GetValues("receiverEmail");

                //Telephone country code 
                string[] phoneCountry = contextHttp.Request.Form.GetValues("phoneCountry");

                // A type to specify the receiver's phone number.
                // The PayRequest must pass either an email address or a phone number as the payment receiver.
                string[] phoneNumber = contextHttp.Request.Form.GetValues("phoneNumber");

                //Telephone extension
                string[] phoneExtn = contextHttp.Request.Form.GetValues("phoneExtn");

                // (Optional) Whether this receiver is the primary receiver, 
                // which makes the payment a chained payment.You can specify at most one primary receiver. 
                // Omit this field for simple and parallel payments. Allowable values are:
                //  true – Primary receiver
                //  false – Secondary receiver (default)
                string[] primaryReceiver = contextHttp.Request.Form.GetValues("primaryReceiver");

                // (Optional) Your own invoice or tracking number.
                //Character length and limitations: 127 single-byte alphanumeric characters
                string[] invoiceId = contextHttp.Request.Form.GetValues("invoiceId");

                // (Optional) The transaction type for the payment. Allowable values are:
                // GOODS – This is a payment for non-digital goods
                // SERVICE – This is a payment for services (default)
                // PERSONAL – This is a person-to-person payment
                // CASHADVANCE – This is a person-to-person payment for a cash advance
                // DIGITALGOODS – This is a payment for digital goods
                // BANK_MANAGED_WITHDRAWAL – This is a person-to-person payment for bank withdrawals, available only with special permission.
                string[] paymentType = contextHttp.Request.Form.GetValues("paymentType");
                //(Optional) The transaction subtype for the payment. 
                string[] paymentSubType = contextHttp.Request.Form.GetValues("paymentSubType");

	            List<Receiver> receivers = new List<Receiver>();
	            for(int i=0; i<amt.Length; i++) {
                    Receiver r = new Receiver(Convert.ToDecimal(amt[i]));
		            r.email = receiverEmail[i];
                    r.primary = Convert.ToBoolean(primaryReceiver[i]);
		            if(invoiceId[i] != string.Empty) {
			            r.invoiceId = invoiceId[i];
		            }
		            if(paymentType[i] != string.Empty) {
			            r.paymentType = paymentType[i];
		            }
		            if(paymentSubType[i] != string.Empty) {
			            r.paymentSubType = paymentSubType[i];
		            }
		            if(phoneCountry[i] != string.Empty && phoneNumber[i] != string.Empty) {
			            r.phone = new PhoneNumberType(phoneCountry[i], phoneNumber[i]);
			            if(phoneExtn[i] != string.Empty) {
				            r.phone.extension = phoneExtn[i];
			            }
		            }
                    receivers.Add(r);
	            }
	            request.receiverList = new ReceiverList(receivers);
            }

            // PayPal uses 3-character ISO-4217 codes for specifying currencies in fields and variables.  
            if(parameters["currencyCode"] != string.Empty) {
	            request.currencyCode = parameters["currencyCode"];
            }

            // The key used to create the payment that you want to refund
            if(parameters["payKey"] != string.Empty) {
	            request.payKey = parameters["payKey"];
            }

            // A PayPal transaction ID associated with the receiver whose payment 
            // you want to refund to the sender. Use field name characters exactly as shown.
            if(parameters["transactionId"] != string.Empty) {
	            request.transactionId = parameters["transactionId"];
            }

            // The tracking ID associated with the payment that you want to refund
            if(parameters["trackingId"] != string.Empty) {
                request.trackingId = parameters["trackingId"];
            }            
          
            AdaptivePaymentsService service = null;
            RefundResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.Refund(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                responseValues.Add("Currency code", response.currencyCode);
                int idx = 1;
                foreach (RefundInfo refund in response.refundInfoList.refundInfo)
                {
                    //Receiver's email address.Maximum length: 127 characters
                    responseValues.Add("Refund receiver " + idx, refund.receiver.email);
                    // Amount to be refunded to the receiver.
                    responseValues.Add("Refund amount " + idx, refund.receiver.amount.ToString());
                    // Status of the refund. It is one of the following values:
                    //   REFUNDED – Refund successfully completed
                    //   REFUNDED_PENDING – Refund awaiting transfer of funds; for example, a refund paid by eCheck.
                    //   NOT_PAID – Payment was never made; therefore, it cannot be refunded.
                    //   ALREADY_REVERSED_OR_REFUNDED – Request rejected because the refund was already made, or the payment was reversed prior to this request.
                    //   NO_API_ACCESS_TO_RECEIVER – Request cannot be completed because you do not have third-party access from the receiver to make the refund.
                    //   REFUND_NOT_ALLOWED – Refund is not allowed.
                    //   INSUFFICIENT_BALANCE – Request rejected because the receiver from which the refund is to be paid does not have sufficient funds or the funding source cannot be used to make a refund.
                    //   AMOUNT_EXCEEDS_REFUNDABLE – Request rejected because you attempted to refund more than the remaining amount of the payment; call the PaymentDetails API operation to determine the amount already refunded.
                    //   PREVIOUS_REFUND_PENDING – Request rejected because a refund is currently pending for this part of the payment
                    //   NOT_PROCESSED – Request rejected because it cannot be processed at this time
                    //   REFUND_ERROR – Request rejected because of an internal error
                    //   PREVIOUS_REFUND_ERROR – Request rejected because another part of this refund caused an internal error.
                    responseValues.Add("Refund status " + idx, refund.refundStatus);

                    
                    responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
                }
            }
            Display(contextHttp, "Refund", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }
        
        /// <summary>
        /// Handle ConvertCurrency API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void ConvertCurrency(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // (Required) The currency code
            string[] fromCurrencyCodes = contextHttp.Request.Form.GetValues("currencyCode");

            //(Required) The amount to be converted.
            string[] fromCurrencyAmounts = contextHttp.Request.Form.GetValues("currencyAmount");

            // (Required) The currency code
            string[] toCurrencyCodes = contextHttp.Request.Form.GetValues("toCurrencyCode");

            List<CurrencyType> currencies = new List<CurrencyType>();
            for(int i=0; i<fromCurrencyCodes.Length; i++)
            {
                currencies.Add(
                    new CurrencyType(fromCurrencyCodes[i], Convert.ToDecimal(fromCurrencyAmounts[i]))
                );
            }
            CurrencyList baseAmountList = new CurrencyList(currencies);

            List<string> toCurrencyCodeList = new List<string>();
            for (int i = 0; i < toCurrencyCodes.Length; i++)
                toCurrencyCodeList.Add(toCurrencyCodes[i]);
            CurrencyCodeList convertToCurrencyList = new CurrencyCodeList(toCurrencyCodeList);

            ConvertCurrencyRequest request = new ConvertCurrencyRequest(
                new RequestEnvelope("en_US"), baseAmountList, convertToCurrencyList);
            
            // (Optional)The two-character ISO code for the country where the
		    // function is supposed to happen. The default value is US.
            if (parameters["countryCode"] != string.Empty)
                request.countryCode = parameters["countryCode"];

            // (Optional)The conversion type allows you to determine the converted amounts 
            // for a PayPal user in different currency conversion scenarios, e.g., 
            // sending a payment in a different currency than what this user holds, 
            // accepting payment in a different currency than what the user holds, 
            // or converting a balance to a different currency than the user holds.. 
            // The default value is SENDER_SIDE .
            if (parameters["conversionType"] != string.Empty)
                request.conversionType = parameters["conversionType"];

            AdaptivePaymentsService service = null;
            ConvertCurrencyResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.ConvertCurrency(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                if (response.estimatedAmountTable != null
                    && response.estimatedAmountTable.currencyConversionList != null)
                {
                    int idx = 1;

                    //The list of converted currencies.
                    foreach (CurrencyConversionList list in response.estimatedAmountTable.currencyConversionList)
                    {
                        responseValues.Add("Base amount " + idx,
                            list.baseAmount.amount + " " + list.baseAmount.code);
                        idx++;
                    }
                }

                
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }
            Display(contextHttp, "ConvertCurrency", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetAllowedFundingSources API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void GetAllowedFundingSources(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; 
            // by default it is en_US, which is the only language currently supported. 
            //key : (Required) The preapproval key that identifies the preapproval
            GetAllowedFundingSourcesRequest request = 
                new GetAllowedFundingSourcesRequest(new RequestEnvelope("en_US"), parameters["key"]);

            AdaptivePaymentsService service = null;
            GetAllowedFundingSourcesResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.GetAllowedFundingSources(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach (FundingSource source in response.fundingSource)
                {
                    
                    responseValues.Add("Funding source id " + idx, source.fundingSourceId);

                    responseValues.Add("Funding source name " + idx, source.displayName);
                    idx++;
                }                
            }
            Display(contextHttp, "GetAllowedFundingSources", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetFundingPlans API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void GetFundingPlans(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : The key used to create the payment whose funding sources you want to determine. 
            GetFundingPlansRequest request = new GetFundingPlansRequest(new RequestEnvelope("en_US"),
                parameters["payKey"]);
          
            AdaptivePaymentsService service = null;
            GetFundingPlansResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.GetFundingPlans(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach (FundingPlan plan in response.fundingPlan) {
                    responseValues.Add("Funding plan Id " + idx, plan.fundingPlanId);
                    responseValues.Add("Funding plan amount " + idx, 
                        plan.fundingAmount.amount + plan.fundingAmount.code );
                    idx++;
                }
            }
            Display(contextHttp, "GetFundingPlans", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }
        
        /// <summary>
        /// Handle GetShippingAddresses API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void GetShippingAddresses(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;
            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported.
            // key : (Required) The payment paykey that identifies the account holder for whom you want 
            // to obtain the selected shipping address.
            //  Note:
            //  Shipping information can only be retrieved through the payment payKey; not through the preapprovalKey.
            GetShippingAddressesRequest request = new GetShippingAddressesRequest(new RequestEnvelope("en_US"),
                parameters["key"]);
        
            AdaptivePaymentsService service = null;
            GetShippingAddressesResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.GetShippingAddresses(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                if (response.selectedAddress != null)
                {
                    // The name associated with the address.
                    responseValues.Add("Address name", response.selectedAddress.addresseeName);

                    // The ID associated with the address.
                    responseValues.Add("Address Id", response.selectedAddress.addressId);
                    if (response.selectedAddress.baseAddress != null)
                    {
                        // Street address.
                        responseValues.Add("Address line", response.selectedAddress.baseAddress.line1);
                        // The city of the address.
                        responseValues.Add("City", response.selectedAddress.baseAddress.city);
                        // The state for the address
                        responseValues.Add("State", response.selectedAddress.baseAddress.state);                       
                    }
                }
            }
            Display(contextHttp, "GetShippingAddresses", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetAvailableShippingAddresses API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void GetAvailableShippingAddresses(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported.
            // key : (Required) The payment paykey that identifies the account holder 
            GetAvailableShippingAddressesRequest request = new GetAvailableShippingAddressesRequest(
                    new RequestEnvelope("en_US"), parameters["key"]);
       
            AdaptivePaymentsService service = null;
            GetAvailableShippingAddressesResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.GetAvailableShippingAddresses(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach(Address addr in response.availableAddress) 
                {
                    // The name associated with the address.
                    responseValues.Add("Address name " + idx, addr.addresseeName);
                    // The ID associated with the address.
                    responseValues.Add("Address Id " + idx, addr.addressId);
                    if (addr.baseAddress != null)
                    {
                        // Street address.
                        responseValues.Add("Address line " + idx, addr.baseAddress.line1);
                        // The city of the address.
                        responseValues.Add("City " + idx, addr.baseAddress.city);
                        // The state for the address
                        responseValues.Add("State " + idx, addr.baseAddress.state);

                        
                        responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
                    }
                }
            }
            Display(contextHttp, "GetAvailableShippingAddresses", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle SetPaymentOptions API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void SetPaymentOptions(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : (Required) The pay key that identifies the payment for which you want 
            // to set payment options. This is the pay key returned in the PayResponse message.
            SetPaymentOptionsRequest request = new SetPaymentOptionsRequest(new RequestEnvelope("en_US"), parameters["payKey"]);
            if (parameters["institutionId"] != string.Empty)
            {
                request.initiatingEntity = new InitiatingEntity();
                // institutionid : (Required) The unique identifier assigned to the institution
                // firstname :  (Required) The first name of the consumer as known by the institution.
                // lastname: (Required) The last name of the consumer as known by the institution.
                // displayname : (Required) The full name of the consumer as known by the institution.
                // institutioncustomerid : (Required) The unique identifier assigned to the consumer by the institution
                // countrycode : (Required) The two-character country code of the home country of the end consumer
                // email : (Optional) The email address of the consumer as known by the institution.
                request.initiatingEntity.institutionCustomer = new InstitutionCustomer(
                    parameters["institutionId"], parameters["firstName"], 
                    parameters["lastName"], parameters["displayName"], 
                    parameters["institutionCustomerId"], parameters["countryCode"]);
                if (parameters["email"] != string.Empty)
                {
                    request.initiatingEntity.institutionCustomer.email = parameters["email"];
                }
            }

            if (parameters["emailHeaderImageUrl"] != string.Empty || parameters["emailMarketingImageUrl"] != string.Empty
                || parameters["headerImageUrl"] != string.Empty || parameters["businessName"] != string.Empty)
            {
                request.displayOptions = new DisplayOptions();

                //(Optional) The URL of the image that displays in the in the header of customer emails. 
                // The URL cannot exceed 1,024 characters. The image dimensions are 
                // 43 pixels high x 240 pixels wide.
                if (parameters["emailHeaderImageUrl"] != string.Empty )
                    request.displayOptions.emailHeaderImageUrl = parameters["emailHeaderImageUrl"];

                //(Optional) The URL of the image that displays in the in customer emails. 
                // The URL cannot exceed 1,024 characters. The image dimensions are 
                // 80 pixels high x 530 pixels wide.
                if (parameters["emailMarketingImageUrl"] != string.Empty)
                    request.displayOptions.emailMarketingImageUrl = parameters["emailMarketingImageUrl"];

                // (Optional) The URL of an image that displays in the header of a payment page. 
                // If set, it overrides the header image URL specified in your account's Profile. 
                // The URL cannot exceed 1,024 characters. The image dimensions are 
                // 90 pixels high x 750 pixels wide.
                if(parameters["headerImageUrl"] != string.Empty )
                    request.displayOptions.headerImageUrl = parameters["headerImageUrl"];

                //(Optional) The business name to display. The name cannot exceed 128 characters. 
                if(parameters["businessName"] != string.Empty)
                    request.displayOptions.businessName = parameters["businessName"];
            }
            if (parameters["shippingAddressId"] != string.Empty)
            {
                // (Optional) Sender's shipping address ID.
                request.shippingAddressId = parameters["shippingAddressId"];
            }

            if (parameters["requireShippingAddressSelection"] != string.Empty || parameters["referrerCode"] != string.Empty)
            {
                request.senderOptions = new SenderOptions();
                
                //(Optional) If true, require the sender to select a shipping address during 
                //the embedded payment flow;  default is false. 
                if (parameters["requireShippingAddressSelection"] != string.Empty)
                    request.senderOptions.requireShippingAddressSelection = 
                       Convert.ToBoolean(parameters["requireShippingAddressSelection"]);

                // (Optional) A code that identifies the partner associated with this transaction.
                // Maximum length: 32 characters.
                if (parameters["referrerCode"] != string.Empty)
                    request.senderOptions.referrerCode = parameters["referrerCode"];
            }
            request.receiverOptions = new List<ReceiverOptions>();
            ReceiverOptions receiverOption = new ReceiverOptions();
            request.receiverOptions.Add(receiverOption);

            //  (Optional) A description you want to associate with the payment. 
            // This overrides the value of the memo in Pay API for each receiver. 
            // If this is not specified the value in the memo will be used.
            // Maximum length: 1000 characters
            if (parameters["description"] != string.Empty)
                receiverOption.description = parameters["description"];

            // (Optional) An external reference or identifier you want to associate with the payment.
            // Maximum length: 1000 characters
            if (parameters["customId"] != string.Empty)
                receiverOption.customId = parameters["customId"];

            // (Optional) Name of item. 
            string[] name = contextHttp.Request.Form.GetValues("name");

            // (Optional) External reference to item or item ID. 
            string[] identifier = contextHttp.Request.Form.GetValues("identifier");

            // (Optional) Total of item line. 
            string[] price = contextHttp.Request.Form.GetValues("price");

            // (Optional) Price of an individual item. 
            string[] itemPrice = contextHttp.Request.Form.GetValues("itemPrice");

            // (Optional) Item quantity. 
            string[] itemCount = contextHttp.Request.Form.GetValues("itemCount");
            if (name.Length > 0 && name[0] != string.Empty)
            {
                receiverOption.invoiceData = new InvoiceData();
                for (int j = 0; j < name.Length; j++)
                {
                    InvoiceItem item = new InvoiceItem();
                    if (name[j] != string.Empty)
                        item.name = name[j];
                    if (identifier[j] != string.Empty)
                        item.identifier = identifier[j];
                    if (price[j] != string.Empty)
                        item.price = Convert.ToDecimal(price[j]);
                    if (itemPrice[j] != string.Empty)
                        item.itemPrice = Convert.ToDecimal(itemPrice[j]);
                    if (itemCount[j] != string.Empty)
                        item.itemCount = Convert.ToInt32(itemCount[j]);
                    receiverOption.invoiceData.item.Add(item);
                }

                // (Optional) Total tax associated with the payment. 
                if (parameters["totalTax"] != string.Empty)
                    receiverOption.invoiceData.totalTax = Convert.ToDecimal(parameters["totalTax"]);

                // (Optional) Total shipping charge associated with the payment. 
                if (parameters["totalShipping"] != string.Empty)
                    receiverOption.invoiceData.totalShipping = Convert.ToDecimal(parameters["totalShipping"]);
            }


            if (parameters["emailIdentifier"] != string.Empty ||
                (parameters["phoneCountry"] != string.Empty && parameters["phoneNumber"] != string.Empty))
            {
                receiverOption.receiver = new ReceiverIdentifier();

                // (Optional) Receiver's email address.Maximum length: 127 characters
                if(parameters["emailIdentifier"] != string.Empty)
                    receiverOption.receiver.email = parameters["emailIdentifier"];

                // (Optional) Receiver's phone number. 
                if (parameters["phoneCountry"] != string.Empty && parameters["phoneNumber"] != string.Empty)
                {
                    receiverOption.receiver.phone = 
                        new PhoneNumberType(parameters["phoneCountry"], parameters["phoneNumber"]);

                    // (Optional) Telephone extension. 
                    if (parameters["phoneExtn"] != string.Empty)
                        receiverOption.receiver.phone.extension = parameters["phoneExtn"];
                }
            }

            // (Optional) A code that identifies the partner associated with this transaction. 
            if (parameters["receiverReferrerCode"] != string.Empty)
                receiverOption.referrerCode = parameters["receiverReferrerCode"];
               
            AdaptivePaymentsService service = null;
            SetPaymentOptionsResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.SetPaymentOptions(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }
                        
            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }

            Display(contextHttp, "SetPaymentOptions", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, null);
        }

        /// <summary>
        /// Handle GetPaymentOptions API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void GetPaymentOptions(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : (Required) The pay key that identifies the payment for which you want to get payment options. 
            // This is the pay key you used to set the payment options.
            GetPaymentOptionsRequest request = new GetPaymentOptionsRequest(new RequestEnvelope("en_US"), parameters["payKey"]);
     
            AdaptivePaymentsService service = null;
            GetPaymentOptionsResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.GetPaymentOptions(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach(ReceiverOptions option in response.receiverOptions)
                {
                    // Specifies information about each receiver.
                    responseValues.Add("Receiver option " + idx, option.description);
                    if(option.receiver.email != null)
                        responseValues.Add("Receiver email " + idx, option.receiver.email);
                    idx++;
                }
                if(response.displayOptions != null) 
                {
                    // The business name to display.
                    // Note:
                    // The headerImageUrl and businessName parameters are mutually exclusive; 
                    // only one of these fields can be used. If you specify both, the image will 
                    // take precedence over the business name.
                    responseValues.Add("Business name", response.displayOptions.businessName);

                    // The URL of the image that displays in the header of a payment page. 
                    // Use this to configure payment flows by passing a different image URL 
                    // for different scenarios. If set, it overrides the header image URL 
                    // specified in your account's Profile. The image dimensions 
                    // are 90 pixels high x 750 pixels wide.
                    // Note:
                    // The headerImageUrl and businessName parameters are mutually exclusive; 
                    // only one of these fields can be used. If you specify both, the image 
                    // will take precedence over the business name.

                    responseValues.Add("Header image", response.displayOptions.headerImageUrl);

                    // The URL of the image that displays in the in the header of customer emails. 
                    // The image dimensions are 43 pixels high x 240 pixels wide.
                    responseValues.Add("Email header image", response.displayOptions.emailHeaderImageUrl);
                }

                // Sender's shipping address ID.
                responseValues.Add("Shipping address Id", response.shippingAddressId);

                
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }
            Display(contextHttp, "GetPaymentOptions", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle ExecutePayment API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void ExecutePayment(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : (Optional) The pay key that identifies the payment to be executed. 
            // This is the pay key returned in the PayResponse message. 
            ExecutePaymentRequest request = new ExecutePaymentRequest(new RequestEnvelope("en_US"), parameters["payKey"]);

            // (Optional) The ID of the funding plan from which to make this payment. 
            request.fundingPlanId = parameters["fundingPlanId"];
            
            AdaptivePaymentsService service = null;
            ExecutePaymentResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.ExecutePayment(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }

            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // Important: You must test the value of paymentExecStatus for an error even if 
                // responseEnvelope.ack is Success. If the PaymentExecStatus is ERROR, 
                // the Pay Key can no longer be used. 
                responseValues.Add("Payment exeucution status", response.paymentExecStatus);

                
                responseValues.Add("Acknowledgement", response.responseEnvelope.ack.ToString());
            }
            Display(contextHttp, "ExecutePayment", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetUserLimits API call
        /// </summary>
        /// <param name="contextHttp"></param>
        private void GetUserLimits(HttpContext contextHttp)
        {
            NameValueCollection parameters = contextHttp.Request.Params;

            List<string> limitType = new List<string>();

            if (parameters["limitType"] != string.Empty)
            {
                limitType.Add(parameters["limitType"]);
            }

            AccountIdentifier accountId = new AccountIdentifier();
            if (parameters["email"] != string.Empty)
            {
                accountId.email = parameters["email"];
            }
            if (parameters["phoneCountry"] != string.Empty && parameters["phoneNumber"] != string.Empty)
            {
                accountId.phone = new PhoneNumberType(parameters["phoneCountry"], parameters["phoneNumber"]);
                if (parameters["phoneExtension"] != string.Empty)
                    accountId.phone.extension = parameters["phoneExtension"];
            }

            GetUserLimitsRequest request = new GetUserLimitsRequest(
                    new RequestEnvelope("en_US"), accountId, parameters["country"], 
                    parameters["currencyCode"], limitType);
         
            AdaptivePaymentsService service = null;
            GetUserLimitsResponse response = null;
            try
            {
                // Configuration map containing signature credentials and other required configuration.
                // For a full list of configuration parameters refer in wiki page 
                // (https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
                Dictionary<string, string> configurationMap = Configuration.GetAcctAndConfig();

                // Creating service wrapper object to make an API call and loading
                // configuration map for your credentials and endpoint
                service = new AdaptivePaymentsService(configurationMap);
                response = service.GetUserLimits(request);
            }
            catch (System.Exception e)
            {
                contextHttp.Response.Write(e.Message);
                return;
            }
 
            Dictionary<string, string> responseValues = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(response.responseEnvelope.ack == AckCode.FAILURE) &&
                !(response.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach (UserLimit userLimit in response.userLimit)
                {
                    responseValues.Add("Limit amount " + idx,
                        userLimit.limitAmount.amount + userLimit.limitAmount.code);
                    responseValues.Add("Limit type " + idx, userLimit.limitType);
                    idx++;
                }
            }
            Display(contextHttp, "GetUserLimits", responseValues, service.getLastRequest(), service.getLastResponse(), response.error, redirectUrl);
        }       
        
        /// <summary>
        /// Utility method for displaying API response
        /// </summary>
        /// <param name="contextHttp"></param>
        /// <param name="apiName"></param>
        /// <param name="responseValues"></param>
        /// <param name="requestPayload"></param>
        /// <param name="responsePayload"></param>
        /// <param name="errorMessages"></param>
        /// <param name="redirectUrl"></param>
        private void Display(HttpContext contextHttp, string apiName, Dictionary<string, string> responseValues, string requestPayload, string responsePayload, List<ErrorData> errorMessages, string redirectUrl)
        {

            contextHttp.Response.Write("<html><head><title>");
            contextHttp.Response.Write("PayPal Adaptive Payments - " + apiName);
            contextHttp.Response.Write("</title><link rel='stylesheet' href='Content/sdk.css' type='text/css'/></head><body>");
            contextHttp.Response.Write("<h3>" + apiName + " response</h3>");
            if (errorMessages != null && errorMessages.Count > 0)
            {
                contextHttp.Response.Write("<div class='section_header'>Error messages</div>");
                contextHttp.Response.Write("<div class='note'>Investigate the response object for further error information</div><ul>");
                foreach (ErrorData error in errorMessages)
                {   
                    contextHttp.Response.Write("<li>" + error.message + "</li>");       
                }
                contextHttp.Response.Write("</ul>");
            }
            if (redirectUrl != null)
            {
                string red = "<div>This API involves a web flow. You must now redirect your user to " + redirectUrl;
                red = red + "<br />Please click <a href='" + redirectUrl + "' target='_parent'>here</a> to try the flow.</div><br/>";
                contextHttp.Response.Write(red);
            }
            contextHttp.Response.Write("<div class='section_header'>Key values from response</div>");
            contextHttp.Response.Write("<div class='note'>Consult response object and reference doc for complete list of response values.</div><table>");
                                   
            foreach (KeyValuePair<string, string> entry in responseValues)
            {
                contextHttp.Response.Write("<tr><td class='label'>");
                contextHttp.Response.Write(entry.Key);
                contextHttp.Response.Write(": </td><td>");

                if (entry.Key == "Redirect To PayPal")
                {
                    contextHttp.Response.Write("<a id='");
                    contextHttp.Response.Write(entry.Key);
                    contextHttp.Response.Write("' href=");
                    contextHttp.Response.Write(entry.Value);
                    contextHttp.Response.Write(">Redirect To PayPal</a>");
                }
                else
                {
                    contextHttp.Response.Write("<div id='");
                    contextHttp.Response.Write(entry.Key);
                    contextHttp.Response.Write("'>");
                    contextHttp.Response.Write(entry.Value);
                }

                contextHttp.Response.Write("</td></tr>");
            }

            contextHttp.Response.Write("</table><h4>Request:</h4><br/><textarea rows=15 cols=80 readonly>");
            contextHttp.Response.Write(requestPayload);
            contextHttp.Response.Write("</textarea><br/><h4>Response</h4><br/><textarea rows=15 cols=80 readonly>");
            contextHttp.Response.Write(responsePayload);
            contextHttp.Response.Write("</textarea>");            
            contextHttp.Response.Write("<br/><br/><a href='Default.aspx'>Home<a><br/><br/></body></html>");
        }
    }
}