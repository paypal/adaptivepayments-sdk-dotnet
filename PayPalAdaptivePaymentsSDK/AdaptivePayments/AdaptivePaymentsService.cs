using System;
using System.Collections.Generic;
using System.Xml;
using PayPal;
using PayPal.Authentication;
using PayPal.Util;
using PayPal.Manager;
using PayPal.NVP;
using PayPal.AdaptivePayments.Model;

namespace PayPal.AdaptivePayments 
{
	public partial class AdaptivePaymentsService : BasePayPalService 
	{

		/// <summary>
		/// Service Version
		/// </summary>
		private const string ServiceVersion = "1.8.5";

		/// <summary>
		/// Service Name
		/// </summary>
		private const string ServiceName = "AdaptivePayments";
		
		/// <summary>
		/// SDK Name
		/// </summary>
		private const string SDKName = "adaptivepayments-dotnet-sdk";
	
		/// <summary>
		/// SDK Version
		/// </summary>
		private const string SDKVersion = "2.6.106";

		/// <summary>
		/// Default constructor for loading configuration from *.Config file
		/// </summary>
		public AdaptivePaymentsService() : base() {}
		
		/// <summary>
		/// constructor for passing in a dynamic configuration object
		/// </summary>
		public AdaptivePaymentsService(Dictionary<string, string> config) : base(config) {}
		

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="cancelPreapprovalRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public CancelPreapprovalResponse CancelPreapproval(CancelPreapprovalRequest cancelPreapprovalRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, cancelPreapprovalRequest.ToNVPString(string.Empty), ServiceName, "CancelPreapproval", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return CancelPreapprovalResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="cancelPreapprovalRequest"></param>
	 	
