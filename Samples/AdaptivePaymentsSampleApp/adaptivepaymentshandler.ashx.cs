using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Collections.Generic;
using System.Collections.Specialized;
using PayPal;
using PayPal.Exception;
using PayPal.Util;
using PayPal.AdaptivePayments;
using System.Configuration;
using PayPal.AdaptivePayments.Model;

namespace AdaptivePaymentsSampleApp
{
    /// <summary>
    /// Summary description for codebehindclassname
    /// </summary>

    public class adaptivepaymentshandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            String strCall = context.Request.Params["AdaptivePaymentsBtn"];

            if (strCall.Equals("Pay"))
            {
                Pay(context);
            }
            else if (strCall.Equals("PaymentDetails"))
            {
                PaymentDetails(context);
            }
            else if (strCall.Equals("Preapproval"))
            {
                Preapproval(context);
            }
            else if (strCall.Equals("PreapprovalDetails"))
            {
                PreapprovalDetails(context);
            }
            else if (strCall.Equals("CancelPreapproval"))
            {
                CancelPreapproval(context);
            }
            else if (strCall.Equals("ConfirmPreapproval"))
            {
                ConfirmPreapproval(context);
            }
            else if (strCall.Equals("Refund"))
            {
                Refund(context);
            }
            else if (strCall.Equals("ConvertCurrency"))
            {
                ConvertCurrency(context);
            }
            else if (strCall.Equals("GetAllowedFundingSources"))
            {
                GetAllowedFundingSources(context);
            }
            else if (strCall.Equals("GetFundingPlans"))
            {
                GetFundingPlans(context);
            }
            else if (strCall.Equals("GetShippingAddresses"))
            {
                GetShippingAddresses(context);
            }
            else if (strCall.Equals("GetAvailableShippingAddresses"))
            {
                GetAvailableShippingAddresses(context);
            }
            else if (strCall.Equals("SetPaymentOptions"))
            {
                SetPaymentOptions(context);
            }
            else if (strCall.Equals("GetPaymentOptions"))
            {
                GetPaymentOptions(context);
            }
            else if (strCall.Equals("ExecutePayment"))
            {
                ExecutePayment(context);
            }
            else if (strCall.Equals("GetUserLimits"))
            {
                GetUserLimits(context);
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
        /// <param name="context"></param>
        private void Pay(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            ReceiverList receiverList = new ReceiverList();
            receiverList.receiver = new List<Receiver>();
            //(Required) Amount to be paid to the receiver
            string[] amt = context.Request.Form.GetValues("receiverAmount");
            // Receiver's email address. This address can be unregistered with paypal.com.
		    // If so, a receiver cannot claim the payment until a PayPal account is linked
		    // to the email address. The PayRequest must pass either an email address or a phone number. 
		    // Maximum length: 127 characters 
            string[] receiverEmail = context.Request.Form.GetValues("receiverEmail");
            //Telephone country code 
            string[] phoneCountry = context.Request.Form.GetValues("phoneCountry");
            // A type to specify the receiver's phone number.
		    // The PayRequest must pass either an email address or a phone number as the payment receiver. 
            string[] phoneNumber = context.Request.Form.GetValues("phoneNumber");
            //Telephone extension
            string[] phoneExtn = context.Request.Form.GetValues("phoneExtn");
            // (Optional) Whether this receiver is the primary receiver, 
		    // which makes the payment a chained payment.You can specify at most one primary receiver. 
		    // Omit this field for simple and parallel payments. Allowable values are:
		    //  true – Primary receiver
		    //  false – Secondary receiver (default)
		    string[] primaryReceiver = context.Request.Form.GetValues("primaryReceiver");
            //  (Optional) The invoice number for the payment. 
            //  This data in this field shows on the Transaction Details report. 
            //  Maximum length: 127 characters
            string[] invoiceId = context.Request.Form.GetValues("invoiceId");
            
		    // (Optional) The transaction type for the payment. Allowable values are:
		    // GOODS – This is a payment for non-digital goods
		    // SERVICE – This is a payment for services (default)
		    // PERSONAL – This is a person-to-person payment
		    // CASHADVANCE – This is a person-to-person payment for a cash advance
		    // DIGITALGOODS – This is a payment for digital goods
		    // BANK_MANAGED_WITHDRAWAL – This is a person-to-person payment for bank withdrawals, available only with special permission.
		    string[] paymentType = context.Request.Form.GetValues("paymentType");
            //(Optional) The transaction subtype for the payment. 
            string[] paymentSubType = context.Request.Form.GetValues("paymentSubType");
            for (int i = 0; i < amt.Length; i++)
            {
                Receiver rec = new Receiver(Decimal.Parse(amt[i]));
                if(receiverEmail[i] != "")
                    rec.email = receiverEmail[i];
                if (phoneCountry[i] != "" && phoneNumber[i] != "")
                {
                    rec.phone = new PhoneNumberType(phoneCountry[i], phoneNumber[i]);
                    if (phoneExtn[i] != "")
                    {
                        rec.phone.extension = phoneExtn[i];
                    }
                }
                if (primaryReceiver[i] != "")
                    rec.primary = Boolean.Parse(primaryReceiver[i]);
                if (invoiceId[i] != "")
                    rec.invoiceId = invoiceId[i];
                if (paymentType[i] != "")
                    rec.paymentType = paymentType[i];
                if (paymentSubType[i] != "")
                    rec.paymentSubType = paymentSubType[i];
                receiverList.receiver.Add(rec);
            }  
          
            PayRequest req = new PayRequest(new RequestEnvelope("en_US"), parameters["actionType"], 
                                parameters["cancelUrl"], parameters["currencyCode"], 
                                receiverList, parameters["returnUrl"]);

            //Fix for release
            if (parameters["ipnNotificationUrl"] != "")
            {
                req.ipnNotificationUrl = parameters["ipnNotificationUrl"];
            }
            //(Optional) A note associated with the payment (text, not HTML). 
            // Maximum length: 1000 characters, including newline characters 
            if (parameters["memo"] != "")
            {
                req.memo = parameters["memo"];
            }
            //The sender's personal identification number, which was specified 
            //when the sender signed up for a preapproval. 
            if (parameters["pin"] != "")
            {
                req.pin = parameters["pin"];
            }
            // (Optional) The key associated with a preapproval for this payment. 
            // The preapproval key is required if this is a preapproved payment.
            // Note: The Preapproval API is unavailable to API callers with Standard permission levels.
            if (parameters["preapprovalKey"] != "")
            {
                req.preapprovalKey = parameters["preapprovalKey"];
            }

            // set optional parameters
            //(Optional) Whether to reverse parallel payments if an error occurs with a payment. 
            //Allowable values are:
            //true – Each parallel payment is reversed if an error occurs
            //false – Only incomplete payments are reversed (default)
            if (parameters["reverseAllParallelPaymentsOnError"] != "")
                req.reverseAllParallelPaymentsOnError = 
                    Boolean.Parse(parameters["reverseAllParallelPaymentsOnError"]);

            // Sender's email address 
            if (parameters["senderEmail"] != "")
                req.senderEmail = parameters["senderEmail"];

            //(Optional) A unique ID that you specify to track the payment.
            //Note: You are responsible for ensuring that the ID is unique.
            //Maximum length: 127 characters 
            if (parameters["trackingId"] != "")
                req.trackingId = parameters["trackingId"];

            // (Optional) Specifies a list of allowed funding types for the payment. 
            // This is a list of funding selections that can be combined in any order 
            // to allow payments to use the indicated funding type. If this Parameter is omitted, 
            // the payment can be funded by any funding type that is supported for Adaptive Payments.
            // Note: FundingConstraint is unavailable to API callers with standard permission levels; 
            // for more information, refer to the section Adaptive Payments Permission Levels.
            if (parameters["fundingConstraint"] != "")
            {
                req.fundingConstraint = new FundingConstraint();
                req.fundingConstraint.allowedFundingType = new FundingTypeList();
                req.fundingConstraint.allowedFundingType.fundingTypeInfo.Add(
                    new FundingTypeInfo(parameters["fundingConstraint"]));
            }

            if (parameters["emailIdentifier"] != ""
                || (parameters["senderPhoneCountry"] != "" && parameters["senderPhoneNumber"] != "")
                || parameters["useCredentials"] != "")
            {
                req.sender = new SenderIdentifier();
                //  (Optional) Sender's email address. Maximum length: 127 characters 
                if (parameters["emailIdentifier"] != "")
                    req.sender.email = parameters["emailIdentifier"];

                 // Sender Telephone country code
                 // Sender Telephone number
                 // Sender Telephone extension
                if (parameters["senderPhoneCountry"] != "" && parameters["senderPhoneNumber"] != "")
                {
                    req.sender.phone = new PhoneNumberType(parameters["senderPhoneCountry"], parameters["senderPhoneNumber"]);
                    if (parameters["senderPhoneExtn"] != "")
                        req.sender.phone.extension = parameters["senderPhoneExtn"];
                }

                // (Optional) If true, use credentials to identify the sender; default is false. 
                if (parameters["useCredentials"] != "")
                    req.sender.useCredentials = Boolean.Parse(parameters["useCredentials"]);
            }

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            PayResponse resp = null;
            try
            {
                resp = service.Pay(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if ( !(resp.responseEnvelope.ack == AckCode.FAILURE) && 
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING) )
            {
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"]
                                     + "_ap-payment&paykey=" + resp.payKey;
                // The pay key, which is a token you use in other Adaptive Payment APIs 
				// (such as the Refund Method) to identify this payment. 
				// The pay key is valid for 3 hours; the payment must be approved while the 
				// pay key is valid. 
				keyResponseParams.Add("Pay key", resp.payKey);
                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                keyResponseParams.Add("Payment execution status", resp.paymentExecStatus);
                if (resp.defaultFundingPlan != null && resp.defaultFundingPlan.senderFees != null)
                {
                    //Fees to be paid by the sender.
                    keyResponseParams.Add("Sender fees", resp.defaultFundingPlan.senderFees.amount +
                                                resp.defaultFundingPlan.senderFees.code);
                }

                //Selenium Test Case
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }
            displayResponse(context, "Pay", keyResponseParams, service.getLastRequest(), service.getLastResponse(), 
                resp.error, redirectUrl);            
        }

        /// <summary>
        /// Handle PaymentDetails API call
        /// </summary>
        /// <param name="context"></param>
        private void PaymentDetails(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            PaymentDetailsRequest req = new PaymentDetailsRequest(new RequestEnvelope("en_US")); 
            // set optional parameters
            //(Optional) The pay key that identifies the payment for which 
            // you want to retrieve details. This is the pay key returned in the PayResponse message. 
            if (parameters["payKey"] != "")
                req.payKey = parameters["payKey"];
            // (Optional) The PayPal transaction ID associated with the payment. 
            // The IPN message associated with the payment contains the transaction ID. 
            if (parameters["transactionId"] != "")
                req.transactionId = parameters["transactionId"];
            // (Optional) The tracking ID that was specified for this payment 
            // in the PayRequest message. Maximum length: 127 characters 
            if (parameters["trackingId"] != "")
                req.trackingId = parameters["trackingId"];

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            PaymentDetailsResponse resp = null;
            try
            {
                resp = service.PaymentDetails(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //(Optional) The pay key that identifies the payment 
                keyResponseParams.Add("Pay key", resp.payKey);
                // The status of the payment. Possible values are:
                // CREATED – The payment request was received; funds will be transferred once the payment is approved
                // COMPLETED – The payment was successful
                // INCOMPLETE – Some transfers succeeded and some failed for a parallel payment or, for a delayed chained payment, secondary receivers have not been paid
                // ERROR – The payment failed and all attempted transfers failed or all completed transfers were successfully reversed
                // REVERSALERROR – One or more transfers failed when attempting to reverse a payment
                // PROCESSING – The payment is in progress
                // PENDING – The payment is awaiting processing
                keyResponseParams.Add("Payment execution status", resp.status);

                // The sender's email address. 
                keyResponseParams.Add("Sender email", resp.senderEmail);

                //Acknowledgement code. It is one of the following values:
                // Success – The operation completed successfully.
                // Failure – The operation failed.
                // SuccessWithWarning – The operation completed successfully; however, there is a warning message.
                // FailureWithWarning – The operation failed with a warning message.
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());

                // Whether the Pay request is set up to create a payment request with the SetPaymentOptions 
                // request, and then fulfill the payment with the ExecutePayment request. 
                // Possible values are:
                // PAY – Use this option if you are not using the Pay request in combination with ExecutePayment.
                // CREATE – Use this option to set up the payment instructions with SetPaymentOptions and then execute the payment at a later time with the ExecutePayment.
                // PAY_PRIMARY – For chained payments only, specify this value to delay payments to the secondary receivers; only the payment to the primary receiver is processed.
                keyResponseParams.Add("Action Type", resp.actionType);
            }
            displayResponse(context, "PaymentDetails", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle Preapproval API
        /// </summary>
        /// <param name="context"></param>
        private void Preapproval(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // cancel url : URL to redirect the sender's browser to after canceling the preapproval 
            // currency code : The code for the currency in which the payment is made; you can specify only one currency, regardless of the number of receivers 
            // return url : URL to redirect the sender's browser to after the sender has logged into PayPal and confirmed the preapproval 
            // starting date : First date for which the preapproval is valid. It cannot be before today's date or after the ending date. 
            PreapprovalRequest req = new PreapprovalRequest(new RequestEnvelope("en_US"), parameters["cancelUrl"], 
                    parameters["currencyCode"], parameters["returnUrl"], parameters["startingDate"]);
            
            // (Optional) The day of the month on which a monthly payment is to be made. 
            // Allowable values are numbers between 0 and 31. A number between 1 and 31 
            // indicates the date of the month. Specifying 0 indicates that payment can be 
            // made on any day of the month. 
            if(parameters["dateOfMonth"] != "") 
            {
	            req.dateOfMonth = Int32.Parse(parameters["dateOfMonth"]);
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

            if(parameters["dayOfWeek"] != "" && parameters["dayOfWeek"] != "") 
            {
                req.dayOfWeek = (PayPal.AdaptivePayments.Model.DayOfWeek)
                        Enum.Parse(typeof(PayPal.AdaptivePayments.Model.DayOfWeek), parameters["dayOfWeek"]);
            }

            //(Optional) The day of the month on which a monthly payment is to be made. 
            // Allowable values are numbers between 0 and 31. A number between 1 and 31 
            // indicates the date of the month. Specifying 0 indicates that payment 
            // can be made on any day of the month. 
            if(parameters["dateOfMonth"] != "") 
            {
	            req.dateOfMonth = Int32.Parse(parameters["dateOfMonth"]);
            }

            // xs:dateTime (Optional) Last date for which the preapproval is valid. 
            // It cannot be later than one year from the starting date.
            // Note: You must specify a value unless you have specific permission 
            // from PayPal to omit this value. 
            if(parameters["endingDate"] != "") 
            {
	            req.endingDate = parameters["endingDate"];
            }

            // (Optional) The preapproved maximum amount per payment. 
            // It cannot exceed the preapproved maximum total amount of all payments. 
            if(parameters["maxAmountPerPayment"] != "") 
            {
	            req.maxAmountPerPayment = Decimal.Parse(parameters["maxAmountPerPayment"]);
            }

            // (Optional) The preapproved maximum number of payments. 
            // It cannot exceed the preapproved maximum total number of all payments. 
            if(parameters["maxNumberOfPayments"] != "" ) 
            {
	            req.maxNumberOfPayments = Int32.Parse(parameters["maxNumberOfPayments"]);
            }

            //(Optional) The preapproved maximum number of all payments per period. 
            // You must specify a value unless you have specific permission from PayPal. 
            if(parameters["maxNumberOfPaymentsPerPeriod"] != "") 
            {
	            req.maxNumberOfPaymentsPerPeriod = Int32.Parse(parameters["maxNumberOfPaymentsPerPeriod"]);
            }

            // The preapproved maximum total amount of all payments. 
            // It cannot exceed $2,000 USD or its equivalent in other currencies. 
            // Contact PayPal if you do not want to specify a maximum amount. 
            if(parameters["maxTotalAmountOfAllPayments"] != "") 
            {
	            req.maxTotalAmountOfAllPayments = Decimal.Parse(parameters["maxTotalAmountOfAllPayments"]);
            }

            //(Optional) The payment period. It is one of the following values:
            //    NO_PERIOD_SPECIFIED
            //    DAILY – Each day
            //    WEEKLY – Each week
            //    BIWEEKLY – Every other week
            //    SEMIMONTHLY – Twice a month
            //    MONTHLY – Each month
            //    ANNUALLY – Each year
            if(parameters["paymentPeriod"] != "" && parameters["paymentPeriod"] != "") 
            {
	            req.paymentPeriod = parameters["paymentPeriod"];
            }

            // (Optional) A note about the preapproval. 
            // Maximum length: 1000 characters, including newline characters 
            if(parameters["memo"] != "") 
            {
	            req.memo = parameters["memo"];
            }

            // Optional) The URL to which you want all IPN messages for 
            // this preapproval to be sent. This URL supersedes the 
            // IPN notification URL in your profile. Maximum length: 1024 characters 
            if(parameters["ipnNotificationUrl"] != "") 
            {
	            req.ipnNotificationUrl = parameters["ipnNotificationUrl"];
            }

            // (Optional) Sender's email address. If not specified, the email address 
            // of the sender who logs in to approve the request becomes the email address 
            // associated with the preapproval key. Maximum length: 127 characters 
            if(parameters["senderEmail"] != "") 
            {
	            req.senderEmail = parameters["senderEmail"];
            }

            // (Optional) Whether a personal identification number (PIN) is required. 
            // It is one of the following values:

            //    NOT_REQUIRED – A PIN is not required (default)
            //    REQUIRED – A PIN is required; the sender must specify a PIN when setting up the preapproval on PayPal
            if(parameters["pinType"] != "" && parameters["pinType"] != "") 
            {
	            req.pinType = parameters["pinType"];
            }

            // (Optional) The payer of PayPal fees. Allowable values are:
            //    SENDER – Sender pays all fees (for personal, implicit simple/parallel payments; do not use for chained or unilateral payments)
            //    PRIMARYRECEIVER – Primary receiver pays all fees (chained payments only)
            //    EACHRECEIVER – Each receiver pays their own fee (default, personal and unilateral payments)
            //    SECONDARYONLY – Secondary receivers pay all fees (use only for chained payments with one secondary receiver)
            if(parameters["feesPayer"] != "") 
            {
	            req.feesPayer = parameters["feesPayer"];
            }

            //(Optional) Whether to display the maximum total amount of this preapproval. It is one of the following values:
            // TRUE – Display the amount
            // FALSE – Do not display the amount (default)
            if (parameters["displayMaxTotalAmount"] != "")
            {
                req.displayMaxTotalAmount = Boolean.Parse(parameters["displayMaxTotalAmount"]);
            }

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            PreapprovalResponse resp = null;
            try
            {
                resp = service.Preapproval(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //  A preapproval key that identifies the preapproval requested.
                keyResponseParams.Add("Preapproval key", resp.preapprovalKey);

                //Selenium Test Case
                redirectUrl = ConfigurationManager.AppSettings["PAYPAL_REDIRECT_URL"]
                                     + "_ap-preapproval&preapprovalkey=" + resp.preapprovalKey;
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
                keyResponseParams.Add("Redirect To PayPal", redirectUrl);
            }
            displayResponse(context, "Preapproval", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }


        /// <summary>
        /// Handle PreapprovalDetails API call
        /// </summary>
        /// <param name="context"></param>
        private void PreapprovalDetails(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // preapproval key : (Required) A preapproval key that identifies the preapproval for which you want to retrieve details. The preapproval key is returned in the PreapprovalResponse message
            PreapprovalDetailsRequest req = new PreapprovalDetailsRequest(new RequestEnvelope("en_US"), 
                parameters["preapprovalKey"]);
            
            //  (Optional) An option that lets you retrieve a list of billing addresses for the sender.
            //     true – Includes the billing address in the response
            //     false – Omits the billing address from the response (default)
            // Note:
            // This field is available only to API callers with advanced permission levels. For information, refer to the section Adaptive Payments Permission Levels.
            if (parameters["getBillingAddress"] != "")
                req.getBillingAddress = Boolean.Parse(parameters["getBillingAddress"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            PreapprovalDetailsResponse resp = null;
            try
            {
                resp = service.PreapprovalDetails(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //Whether this preapproval is active, represented by the following values:
                //  ACTIVE – The preapproval is active
                //  CANCELED – The preapproval was explicitly canceled by the sender or by PayPal
                //  DEACTIVATED – The preapproval is not active; you can reactivate it by resetting the personal identification number (PIN) or by contacting PayPal
                keyResponseParams.Add("Status", resp.status);

                // First date for which the preapproval is valid.
                keyResponseParams.Add("Starting date", resp.startingDate);
                
                // Last date for which the preapproval is valid. Time is currently not supported.
                // Note:
                // You must specify a value unless you have specific permission from PayPal to 
                // omit this value.
                keyResponseParams.Add("Ending date", resp.endingDate);

                // Sender’s email address. If not specified, the email address of 
                // the sender who logs in to approve the request becomes the email 
                // address associated with the preapproval key.
                keyResponseParams.Add("Sender email", resp.senderEmail);

                keyResponseParams.Add("Currency code", resp.currencyCode);

                // The preapproved maximum total amount of all payments.
                // Note:
                // You must specify a value unless you have specific permission from PayPal to omit this value.
                keyResponseParams.Add("Maximum amount (across all payments)", resp.maxTotalAmountOfAllPayments.ToString());

                //Selenium Test Case
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }
            displayResponse(context, "PreapprovalDetails", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle CancelPreapproval API call
        /// </summary>
        /// <param name="context"></param>
        private void CancelPreapproval(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // preapproval key : (Required) A preapproval key that identifies the preapproval for which you want to retrieve details. The preapproval key is returned in the PreapprovalResponse message
            CancelPreapprovalRequest req = new CancelPreapprovalRequest(new RequestEnvelope("en_US"),
                parameters["preapprovalKey"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            CancelPreapprovalResponse resp = null;
            try
            {
                resp = service.CancelPreapproval(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //Selenium Test Case
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }
            displayResponse(context, "CancelPreapproval", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle ConfirmPreapproval API call
        /// </summary>
        /// <param name="context"></param>
        private void ConfirmPreapproval(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            // preapproval key : (Required) A preapproval key that identifies the preapproval for which you want to retrieve details. The preapproval key is returned in the PreapprovalResponse message
            ConfirmPreapprovalRequest req = new ConfirmPreapprovalRequest(new RequestEnvelope("en_US"),
                parameters["preapprovalKey"]);

            // Set optional parameters
            //The sender's personal identification number, which was specified 
            //when the sender signed up for a preapproval.
            if (parameters["pin"] != "")
                req.pin = parameters["pin"];

            //Funding source ID.
            if (parameters["fundingSourceId"] != "")
                req.fundingSourceId = parameters["fundingSourceId"];

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            ConfirmPreapprovalResponse resp = null;
            try
            {
                resp = service.ConfirmPreapproval(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                //nothing to add
            }
            displayResponse(context, "ConfirmPreapproval", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }


        /// <summary>
        /// Handle Refund API call
        /// </summary>
        /// <param name="context"></param>
        private void Refund(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;

            // error language : (Required) RFC 3066 language in which error messages are returned; by default it is en_US, which is the only language currently supported. 
            RefundRequest req = new RefundRequest(new RequestEnvelope("en_US"));

            // Set optional parameters
            if(parameters["receiverEmail"].Length > 0) 
            {
                //(Required) Amount to be paid to the receiver
                string[] amt = context.Request.Form.GetValues("receiverAmount");

                // Receiver's email address. This address can be unregistered with paypal.com.
                // If so, a receiver cannot claim the payment until a PayPal account is linked
                // to the email address. The PayRequest must pass either an email address or a phone number. 
                // Maximum length: 127 characters
                string[] receiverEmail = context.Request.Form.GetValues("receiverEmail");

                //Telephone country code 
                string[] phoneCountry = context.Request.Form.GetValues("phoneCountry");

                // A type to specify the receiver's phone number.
                // The PayRequest must pass either an email address or a phone number as the payment receiver.
                string[] phoneNumber = context.Request.Form.GetValues("phoneNumber");

                //Telephone extension
                string[] phoneExtn = context.Request.Form.GetValues("phoneExtn");

                // (Optional) Whether this receiver is the primary receiver, 
                // which makes the payment a chained payment.You can specify at most one primary receiver. 
                // Omit this field for simple and parallel payments. Allowable values are:
                //  true – Primary receiver
                //  false – Secondary receiver (default)
                string[] primaryReceiver = context.Request.Form.GetValues("primaryReceiver");

                // (Optional) Your own invoice or tracking number.
                //Character length and limitations: 127 single-byte alphanumeric characters
                string[] invoiceId = context.Request.Form.GetValues("invoiceId");

                // (Optional) The transaction type for the payment. Allowable values are:
                // GOODS – This is a payment for non-digital goods
                // SERVICE – This is a payment for services (default)
                // PERSONAL – This is a person-to-person payment
                // CASHADVANCE – This is a person-to-person payment for a cash advance
                // DIGITALGOODS – This is a payment for digital goods
                // BANK_MANAGED_WITHDRAWAL – This is a person-to-person payment for bank withdrawals, available only with special permission.
                string[] paymentType = context.Request.Form.GetValues("paymentType");
                //(Optional) The transaction subtype for the payment. 
                string[] paymentSubType = context.Request.Form.GetValues("paymentSubType");

	            List<Receiver> receivers = new List<Receiver>();
	            for(int i=0; i<amt.Length; i++) {
                    Receiver r = new Receiver(Decimal.Parse(amt[i]));
		            r.email = receiverEmail[i];
                    r.primary = Boolean.Parse(primaryReceiver[i]);
		            if(invoiceId[i] != "") {
			            r.invoiceId = invoiceId[i];
		            }
		            if(paymentType[i] != "") {
			            r.paymentType = paymentType[i];
		            }
		            if(paymentSubType[i] != "") {
			            r.paymentSubType = paymentSubType[i];
		            }
		            if(phoneCountry[i] != "" && phoneNumber[i] != "") {
			            r.phone = new PhoneNumberType(phoneCountry[i], phoneNumber[i]);
			            if(phoneExtn[i] != "") {
				            r.phone.extension = phoneExtn[i];
			            }
		            }
                    receivers.Add(r);
	            }
	            req.receiverList = new ReceiverList(receivers);
            }

            // PayPal uses 3-character ISO-4217 codes for specifying currencies in fields and variables.  
            if(parameters["currencyCode"] != "") {
	            req.currencyCode = parameters["currencyCode"];
            }

            // The key used to create the payment that you want to refund
            if(parameters["payKey"] != "") {
	            req.payKey = parameters["payKey"];
            }

            // A PayPal transaction ID associated with the receiver whose payment 
            // you want to refund to the sender. Use field name characters exactly as shown.
            if(parameters["transactionId"] != "") {
	            req.transactionId = parameters["transactionId"];
            }

            // The tracking ID associated with the payment that you want to refund
            if(parameters["trackingId"] != "") {
                req.trackingId = parameters["trackingId"];
            }            

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            RefundResponse resp = null;
            try
            {
                resp = service.Refund(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                keyResponseParams.Add("Currency code", resp.currencyCode);
                int idx = 1;
                foreach (RefundInfo refund in resp.refundInfoList.refundInfo)
                {
                    //Receiver's email address.Maximum length: 127 characters
                    keyResponseParams.Add("Refund receiver " + idx, refund.receiver.email);
                    // Amount to be refunded to the receiver.
                    keyResponseParams.Add("Refund amount " + idx, refund.receiver.amount.ToString());
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
                    keyResponseParams.Add("Refund status " + idx, refund.refundStatus);

                    //Selenium Test Case
                    keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
                }
            }
            displayResponse(context, "Refund", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }


        /// <summary>
        /// Handle ConvertCurrency API call
        /// </summary>
        /// <param name="context"></param>
        private void ConvertCurrency(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // (Required) The currency code
            string[] fromCurrencyCodes = context.Request.Form.GetValues("currencyCode");

            //(Required) The amount to be converted.
            string[] fromCurrencyAmounts = context.Request.Form.GetValues("currencyAmount");

            // (Required) The currency code
            string[] toCurrencyCodes = context.Request.Form.GetValues("toCurrencyCode");

            List<CurrencyType> currencies = new List<CurrencyType>();
            for(int i=0; i<fromCurrencyCodes.Length; i++)
            {
                currencies.Add(
                    new CurrencyType(fromCurrencyCodes[i], decimal.Parse(fromCurrencyAmounts[i]))
                );
            }
            CurrencyList baseAmountList = new CurrencyList(currencies);

            List<String> toCurrencyCodeList = new List<String>();
            for (int i = 0; i < toCurrencyCodes.Length; i++)
                toCurrencyCodeList.Add(toCurrencyCodes[i]);
            CurrencyCodeList convertToCurrencyList = new CurrencyCodeList(toCurrencyCodeList);

            ConvertCurrencyRequest req = new ConvertCurrencyRequest(
                new RequestEnvelope("en_US"), baseAmountList, convertToCurrencyList);
            
            // (Optional)The two-character ISO code for the country where the
		    // function is supposed to happen. The default value is US.
            if (parameters["countryCode"] != "")
                req.countryCode = parameters["countryCode"];

            // (Optional)The conversion type allows you to determine the converted amounts 
            // for a PayPal user in different currency conversion scenarios, e.g., 
            // sending a payment in a different currency than what this user holds, 
            // accepting payment in a different currency than what the user holds, 
            // or converting a balance to a different currency than the user holds.. 
            // The default value is SENDER_SIDE .
            if (parameters["conversionType"] != "")
                req.conversionType = parameters["conversionType"];


            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            ConvertCurrencyResponse resp = null;
            try
            {
                resp = service.ConvertCurrency(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                if (resp.estimatedAmountTable != null
                    && resp.estimatedAmountTable.currencyConversionList != null)
                {
                    int idx = 1;

                    //The list of converted currencies.
                    foreach (CurrencyConversionList list in resp.estimatedAmountTable.currencyConversionList)
                    {
                        keyResponseParams.Add("Base amount " + idx,
                            list.baseAmount.amount + " " + list.baseAmount.code);
                        idx++;
                    }
                }

                //Selenium Test Case
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }
            displayResponse(context, "ConvertCurrency", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetAllowedFundingSources API call
        /// </summary>
        /// <param name="context"></param>
        private void GetAllowedFundingSources(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error messages are returned; 
            // by default it is en_US, which is the only language currently supported. 
            //key : (Required) The preapproval key that identifies the preapproval
            GetAllowedFundingSourcesRequest req = 
                new GetAllowedFundingSourcesRequest(new RequestEnvelope("en_US"), parameters["key"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            GetAllowedFundingSourcesResponse resp = null;
            try
            {
                resp = service.GetAllowedFundingSources(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach (FundingSource source in resp.fundingSource)
                {
                    
                    keyResponseParams.Add("Funding source id " + idx, source.fundingSourceId);

                    keyResponseParams.Add("Funding source name " + idx, source.displayName);
                    idx++;
                }                
            }
            displayResponse(context, "GetAllowedFundingSources", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }


        /// <summary>
        /// Handle GetFundingPlans API call
        /// </summary>
        /// <param name="context"></param>
        private void GetFundingPlans(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : The key used to create the payment whose funding sources you want to determine. 
            GetFundingPlansRequest req = new GetFundingPlansRequest(new RequestEnvelope("en_US"),
                parameters["payKey"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            GetFundingPlansResponse resp = null;
            try
            {
                resp = service.GetFundingPlans(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach (FundingPlan plan in resp.fundingPlan) {
                    keyResponseParams.Add("Funding plan Id " + idx, plan.fundingPlanId);
                    keyResponseParams.Add("Funding plan amount " + idx, 
                        plan.fundingAmount.amount + plan.fundingAmount.code );
                    idx++;
                }
            }
            displayResponse(context, "GetFundingPlans", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }


        /// <summary>
        /// Handle GetShippingAddresses API call
        /// </summary>
        /// <param name="context"></param>
        private void GetShippingAddresses(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;
            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported.
            // key : (Required) The payment paykey that identifies the account holder for whom you want 
            // to obtain the selected shipping address.
            //  Note:
            //  Shipping information can only be retrieved through the payment payKey; not through the preapprovalKey.
            GetShippingAddressesRequest req = new GetShippingAddressesRequest(new RequestEnvelope("en_US"),
                parameters["key"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            GetShippingAddressesResponse resp = null;
            try
            {
                resp = service.GetShippingAddresses(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                if (resp.selectedAddress != null)
                {
                    // The name associated with the address.
                    keyResponseParams.Add("Address name", resp.selectedAddress.addresseeName);

                    // The ID associated with the address.
                    keyResponseParams.Add("Address Id", resp.selectedAddress.addressId);
                    if (resp.selectedAddress.baseAddress != null)
                    {
                        // Street address.
                        keyResponseParams.Add("Address line", resp.selectedAddress.baseAddress.line1);
                        // The city of the address.
                        keyResponseParams.Add("City", resp.selectedAddress.baseAddress.city);
                        // The state for the address
                        keyResponseParams.Add("State", resp.selectedAddress.baseAddress.state);                       
                    }
                }
            }
            displayResponse(context, "GetShippingAddresses", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetAvailableShippingAddresses API call
        /// </summary>
        /// <param name="context"></param>
        private void GetAvailableShippingAddresses(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported.
            // key : (Required) The payment paykey that identifies the account holder 
            GetAvailableShippingAddressesRequest req = new GetAvailableShippingAddressesRequest(
                    new RequestEnvelope("en_US"), parameters["key"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            GetAvailableShippingAddressesResponse resp = null;
            try
            {
                resp = service.GetAvailableShippingAddresses(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach(Address addr in resp.availableAddress) 
                {
                    // The name associated with the address.
                    keyResponseParams.Add("Address name " + idx, addr.addresseeName);
                    // The ID associated with the address.
                    keyResponseParams.Add("Address Id " + idx, addr.addressId);
                    if (addr.baseAddress != null)
                    {
                        // Street address.
                        keyResponseParams.Add("Address line " + idx, addr.baseAddress.line1);
                        // The city of the address.
                        keyResponseParams.Add("City " + idx, addr.baseAddress.city);
                        // The state for the address
                        keyResponseParams.Add("State " + idx, addr.baseAddress.state);

                        //Selenium Test Case
                        keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
                    }
                }
            }
            displayResponse(context, "GetAvailableShippingAddresses", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle SetPaymentOptions API call
        /// </summary>
        /// <param name="context"></param>
        private void SetPaymentOptions(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : (Required) The pay key that identifies the payment for which you want 
            // to set payment options. This is the pay key returned in the PayResponse message.
            SetPaymentOptionsRequest req = new SetPaymentOptionsRequest(new RequestEnvelope("en_US"), parameters["payKey"]);
            if (parameters["institutionId"] != "")
            {
                req.initiatingEntity = new InitiatingEntity();
                // institutionid : (Required) The unique identifier assigned to the institution
                // firstname :  (Required) The first name of the consumer as known by the institution.
                // lastname: (Required) The last name of the consumer as known by the institution.
                // displayname : (Required) The full name of the consumer as known by the institution.
                // institutioncustomerid : (Required) The unique identifier assigned to the consumer by the institution
                // countrycode : (Required) The two-character country code of the home country of the end consumer
                // email : (Optional) The email address of the consumer as known by the institution.
                req.initiatingEntity.institutionCustomer = new InstitutionCustomer(
                    parameters["institutionId"], parameters["firstName"], 
                    parameters["lastName"], parameters["displayName"], 
                    parameters["institutionCustomerId"], parameters["countryCode"]);
                if (parameters["email"] != "")
                {
                    req.initiatingEntity.institutionCustomer.email = parameters["email"];
                }
            }

            if (parameters["emailHeaderImageUrl"] != "" || parameters["emailMarketingImageUrl"] != ""
                || parameters["headerImageUrl"] != "" || parameters["businessName"] != "")
            {
                req.displayOptions = new DisplayOptions();

                //(Optional) The URL of the image that displays in the in the header of customer emails. 
                // The URL cannot exceed 1,024 characters. The image dimensions are 
                // 43 pixels high x 240 pixels wide.
                if (parameters["emailHeaderImageUrl"] != "" )
                    req.displayOptions.emailHeaderImageUrl = parameters["emailHeaderImageUrl"];

                //(Optional) The URL of the image that displays in the in customer emails. 
                // The URL cannot exceed 1,024 characters. The image dimensions are 
                // 80 pixels high x 530 pixels wide.
                if (parameters["emailMarketingImageUrl"] != "")
                    req.displayOptions.emailMarketingImageUrl = parameters["emailMarketingImageUrl"];

                // (Optional) The URL of an image that displays in the header of a payment page. 
                // If set, it overrides the header image URL specified in your account's Profile. 
                // The URL cannot exceed 1,024 characters. The image dimensions are 
                // 90 pixels high x 750 pixels wide.
                if(parameters["headerImageUrl"] != "" )
                    req.displayOptions.headerImageUrl = parameters["headerImageUrl"];

                //(Optional) The business name to display. The name cannot exceed 128 characters. 
                if(parameters["businessName"] != "")
                    req.displayOptions.businessName = parameters["businessName"];
            }
            if (parameters["shippingAddressId"] != "")
            {
                // (Optional) Sender's shipping address ID.
                req.shippingAddressId = parameters["shippingAddressId"];
            }

            if (parameters["requireShippingAddressSelection"] != "" || parameters["referrerCode"] != "")
            {
                req.senderOptions = new SenderOptions();
                
                //(Optional) If true, require the sender to select a shipping address during 
                //the embedded payment flow;  default is false. 
                if (parameters["requireShippingAddressSelection"] != "")
                    req.senderOptions.requireShippingAddressSelection = 
                        Boolean.Parse(parameters["requireShippingAddressSelection"]);

                // (Optional) A code that identifies the partner associated with this transaction.
                // Maximum length: 32 characters.
                if (parameters["referrerCode"] != "")
                    req.senderOptions.referrerCode = parameters["referrerCode"];
            }
            req.receiverOptions = new List<ReceiverOptions>();
            ReceiverOptions receiverOption = new ReceiverOptions();
            req.receiverOptions.Add(receiverOption);

            //  (Optional) A description you want to associate with the payment. 
            // This overrides the value of the memo in Pay API for each receiver. 
            // If this is not specified the value in the memo will be used.
            // Maximum length: 1000 characters
            if (parameters["description"] != "")
                receiverOption.description = parameters["description"];

            // (Optional) An external reference or identifier you want to associate with the payment.
            // Maximum length: 1000 characters
            if (parameters["customId"] != "")
                receiverOption.customId = parameters["customId"];

            // (Optional) Name of item. 
            string[] name = context.Request.Form.GetValues("name");

            // (Optional) External reference to item or item ID. 
            string[] identifier = context.Request.Form.GetValues("identifier");

            // (Optional) Total of item line. 
            string[] price = context.Request.Form.GetValues("price");

            // (Optional) Price of an individual item. 
            string[] itemPrice = context.Request.Form.GetValues("itemPrice");

            // (Optional) Item quantity. 
            string[] itemCount = context.Request.Form.GetValues("itemCount");
            if (name.Length > 0 && name[0] != "")
            {
                receiverOption.invoiceData = new InvoiceData();
                for (int j = 0; j < name.Length; j++)
                {
                    InvoiceItem item = new InvoiceItem();
                    if (name[j] != "")
                        item.name = name[j];
                    if (identifier[j] != "")
                        item.identifier = identifier[j];
                    if (price[j] != "")
                        item.price = Decimal.Parse(price[j]);
                    if (itemPrice[j] != "")
                        item.itemPrice = Decimal.Parse(itemPrice[j]);
                    if (itemCount[j] != "")
                        item.itemCount = Int32.Parse(itemCount[j]);
                    receiverOption.invoiceData.item.Add(item);
                }

                // (Optional) Total tax associated with the payment. 
                if (parameters["totalTax"] != "")
                    receiverOption.invoiceData.totalTax = Decimal.Parse(parameters["totalTax"]);

                // (Optional) Total shipping charge associated with the payment. 
                if (parameters["totalShipping"] != "")
                    receiverOption.invoiceData.totalShipping = Decimal.Parse(parameters["totalShipping"]);
            }


            if (parameters["emailIdentifier"] != "" ||
                (parameters["phoneCountry"] != "" && parameters["phoneNumber"] != ""))
            {
                receiverOption.receiver = new ReceiverIdentifier();

                // (Optional) Receiver's email address.Maximum length: 127 characters
                if(parameters["emailIdentifier"] != "")
                    receiverOption.receiver.email = parameters["emailIdentifier"];

                // (Optional) Receiver's phone number. 
                if (parameters["phoneCountry"] != "" && parameters["phoneNumber"] != "")
                {
                    receiverOption.receiver.phone = 
                        new PhoneNumberType(parameters["phoneCountry"], parameters["phoneNumber"]);

                    // (Optional) Telephone extension. 
                    if (parameters["phoneExtn"] != "")
                        receiverOption.receiver.phone.extension = parameters["phoneExtn"];
                }
            }

            // (Optional) A code that identifies the partner associated with this transaction. 
            if (parameters["receiverReferrerCode"] != "")
                receiverOption.referrerCode = parameters["receiverReferrerCode"];

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            SetPaymentOptionsResponse resp = null;
            try
            {
                resp = service.SetPaymentOptions(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }
                        
            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();

            //Selenium Test Case
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }

            displayResponse(context, "SetPaymentOptions", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, null);
        }

        /// <summary>
        /// Handle GetPaymentOptions API call
        /// </summary>
        /// <param name="context"></param>
        private void GetPaymentOptions(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : (Required) The pay key that identifies the payment for which you want to get payment options. 
            // This is the pay key you used to set the payment options.
            GetPaymentOptionsRequest req = new GetPaymentOptionsRequest(new RequestEnvelope("en_US"), parameters["payKey"]);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            GetPaymentOptionsResponse resp = null;
            try
            {
                resp = service.GetPaymentOptions(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach(ReceiverOptions option in resp.receiverOptions)
                {
                    // Specifies information about each receiver.
                    keyResponseParams.Add("Receiver option " + idx, option.description);
                    if(option.receiver.email != null)
                        keyResponseParams.Add("Receiver email " + idx, option.receiver.email);
                    idx++;
                }
                if(resp.displayOptions != null) 
                {
                    // The business name to display.
                    // Note:
                    // The headerImageUrl and businessName parameters are mutually exclusive; 
                    // only one of these fields can be used. If you specify both, the image will 
                    // take precedence over the business name.
                    keyResponseParams.Add("Business name", resp.displayOptions.businessName);

                    // The URL of the image that displays in the header of a payment page. 
                    // Use this to configure payment flows by passing a different image URL 
                    // for different scenarios. If set, it overrides the header image URL 
                    // specified in your account's Profile. The image dimensions 
                    // are 90 pixels high x 750 pixels wide.
                    // Note:
                    // The headerImageUrl and businessName parameters are mutually exclusive; 
                    // only one of these fields can be used. If you specify both, the image 
                    // will take precedence over the business name.

                    keyResponseParams.Add("Header image", resp.displayOptions.headerImageUrl);

                    // The URL of the image that displays in the in the header of customer emails. 
                    // The image dimensions are 43 pixels high x 240 pixels wide.
                    keyResponseParams.Add("Email header image", resp.displayOptions.emailHeaderImageUrl);
                }

                // Sender's shipping address ID.
                keyResponseParams.Add("Shipping address Id", resp.shippingAddressId);

                //Selenium Test Case
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }
            displayResponse(context, "GetPaymentOptions", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle ExecutePayment API call
        /// </summary>
        /// <param name="context"></param>
        private void ExecutePayment(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;

            // error language : (Required) RFC 3066 language in which error 
            // messages are returned; by default it is en_US, which is the only language currently supported. 
            // paykey : (Optional) The pay key that identifies the payment to be executed. 
            // This is the pay key returned in the PayResponse message. 
            ExecutePaymentRequest req = new ExecutePaymentRequest(new RequestEnvelope("en_US"), parameters["payKey"]);

            // (Optional) The ID of the funding plan from which to make this payment. 
            req.fundingPlanId = parameters["fundingPlanId"];

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            ExecutePaymentResponse resp = null;
            try
            {
                resp = service.ExecutePayment(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
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
                keyResponseParams.Add("Payment exeucution status", resp.paymentExecStatus);

                //Selenium Test Case
                keyResponseParams.Add("Acknowledgement", resp.responseEnvelope.ack.ToString());
            }
            displayResponse(context, "ExecutePayment", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }

        /// <summary>
        /// Handle GetUserLimits API call
        /// </summary>
        /// <param name="context"></param>
        private void GetUserLimits(HttpContext context)
        {
            NameValueCollection parameters = context.Request.Params;

            List<string> limitType = new List<string>();
            if(parameters["limitType"] != "") 
                limitType.Add(parameters["limitType"]);
            AccountIdentifier accountId = new AccountIdentifier();
            if (parameters["email"] != "")
            {
                accountId.email = parameters["email"];
            }
            if (parameters["phoneCountry"] != "" && parameters["phoneNumber"] != "")
            {
                accountId.phone = new PhoneNumberType(parameters["phoneCountry"], parameters["phoneNumber"]);
                if (parameters["phoneExtension"] != "")
                    accountId.phone.extension = parameters["phoneExtension"];
            }

            GetUserLimitsRequest req = new GetUserLimitsRequest(
                    new RequestEnvelope("en_US"), accountId, parameters["country"], 
                    parameters["currencyCode"], limitType);

            // All set. Fire the request            
            AdaptivePaymentsService service = new AdaptivePaymentsService();
            GetUserLimitsResponse resp = null;
            try
            {
                resp = service.GetUserLimits(req);
            }
            catch (System.Exception e)
            {
                context.Response.Write(e.Message);
                return;
            }

            // Display response values. 
            Dictionary<string, string> keyResponseParams = new Dictionary<string, string>();
            string redirectUrl = null;
            if (!(resp.responseEnvelope.ack == AckCode.FAILURE) &&
                !(resp.responseEnvelope.ack == AckCode.FAILUREWITHWARNING))
            {
                int idx = 1;
                foreach (UserLimit userLimit in resp.userLimit)
                {
                    keyResponseParams.Add("Limit amount " + idx,
                        userLimit.limitAmount.amount + userLimit.limitAmount.code);
                    keyResponseParams.Add("Limit type " + idx, userLimit.limitType);
                    idx++;
                }
            }
            displayResponse(context, "GetUserLimits", keyResponseParams, service.getLastRequest(), service.getLastResponse(),
                resp.error, redirectUrl);
        }


        /// <summary>
        /// Utility method for displaying API response
        /// </summary>
        /// <param name="context"></param>
        /// <param name="apiName"></param>
        /// <param name="responseValues"></param>
        /// <param name="requestPayload"></param>
        /// <param name="responsePayload"></param>
        /// <param name="errorMessages"></param>
        /// <param name="redirectUrl"></param>
        private void displayResponse(HttpContext context, string apiName, Dictionary<string, string> responseValues, 
            string requestPayload, string responsePayload, List<ErrorData> errorMessages, string redirectUrl)
        {

            context.Response.Write("<html><head><title>");
            context.Response.Write("PayPal Adaptive Payments - " + apiName);
            context.Response.Write("</title><link rel='stylesheet' href='Content/sdk.css' type='text/css'/></head><body>");
            context.Response.Write("<h3>" + apiName + " response</h3>");
            if (errorMessages != null && errorMessages.Count > 0)
            {
                context.Response.Write("<div class='section_header'>Error messages</div>");
                context.Response.Write("<div class='note'>Investigate the response object for further error information</div><ul>");
                foreach (ErrorData error in errorMessages)
                {   
                    context.Response.Write("<li>" + error.message + "</li>");       
                }
                context.Response.Write("</ul>");
            }
            if (redirectUrl != null)
            {
                string red = "<div>This API involves a web flow. You must now redirect your user to " + redirectUrl;
                red = red + "<br />Please click <a href='" + redirectUrl + "' target='_blank'>here</a> to try the flow.</div><br/>";
                context.Response.Write(red);
            }
            context.Response.Write("<div class='section_header'>Key values from response</div>");
            context.Response.Write("<div class='note'>Consult response object and reference doc for complete list of response values.</div><table>");
            
            /*
            foreach (KeyValuePair<String, String> entry in responseValues) {
                context.Response.Write("<tr><td class='label'>");
                context.Response.Write(entry.Key);
                context.Response.Write(": </td><td>");
                context.Response.Write(entry.Value);
                context.Response.Write("</td></tr>");
            }
            */

            //Selenium Test Case            
            foreach (KeyValuePair<String, String> entry in responseValues)
            {

                context.Response.Write("<tr><td class='label'>");
                context.Response.Write(entry.Key);
                context.Response.Write(": </td><td>");

                if (entry.Key == "Redirect To PayPal")
                {
                    context.Response.Write("<a id='");
                    context.Response.Write(entry.Key);
                    context.Response.Write("' href=");
                    context.Response.Write(entry.Value);
                    context.Response.Write(">Redirect To PayPal</a>");
                }
                else
                {
                    context.Response.Write("<div id='");
                    context.Response.Write(entry.Key);
                    context.Response.Write("'>");
                    context.Response.Write(entry.Value);
                }

                context.Response.Write("</td></tr>");
            }

            context.Response.Write("</table><h4>Request:</h4><br/><textarea rows=15 cols=80 readonly>");
            context.Response.Write(requestPayload);
            context.Response.Write("</textarea><br/><h4>Response</h4><br/><textarea rows=15 cols=80 readonly>");
            context.Response.Write(responsePayload);
            context.Response.Write("</textarea>");            
            context.Response.Write("<br/><br/><a href='Default.aspx'>Home<a><br/><br/></body></html>");
        }
    }
}