	 	public CancelPreapprovalResponse CancelPreapproval(CancelPreapprovalRequest cancelPreapprovalRequest)
	 	{
	 		return CancelPreapproval(cancelPreapprovalRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="cancelPreapprovalRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public CancelPreapprovalResponse CancelPreapproval(CancelPreapprovalRequest cancelPreapprovalRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, cancelPreapprovalRequest.ToNVPString(string.Empty), ServiceName, "CancelPreapproval", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return CancelPreapprovalResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="confirmPreapprovalRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public ConfirmPreapprovalResponse ConfirmPreapproval(ConfirmPreapprovalRequest confirmPreapprovalRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, confirmPreapprovalRequest.ToNVPString(string.Empty), ServiceName, "ConfirmPreapproval", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return ConfirmPreapprovalResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="confirmPreapprovalRequest"></param>
	 	
	 	public ConfirmPreapprovalResponse ConfirmPreapproval(ConfirmPreapprovalRequest confirmPreapprovalRequest)
	 	{
	 		return ConfirmPreapproval(confirmPreapprovalRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="confirmPreapprovalRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public ConfirmPreapprovalResponse ConfirmPreapproval(ConfirmPreapprovalRequest confirmPreapprovalRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, confirmPreapprovalRequest.ToNVPString(string.Empty), ServiceName, "ConfirmPreapproval", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return ConfirmPreapprovalResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="convertCurrencyRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public ConvertCurrencyResponse ConvertCurrency(ConvertCurrencyRequest convertCurrencyRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, convertCurrencyRequest.ToNVPString(string.Empty), ServiceName, "ConvertCurrency", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return ConvertCurrencyResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="convertCurrencyRequest"></param>
	 	
	 	public ConvertCurrencyResponse ConvertCurrency(ConvertCurrencyRequest convertCurrencyRequest)
	 	{
	 		return ConvertCurrency(convertCurrencyRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="convertCurrencyRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public ConvertCurrencyResponse ConvertCurrency(ConvertCurrencyRequest convertCurrencyRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, convertCurrencyRequest.ToNVPString(string.Empty), ServiceName, "ConvertCurrency", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return ConvertCurrencyResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="executePaymentRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public ExecutePaymentResponse ExecutePayment(ExecutePaymentRequest executePaymentRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, executePaymentRequest.ToNVPString(string.Empty), ServiceName, "ExecutePayment", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return ExecutePaymentResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="executePaymentRequest"></param>
	 	
	 	public ExecutePaymentResponse ExecutePayment(ExecutePaymentRequest executePaymentRequest)
	 	{
	 		return ExecutePayment(executePaymentRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="executePaymentRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public ExecutePaymentResponse ExecutePayment(ExecutePaymentRequest executePaymentRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, executePaymentRequest.ToNVPString(string.Empty), ServiceName, "ExecutePayment", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return ExecutePaymentResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getAllowedFundingSourcesRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetAllowedFundingSourcesResponse GetAllowedFundingSources(GetAllowedFundingSourcesRequest getAllowedFundingSourcesRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getAllowedFundingSourcesRequest.ToNVPString(string.Empty), ServiceName, "GetAllowedFundingSources", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetAllowedFundingSourcesResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getAllowedFundingSourcesRequest"></param>
	 	
	 	public GetAllowedFundingSourcesResponse GetAllowedFundingSources(GetAllowedFundingSourcesRequest getAllowedFundingSourcesRequest)
	 	{
	 		return GetAllowedFundingSources(getAllowedFundingSourcesRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getAllowedFundingSourcesRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetAllowedFundingSourcesResponse GetAllowedFundingSources(GetAllowedFundingSourcesRequest getAllowedFundingSourcesRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getAllowedFundingSourcesRequest.ToNVPString(string.Empty), ServiceName, "GetAllowedFundingSources", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetAllowedFundingSourcesResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getPaymentOptionsRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetPaymentOptionsResponse GetPaymentOptions(GetPaymentOptionsRequest getPaymentOptionsRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getPaymentOptionsRequest.ToNVPString(string.Empty), ServiceName, "GetPaymentOptions", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetPaymentOptionsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getPaymentOptionsRequest"></param>
	 	
	 	public GetPaymentOptionsResponse GetPaymentOptions(GetPaymentOptionsRequest getPaymentOptionsRequest)
	 	{
	 		return GetPaymentOptions(getPaymentOptionsRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getPaymentOptionsRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetPaymentOptionsResponse GetPaymentOptions(GetPaymentOptionsRequest getPaymentOptionsRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getPaymentOptionsRequest.ToNVPString(string.Empty), ServiceName, "GetPaymentOptions", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetPaymentOptionsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="paymentDetailsRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public PaymentDetailsResponse PaymentDetails(PaymentDetailsRequest paymentDetailsRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, paymentDetailsRequest.ToNVPString(string.Empty), ServiceName, "PaymentDetails", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return PaymentDetailsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="paymentDetailsRequest"></param>
	 	
	 	public PaymentDetailsResponse PaymentDetails(PaymentDetailsRequest paymentDetailsRequest)
	 	{
	 		return PaymentDetails(paymentDetailsRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="paymentDetailsRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public PaymentDetailsResponse PaymentDetails(PaymentDetailsRequest paymentDetailsRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, paymentDetailsRequest.ToNVPString(string.Empty), ServiceName, "PaymentDetails", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return PaymentDetailsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="payRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public PayResponse Pay(PayRequest payRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, payRequest.ToNVPString(string.Empty), ServiceName, "Pay", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return PayResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="payRequest"></param>
	 	
	 	public PayResponse Pay(PayRequest payRequest)
	 	{
	 		return Pay(payRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="payRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public PayResponse Pay(PayRequest payRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, payRequest.ToNVPString(string.Empty), ServiceName, "Pay", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return PayResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="preapprovalDetailsRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public PreapprovalDetailsResponse PreapprovalDetails(PreapprovalDetailsRequest preapprovalDetailsRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, preapprovalDetailsRequest.ToNVPString(string.Empty), ServiceName, "PreapprovalDetails", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return PreapprovalDetailsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="preapprovalDetailsRequest"></param>
	 	
	 	public PreapprovalDetailsResponse PreapprovalDetails(PreapprovalDetailsRequest preapprovalDetailsRequest)
	 	{
	 		return PreapprovalDetails(preapprovalDetailsRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="preapprovalDetailsRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public PreapprovalDetailsResponse PreapprovalDetails(PreapprovalDetailsRequest preapprovalDetailsRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, preapprovalDetailsRequest.ToNVPString(string.Empty), ServiceName, "PreapprovalDetails", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return PreapprovalDetailsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="preapprovalRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public PreapprovalResponse Preapproval(PreapprovalRequest preapprovalRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, preapprovalRequest.ToNVPString(string.Empty), ServiceName, "Preapproval", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return PreapprovalResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="preapprovalRequest"></param>
	 	
	 	public PreapprovalResponse Preapproval(PreapprovalRequest preapprovalRequest)
	 	{
	 		return Preapproval(preapprovalRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="preapprovalRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public PreapprovalResponse Preapproval(PreapprovalRequest preapprovalRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, preapprovalRequest.ToNVPString(string.Empty), ServiceName, "Preapproval", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return PreapprovalResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="refundRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public RefundResponse Refund(RefundRequest refundRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, refundRequest.ToNVPString(string.Empty), ServiceName, "Refund", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return RefundResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="refundRequest"></param>
	 	
	 	public RefundResponse Refund(RefundRequest refundRequest)
	 	{
	 		return Refund(refundRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="refundRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public RefundResponse Refund(RefundRequest refundRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, refundRequest.ToNVPString(string.Empty), ServiceName, "Refund", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return RefundResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="setPaymentOptionsRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public SetPaymentOptionsResponse SetPaymentOptions(SetPaymentOptionsRequest setPaymentOptionsRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, setPaymentOptionsRequest.ToNVPString(string.Empty), ServiceName, "SetPaymentOptions", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return SetPaymentOptionsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="setPaymentOptionsRequest"></param>
	 	
	 	public SetPaymentOptionsResponse SetPaymentOptions(SetPaymentOptionsRequest setPaymentOptionsRequest)
	 	{
	 		return SetPaymentOptions(setPaymentOptionsRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="setPaymentOptionsRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public SetPaymentOptionsResponse SetPaymentOptions(SetPaymentOptionsRequest setPaymentOptionsRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, setPaymentOptionsRequest.ToNVPString(string.Empty), ServiceName, "SetPaymentOptions", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return SetPaymentOptionsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getFundingPlansRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetFundingPlansResponse GetFundingPlans(GetFundingPlansRequest getFundingPlansRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getFundingPlansRequest.ToNVPString(string.Empty), ServiceName, "GetFundingPlans", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetFundingPlansResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getFundingPlansRequest"></param>
	 	
	 	public GetFundingPlansResponse GetFundingPlans(GetFundingPlansRequest getFundingPlansRequest)
	 	{
	 		return GetFundingPlans(getFundingPlansRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getFundingPlansRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetFundingPlansResponse GetFundingPlans(GetFundingPlansRequest getFundingPlansRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getFundingPlansRequest.ToNVPString(string.Empty), ServiceName, "GetFundingPlans", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetFundingPlansResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getAvailableShippingAddressesRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetAvailableShippingAddressesResponse GetAvailableShippingAddresses(GetAvailableShippingAddressesRequest getAvailableShippingAddressesRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getAvailableShippingAddressesRequest.ToNVPString(string.Empty), ServiceName, "GetAvailableShippingAddresses", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetAvailableShippingAddressesResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getAvailableShippingAddressesRequest"></param>
	 	
	 	public GetAvailableShippingAddressesResponse GetAvailableShippingAddresses(GetAvailableShippingAddressesRequest getAvailableShippingAddressesRequest)
	 	{
	 		return GetAvailableShippingAddresses(getAvailableShippingAddressesRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getAvailableShippingAddressesRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetAvailableShippingAddressesResponse GetAvailableShippingAddresses(GetAvailableShippingAddressesRequest getAvailableShippingAddressesRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getAvailableShippingAddressesRequest.ToNVPString(string.Empty), ServiceName, "GetAvailableShippingAddresses", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetAvailableShippingAddressesResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getShippingAddressesRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetShippingAddressesResponse GetShippingAddresses(GetShippingAddressesRequest getShippingAddressesRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getShippingAddressesRequest.ToNVPString(string.Empty), ServiceName, "GetShippingAddresses", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetShippingAddressesResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getShippingAddressesRequest"></param>
	 	
	 	public GetShippingAddressesResponse GetShippingAddresses(GetShippingAddressesRequest getShippingAddressesRequest)
	 	{
	 		return GetShippingAddresses(getShippingAddressesRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getShippingAddressesRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetShippingAddressesResponse GetShippingAddresses(GetShippingAddressesRequest getShippingAddressesRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getShippingAddressesRequest.ToNVPString(string.Empty), ServiceName, "GetShippingAddresses", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetShippingAddressesResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getUserLimitsRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetUserLimitsResponse GetUserLimits(GetUserLimitsRequest getUserLimitsRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getUserLimitsRequest.ToNVPString(string.Empty), ServiceName, "GetUserLimits", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetUserLimitsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getUserLimitsRequest"></param>
	 	
	 	public GetUserLimitsResponse GetUserLimits(GetUserLimitsRequest getUserLimitsRequest)
	 	{
	 		return GetUserLimits(getUserLimitsRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getUserLimitsRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetUserLimitsResponse GetUserLimits(GetUserLimitsRequest getUserLimitsRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getUserLimitsRequest.ToNVPString(string.Empty), ServiceName, "GetUserLimits", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetUserLimitsResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}

		/// <summary>
		/// 
	 	/// </summary>
		///<param name="getPrePaymentDisclosureRequest"></param>
		///<param name="apiUserName">API Username that you want to authenticate this call against. This username and the corresponding 3-token/certificate credentials must be available in Web.Config/App.Config</param>
	 	public GetPrePaymentDisclosureResponse GetPrePaymentDisclosure(GetPrePaymentDisclosureRequest getPrePaymentDisclosureRequest, string apiUserName)
	 	{	 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getPrePaymentDisclosureRequest.ToNVPString(string.Empty), ServiceName, "GetPrePaymentDisclosure", apiUserName, getAccessToken(), getAccessTokenSecret());
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";
			
			NVPUtil util = new NVPUtil();
			return GetPrePaymentDisclosureResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	 
	 	/// <summary> 
		/// 
	 	/// </summary>
		///<param name="getPrePaymentDisclosureRequest"></param>
	 	
	 	public GetPrePaymentDisclosureResponse GetPrePaymentDisclosure(GetPrePaymentDisclosureRequest getPrePaymentDisclosureRequest)
	 	{
	 		return GetPrePaymentDisclosure(getPrePaymentDisclosureRequest,(string) null);
	 	}
	 	
	 	/// <summary>
		/// 
	 	/// </summary>
		///<param name="getPrePaymentDisclosureRequest"></param>
		///<param name="credential">An explicit ICredential object that you want to authenticate this call against</param> 
	 	public GetPrePaymentDisclosureResponse GetPrePaymentDisclosure(GetPrePaymentDisclosureRequest getPrePaymentDisclosureRequest, ICredential credential)
	 	{	 			 		
			IAPICallPreHandler apiCallPreHandler = new PlatformAPICallPreHandler(this.config, getPrePaymentDisclosureRequest.ToNVPString(string.Empty), ServiceName, "GetPrePaymentDisclosure", credential);
	   	 	((PlatformAPICallPreHandler) apiCallPreHandler).SDKName = SDKName;
			((PlatformAPICallPreHandler) apiCallPreHandler).SDKVersion = SDKVersion;
			((PlatformAPICallPreHandler) apiCallPreHandler).PortName = "AdaptivePayments";

			NVPUtil util = new NVPUtil();
			return GetPrePaymentDisclosureResponse.CreateInstance(util.ParseNVPString(Call(apiCallPreHandler)), string.Empty, -1);
			
	 	}
	}
}
