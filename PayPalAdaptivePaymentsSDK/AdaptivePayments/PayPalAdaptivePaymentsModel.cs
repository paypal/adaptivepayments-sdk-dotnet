/*
 * Stub objects for AdaptivePayments 
 * AUTO_GENERATED_CODE 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using PayPal.Util;

namespace PayPal.AdaptivePayments.Model
{

	/// <summary>
	/// Utility class for Enums with descriptions
	/// </summary>
	public static class EnumUtils
	{
		/// <summary>
		/// Get description for a give enum value
		/// </summary>	
		public static string GetDescription(Enum value)
		{
			string description = "";
			DescriptionAttribute[] attributes = (DescriptionAttribute[])value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
			{
				description= attributes[0].Description;
			}
			return description;
		}
		
		/// <summary>
		/// Convert a string to an enum object
		/// </summary>	
		public static object GetValue(string value,Type enumType)
		{
			string[] names = Enum.GetNames(enumType);
			foreach(string name in names)
            {
            	if (GetDescription((Enum)Enum.Parse(enumType, name)).Equals(value))
            	{
					return Enum.Parse(enumType, name);
				}
			}
			return null;
		}
	}


	/// <summary>
	/// 
    /// </summary>
	public partial class AccountIdentifier	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string emailField;
		public string email
		{
			get
			{
				return this.emailField;
			}
			set
			{
				this.emailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PhoneNumberType phoneField;
		public PhoneNumberType phone
		{
			get
			{
				return this.phoneField;
			}
			set
			{
				this.phoneField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string accountIdField;
		public string accountId
		{
			get
			{
				return this.accountIdField;
			}
			set
			{
				this.accountIdField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public AccountIdentifier()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.email != null)
			{
					sb.Append(prefix).Append("email").Append("=").Append(HttpUtility.UrlEncode(this.email, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.phone != null)
			{
					string newPrefix = prefix + "phone" + ".";
					sb.Append(this.phoneField.ToNVPString(newPrefix));
			}
			if (this.accountId != null)
			{
					sb.Append(prefix).Append("accountId").Append("=").Append(HttpUtility.UrlEncode(this.accountId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new AccountIdentifier object created from the passed in NVP map
	 	/// </returns>
		public static AccountIdentifier CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			AccountIdentifier accountIdentifier = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "email";
			if (map.ContainsKey(key))
			{
				accountIdentifier = (accountIdentifier == null) ? new AccountIdentifier() : accountIdentifier;
				accountIdentifier.email = map[key];
			}
			PhoneNumberType phone =  PhoneNumberType.CreateInstance(map, prefix + "phone", -1);
			if (phone != null)
			{
				accountIdentifier = (accountIdentifier == null) ? new AccountIdentifier() : accountIdentifier;
				accountIdentifier.phone = phone;
			}
			key = prefix + "accountId";
			if (map.ContainsKey(key))
			{
				accountIdentifier = (accountIdentifier == null) ? new AccountIdentifier() : accountIdentifier;
				accountIdentifier.accountId = map[key];
			}
			return accountIdentifier;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class BaseAddress	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string line1Field;
		public string line1
		{
			get
			{
				return this.line1Field;
			}
			set
			{
				this.line1Field = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string line2Field;
		public string line2
		{
			get
			{
				return this.line2Field;
			}
			set
			{
				this.line2Field = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string cityField;
		public string city
		{
			get
			{
				return this.cityField;
			}
			set
			{
				this.cityField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string stateField;
		public string state
		{
			get
			{
				return this.stateField;
			}
			set
			{
				this.stateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string postalCodeField;
		public string postalCode
		{
			get
			{
				return this.postalCodeField;
			}
			set
			{
				this.postalCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string countryCodeField;
		public string countryCode
		{
			get
			{
				return this.countryCodeField;
			}
			set
			{
				this.countryCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string typeField;
		public string type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public BaseAddress(string line1, string city, string countryCode)
	 	{
			this.line1 = line1;
			this.city = city;
			this.countryCode = countryCode;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public BaseAddress()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.line1 != null)
			{
					sb.Append(prefix).Append("line1").Append("=").Append(HttpUtility.UrlEncode(this.line1, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.line2 != null)
			{
					sb.Append(prefix).Append("line2").Append("=").Append(HttpUtility.UrlEncode(this.line2, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.city != null)
			{
					sb.Append(prefix).Append("city").Append("=").Append(HttpUtility.UrlEncode(this.city, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.state != null)
			{
					sb.Append(prefix).Append("state").Append("=").Append(HttpUtility.UrlEncode(this.state, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.postalCode != null)
			{
					sb.Append(prefix).Append("postalCode").Append("=").Append(HttpUtility.UrlEncode(this.postalCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.countryCode != null)
			{
					sb.Append(prefix).Append("countryCode").Append("=").Append(HttpUtility.UrlEncode(this.countryCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.type != null)
			{
					sb.Append(prefix).Append("type").Append("=").Append(HttpUtility.UrlEncode(this.type, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new BaseAddress object created from the passed in NVP map
	 	/// </returns>
		public static BaseAddress CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			BaseAddress baseAddress = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "line1";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.line1 = map[key];
			}
			key = prefix + "line2";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.line2 = map[key];
			}
			key = prefix + "city";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.city = map[key];
			}
			key = prefix + "state";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.state = map[key];
			}
			key = prefix + "postalCode";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.postalCode = map[key];
			}
			key = prefix + "countryCode";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.countryCode = map[key];
			}
			key = prefix + "type";
			if (map.ContainsKey(key))
			{
				baseAddress = (baseAddress == null) ? new BaseAddress() : baseAddress;
				baseAddress.type = map[key];
			}
			return baseAddress;
		}
	}




	/// <summary>
	/// Details about the end user of the application invoking this
	/// service. 
    /// </summary>
	public partial class ClientDetailsType	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string ipAddressField;
		public string ipAddress
		{
			get
			{
				return this.ipAddressField;
			}
			set
			{
				this.ipAddressField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string deviceIdField;
		public string deviceId
		{
			get
			{
				return this.deviceIdField;
			}
			set
			{
				this.deviceIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string applicationIdField;
		public string applicationId
		{
			get
			{
				return this.applicationIdField;
			}
			set
			{
				this.applicationIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string modelField;
		public string model
		{
			get
			{
				return this.modelField;
			}
			set
			{
				this.modelField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string geoLocationField;
		public string geoLocation
		{
			get
			{
				return this.geoLocationField;
			}
			set
			{
				this.geoLocationField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string customerTypeField;
		public string customerType
		{
			get
			{
				return this.customerTypeField;
			}
			set
			{
				this.customerTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string partnerNameField;
		public string partnerName
		{
			get
			{
				return this.partnerNameField;
			}
			set
			{
				this.partnerNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string customerIdField;
		public string customerId
		{
			get
			{
				return this.customerIdField;
			}
			set
			{
				this.customerIdField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ClientDetailsType()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.ipAddress != null)
			{
					sb.Append(prefix).Append("ipAddress").Append("=").Append(HttpUtility.UrlEncode(this.ipAddress, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.deviceId != null)
			{
					sb.Append(prefix).Append("deviceId").Append("=").Append(HttpUtility.UrlEncode(this.deviceId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.applicationId != null)
			{
					sb.Append(prefix).Append("applicationId").Append("=").Append(HttpUtility.UrlEncode(this.applicationId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.model != null)
			{
					sb.Append(prefix).Append("model").Append("=").Append(HttpUtility.UrlEncode(this.model, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.geoLocation != null)
			{
					sb.Append(prefix).Append("geoLocation").Append("=").Append(HttpUtility.UrlEncode(this.geoLocation, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.customerType != null)
			{
					sb.Append(prefix).Append("customerType").Append("=").Append(HttpUtility.UrlEncode(this.customerType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.partnerName != null)
			{
					sb.Append(prefix).Append("partnerName").Append("=").Append(HttpUtility.UrlEncode(this.partnerName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.customerId != null)
			{
					sb.Append(prefix).Append("customerId").Append("=").Append(HttpUtility.UrlEncode(this.customerId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class CurrencyType	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string codeField;
		public string code
		{
			get
			{
				return this.codeField;
			}
			set
			{
				this.codeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? amountField;
		public decimal? amount
		{
			get
			{
				return this.amountField;
			}
			set
			{
				this.amountField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public CurrencyType(string code, decimal? amount)
	 	{
			this.code = code;
			this.amount = amount;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CurrencyType()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.code != null)
			{
					sb.Append(prefix).Append("code").Append("=").Append(HttpUtility.UrlEncode(this.code, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.amount != null)
			{
					sb.Append(prefix).Append("amount").Append("=").Append(Convert.ToString(this.amount, DefaultCulture)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new CurrencyType object created from the passed in NVP map
	 	/// </returns>
		public static CurrencyType CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			CurrencyType currencyType = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "code";
			if (map.ContainsKey(key))
			{
				currencyType = (currencyType == null) ? new CurrencyType() : currencyType;
				currencyType.code = map[key];
			}
			key = prefix + "amount";
			if (map.ContainsKey(key))
			{
				currencyType = (currencyType == null) ? new CurrencyType() : currencyType;
				currencyType.amount = System.Convert.ToDecimal(map[key]);
			}
			return currencyType;
		}
	}




	/// <summary>
	/// This type contains the detailed error information resulting
	/// from the service operation. 
    /// </summary>
	public partial class ErrorData	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private int? errorIdField;
		public int? errorId
		{
			get
			{
				return this.errorIdField;
			}
			set
			{
				this.errorIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string domainField;
		public string domain
		{
			get
			{
				return this.domainField;
			}
			set
			{
				this.domainField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string subdomainField;
		public string subdomain
		{
			get
			{
				return this.subdomainField;
			}
			set
			{
				this.subdomainField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ErrorSeverity? severityField;
		public ErrorSeverity? severity
		{
			get
			{
				return this.severityField;
			}
			set
			{
				this.severityField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ErrorCategory? categoryField;
		public ErrorCategory? category
		{
			get
			{
				return this.categoryField;
			}
			set
			{
				this.categoryField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string messageField;
		public string message
		{
			get
			{
				return this.messageField;
			}
			set
			{
				this.messageField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string exceptionIdField;
		public string exceptionId
		{
			get
			{
				return this.exceptionIdField;
			}
			set
			{
				this.exceptionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorParameter> parameterField = new List<ErrorParameter>();
		public List<ErrorParameter> parameter
		{
			get
			{
				return this.parameterField;
			}
			set
			{
				this.parameterField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ErrorData()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ErrorData object created from the passed in NVP map
	 	/// </returns>
		public static ErrorData CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ErrorData errorData = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "errorId";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.errorId = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "domain";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.domain = map[key];
			}
			key = prefix + "subdomain";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.subdomain = map[key];
			}
			key = prefix + "severity";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.severity = (ErrorSeverity)EnumUtils.GetValue(map[key],typeof(ErrorSeverity));
			}
			key = prefix + "category";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.category = (ErrorCategory)EnumUtils.GetValue(map[key],typeof(ErrorCategory));
			}
			key = prefix + "message";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.message = map[key];
			}
			key = prefix + "exceptionId";
			if (map.ContainsKey(key))
			{
				errorData = (errorData == null) ? new ErrorData() : errorData;
				errorData.exceptionId = map[key];
			}
			i = 0;
			while(true)
			{
				ErrorParameter parameter =  ErrorParameter.CreateInstance(map, prefix + "parameter", i);
				if (parameter != null)
				{
					errorData = (errorData == null) ? new ErrorData() : errorData;
					errorData.parameter.Add(parameter);
					i++;
				} 
				else
				{
					break;
				}
			}
			return errorData;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class ErrorParameter	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string nameField;
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string valueField;
		public string value
		{
			get
			{
				return this.valueField;
			}
			set
			{
				this.valueField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ErrorParameter()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ErrorParameter object created from the passed in NVP map
	 	/// </returns>
		public static ErrorParameter CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ErrorParameter errorParameter = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "name";
			if (map.ContainsKey(key))
			{
				errorParameter = (errorParameter == null) ? new ErrorParameter() : errorParameter;
				errorParameter.name = map[key];
			}
			key = prefix.Substring(0, prefix.Length - 1);
			if (map.ContainsKey(key))
			{
				errorParameter = (errorParameter == null) ? new ErrorParameter() : errorParameter;
				errorParameter.value = map[key];
			}
			return errorParameter;
		}
	}




	/// <summary>
	/// This specifies a fault, encapsulating error data, with
	/// specific error codes. 
    /// </summary>
	public partial class FaultMessage	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FaultMessage()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FaultMessage object created from the passed in NVP map
	 	/// </returns>
		public static FaultMessage CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FaultMessage faultMessage = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				faultMessage = (faultMessage == null) ? new FaultMessage() : faultMessage;
				faultMessage.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					faultMessage = (faultMessage == null) ? new FaultMessage() : faultMessage;
					faultMessage.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return faultMessage;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class PhoneNumberType	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string countryCodeField;
		public string countryCode
		{
			get
			{
				return this.countryCodeField;
			}
			set
			{
				this.countryCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string phoneNumberField;
		public string phoneNumber
		{
			get
			{
				return this.phoneNumberField;
			}
			set
			{
				this.phoneNumberField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string extensionField;
		public string extension
		{
			get
			{
				return this.extensionField;
			}
			set
			{
				this.extensionField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public PhoneNumberType(string countryCode, string phoneNumber)
	 	{
			this.countryCode = countryCode;
			this.phoneNumber = phoneNumber;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PhoneNumberType()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.countryCode != null)
			{
					sb.Append(prefix).Append("countryCode").Append("=").Append(HttpUtility.UrlEncode(this.countryCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.phoneNumber != null)
			{
					sb.Append(prefix).Append("phoneNumber").Append("=").Append(HttpUtility.UrlEncode(this.phoneNumber, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.extension != null)
			{
					sb.Append(prefix).Append("extension").Append("=").Append(HttpUtility.UrlEncode(this.extension, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PhoneNumberType object created from the passed in NVP map
	 	/// </returns>
		public static PhoneNumberType CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PhoneNumberType phoneNumberType = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "countryCode";
			if (map.ContainsKey(key))
			{
				phoneNumberType = (phoneNumberType == null) ? new PhoneNumberType() : phoneNumberType;
				phoneNumberType.countryCode = map[key];
			}
			key = prefix + "phoneNumber";
			if (map.ContainsKey(key))
			{
				phoneNumberType = (phoneNumberType == null) ? new PhoneNumberType() : phoneNumberType;
				phoneNumberType.phoneNumber = map[key];
			}
			key = prefix + "extension";
			if (map.ContainsKey(key))
			{
				phoneNumberType = (phoneNumberType == null) ? new PhoneNumberType() : phoneNumberType;
				phoneNumberType.extension = map[key];
			}
			return phoneNumberType;
		}
	}




	/// <summary>
	/// This specifies the list of parameters with every request to
	/// the service. 
    /// </summary>
	public partial class RequestEnvelope	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private DetailLevelCode? detailLevelField;
		public DetailLevelCode? detailLevel
		{
			get
			{
				return this.detailLevelField;
			}
			set
			{
				this.detailLevelField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string errorLanguageField;
		public string errorLanguage
		{
			get
			{
				return this.errorLanguageField;
			}
			set
			{
				this.errorLanguageField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public RequestEnvelope(string errorLanguage)
	 	{
			this.errorLanguage = errorLanguage;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public RequestEnvelope()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.detailLevel != null)
			{
					sb.Append(prefix).Append("detailLevel").Append("=").Append(EnumUtils.GetDescription(this.detailLevel));
					sb.Append("&");
			}
			if (this.errorLanguage != null)
			{
					sb.Append(prefix).Append("errorLanguage").Append("=").Append(HttpUtility.UrlEncode(this.errorLanguage, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// This specifies a list of parameters with every response from
	/// a service. 
    /// </summary>
	public partial class ResponseEnvelope	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string timestampField;
		public string timestamp
		{
			get
			{
				return this.timestampField;
			}
			set
			{
				this.timestampField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private AckCode? ackField;
		public AckCode? ack
		{
			get
			{
				return this.ackField;
			}
			set
			{
				this.ackField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string correlationIdField;
		public string correlationId
		{
			get
			{
				return this.correlationIdField;
			}
			set
			{
				this.correlationIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string buildField;
		public string build
		{
			get
			{
				return this.buildField;
			}
			set
			{
				this.buildField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ResponseEnvelope()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ResponseEnvelope object created from the passed in NVP map
	 	/// </returns>
		public static ResponseEnvelope CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ResponseEnvelope responseEnvelope = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "timestamp";
			if (map.ContainsKey(key))
			{
				responseEnvelope = (responseEnvelope == null) ? new ResponseEnvelope() : responseEnvelope;
				responseEnvelope.timestamp = map[key];
			}
			key = prefix + "ack";
			if (map.ContainsKey(key))
			{
				responseEnvelope = (responseEnvelope == null) ? new ResponseEnvelope() : responseEnvelope;
				responseEnvelope.ack = (AckCode)EnumUtils.GetValue(map[key],typeof(AckCode));
			}
			key = prefix + "correlationId";
			if (map.ContainsKey(key))
			{
				responseEnvelope = (responseEnvelope == null) ? new ResponseEnvelope() : responseEnvelope;
				responseEnvelope.correlationId = map[key];
			}
			key = prefix + "build";
			if (map.ContainsKey(key))
			{
				responseEnvelope = (responseEnvelope == null) ? new ResponseEnvelope() : responseEnvelope;
				responseEnvelope.build = map[key];
			}
			return responseEnvelope;
		}
	}




	/// <summary>
	/// AckCodeType This code identifies the
	///  acknowledgment code types that could be used to
	///  communicate the status of processing a (request)
	///  message to an application. This code would be
	///  used as part of a response message that contains
	///  an application level acknowledgment element.
	///  
	/// </summary>
    [Serializable]
	public enum AckCode {
		[Description("Success")]SUCCESS,	
		[Description("Failure")]FAILURE,	
		[Description("Warning")]WARNING,	
		[Description("SuccessWithWarning")]SUCCESSWITHWARNING,	
		[Description("FailureWithWarning")]FAILUREWITHWARNING	
	}




	/// <summary>
	/// 
	/// </summary>
    [Serializable]
	public enum DayOfWeek {
		[Description("NO_DAY_SPECIFIED")]NODAYSPECIFIED,	
		[Description("SUNDAY")]SUNDAY,	
		[Description("MONDAY")]MONDAY,	
		[Description("TUESDAY")]TUESDAY,	
		[Description("WEDNESDAY")]WEDNESDAY,	
		[Description("THURSDAY")]THURSDAY,	
		[Description("FRIDAY")]FRIDAY,	
		[Description("SATURDAY")]SATURDAY	
	}




	/// <summary>
	/// DetailLevelCodeType
	///  
	/// </summary>
    [Serializable]
	public enum DetailLevelCode {
		[Description("ReturnAll")]RETURNALL	
	}




	/// <summary>
	/// 
	/// </summary>
    [Serializable]
	public enum ErrorCategory {
		[Description("System")]SYSTEM,	
		[Description("Application")]APPLICATION,	
		[Description("Request")]REQUEST	
	}




	/// <summary>
	/// 
	/// </summary>
    [Serializable]
	public enum ErrorSeverity {
		[Description("Error")]ERROR,	
		[Description("Warning")]WARNING	
	}




	/// <summary>
	/// 
	/// </summary>
    [Serializable]
	public enum Status {
		[Description("RTR")]RTR,	
		[Description("NON_RTR")]NONRTR,	
		[Description("MISSING_RECEIVER_COUNTRY_INFORMATION")]MISSINGRECEIVERCOUNTRYINFORMATION	
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class Address	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string addresseeNameField;
		public string addresseeName
		{
			get
			{
				return this.addresseeNameField;
			}
			set
			{
				this.addresseeNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private BaseAddress baseAddressField;
		public BaseAddress baseAddress
		{
			get
			{
				return this.baseAddressField;
			}
			set
			{
				this.baseAddressField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string addressIdField;
		public string addressId
		{
			get
			{
				return this.addressIdField;
			}
			set
			{
				this.addressIdField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public Address()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new Address object created from the passed in NVP map
	 	/// </returns>
		public static Address CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			Address address = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "addresseeName";
			if (map.ContainsKey(key))
			{
				address = (address == null) ? new Address() : address;
				address.addresseeName = map[key];
			}
			BaseAddress baseAddress =  BaseAddress.CreateInstance(map, prefix + "baseAddress", -1);
			if (baseAddress != null)
			{
				address = (address == null) ? new Address() : address;
				address.baseAddress = baseAddress;
			}
			key = prefix + "addressId";
			if (map.ContainsKey(key))
			{
				address = (address == null) ? new Address() : address;
				address.addressId = map[key];
			}
			return address;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class AddressList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<Address> addressField = new List<Address>();
		public List<Address> address
		{
			get
			{
				return this.addressField;
			}
			set
			{
				this.addressField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public AddressList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new AddressList object created from the passed in NVP map
	 	/// </returns>
		public static AddressList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			AddressList addressList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				Address address =  Address.CreateInstance(map, prefix + "address", i);
				if (address != null)
				{
					addressList = (addressList == null) ? new AddressList() : addressList;
					addressList.address.Add(address);
					i++;
				} 
				else
				{
					break;
				}
			}
			return addressList;
		}
	}




	/// <summary>
	/// A list of ISO currency codes. 
    /// </summary>
	public partial class CurrencyCodeList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<string> currencyCodeField = new List<string>();
		public List<string> currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public CurrencyCodeList(List<string> currencyCode)
	 	{
			this.currencyCode = currencyCode;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CurrencyCodeList()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.currencyCode.Count; i++)
			{
				if (this.currencyCode[i] != null)
				{
					sb.Append(prefix).Append("currencyCode").Append("(").Append(i).Append(")").Append("=").Append(HttpUtility.UrlEncode(this.currencyCode[i], BaseConstants.ENCODING_FORMAT)).Append("&");
				}
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// A list of estimated currency conversions for a base
	/// currency. 
    /// </summary>
	public partial class CurrencyConversionList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType baseAmountField;
		public CurrencyType baseAmount
		{
			get
			{
				return this.baseAmountField;
			}
			set
			{
				this.baseAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyList currencyListField;
		public CurrencyList currencyList
		{
			get
			{
				return this.currencyListField;
			}
			set
			{
				this.currencyListField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CurrencyConversionList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new CurrencyConversionList object created from the passed in NVP map
	 	/// </returns>
		public static CurrencyConversionList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			CurrencyConversionList currencyConversionList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			CurrencyType baseAmount =  CurrencyType.CreateInstance(map, prefix + "baseAmount", -1);
			if (baseAmount != null)
			{
				currencyConversionList = (currencyConversionList == null) ? new CurrencyConversionList() : currencyConversionList;
				currencyConversionList.baseAmount = baseAmount;
			}
			CurrencyList currencyList =  CurrencyList.CreateInstance(map, prefix + "currencyList", -1);
			if (currencyList != null)
			{
				currencyConversionList = (currencyConversionList == null) ? new CurrencyConversionList() : currencyConversionList;
				currencyConversionList.currencyList = currencyList;
			}
			return currencyConversionList;
		}
	}




	/// <summary>
	/// A table that contains a list of estimated currency
	/// conversions for a base currency in each row. 
    /// </summary>
	public partial class CurrencyConversionTable	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<CurrencyConversionList> currencyConversionListField = new List<CurrencyConversionList>();
		public List<CurrencyConversionList> currencyConversionList
		{
			get
			{
				return this.currencyConversionListField;
			}
			set
			{
				this.currencyConversionListField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CurrencyConversionTable()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new CurrencyConversionTable object created from the passed in NVP map
	 	/// </returns>
		public static CurrencyConversionTable CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			CurrencyConversionTable currencyConversionTable = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				CurrencyConversionList currencyConversionList =  CurrencyConversionList.CreateInstance(map, prefix + "currencyConversionList", i);
				if (currencyConversionList != null)
				{
					currencyConversionTable = (currencyConversionTable == null) ? new CurrencyConversionTable() : currencyConversionTable;
					currencyConversionTable.currencyConversionList.Add(currencyConversionList);
					i++;
				} 
				else
				{
					break;
				}
			}
			return currencyConversionTable;
		}
	}




	/// <summary>
	/// A list of ISO currencies. 
    /// </summary>
	public partial class CurrencyList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<CurrencyType> currencyField = new List<CurrencyType>();
		public List<CurrencyType> currency
		{
			get
			{
				return this.currencyField;
			}
			set
			{
				this.currencyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public CurrencyList(List<CurrencyType> currency)
	 	{
			this.currency = currency;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CurrencyList()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.currency.Count; i++)
			{
				if (this.currency[i] != null)
				{
					string newPrefix = prefix + "currency" + "(" + i + ").";
					sb.Append(this.currency[i].ToNVPString(newPrefix));
				}
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new CurrencyList object created from the passed in NVP map
	 	/// </returns>
		public static CurrencyList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			CurrencyList currencyList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				CurrencyType currency =  CurrencyType.CreateInstance(map, prefix + "currency", i);
				if (currency != null)
				{
					currencyList = (currencyList == null) ? new CurrencyList() : currencyList;
					currencyList.currency.Add(currency);
					i++;
				} 
				else
				{
					break;
				}
			}
			return currencyList;
		}
	}




	/// <summary>
	/// Customizable options that a client application can specify
	/// for display purposes. 
    /// </summary>
	public partial class DisplayOptions	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string emailHeaderImageUrlField;
		public string emailHeaderImageUrl
		{
			get
			{
				return this.emailHeaderImageUrlField;
			}
			set
			{
				this.emailHeaderImageUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string emailMarketingImageUrlField;
		public string emailMarketingImageUrl
		{
			get
			{
				return this.emailMarketingImageUrlField;
			}
			set
			{
				this.emailMarketingImageUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string headerImageUrlField;
		public string headerImageUrl
		{
			get
			{
				return this.headerImageUrlField;
			}
			set
			{
				this.headerImageUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string businessNameField;
		public string businessName
		{
			get
			{
				return this.businessNameField;
			}
			set
			{
				this.businessNameField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public DisplayOptions()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.emailHeaderImageUrl != null)
			{
					sb.Append(prefix).Append("emailHeaderImageUrl").Append("=").Append(HttpUtility.UrlEncode(this.emailHeaderImageUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.emailMarketingImageUrl != null)
			{
					sb.Append(prefix).Append("emailMarketingImageUrl").Append("=").Append(HttpUtility.UrlEncode(this.emailMarketingImageUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.headerImageUrl != null)
			{
					sb.Append(prefix).Append("headerImageUrl").Append("=").Append(HttpUtility.UrlEncode(this.headerImageUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.businessName != null)
			{
					sb.Append(prefix).Append("businessName").Append("=").Append(HttpUtility.UrlEncode(this.businessName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new DisplayOptions object created from the passed in NVP map
	 	/// </returns>
		public static DisplayOptions CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			DisplayOptions displayOptions = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "emailHeaderImageUrl";
			if (map.ContainsKey(key))
			{
				displayOptions = (displayOptions == null) ? new DisplayOptions() : displayOptions;
				displayOptions.emailHeaderImageUrl = map[key];
			}
			key = prefix + "emailMarketingImageUrl";
			if (map.ContainsKey(key))
			{
				displayOptions = (displayOptions == null) ? new DisplayOptions() : displayOptions;
				displayOptions.emailMarketingImageUrl = map[key];
			}
			key = prefix + "headerImageUrl";
			if (map.ContainsKey(key))
			{
				displayOptions = (displayOptions == null) ? new DisplayOptions() : displayOptions;
				displayOptions.headerImageUrl = map[key];
			}
			key = prefix + "businessName";
			if (map.ContainsKey(key))
			{
				displayOptions = (displayOptions == null) ? new DisplayOptions() : displayOptions;
				displayOptions.businessName = map[key];
			}
			return displayOptions;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class ErrorList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ErrorList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ErrorList object created from the passed in NVP map
	 	/// </returns>
		public static ErrorList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ErrorList errorList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					errorList = (errorList == null) ? new ErrorList() : errorList;
					errorList.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return errorList;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class FundingConstraint	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private FundingTypeList allowedFundingTypeField;
		public FundingTypeList allowedFundingType
		{
			get
			{
				return this.allowedFundingTypeField;
			}
			set
			{
				this.allowedFundingTypeField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FundingConstraint()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.allowedFundingType != null)
			{
					string newPrefix = prefix + "allowedFundingType" + ".";
					sb.Append(this.allowedFundingTypeField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FundingConstraint object created from the passed in NVP map
	 	/// </returns>
		public static FundingConstraint CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FundingConstraint fundingConstraint = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			FundingTypeList allowedFundingType =  FundingTypeList.CreateInstance(map, prefix + "allowedFundingType", -1);
			if (allowedFundingType != null)
			{
				fundingConstraint = (fundingConstraint == null) ? new FundingConstraint() : fundingConstraint;
				fundingConstraint.allowedFundingType = allowedFundingType;
			}
			return fundingConstraint;
		}
	}




	/// <summary>
	/// FundingTypeInfo represents one allowed funding type. 
    /// </summary>
	public partial class FundingTypeInfo	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string fundingTypeField;
		public string fundingType
		{
			get
			{
				return this.fundingTypeField;
			}
			set
			{
				this.fundingTypeField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public FundingTypeInfo(string fundingType)
	 	{
			this.fundingType = fundingType;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FundingTypeInfo()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.fundingType != null)
			{
					sb.Append(prefix).Append("fundingType").Append("=").Append(HttpUtility.UrlEncode(this.fundingType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FundingTypeInfo object created from the passed in NVP map
	 	/// </returns>
		public static FundingTypeInfo CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FundingTypeInfo fundingTypeInfo = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "fundingType";
			if (map.ContainsKey(key))
			{
				fundingTypeInfo = (fundingTypeInfo == null) ? new FundingTypeInfo() : fundingTypeInfo;
				fundingTypeInfo.fundingType = map[key];
			}
			return fundingTypeInfo;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class FundingTypeList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<FundingTypeInfo> fundingTypeInfoField = new List<FundingTypeInfo>();
		public List<FundingTypeInfo> fundingTypeInfo
		{
			get
			{
				return this.fundingTypeInfoField;
			}
			set
			{
				this.fundingTypeInfoField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public FundingTypeList(List<FundingTypeInfo> fundingTypeInfo)
	 	{
			this.fundingTypeInfo = fundingTypeInfo;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FundingTypeList()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.fundingTypeInfo.Count; i++)
			{
				if (this.fundingTypeInfo[i] != null)
				{
					string newPrefix = prefix + "fundingTypeInfo" + "(" + i + ").";
					sb.Append(this.fundingTypeInfo[i].ToNVPString(newPrefix));
				}
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FundingTypeList object created from the passed in NVP map
	 	/// </returns>
		public static FundingTypeList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FundingTypeList fundingTypeList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				FundingTypeInfo fundingTypeInfo =  FundingTypeInfo.CreateInstance(map, prefix + "fundingTypeInfo", i);
				if (fundingTypeInfo != null)
				{
					fundingTypeList = (fundingTypeList == null) ? new FundingTypeList() : fundingTypeList;
					fundingTypeList.fundingTypeInfo.Add(fundingTypeInfo);
					i++;
				} 
				else
				{
					break;
				}
			}
			return fundingTypeList;
		}
	}




	/// <summary>
	/// Describes the conversion between 2 currencies. 
    /// </summary>
	public partial class CurrencyConversion	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType fromField;
		public CurrencyType from
		{
			get
			{
				return this.fromField;
			}
			set
			{
				this.fromField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType toField;
		public CurrencyType to
		{
			get
			{
				return this.toField;
			}
			set
			{
				this.toField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? exchangeRateField;
		public decimal? exchangeRate
		{
			get
			{
				return this.exchangeRateField;
			}
			set
			{
				this.exchangeRateField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CurrencyConversion()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new CurrencyConversion object created from the passed in NVP map
	 	/// </returns>
		public static CurrencyConversion CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			CurrencyConversion currencyConversion = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			CurrencyType from =  CurrencyType.CreateInstance(map, prefix + "from", -1);
			if (from != null)
			{
				currencyConversion = (currencyConversion == null) ? new CurrencyConversion() : currencyConversion;
				currencyConversion.from = from;
			}
			CurrencyType to =  CurrencyType.CreateInstance(map, prefix + "to", -1);
			if (to != null)
			{
				currencyConversion = (currencyConversion == null) ? new CurrencyConversion() : currencyConversion;
				currencyConversion.to = to;
			}
			key = prefix + "exchangeRate";
			if (map.ContainsKey(key))
			{
				currencyConversion = (currencyConversion == null) ? new CurrencyConversion() : currencyConversion;
				currencyConversion.exchangeRate = System.Convert.ToDecimal(map[key]);
			}
			return currencyConversion;
		}
	}




	/// <summary>
	/// Funding source information. 
    /// </summary>
	public partial class FundingSource	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string lastFourOfAccountNumberField;
		public string lastFourOfAccountNumber
		{
			get
			{
				return this.lastFourOfAccountNumberField;
			}
			set
			{
				this.lastFourOfAccountNumberField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string typeField;
		public string type
		{
			get
			{
				return this.typeField;
			}
			set
			{
				this.typeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string displayNameField;
		public string displayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string fundingSourceIdField;
		public string fundingSourceId
		{
			get
			{
				return this.fundingSourceIdField;
			}
			set
			{
				this.fundingSourceIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? allowedField;
		public bool? allowed
		{
			get
			{
				return this.allowedField;
			}
			set
			{
				this.allowedField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FundingSource()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FundingSource object created from the passed in NVP map
	 	/// </returns>
		public static FundingSource CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FundingSource fundingSource = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "lastFourOfAccountNumber";
			if (map.ContainsKey(key))
			{
				fundingSource = (fundingSource == null) ? new FundingSource() : fundingSource;
				fundingSource.lastFourOfAccountNumber = map[key];
			}
			key = prefix + "type";
			if (map.ContainsKey(key))
			{
				fundingSource = (fundingSource == null) ? new FundingSource() : fundingSource;
				fundingSource.type = map[key];
			}
			key = prefix + "displayName";
			if (map.ContainsKey(key))
			{
				fundingSource = (fundingSource == null) ? new FundingSource() : fundingSource;
				fundingSource.displayName = map[key];
			}
			key = prefix + "fundingSourceId";
			if (map.ContainsKey(key))
			{
				fundingSource = (fundingSource == null) ? new FundingSource() : fundingSource;
				fundingSource.fundingSourceId = map[key];
			}
			key = prefix + "allowed";
			if (map.ContainsKey(key))
			{
				fundingSource = (fundingSource == null) ? new FundingSource() : fundingSource;
				fundingSource.allowed = System.Convert.ToBoolean(map[key]);
			}
			return fundingSource;
		}
	}




	/// <summary>
	/// Amount to be charged to a particular funding source. 
    /// </summary>
	public partial class FundingPlanCharge	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType chargeField;
		public CurrencyType charge
		{
			get
			{
				return this.chargeField;
			}
			set
			{
				this.chargeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FundingSource fundingSourceField;
		public FundingSource fundingSource
		{
			get
			{
				return this.fundingSourceField;
			}
			set
			{
				this.fundingSourceField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FundingPlanCharge()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FundingPlanCharge object created from the passed in NVP map
	 	/// </returns>
		public static FundingPlanCharge CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FundingPlanCharge fundingPlanCharge = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			CurrencyType charge =  CurrencyType.CreateInstance(map, prefix + "charge", -1);
			if (charge != null)
			{
				fundingPlanCharge = (fundingPlanCharge == null) ? new FundingPlanCharge() : fundingPlanCharge;
				fundingPlanCharge.charge = charge;
			}
			FundingSource fundingSource =  FundingSource.CreateInstance(map, prefix + "fundingSource", -1);
			if (fundingSource != null)
			{
				fundingPlanCharge = (fundingPlanCharge == null) ? new FundingPlanCharge() : fundingPlanCharge;
				fundingPlanCharge.fundingSource = fundingSource;
			}
			return fundingPlanCharge;
		}
	}




	/// <summary>
	/// FundingPlan describes the funding sources to be used for a
	/// specific payment. 
    /// </summary>
	public partial class FundingPlan	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string fundingPlanIdField;
		public string fundingPlanId
		{
			get
			{
				return this.fundingPlanIdField;
			}
			set
			{
				this.fundingPlanIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType fundingAmountField;
		public CurrencyType fundingAmount
		{
			get
			{
				return this.fundingAmountField;
			}
			set
			{
				this.fundingAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FundingSource backupFundingSourceField;
		public FundingSource backupFundingSource
		{
			get
			{
				return this.backupFundingSourceField;
			}
			set
			{
				this.backupFundingSourceField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType senderFeesField;
		public CurrencyType senderFees
		{
			get
			{
				return this.senderFeesField;
			}
			set
			{
				this.senderFeesField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyConversion currencyConversionField;
		public CurrencyConversion currencyConversion
		{
			get
			{
				return this.currencyConversionField;
			}
			set
			{
				this.currencyConversionField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<FundingPlanCharge> chargeField = new List<FundingPlanCharge>();
		public List<FundingPlanCharge> charge
		{
			get
			{
				return this.chargeField;
			}
			set
			{
				this.chargeField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FundingPlan()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FundingPlan object created from the passed in NVP map
	 	/// </returns>
		public static FundingPlan CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FundingPlan fundingPlan = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "fundingPlanId";
			if (map.ContainsKey(key))
			{
				fundingPlan = (fundingPlan == null) ? new FundingPlan() : fundingPlan;
				fundingPlan.fundingPlanId = map[key];
			}
			CurrencyType fundingAmount =  CurrencyType.CreateInstance(map, prefix + "fundingAmount", -1);
			if (fundingAmount != null)
			{
				fundingPlan = (fundingPlan == null) ? new FundingPlan() : fundingPlan;
				fundingPlan.fundingAmount = fundingAmount;
			}
			FundingSource backupFundingSource =  FundingSource.CreateInstance(map, prefix + "backupFundingSource", -1);
			if (backupFundingSource != null)
			{
				fundingPlan = (fundingPlan == null) ? new FundingPlan() : fundingPlan;
				fundingPlan.backupFundingSource = backupFundingSource;
			}
			CurrencyType senderFees =  CurrencyType.CreateInstance(map, prefix + "senderFees", -1);
			if (senderFees != null)
			{
				fundingPlan = (fundingPlan == null) ? new FundingPlan() : fundingPlan;
				fundingPlan.senderFees = senderFees;
			}
			CurrencyConversion currencyConversion =  CurrencyConversion.CreateInstance(map, prefix + "currencyConversion", -1);
			if (currencyConversion != null)
			{
				fundingPlan = (fundingPlan == null) ? new FundingPlan() : fundingPlan;
				fundingPlan.currencyConversion = currencyConversion;
			}
			i = 0;
			while(true)
			{
				FundingPlanCharge charge =  FundingPlanCharge.CreateInstance(map, prefix + "charge", i);
				if (charge != null)
				{
					fundingPlan = (fundingPlan == null) ? new FundingPlan() : fundingPlan;
					fundingPlan.charge.Add(charge);
					i++;
				} 
				else
				{
					break;
				}
			}
			return fundingPlan;
		}
	}




	/// <summary>
	/// Details about the party that initiated this payment. The API
	/// user is making this payment on behalf of the initiator. The
	/// initiator can simply be an institution or a customer of the
	/// institution. 
    /// </summary>
	public partial class InitiatingEntity	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private InstitutionCustomer institutionCustomerField;
		public InstitutionCustomer institutionCustomer
		{
			get
			{
				return this.institutionCustomerField;
			}
			set
			{
				this.institutionCustomerField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public InitiatingEntity()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.institutionCustomer != null)
			{
					string newPrefix = prefix + "institutionCustomer" + ".";
					sb.Append(this.institutionCustomerField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new InitiatingEntity object created from the passed in NVP map
	 	/// </returns>
		public static InitiatingEntity CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			InitiatingEntity initiatingEntity = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			InstitutionCustomer institutionCustomer =  InstitutionCustomer.CreateInstance(map, prefix + "institutionCustomer", -1);
			if (institutionCustomer != null)
			{
				initiatingEntity = (initiatingEntity == null) ? new InitiatingEntity() : initiatingEntity;
				initiatingEntity.institutionCustomer = institutionCustomer;
			}
			return initiatingEntity;
		}
	}




	/// <summary>
	/// The customer of the initiating institution 
    /// </summary>
	public partial class InstitutionCustomer	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string institutionIdField;
		public string institutionId
		{
			get
			{
				return this.institutionIdField;
			}
			set
			{
				this.institutionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string firstNameField;
		public string firstName
		{
			get
			{
				return this.firstNameField;
			}
			set
			{
				this.firstNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string lastNameField;
		public string lastName
		{
			get
			{
				return this.lastNameField;
			}
			set
			{
				this.lastNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string middleNameField;
		public string middleName
		{
			get
			{
				return this.middleNameField;
			}
			set
			{
				this.middleNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string displayNameField;
		public string displayName
		{
			get
			{
				return this.displayNameField;
			}
			set
			{
				this.displayNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string institutionCustomerIdField;
		public string institutionCustomerId
		{
			get
			{
				return this.institutionCustomerIdField;
			}
			set
			{
				this.institutionCustomerIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string countryCodeField;
		public string countryCode
		{
			get
			{
				return this.countryCodeField;
			}
			set
			{
				this.countryCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string emailField;
		public string email
		{
			get
			{
				return this.emailField;
			}
			set
			{
				this.emailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string dateOfBirthField;
		public string dateOfBirth
		{
			get
			{
				return this.dateOfBirthField;
			}
			set
			{
				this.dateOfBirthField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private BaseAddress addressField;
		public BaseAddress address
		{
			get
			{
				return this.addressField;
			}
			set
			{
				this.addressField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public InstitutionCustomer(string institutionId, string firstName, string lastName, string displayName, string institutionCustomerId, string countryCode)
	 	{
			this.institutionId = institutionId;
			this.firstName = firstName;
			this.lastName = lastName;
			this.displayName = displayName;
			this.institutionCustomerId = institutionCustomerId;
			this.countryCode = countryCode;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public InstitutionCustomer()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.institutionId != null)
			{
					sb.Append(prefix).Append("institutionId").Append("=").Append(HttpUtility.UrlEncode(this.institutionId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.firstName != null)
			{
					sb.Append(prefix).Append("firstName").Append("=").Append(HttpUtility.UrlEncode(this.firstName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.lastName != null)
			{
					sb.Append(prefix).Append("lastName").Append("=").Append(HttpUtility.UrlEncode(this.lastName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.middleName != null)
			{
					sb.Append(prefix).Append("middleName").Append("=").Append(HttpUtility.UrlEncode(this.middleName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.displayName != null)
			{
					sb.Append(prefix).Append("displayName").Append("=").Append(HttpUtility.UrlEncode(this.displayName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.institutionCustomerId != null)
			{
					sb.Append(prefix).Append("institutionCustomerId").Append("=").Append(HttpUtility.UrlEncode(this.institutionCustomerId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.countryCode != null)
			{
					sb.Append(prefix).Append("countryCode").Append("=").Append(HttpUtility.UrlEncode(this.countryCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.email != null)
			{
					sb.Append(prefix).Append("email").Append("=").Append(HttpUtility.UrlEncode(this.email, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.dateOfBirth != null)
			{
					sb.Append(prefix).Append("dateOfBirth").Append("=").Append(this.dateOfBirth).Append("&");
			}
			if (this.address != null)
			{
					string newPrefix = prefix + "address" + ".";
					sb.Append(this.addressField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new InstitutionCustomer object created from the passed in NVP map
	 	/// </returns>
		public static InstitutionCustomer CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			InstitutionCustomer institutionCustomer = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "institutionId";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.institutionId = map[key];
			}
			key = prefix + "firstName";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.firstName = map[key];
			}
			key = prefix + "lastName";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.lastName = map[key];
			}
			key = prefix + "middleName";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.middleName = map[key];
			}
			key = prefix + "displayName";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.displayName = map[key];
			}
			key = prefix + "institutionCustomerId";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.institutionCustomerId = map[key];
			}
			key = prefix + "countryCode";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.countryCode = map[key];
			}
			key = prefix + "email";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.email = map[key];
			}
			key = prefix + "dateOfBirth";
			if (map.ContainsKey(key))
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.dateOfBirth = map[key];
			}
			BaseAddress address =  BaseAddress.CreateInstance(map, prefix + "address", -1);
			if (address != null)
			{
				institutionCustomer = (institutionCustomer == null) ? new InstitutionCustomer() : institutionCustomer;
				institutionCustomer.address = address;
			}
			return institutionCustomer;
		}
	}




	/// <summary>
	/// Describes an individual item for an invoice. 
    /// </summary>
	public partial class InvoiceItem	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string nameField;
		public string name
		{
			get
			{
				return this.nameField;
			}
			set
			{
				this.nameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string identifierField;
		public string identifier
		{
			get
			{
				return this.identifierField;
			}
			set
			{
				this.identifierField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? priceField;
		public decimal? price
		{
			get
			{
				return this.priceField;
			}
			set
			{
				this.priceField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? itemPriceField;
		public decimal? itemPrice
		{
			get
			{
				return this.itemPriceField;
			}
			set
			{
				this.itemPriceField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? itemCountField;
		public int? itemCount
		{
			get
			{
				return this.itemCountField;
			}
			set
			{
				this.itemCountField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public InvoiceItem()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.name != null)
			{
					sb.Append(prefix).Append("name").Append("=").Append(HttpUtility.UrlEncode(this.name, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.identifier != null)
			{
					sb.Append(prefix).Append("identifier").Append("=").Append(HttpUtility.UrlEncode(this.identifier, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.price != null)
			{
					sb.Append(prefix).Append("price").Append("=").Append(Convert.ToString(this.price, DefaultCulture)).Append("&");
			}
			if (this.itemPrice != null)
			{
					sb.Append(prefix).Append("itemPrice").Append("=").Append(Convert.ToString(this.itemPrice, DefaultCulture)).Append("&");
			}
			if (this.itemCount != null)
			{
					sb.Append(prefix).Append("itemCount").Append("=").Append(this.itemCount).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new InvoiceItem object created from the passed in NVP map
	 	/// </returns>
		public static InvoiceItem CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			InvoiceItem invoiceItem = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "name";
			if (map.ContainsKey(key))
			{
				invoiceItem = (invoiceItem == null) ? new InvoiceItem() : invoiceItem;
				invoiceItem.name = map[key];
			}
			key = prefix + "identifier";
			if (map.ContainsKey(key))
			{
				invoiceItem = (invoiceItem == null) ? new InvoiceItem() : invoiceItem;
				invoiceItem.identifier = map[key];
			}
			key = prefix + "price";
			if (map.ContainsKey(key))
			{
				invoiceItem = (invoiceItem == null) ? new InvoiceItem() : invoiceItem;
				invoiceItem.price = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "itemPrice";
			if (map.ContainsKey(key))
			{
				invoiceItem = (invoiceItem == null) ? new InvoiceItem() : invoiceItem;
				invoiceItem.itemPrice = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "itemCount";
			if (map.ContainsKey(key))
			{
				invoiceItem = (invoiceItem == null) ? new InvoiceItem() : invoiceItem;
				invoiceItem.itemCount = System.Convert.ToInt32(map[key]);
			}
			return invoiceItem;
		}
	}




	/// <summary>
	/// Describes a payment for a particular receiver (merchant),
	/// contains list of additional per item details. 
    /// </summary>
	public partial class InvoiceData	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<InvoiceItem> itemField = new List<InvoiceItem>();
		public List<InvoiceItem> item
		{
			get
			{
				return this.itemField;
			}
			set
			{
				this.itemField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? totalTaxField;
		public decimal? totalTax
		{
			get
			{
				return this.totalTaxField;
			}
			set
			{
				this.totalTaxField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? totalShippingField;
		public decimal? totalShipping
		{
			get
			{
				return this.totalShippingField;
			}
			set
			{
				this.totalShippingField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public InvoiceData()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.item.Count; i++)
			{
				if (this.item[i] != null)
				{
					string newPrefix = prefix + "item" + "(" + i + ").";
					sb.Append(this.item[i].ToNVPString(newPrefix));
				}
			}
			if (this.totalTax != null)
			{
					sb.Append(prefix).Append("totalTax").Append("=").Append(Convert.ToString(this.totalTax, DefaultCulture)).Append("&");
			}
			if (this.totalShipping != null)
			{
					sb.Append(prefix).Append("totalShipping").Append("=").Append(Convert.ToString(this.totalShipping, DefaultCulture)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new InvoiceData object created from the passed in NVP map
	 	/// </returns>
		public static InvoiceData CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			InvoiceData invoiceData = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				InvoiceItem item =  InvoiceItem.CreateInstance(map, prefix + "item", i);
				if (item != null)
				{
					invoiceData = (invoiceData == null) ? new InvoiceData() : invoiceData;
					invoiceData.item.Add(item);
					i++;
				} 
				else
				{
					break;
				}
			}
			key = prefix + "totalTax";
			if (map.ContainsKey(key))
			{
				invoiceData = (invoiceData == null) ? new InvoiceData() : invoiceData;
				invoiceData.totalTax = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "totalShipping";
			if (map.ContainsKey(key))
			{
				invoiceData = (invoiceData == null) ? new InvoiceData() : invoiceData;
				invoiceData.totalShipping = System.Convert.ToDecimal(map[key]);
			}
			return invoiceData;
		}
	}




	/// <summary>
	/// The error that resulted from an attempt to make a payment to
	/// a receiver. 
    /// </summary>
	public partial class PayError	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private Receiver receiverField;
		public Receiver receiver
		{
			get
			{
				return this.receiverField;
			}
			set
			{
				this.receiverField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ErrorData errorField;
		public ErrorData error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PayError()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PayError object created from the passed in NVP map
	 	/// </returns>
		public static PayError CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PayError payError = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			Receiver receiver =  Receiver.CreateInstance(map, prefix + "receiver", -1);
			if (receiver != null)
			{
				payError = (payError == null) ? new PayError() : payError;
				payError.receiver = receiver;
			}
			ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", -1);
			if (error != null)
			{
				payError = (payError == null) ? new PayError() : payError;
				payError.error = error;
			}
			return payError;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class PayErrorList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<PayError> payErrorField = new List<PayError>();
		public List<PayError> payError
		{
			get
			{
				return this.payErrorField;
			}
			set
			{
				this.payErrorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PayErrorList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PayErrorList object created from the passed in NVP map
	 	/// </returns>
		public static PayErrorList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PayErrorList payErrorList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				PayError payError =  PayError.CreateInstance(map, prefix + "payError", i);
				if (payError != null)
				{
					payErrorList = (payErrorList == null) ? new PayErrorList() : payErrorList;
					payErrorList.payError.Add(payError);
					i++;
				} 
				else
				{
					break;
				}
			}
			return payErrorList;
		}
	}




	/// <summary>
	/// PaymentInfo represents the payment attempt made to a
	/// Receiver of a PayRequest. If the execution of the payment
	/// has not yet completed, there will not be any transaction
	/// details. 
    /// </summary>
	public partial class PaymentInfo	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string transactionIdField;
		public string transactionId
		{
			get
			{
				return this.transactionIdField;
			}
			set
			{
				this.transactionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string transactionStatusField;
		public string transactionStatus
		{
			get
			{
				return this.transactionStatusField;
			}
			set
			{
				this.transactionStatusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private Receiver receiverField;
		public Receiver receiver
		{
			get
			{
				return this.receiverField;
			}
			set
			{
				this.receiverField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? refundedAmountField;
		public decimal? refundedAmount
		{
			get
			{
				return this.refundedAmountField;
			}
			set
			{
				this.refundedAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? pendingRefundField;
		public bool? pendingRefund
		{
			get
			{
				return this.pendingRefundField;
			}
			set
			{
				this.pendingRefundField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string senderTransactionIdField;
		public string senderTransactionId
		{
			get
			{
				return this.senderTransactionIdField;
			}
			set
			{
				this.senderTransactionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string senderTransactionStatusField;
		public string senderTransactionStatus
		{
			get
			{
				return this.senderTransactionStatusField;
			}
			set
			{
				this.senderTransactionStatusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string pendingReasonField;
		public string pendingReason
		{
			get
			{
				return this.pendingReasonField;
			}
			set
			{
				this.pendingReasonField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PaymentInfo()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PaymentInfo object created from the passed in NVP map
	 	/// </returns>
		public static PaymentInfo CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PaymentInfo paymentInfo = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "transactionId";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.transactionId = map[key];
			}
			key = prefix + "transactionStatus";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.transactionStatus = map[key];
			}
			Receiver receiver =  Receiver.CreateInstance(map, prefix + "receiver", -1);
			if (receiver != null)
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.receiver = receiver;
			}
			key = prefix + "refundedAmount";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.refundedAmount = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "pendingRefund";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.pendingRefund = System.Convert.ToBoolean(map[key]);
			}
			key = prefix + "senderTransactionId";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.senderTransactionId = map[key];
			}
			key = prefix + "senderTransactionStatus";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.senderTransactionStatus = map[key];
			}
			key = prefix + "pendingReason";
			if (map.ContainsKey(key))
			{
				paymentInfo = (paymentInfo == null) ? new PaymentInfo() : paymentInfo;
				paymentInfo.pendingReason = map[key];
			}
			return paymentInfo;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class PaymentInfoList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<PaymentInfo> paymentInfoField = new List<PaymentInfo>();
		public List<PaymentInfo> paymentInfo
		{
			get
			{
				return this.paymentInfoField;
			}
			set
			{
				this.paymentInfoField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PaymentInfoList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PaymentInfoList object created from the passed in NVP map
	 	/// </returns>
		public static PaymentInfoList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PaymentInfoList paymentInfoList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				PaymentInfo paymentInfo =  PaymentInfo.CreateInstance(map, prefix + "paymentInfo", i);
				if (paymentInfo != null)
				{
					paymentInfoList = (paymentInfoList == null) ? new PaymentInfoList() : paymentInfoList;
					paymentInfoList.paymentInfo.Add(paymentInfo);
					i++;
				} 
				else
				{
					break;
				}
			}
			return paymentInfoList;
		}
	}




	/// <summary>
	/// Receiver is the party where funds are transferred to. A
	/// primary receiver receives a payment directly from the sender
	/// in a chained split payment. A primary receiver should not be
	/// specified when making a single or parallel split payment. 
    /// </summary>
	public partial class Receiver	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private decimal? amountField;
		public decimal? amount
		{
			get
			{
				return this.amountField;
			}
			set
			{
				this.amountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string emailField;
		public string email
		{
			get
			{
				return this.emailField;
			}
			set
			{
				this.emailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PhoneNumberType phoneField;
		public PhoneNumberType phone
		{
			get
			{
				return this.phoneField;
			}
			set
			{
				this.phoneField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? primaryField;
		public bool? primary
		{
			get
			{
				return this.primaryField;
			}
			set
			{
				this.primaryField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string invoiceIdField;
		public string invoiceId
		{
			get
			{
				return this.invoiceIdField;
			}
			set
			{
				this.invoiceIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string paymentTypeField;
		public string paymentType
		{
			get
			{
				return this.paymentTypeField;
			}
			set
			{
				this.paymentTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string paymentSubTypeField;
		public string paymentSubType
		{
			get
			{
				return this.paymentSubTypeField;
			}
			set
			{
				this.paymentSubTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string accountIdField;
		public string accountId
		{
			get
			{
				return this.accountIdField;
			}
			set
			{
				this.accountIdField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public Receiver(decimal? amount)
	 	{
			this.amount = amount;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public Receiver()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.amount != null)
			{
					sb.Append(prefix).Append("amount").Append("=").Append(Convert.ToString(this.amount, DefaultCulture)).Append("&");
			}
			if (this.email != null)
			{
					sb.Append(prefix).Append("email").Append("=").Append(HttpUtility.UrlEncode(this.email, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.phone != null)
			{
					string newPrefix = prefix + "phone" + ".";
					sb.Append(this.phoneField.ToNVPString(newPrefix));
			}
			if (this.primary != null)
			{
					sb.Append(prefix).Append("primary").Append("=").Append(this.primary.ToString().ToLower()).Append("&");
			}
			if (this.invoiceId != null)
			{
					sb.Append(prefix).Append("invoiceId").Append("=").Append(HttpUtility.UrlEncode(this.invoiceId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.paymentType != null)
			{
					sb.Append(prefix).Append("paymentType").Append("=").Append(HttpUtility.UrlEncode(this.paymentType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.paymentSubType != null)
			{
					sb.Append(prefix).Append("paymentSubType").Append("=").Append(HttpUtility.UrlEncode(this.paymentSubType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.accountId != null)
			{
					sb.Append(prefix).Append("accountId").Append("=").Append(HttpUtility.UrlEncode(this.accountId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new Receiver object created from the passed in NVP map
	 	/// </returns>
		public static Receiver CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			Receiver receiver = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "amount";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.amount = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "email";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.email = map[key];
			}
			PhoneNumberType phone =  PhoneNumberType.CreateInstance(map, prefix + "phone", -1);
			if (phone != null)
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.phone = phone;
			}
			key = prefix + "primary";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.primary = System.Convert.ToBoolean(map[key]);
			}
			key = prefix + "invoiceId";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.invoiceId = map[key];
			}
			key = prefix + "paymentType";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.paymentType = map[key];
			}
			key = prefix + "paymentSubType";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.paymentSubType = map[key];
			}
			key = prefix + "accountId";
			if (map.ContainsKey(key))
			{
				receiver = (receiver == null) ? new Receiver() : receiver;
				receiver.accountId = map[key];
			}
			return receiver;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class ReceiverList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<Receiver> receiverField = new List<Receiver>();
		public List<Receiver> receiver
		{
			get
			{
				return this.receiverField;
			}
			set
			{
				this.receiverField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public ReceiverList(List<Receiver> receiver)
	 	{
			this.receiver = receiver;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverList()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.receiver.Count; i++)
			{
				if (this.receiver[i] != null)
				{
					string newPrefix = prefix + "receiver" + "(" + i + ").";
					sb.Append(this.receiver[i].ToNVPString(newPrefix));
				}
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The sender identifier type contains information to identify
	/// a PayPal account. 
    /// </summary>
	public partial class ReceiverIdentifier : AccountIdentifier	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverIdentifier()
	 	{
		}


		public new string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToNVPString(prefix));
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ReceiverIdentifier object created from the passed in NVP map
	 	/// </returns>
		public static new ReceiverIdentifier CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ReceiverIdentifier receiverIdentifier = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			AccountIdentifier accountIdentifier = AccountIdentifier.CreateInstance(map, prefix, index);
			if (accountIdentifier != null)
			{
				receiverIdentifier = (receiverIdentifier == null) ? new ReceiverIdentifier() : receiverIdentifier;
				receiverIdentifier.email = accountIdentifier.email;
				receiverIdentifier.phone = accountIdentifier.phone;
				receiverIdentifier.accountId = accountIdentifier.accountId;
			}
			return receiverIdentifier;
		}
	}




	/// <summary>
	/// Options that apply to the receiver of a payment, allows
	/// setting additional details for payment using invoice. 
    /// </summary>
	public partial class ReceiverOptions	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string descriptionField;
		public string description
		{
			get
			{
				return this.descriptionField;
			}
			set
			{
				this.descriptionField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string customIdField;
		public string customId
		{
			get
			{
				return this.customIdField;
			}
			set
			{
				this.customIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private InvoiceData invoiceDataField;
		public InvoiceData invoiceData
		{
			get
			{
				return this.invoiceDataField;
			}
			set
			{
				this.invoiceDataField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ReceiverIdentifier receiverField;
		public ReceiverIdentifier receiver
		{
			get
			{
				return this.receiverField;
			}
			set
			{
				this.receiverField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string referrerCodeField;
		public string referrerCode
		{
			get
			{
				return this.referrerCodeField;
			}
			set
			{
				this.referrerCodeField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public ReceiverOptions(ReceiverIdentifier receiver)
	 	{
			this.receiver = receiver;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverOptions()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.description != null)
			{
					sb.Append(prefix).Append("description").Append("=").Append(HttpUtility.UrlEncode(this.description, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.customId != null)
			{
					sb.Append(prefix).Append("customId").Append("=").Append(HttpUtility.UrlEncode(this.customId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.invoiceData != null)
			{
					string newPrefix = prefix + "invoiceData" + ".";
					sb.Append(this.invoiceDataField.ToNVPString(newPrefix));
			}
			if (this.receiver != null)
			{
					string newPrefix = prefix + "receiver" + ".";
					sb.Append(this.receiverField.ToNVPString(newPrefix));
			}
			if (this.referrerCode != null)
			{
					sb.Append(prefix).Append("referrerCode").Append("=").Append(HttpUtility.UrlEncode(this.referrerCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ReceiverOptions object created from the passed in NVP map
	 	/// </returns>
		public static ReceiverOptions CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ReceiverOptions receiverOptions = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "description";
			if (map.ContainsKey(key))
			{
				receiverOptions = (receiverOptions == null) ? new ReceiverOptions() : receiverOptions;
				receiverOptions.description = map[key];
			}
			key = prefix + "customId";
			if (map.ContainsKey(key))
			{
				receiverOptions = (receiverOptions == null) ? new ReceiverOptions() : receiverOptions;
				receiverOptions.customId = map[key];
			}
			InvoiceData invoiceData =  InvoiceData.CreateInstance(map, prefix + "invoiceData", -1);
			if (invoiceData != null)
			{
				receiverOptions = (receiverOptions == null) ? new ReceiverOptions() : receiverOptions;
				receiverOptions.invoiceData = invoiceData;
			}
			ReceiverIdentifier receiver =  ReceiverIdentifier.CreateInstance(map, prefix + "receiver", -1);
			if (receiver != null)
			{
				receiverOptions = (receiverOptions == null) ? new ReceiverOptions() : receiverOptions;
				receiverOptions.receiver = receiver;
			}
			key = prefix + "referrerCode";
			if (map.ContainsKey(key))
			{
				receiverOptions = (receiverOptions == null) ? new ReceiverOptions() : receiverOptions;
				receiverOptions.referrerCode = map[key];
			}
			return receiverOptions;
		}
	}




	/// <summary>
	/// RefundInfo represents the refund attempt made to a Receiver
	/// of a PayRequest. 
    /// </summary>
	public partial class RefundInfo	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private Receiver receiverField;
		public Receiver receiver
		{
			get
			{
				return this.receiverField;
			}
			set
			{
				this.receiverField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string refundStatusField;
		public string refundStatus
		{
			get
			{
				return this.refundStatusField;
			}
			set
			{
				this.refundStatusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? refundNetAmountField;
		public decimal? refundNetAmount
		{
			get
			{
				return this.refundNetAmountField;
			}
			set
			{
				this.refundNetAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? refundFeeAmountField;
		public decimal? refundFeeAmount
		{
			get
			{
				return this.refundFeeAmountField;
			}
			set
			{
				this.refundFeeAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? refundGrossAmountField;
		public decimal? refundGrossAmount
		{
			get
			{
				return this.refundGrossAmountField;
			}
			set
			{
				this.refundGrossAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? totalOfAllRefundsField;
		public decimal? totalOfAllRefunds
		{
			get
			{
				return this.totalOfAllRefundsField;
			}
			set
			{
				this.totalOfAllRefundsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? refundHasBecomeFullField;
		public bool? refundHasBecomeFull
		{
			get
			{
				return this.refundHasBecomeFullField;
			}
			set
			{
				this.refundHasBecomeFullField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string encryptedRefundTransactionIdField;
		public string encryptedRefundTransactionId
		{
			get
			{
				return this.encryptedRefundTransactionIdField;
			}
			set
			{
				this.encryptedRefundTransactionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string refundTransactionStatusField;
		public string refundTransactionStatus
		{
			get
			{
				return this.refundTransactionStatusField;
			}
			set
			{
				this.refundTransactionStatusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ErrorList errorListField;
		public ErrorList errorList
		{
			get
			{
				return this.errorListField;
			}
			set
			{
				this.errorListField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public RefundInfo()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new RefundInfo object created from the passed in NVP map
	 	/// </returns>
		public static RefundInfo CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			RefundInfo refundInfo = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			Receiver receiver =  Receiver.CreateInstance(map, prefix + "receiver", -1);
			if (receiver != null)
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.receiver = receiver;
			}
			key = prefix + "refundStatus";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.refundStatus = map[key];
			}
			key = prefix + "refundNetAmount";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.refundNetAmount = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "refundFeeAmount";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.refundFeeAmount = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "refundGrossAmount";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.refundGrossAmount = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "totalOfAllRefunds";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.totalOfAllRefunds = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "refundHasBecomeFull";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.refundHasBecomeFull = System.Convert.ToBoolean(map[key]);
			}
			key = prefix + "encryptedRefundTransactionId";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.encryptedRefundTransactionId = map[key];
			}
			key = prefix + "refundTransactionStatus";
			if (map.ContainsKey(key))
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.refundTransactionStatus = map[key];
			}
			ErrorList errorList =  ErrorList.CreateInstance(map, prefix + "errorList", -1);
			if (errorList != null)
			{
				refundInfo = (refundInfo == null) ? new RefundInfo() : refundInfo;
				refundInfo.errorList = errorList;
			}
			return refundInfo;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class RefundInfoList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<RefundInfo> refundInfoField = new List<RefundInfo>();
		public List<RefundInfo> refundInfo
		{
			get
			{
				return this.refundInfoField;
			}
			set
			{
				this.refundInfoField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public RefundInfoList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new RefundInfoList object created from the passed in NVP map
	 	/// </returns>
		public static RefundInfoList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			RefundInfoList refundInfoList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				RefundInfo refundInfo =  RefundInfo.CreateInstance(map, prefix + "refundInfo", i);
				if (refundInfo != null)
				{
					refundInfoList = (refundInfoList == null) ? new RefundInfoList() : refundInfoList;
					refundInfoList.refundInfo.Add(refundInfo);
					i++;
				} 
				else
				{
					break;
				}
			}
			return refundInfoList;
		}
	}




	/// <summary>
	/// Options that apply to the sender of a payment. 
    /// </summary>
	public partial class SenderOptions	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private bool? requireShippingAddressSelectionField;
		public bool? requireShippingAddressSelection
		{
			get
			{
				return this.requireShippingAddressSelectionField;
			}
			set
			{
				this.requireShippingAddressSelectionField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string referrerCodeField;
		public string referrerCode
		{
			get
			{
				return this.referrerCodeField;
			}
			set
			{
				this.referrerCodeField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public SenderOptions()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requireShippingAddressSelection != null)
			{
					sb.Append(prefix).Append("requireShippingAddressSelection").Append("=").Append(this.requireShippingAddressSelection.ToString().ToLower()).Append("&");
			}
			if (this.referrerCode != null)
			{
					sb.Append(prefix).Append("referrerCode").Append("=").Append(HttpUtility.UrlEncode(this.referrerCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new SenderOptions object created from the passed in NVP map
	 	/// </returns>
		public static SenderOptions CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			SenderOptions senderOptions = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "requireShippingAddressSelection";
			if (map.ContainsKey(key))
			{
				senderOptions = (senderOptions == null) ? new SenderOptions() : senderOptions;
				senderOptions.requireShippingAddressSelection = System.Convert.ToBoolean(map[key]);
			}
			key = prefix + "referrerCode";
			if (map.ContainsKey(key))
			{
				senderOptions = (senderOptions == null) ? new SenderOptions() : senderOptions;
				senderOptions.referrerCode = map[key];
			}
			return senderOptions;
		}
	}




	/// <summary>
	/// Details about the payer's tax info passed in by the merchant
	/// or partner. 
    /// </summary>
	public partial class TaxIdDetails	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string taxIdField;
		public string taxId
		{
			get
			{
				return this.taxIdField;
			}
			set
			{
				this.taxIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string taxIdTypeField;
		public string taxIdType
		{
			get
			{
				return this.taxIdTypeField;
			}
			set
			{
				this.taxIdTypeField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public TaxIdDetails()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.taxId != null)
			{
					sb.Append(prefix).Append("taxId").Append("=").Append(HttpUtility.UrlEncode(this.taxId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.taxIdType != null)
			{
					sb.Append(prefix).Append("taxIdType").Append("=").Append(HttpUtility.UrlEncode(this.taxIdType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new TaxIdDetails object created from the passed in NVP map
	 	/// </returns>
		public static TaxIdDetails CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			TaxIdDetails taxIdDetails = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "taxId";
			if (map.ContainsKey(key))
			{
				taxIdDetails = (taxIdDetails == null) ? new TaxIdDetails() : taxIdDetails;
				taxIdDetails.taxId = map[key];
			}
			key = prefix + "taxIdType";
			if (map.ContainsKey(key))
			{
				taxIdDetails = (taxIdDetails == null) ? new TaxIdDetails() : taxIdDetails;
				taxIdDetails.taxIdType = map[key];
			}
			return taxIdDetails;
		}
	}




	/// <summary>
	/// The sender identifier type contains information to identify
	/// a PayPal account. 
    /// </summary>
	public partial class SenderIdentifier : AccountIdentifier	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private bool? useCredentialsField;
		public bool? useCredentials
		{
			get
			{
				return this.useCredentialsField;
			}
			set
			{
				this.useCredentialsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private TaxIdDetails taxIdDetailsField;
		public TaxIdDetails taxIdDetails
		{
			get
			{
				return this.taxIdDetailsField;
			}
			set
			{
				this.taxIdDetailsField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public SenderIdentifier()
	 	{
		}


		public new string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToNVPString(prefix));
			if (this.useCredentials != null)
			{
					sb.Append(prefix).Append("useCredentials").Append("=").Append(this.useCredentials.ToString().ToLower()).Append("&");
			}
			if (this.taxIdDetails != null)
			{
					string newPrefix = prefix + "taxIdDetails" + ".";
					sb.Append(this.taxIdDetailsField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new SenderIdentifier object created from the passed in NVP map
	 	/// </returns>
		public static new SenderIdentifier CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			SenderIdentifier senderIdentifier = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			AccountIdentifier accountIdentifier = AccountIdentifier.CreateInstance(map, prefix, index);
			if (accountIdentifier != null)
			{
				senderIdentifier = (senderIdentifier == null) ? new SenderIdentifier() : senderIdentifier;
				senderIdentifier.email = accountIdentifier.email;
				senderIdentifier.phone = accountIdentifier.phone;
				senderIdentifier.accountId = accountIdentifier.accountId;
			}
			key = prefix + "useCredentials";
			if (map.ContainsKey(key))
			{
				senderIdentifier = (senderIdentifier == null) ? new SenderIdentifier() : senderIdentifier;
				senderIdentifier.useCredentials = System.Convert.ToBoolean(map[key]);
			}
			TaxIdDetails taxIdDetails =  TaxIdDetails.CreateInstance(map, prefix + "taxIdDetails", -1);
			if (taxIdDetails != null)
			{
				senderIdentifier = (senderIdentifier == null) ? new SenderIdentifier() : senderIdentifier;
				senderIdentifier.taxIdDetails = taxIdDetails;
			}
			return senderIdentifier;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class UserLimit	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string limitTypeField;
		public string limitType
		{
			get
			{
				return this.limitTypeField;
			}
			set
			{
				this.limitTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType limitAmountField;
		public CurrencyType limitAmount
		{
			get
			{
				return this.limitAmountField;
			}
			set
			{
				this.limitAmountField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public UserLimit()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new UserLimit object created from the passed in NVP map
	 	/// </returns>
		public static UserLimit CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			UserLimit userLimit = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "limitType";
			if (map.ContainsKey(key))
			{
				userLimit = (userLimit == null) ? new UserLimit() : userLimit;
				userLimit.limitType = map[key];
			}
			CurrencyType limitAmount =  CurrencyType.CreateInstance(map, prefix + "limitAmount", -1);
			if (limitAmount != null)
			{
				userLimit = (userLimit == null) ? new UserLimit() : userLimit;
				userLimit.limitAmount = limitAmount;
			}
			return userLimit;
		}
	}




	/// <summary>
	/// This type contains the detailed warning information
	/// resulting from the service operation. 
    /// </summary>
	public partial class WarningData	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private int? warningIdField;
		public int? warningId
		{
			get
			{
				return this.warningIdField;
			}
			set
			{
				this.warningIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string messageField;
		public string message
		{
			get
			{
				return this.messageField;
			}
			set
			{
				this.messageField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public WarningData()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new WarningData object created from the passed in NVP map
	 	/// </returns>
		public static WarningData CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			WarningData warningData = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "warningId";
			if (map.ContainsKey(key))
			{
				warningData = (warningData == null) ? new WarningData() : warningData;
				warningData.warningId = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "message";
			if (map.ContainsKey(key))
			{
				warningData = (warningData == null) ? new WarningData() : warningData;
				warningData.message = map[key];
			}
			return warningData;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class WarningDataList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<WarningData> warningDataField = new List<WarningData>();
		public List<WarningData> warningData
		{
			get
			{
				return this.warningDataField;
			}
			set
			{
				this.warningDataField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public WarningDataList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new WarningDataList object created from the passed in NVP map
	 	/// </returns>
		public static WarningDataList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			WarningDataList warningDataList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				WarningData warningData =  WarningData.CreateInstance(map, prefix + "warningData", i);
				if (warningData != null)
				{
					warningDataList = (warningDataList == null) ? new WarningDataList() : warningDataList;
					warningDataList.warningData.Add(warningData);
					i++;
				} 
				else
				{
					break;
				}
			}
			return warningDataList;
		}
	}




	/// <summary>
	/// The request to cancel a Preapproval. 
    /// </summary>
	public partial class CancelPreapprovalRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string preapprovalKeyField;
		public string preapprovalKey
		{
			get
			{
				return this.preapprovalKeyField;
			}
			set
			{
				this.preapprovalKeyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public CancelPreapprovalRequest(RequestEnvelope requestEnvelope, string preapprovalKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.preapprovalKey = preapprovalKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CancelPreapprovalRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.preapprovalKey != null)
			{
					sb.Append(prefix).Append("preapprovalKey").Append("=").Append(HttpUtility.UrlEncode(this.preapprovalKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The result of the CancelPreapprovalRequest. 
    /// </summary>
	public partial class CancelPreapprovalResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public CancelPreapprovalResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new CancelPreapprovalResponse object created from the passed in NVP map
	 	/// </returns>
		public static CancelPreapprovalResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			CancelPreapprovalResponse cancelPreapprovalResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				cancelPreapprovalResponse = (cancelPreapprovalResponse == null) ? new CancelPreapprovalResponse() : cancelPreapprovalResponse;
				cancelPreapprovalResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					cancelPreapprovalResponse = (cancelPreapprovalResponse == null) ? new CancelPreapprovalResponse() : cancelPreapprovalResponse;
					cancelPreapprovalResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return cancelPreapprovalResponse;
		}
	}




	/// <summary>
	/// The request to confirm a Preapproval. 
    /// </summary>
	public partial class ConfirmPreapprovalRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string preapprovalKeyField;
		public string preapprovalKey
		{
			get
			{
				return this.preapprovalKeyField;
			}
			set
			{
				this.preapprovalKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string fundingSourceIdField;
		public string fundingSourceId
		{
			get
			{
				return this.fundingSourceIdField;
			}
			set
			{
				this.fundingSourceIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string pinField;
		public string pin
		{
			get
			{
				return this.pinField;
			}
			set
			{
				this.pinField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public ConfirmPreapprovalRequest(RequestEnvelope requestEnvelope, string preapprovalKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.preapprovalKey = preapprovalKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ConfirmPreapprovalRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.preapprovalKey != null)
			{
					sb.Append(prefix).Append("preapprovalKey").Append("=").Append(HttpUtility.UrlEncode(this.preapprovalKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.fundingSourceId != null)
			{
					sb.Append(prefix).Append("fundingSourceId").Append("=").Append(HttpUtility.UrlEncode(this.fundingSourceId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.pin != null)
			{
					sb.Append(prefix).Append("pin").Append("=").Append(HttpUtility.UrlEncode(this.pin, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The result of the ConfirmPreapprovalRequest. 
    /// </summary>
	public partial class ConfirmPreapprovalResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ConfirmPreapprovalResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ConfirmPreapprovalResponse object created from the passed in NVP map
	 	/// </returns>
		public static ConfirmPreapprovalResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ConfirmPreapprovalResponse confirmPreapprovalResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				confirmPreapprovalResponse = (confirmPreapprovalResponse == null) ? new ConfirmPreapprovalResponse() : confirmPreapprovalResponse;
				confirmPreapprovalResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					confirmPreapprovalResponse = (confirmPreapprovalResponse == null) ? new ConfirmPreapprovalResponse() : confirmPreapprovalResponse;
					confirmPreapprovalResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return confirmPreapprovalResponse;
		}
	}




	/// <summary>
	/// A request to convert one or more currencies into their
	/// estimated values in other currencies. 
    /// </summary>
	public partial class ConvertCurrencyRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyList baseAmountListField;
		public CurrencyList baseAmountList
		{
			get
			{
				return this.baseAmountListField;
			}
			set
			{
				this.baseAmountListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyCodeList convertToCurrencyListField;
		public CurrencyCodeList convertToCurrencyList
		{
			get
			{
				return this.convertToCurrencyListField;
			}
			set
			{
				this.convertToCurrencyListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string countryCodeField;
		public string countryCode
		{
			get
			{
				return this.countryCodeField;
			}
			set
			{
				this.countryCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string conversionTypeField;
		public string conversionType
		{
			get
			{
				return this.conversionTypeField;
			}
			set
			{
				this.conversionTypeField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public ConvertCurrencyRequest(RequestEnvelope requestEnvelope, CurrencyList baseAmountList, CurrencyCodeList convertToCurrencyList)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.baseAmountList = baseAmountList;
			this.convertToCurrencyList = convertToCurrencyList;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ConvertCurrencyRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.baseAmountList != null)
			{
					string newPrefix = prefix + "baseAmountList" + ".";
					sb.Append(this.baseAmountListField.ToNVPString(newPrefix));
			}
			if (this.convertToCurrencyList != null)
			{
					string newPrefix = prefix + "convertToCurrencyList" + ".";
					sb.Append(this.convertToCurrencyListField.ToNVPString(newPrefix));
			}
			if (this.countryCode != null)
			{
					sb.Append(prefix).Append("countryCode").Append("=").Append(HttpUtility.UrlEncode(this.countryCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.conversionType != null)
			{
					sb.Append(prefix).Append("conversionType").Append("=").Append(HttpUtility.UrlEncode(this.conversionType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// A response that contains a table of estimated converted
	/// currencies based on the Convert Currency Request. 
    /// </summary>
	public partial class ConvertCurrencyResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyConversionTable estimatedAmountTableField;
		public CurrencyConversionTable estimatedAmountTable
		{
			get
			{
				return this.estimatedAmountTableField;
			}
			set
			{
				this.estimatedAmountTableField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ConvertCurrencyResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ConvertCurrencyResponse object created from the passed in NVP map
	 	/// </returns>
		public static ConvertCurrencyResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ConvertCurrencyResponse convertCurrencyResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				convertCurrencyResponse = (convertCurrencyResponse == null) ? new ConvertCurrencyResponse() : convertCurrencyResponse;
				convertCurrencyResponse.responseEnvelope = responseEnvelope;
			}
			CurrencyConversionTable estimatedAmountTable =  CurrencyConversionTable.CreateInstance(map, prefix + "estimatedAmountTable", -1);
			if (estimatedAmountTable != null)
			{
				convertCurrencyResponse = (convertCurrencyResponse == null) ? new ConvertCurrencyResponse() : convertCurrencyResponse;
				convertCurrencyResponse.estimatedAmountTable = estimatedAmountTable;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					convertCurrencyResponse = (convertCurrencyResponse == null) ? new ConvertCurrencyResponse() : convertCurrencyResponse;
					convertCurrencyResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return convertCurrencyResponse;
		}
	}




	/// <summary>
	/// The request to execute the payment request. 
    /// </summary>
	public partial class ExecutePaymentRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string actionTypeField;
		public string actionType
		{
			get
			{
				return this.actionTypeField;
			}
			set
			{
				this.actionTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string fundingPlanIdField;
		public string fundingPlanId
		{
			get
			{
				return this.fundingPlanIdField;
			}
			set
			{
				this.fundingPlanIdField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public ExecutePaymentRequest(RequestEnvelope requestEnvelope, string payKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.payKey = payKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ExecutePaymentRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.actionType != null)
			{
					sb.Append(prefix).Append("actionType").Append("=").Append(HttpUtility.UrlEncode(this.actionType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.fundingPlanId != null)
			{
					sb.Append(prefix).Append("fundingPlanId").Append("=").Append(HttpUtility.UrlEncode(this.fundingPlanId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// Contains information related to Post Payment Disclosure
	/// Details This contains 1.Receivers information 2.Funds
	/// Avalibility Date 
    /// </summary>
	public partial class PostPaymentDisclosure	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private AccountIdentifier accountIdentifierField;
		public AccountIdentifier accountIdentifier
		{
			get
			{
				return this.accountIdentifierField;
			}
			set
			{
				this.accountIdentifierField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string fundsAvailabilityDateField;
		public string fundsAvailabilityDate
		{
			get
			{
				return this.fundsAvailabilityDateField;
			}
			set
			{
				this.fundsAvailabilityDateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string fundsAvailabilityDateDisclaimerTextField;
		public string fundsAvailabilityDateDisclaimerText
		{
			get
			{
				return this.fundsAvailabilityDateDisclaimerTextField;
			}
			set
			{
				this.fundsAvailabilityDateDisclaimerTextField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PostPaymentDisclosure()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PostPaymentDisclosure object created from the passed in NVP map
	 	/// </returns>
		public static PostPaymentDisclosure CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PostPaymentDisclosure postPaymentDisclosure = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			AccountIdentifier accountIdentifier =  AccountIdentifier.CreateInstance(map, prefix + "accountIdentifier", -1);
			if (accountIdentifier != null)
			{
				postPaymentDisclosure = (postPaymentDisclosure == null) ? new PostPaymentDisclosure() : postPaymentDisclosure;
				postPaymentDisclosure.accountIdentifier = accountIdentifier;
			}
			key = prefix + "fundsAvailabilityDate";
			if (map.ContainsKey(key))
			{
				postPaymentDisclosure = (postPaymentDisclosure == null) ? new PostPaymentDisclosure() : postPaymentDisclosure;
				postPaymentDisclosure.fundsAvailabilityDate = map[key];
			}
			key = prefix + "fundsAvailabilityDateDisclaimerText";
			if (map.ContainsKey(key))
			{
				postPaymentDisclosure = (postPaymentDisclosure == null) ? new PostPaymentDisclosure() : postPaymentDisclosure;
				postPaymentDisclosure.fundsAvailabilityDateDisclaimerText = map[key];
			}
			return postPaymentDisclosure;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class PostPaymentDisclosureList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<PostPaymentDisclosure> postPaymentDisclosureField = new List<PostPaymentDisclosure>();
		public List<PostPaymentDisclosure> postPaymentDisclosure
		{
			get
			{
				return this.postPaymentDisclosureField;
			}
			set
			{
				this.postPaymentDisclosureField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PostPaymentDisclosureList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PostPaymentDisclosureList object created from the passed in NVP map
	 	/// </returns>
		public static PostPaymentDisclosureList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PostPaymentDisclosureList postPaymentDisclosureList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				PostPaymentDisclosure postPaymentDisclosure =  PostPaymentDisclosure.CreateInstance(map, prefix + "postPaymentDisclosure", i);
				if (postPaymentDisclosure != null)
				{
					postPaymentDisclosureList = (postPaymentDisclosureList == null) ? new PostPaymentDisclosureList() : postPaymentDisclosureList;
					postPaymentDisclosureList.postPaymentDisclosure.Add(postPaymentDisclosure);
					i++;
				} 
				else
				{
					break;
				}
			}
			return postPaymentDisclosureList;
		}
	}




	/// <summary>
	/// The result of a payment execution. 
    /// </summary>
	public partial class ExecutePaymentResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string paymentExecStatusField;
		public string paymentExecStatus
		{
			get
			{
				return this.paymentExecStatusField;
			}
			set
			{
				this.paymentExecStatusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PayErrorList payErrorListField;
		public PayErrorList payErrorList
		{
			get
			{
				return this.payErrorListField;
			}
			set
			{
				this.payErrorListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PostPaymentDisclosureList postPaymentDisclosureListField;
		public PostPaymentDisclosureList postPaymentDisclosureList
		{
			get
			{
				return this.postPaymentDisclosureListField;
			}
			set
			{
				this.postPaymentDisclosureListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ExecutePaymentResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ExecutePaymentResponse object created from the passed in NVP map
	 	/// </returns>
		public static ExecutePaymentResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ExecutePaymentResponse executePaymentResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				executePaymentResponse = (executePaymentResponse == null) ? new ExecutePaymentResponse() : executePaymentResponse;
				executePaymentResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "paymentExecStatus";
			if (map.ContainsKey(key))
			{
				executePaymentResponse = (executePaymentResponse == null) ? new ExecutePaymentResponse() : executePaymentResponse;
				executePaymentResponse.paymentExecStatus = map[key];
			}
			PayErrorList payErrorList =  PayErrorList.CreateInstance(map, prefix + "payErrorList", -1);
			if (payErrorList != null)
			{
				executePaymentResponse = (executePaymentResponse == null) ? new ExecutePaymentResponse() : executePaymentResponse;
				executePaymentResponse.payErrorList = payErrorList;
			}
			PostPaymentDisclosureList postPaymentDisclosureList =  PostPaymentDisclosureList.CreateInstance(map, prefix + "postPaymentDisclosureList", -1);
			if (postPaymentDisclosureList != null)
			{
				executePaymentResponse = (executePaymentResponse == null) ? new ExecutePaymentResponse() : executePaymentResponse;
				executePaymentResponse.postPaymentDisclosureList = postPaymentDisclosureList;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					executePaymentResponse = (executePaymentResponse == null) ? new ExecutePaymentResponse() : executePaymentResponse;
					executePaymentResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return executePaymentResponse;
		}
	}




	/// <summary>
	/// The request to get the allowed funding sources available for
	/// a preapproval. 
    /// </summary>
	public partial class GetAllowedFundingSourcesRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string keyField;
		public string key
		{
			get
			{
				return this.keyField;
			}
			set
			{
				this.keyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetAllowedFundingSourcesRequest(RequestEnvelope requestEnvelope, string key)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.key = key;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetAllowedFundingSourcesRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.key != null)
			{
					sb.Append(prefix).Append("key").Append("=").Append(HttpUtility.UrlEncode(this.key, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The response to get the backup funding sources available for
	/// a preapproval. 
    /// </summary>
	public partial class GetAllowedFundingSourcesResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<FundingSource> fundingSourceField = new List<FundingSource>();
		public List<FundingSource> fundingSource
		{
			get
			{
				return this.fundingSourceField;
			}
			set
			{
				this.fundingSourceField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetAllowedFundingSourcesResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetAllowedFundingSourcesResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetAllowedFundingSourcesResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetAllowedFundingSourcesResponse getAllowedFundingSourcesResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getAllowedFundingSourcesResponse = (getAllowedFundingSourcesResponse == null) ? new GetAllowedFundingSourcesResponse() : getAllowedFundingSourcesResponse;
				getAllowedFundingSourcesResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				FundingSource fundingSource =  FundingSource.CreateInstance(map, prefix + "fundingSource", i);
				if (fundingSource != null)
				{
					getAllowedFundingSourcesResponse = (getAllowedFundingSourcesResponse == null) ? new GetAllowedFundingSourcesResponse() : getAllowedFundingSourcesResponse;
					getAllowedFundingSourcesResponse.fundingSource.Add(fundingSource);
					i++;
				} 
				else
				{
					break;
				}
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getAllowedFundingSourcesResponse = (getAllowedFundingSourcesResponse == null) ? new GetAllowedFundingSourcesResponse() : getAllowedFundingSourcesResponse;
					getAllowedFundingSourcesResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getAllowedFundingSourcesResponse;
		}
	}




	/// <summary>
	/// The request to get the options of a payment request. 
    /// </summary>
	public partial class GetPaymentOptionsRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetPaymentOptionsRequest(RequestEnvelope requestEnvelope, string payKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.payKey = payKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetPaymentOptionsRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The response message for the GetPaymentOption request 
    /// </summary>
	public partial class GetPaymentOptionsResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private InitiatingEntity initiatingEntityField;
		public InitiatingEntity initiatingEntity
		{
			get
			{
				return this.initiatingEntityField;
			}
			set
			{
				this.initiatingEntityField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private DisplayOptions displayOptionsField;
		public DisplayOptions displayOptions
		{
			get
			{
				return this.displayOptionsField;
			}
			set
			{
				this.displayOptionsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string shippingAddressIdField;
		public string shippingAddressId
		{
			get
			{
				return this.shippingAddressIdField;
			}
			set
			{
				this.shippingAddressIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderOptions senderOptionsField;
		public SenderOptions senderOptions
		{
			get
			{
				return this.senderOptionsField;
			}
			set
			{
				this.senderOptionsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ReceiverOptions> receiverOptionsField = new List<ReceiverOptions>();
		public List<ReceiverOptions> receiverOptions
		{
			get
			{
				return this.receiverOptionsField;
			}
			set
			{
				this.receiverOptionsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetPaymentOptionsResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetPaymentOptionsResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetPaymentOptionsResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetPaymentOptionsResponse getPaymentOptionsResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
				getPaymentOptionsResponse.responseEnvelope = responseEnvelope;
			}
			InitiatingEntity initiatingEntity =  InitiatingEntity.CreateInstance(map, prefix + "initiatingEntity", -1);
			if (initiatingEntity != null)
			{
				getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
				getPaymentOptionsResponse.initiatingEntity = initiatingEntity;
			}
			DisplayOptions displayOptions =  DisplayOptions.CreateInstance(map, prefix + "displayOptions", -1);
			if (displayOptions != null)
			{
				getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
				getPaymentOptionsResponse.displayOptions = displayOptions;
			}
			key = prefix + "shippingAddressId";
			if (map.ContainsKey(key))
			{
				getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
				getPaymentOptionsResponse.shippingAddressId = map[key];
			}
			SenderOptions senderOptions =  SenderOptions.CreateInstance(map, prefix + "senderOptions", -1);
			if (senderOptions != null)
			{
				getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
				getPaymentOptionsResponse.senderOptions = senderOptions;
			}
			i = 0;
			while(true)
			{
				ReceiverOptions receiverOptions =  ReceiverOptions.CreateInstance(map, prefix + "receiverOptions", i);
				if (receiverOptions != null)
				{
					getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
					getPaymentOptionsResponse.receiverOptions.Add(receiverOptions);
					i++;
				} 
				else
				{
					break;
				}
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getPaymentOptionsResponse = (getPaymentOptionsResponse == null) ? new GetPaymentOptionsResponse() : getPaymentOptionsResponse;
					getPaymentOptionsResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getPaymentOptionsResponse;
		}
	}




	/// <summary>
	/// The request to look up the details of a PayRequest. The
	/// PaymentDetailsRequest can be made with either a payKey,
	/// trackingId, or a transactionId of the PayRequest. 
    /// </summary>
	public partial class PaymentDetailsRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string transactionIdField;
		public string transactionId
		{
			get
			{
				return this.transactionIdField;
			}
			set
			{
				this.transactionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string trackingIdField;
		public string trackingId
		{
			get
			{
				return this.trackingIdField;
			}
			set
			{
				this.trackingIdField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public PaymentDetailsRequest(RequestEnvelope requestEnvelope)
	 	{
			this.requestEnvelope = requestEnvelope;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PaymentDetailsRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.transactionId != null)
			{
					sb.Append(prefix).Append("transactionId").Append("=").Append(HttpUtility.UrlEncode(this.transactionId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.trackingId != null)
			{
					sb.Append(prefix).Append("trackingId").Append("=").Append(HttpUtility.UrlEncode(this.trackingId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The details of the PayRequest as specified in the Pay
	/// operation. 
    /// </summary>
	public partial class PaymentDetailsResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string cancelUrlField;
		public string cancelUrl
		{
			get
			{
				return this.cancelUrlField;
			}
			set
			{
				this.cancelUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string ipnNotificationUrlField;
		public string ipnNotificationUrl
		{
			get
			{
				return this.ipnNotificationUrlField;
			}
			set
			{
				this.ipnNotificationUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string memoField;
		public string memo
		{
			get
			{
				return this.memoField;
			}
			set
			{
				this.memoField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PaymentInfoList paymentInfoListField;
		public PaymentInfoList paymentInfoList
		{
			get
			{
				return this.paymentInfoListField;
			}
			set
			{
				this.paymentInfoListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string returnUrlField;
		public string returnUrl
		{
			get
			{
				return this.returnUrlField;
			}
			set
			{
				this.returnUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string senderEmailField;
		public string senderEmail
		{
			get
			{
				return this.senderEmailField;
			}
			set
			{
				this.senderEmailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string statusField;
		public string status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string trackingIdField;
		public string trackingId
		{
			get
			{
				return this.trackingIdField;
			}
			set
			{
				this.trackingIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string actionTypeField;
		public string actionType
		{
			get
			{
				return this.actionTypeField;
			}
			set
			{
				this.actionTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string feesPayerField;
		public string feesPayer
		{
			get
			{
				return this.feesPayerField;
			}
			set
			{
				this.feesPayerField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? reverseAllParallelPaymentsOnErrorField;
		public bool? reverseAllParallelPaymentsOnError
		{
			get
			{
				return this.reverseAllParallelPaymentsOnErrorField;
			}
			set
			{
				this.reverseAllParallelPaymentsOnErrorField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string preapprovalKeyField;
		public string preapprovalKey
		{
			get
			{
				return this.preapprovalKeyField;
			}
			set
			{
				this.preapprovalKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FundingConstraint fundingConstraintField;
		public FundingConstraint fundingConstraint
		{
			get
			{
				return this.fundingConstraintField;
			}
			set
			{
				this.fundingConstraintField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderIdentifier senderField;
		public SenderIdentifier sender
		{
			get
			{
				return this.senderField;
			}
			set
			{
				this.senderField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PaymentDetailsResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PaymentDetailsResponse object created from the passed in NVP map
	 	/// </returns>
		public static PaymentDetailsResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PaymentDetailsResponse paymentDetailsResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "cancelUrl";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.cancelUrl = map[key];
			}
			key = prefix + "currencyCode";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.currencyCode = map[key];
			}
			key = prefix + "ipnNotificationUrl";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.ipnNotificationUrl = map[key];
			}
			key = prefix + "memo";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.memo = map[key];
			}
			PaymentInfoList paymentInfoList =  PaymentInfoList.CreateInstance(map, prefix + "paymentInfoList", -1);
			if (paymentInfoList != null)
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.paymentInfoList = paymentInfoList;
			}
			key = prefix + "returnUrl";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.returnUrl = map[key];
			}
			key = prefix + "senderEmail";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.senderEmail = map[key];
			}
			key = prefix + "status";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.status = map[key];
			}
			key = prefix + "trackingId";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.trackingId = map[key];
			}
			key = prefix + "payKey";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.payKey = map[key];
			}
			key = prefix + "actionType";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.actionType = map[key];
			}
			key = prefix + "feesPayer";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.feesPayer = map[key];
			}
			key = prefix + "reverseAllParallelPaymentsOnError";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.reverseAllParallelPaymentsOnError = System.Convert.ToBoolean(map[key]);
			}
			key = prefix + "preapprovalKey";
			if (map.ContainsKey(key))
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.preapprovalKey = map[key];
			}
			FundingConstraint fundingConstraint =  FundingConstraint.CreateInstance(map, prefix + "fundingConstraint", -1);
			if (fundingConstraint != null)
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.fundingConstraint = fundingConstraint;
			}
			SenderIdentifier sender =  SenderIdentifier.CreateInstance(map, prefix + "sender", -1);
			if (sender != null)
			{
				paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
				paymentDetailsResponse.sender = sender;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					paymentDetailsResponse = (paymentDetailsResponse == null) ? new PaymentDetailsResponse() : paymentDetailsResponse;
					paymentDetailsResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return paymentDetailsResponse;
		}
	}




	/// <summary>
	/// The PayRequest contains the payment instructions to make
	/// from sender to receivers. 
    /// </summary>
	public partial class PayRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ClientDetailsType clientDetailsField;
		public ClientDetailsType clientDetails
		{
			get
			{
				return this.clientDetailsField;
			}
			set
			{
				this.clientDetailsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string actionTypeField;
		public string actionType
		{
			get
			{
				return this.actionTypeField;
			}
			set
			{
				this.actionTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string cancelUrlField;
		public string cancelUrl
		{
			get
			{
				return this.cancelUrlField;
			}
			set
			{
				this.cancelUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string feesPayerField;
		public string feesPayer
		{
			get
			{
				return this.feesPayerField;
			}
			set
			{
				this.feesPayerField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string ipnNotificationUrlField;
		public string ipnNotificationUrl
		{
			get
			{
				return this.ipnNotificationUrlField;
			}
			set
			{
				this.ipnNotificationUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string memoField;
		public string memo
		{
			get
			{
				return this.memoField;
			}
			set
			{
				this.memoField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string pinField;
		public string pin
		{
			get
			{
				return this.pinField;
			}
			set
			{
				this.pinField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string preapprovalKeyField;
		public string preapprovalKey
		{
			get
			{
				return this.preapprovalKeyField;
			}
			set
			{
				this.preapprovalKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ReceiverList receiverListField;
		public ReceiverList receiverList
		{
			get
			{
				return this.receiverListField;
			}
			set
			{
				this.receiverListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? reverseAllParallelPaymentsOnErrorField;
		public bool? reverseAllParallelPaymentsOnError
		{
			get
			{
				return this.reverseAllParallelPaymentsOnErrorField;
			}
			set
			{
				this.reverseAllParallelPaymentsOnErrorField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string senderEmailField;
		public string senderEmail
		{
			get
			{
				return this.senderEmailField;
			}
			set
			{
				this.senderEmailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string returnUrlField;
		public string returnUrl
		{
			get
			{
				return this.returnUrlField;
			}
			set
			{
				this.returnUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string trackingIdField;
		public string trackingId
		{
			get
			{
				return this.trackingIdField;
			}
			set
			{
				this.trackingIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FundingConstraint fundingConstraintField;
		public FundingConstraint fundingConstraint
		{
			get
			{
				return this.fundingConstraintField;
			}
			set
			{
				this.fundingConstraintField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderIdentifier senderField;
		public SenderIdentifier sender
		{
			get
			{
				return this.senderField;
			}
			set
			{
				this.senderField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public PayRequest(RequestEnvelope requestEnvelope, string actionType, string cancelUrl, string currencyCode, ReceiverList receiverList, string returnUrl)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.actionType = actionType;
			this.cancelUrl = cancelUrl;
			this.currencyCode = currencyCode;
			this.receiverList = receiverList;
			this.returnUrl = returnUrl;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PayRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.clientDetails != null)
			{
					string newPrefix = prefix + "clientDetails" + ".";
					sb.Append(this.clientDetailsField.ToNVPString(newPrefix));
			}
			if (this.actionType != null)
			{
					sb.Append(prefix).Append("actionType").Append("=").Append(HttpUtility.UrlEncode(this.actionType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.cancelUrl != null)
			{
					sb.Append(prefix).Append("cancelUrl").Append("=").Append(HttpUtility.UrlEncode(this.cancelUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.currencyCode != null)
			{
					sb.Append(prefix).Append("currencyCode").Append("=").Append(HttpUtility.UrlEncode(this.currencyCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.feesPayer != null)
			{
					sb.Append(prefix).Append("feesPayer").Append("=").Append(HttpUtility.UrlEncode(this.feesPayer, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.ipnNotificationUrl != null)
			{
					sb.Append(prefix).Append("ipnNotificationUrl").Append("=").Append(HttpUtility.UrlEncode(this.ipnNotificationUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.memo != null)
			{
					sb.Append(prefix).Append("memo").Append("=").Append(HttpUtility.UrlEncode(this.memo, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.pin != null)
			{
					sb.Append(prefix).Append("pin").Append("=").Append(HttpUtility.UrlEncode(this.pin, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.preapprovalKey != null)
			{
					sb.Append(prefix).Append("preapprovalKey").Append("=").Append(HttpUtility.UrlEncode(this.preapprovalKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.receiverList != null)
			{
					string newPrefix = prefix + "receiverList" + ".";
					sb.Append(this.receiverListField.ToNVPString(newPrefix));
			}
			if (this.reverseAllParallelPaymentsOnError != null)
			{
					sb.Append(prefix).Append("reverseAllParallelPaymentsOnError").Append("=").Append(this.reverseAllParallelPaymentsOnError.ToString().ToLower()).Append("&");
			}
			if (this.senderEmail != null)
			{
					sb.Append(prefix).Append("senderEmail").Append("=").Append(HttpUtility.UrlEncode(this.senderEmail, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.returnUrl != null)
			{
					sb.Append(prefix).Append("returnUrl").Append("=").Append(HttpUtility.UrlEncode(this.returnUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.trackingId != null)
			{
					sb.Append(prefix).Append("trackingId").Append("=").Append(HttpUtility.UrlEncode(this.trackingId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.fundingConstraint != null)
			{
					string newPrefix = prefix + "fundingConstraint" + ".";
					sb.Append(this.fundingConstraintField.ToNVPString(newPrefix));
			}
			if (this.sender != null)
			{
					string newPrefix = prefix + "sender" + ".";
					sb.Append(this.senderField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The PayResponse contains the result of the Pay operation.
	/// The payKey and execution status of the request should always
	/// be provided. 
    /// </summary>
	public partial class PayResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string paymentExecStatusField;
		public string paymentExecStatus
		{
			get
			{
				return this.paymentExecStatusField;
			}
			set
			{
				this.paymentExecStatusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PayErrorList payErrorListField;
		public PayErrorList payErrorList
		{
			get
			{
				return this.payErrorListField;
			}
			set
			{
				this.payErrorListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private PaymentInfoList paymentInfoListField;
		public PaymentInfoList paymentInfoList
		{
			get
			{
				return this.paymentInfoListField;
			}
			set
			{
				this.paymentInfoListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderIdentifier senderField;
		public SenderIdentifier sender
		{
			get
			{
				return this.senderField;
			}
			set
			{
				this.senderField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FundingPlan defaultFundingPlanField;
		public FundingPlan defaultFundingPlan
		{
			get
			{
				return this.defaultFundingPlanField;
			}
			set
			{
				this.defaultFundingPlanField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private WarningDataList warningDataListField;
		public WarningDataList warningDataList
		{
			get
			{
				return this.warningDataListField;
			}
			set
			{
				this.warningDataListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PayResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PayResponse object created from the passed in NVP map
	 	/// </returns>
		public static PayResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PayResponse payResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "payKey";
			if (map.ContainsKey(key))
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.payKey = map[key];
			}
			key = prefix + "paymentExecStatus";
			if (map.ContainsKey(key))
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.paymentExecStatus = map[key];
			}
			PayErrorList payErrorList =  PayErrorList.CreateInstance(map, prefix + "payErrorList", -1);
			if (payErrorList != null)
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.payErrorList = payErrorList;
			}
			PaymentInfoList paymentInfoList =  PaymentInfoList.CreateInstance(map, prefix + "paymentInfoList", -1);
			if (paymentInfoList != null)
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.paymentInfoList = paymentInfoList;
			}
			SenderIdentifier sender =  SenderIdentifier.CreateInstance(map, prefix + "sender", -1);
			if (sender != null)
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.sender = sender;
			}
			FundingPlan defaultFundingPlan =  FundingPlan.CreateInstance(map, prefix + "defaultFundingPlan", -1);
			if (defaultFundingPlan != null)
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.defaultFundingPlan = defaultFundingPlan;
			}
			WarningDataList warningDataList =  WarningDataList.CreateInstance(map, prefix + "warningDataList", -1);
			if (warningDataList != null)
			{
				payResponse = (payResponse == null) ? new PayResponse() : payResponse;
				payResponse.warningDataList = warningDataList;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					payResponse = (payResponse == null) ? new PayResponse() : payResponse;
					payResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return payResponse;
		}
	}




	/// <summary>
	/// The request to look up the details of a Preapproval. 
    /// </summary>
	public partial class PreapprovalDetailsRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string preapprovalKeyField;
		public string preapprovalKey
		{
			get
			{
				return this.preapprovalKeyField;
			}
			set
			{
				this.preapprovalKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? getBillingAddressField;
		public bool? getBillingAddress
		{
			get
			{
				return this.getBillingAddressField;
			}
			set
			{
				this.getBillingAddressField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public PreapprovalDetailsRequest(RequestEnvelope requestEnvelope, string preapprovalKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.preapprovalKey = preapprovalKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PreapprovalDetailsRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.preapprovalKey != null)
			{
					sb.Append(prefix).Append("preapprovalKey").Append("=").Append(HttpUtility.UrlEncode(this.preapprovalKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.getBillingAddress != null)
			{
					sb.Append(prefix).Append("getBillingAddress").Append("=").Append(this.getBillingAddress.ToString().ToLower()).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The details of the Preapproval as specified in the
	/// Preapproval operation. 
    /// </summary>
	public partial class PreapprovalDetailsResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? approvedField;
		public bool? approved
		{
			get
			{
				return this.approvedField;
			}
			set
			{
				this.approvedField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string cancelUrlField;
		public string cancelUrl
		{
			get
			{
				return this.cancelUrlField;
			}
			set
			{
				this.cancelUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? curPaymentsField;
		public int? curPayments
		{
			get
			{
				return this.curPaymentsField;
			}
			set
			{
				this.curPaymentsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? curPaymentsAmountField;
		public decimal? curPaymentsAmount
		{
			get
			{
				return this.curPaymentsAmountField;
			}
			set
			{
				this.curPaymentsAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? curPeriodAttemptsField;
		public int? curPeriodAttempts
		{
			get
			{
				return this.curPeriodAttemptsField;
			}
			set
			{
				this.curPeriodAttemptsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string curPeriodEndingDateField;
		public string curPeriodEndingDate
		{
			get
			{
				return this.curPeriodEndingDateField;
			}
			set
			{
				this.curPeriodEndingDateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? dateOfMonthField;
		public int? dateOfMonth
		{
			get
			{
				return this.dateOfMonthField;
			}
			set
			{
				this.dateOfMonthField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private DayOfWeek? dayOfWeekField;
		public DayOfWeek? dayOfWeek
		{
			get
			{
				return this.dayOfWeekField;
			}
			set
			{
				this.dayOfWeekField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string endingDateField;
		public string endingDate
		{
			get
			{
				return this.endingDateField;
			}
			set
			{
				this.endingDateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? maxAmountPerPaymentField;
		public decimal? maxAmountPerPayment
		{
			get
			{
				return this.maxAmountPerPaymentField;
			}
			set
			{
				this.maxAmountPerPaymentField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? maxNumberOfPaymentsField;
		public int? maxNumberOfPayments
		{
			get
			{
				return this.maxNumberOfPaymentsField;
			}
			set
			{
				this.maxNumberOfPaymentsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? maxNumberOfPaymentsPerPeriodField;
		public int? maxNumberOfPaymentsPerPeriod
		{
			get
			{
				return this.maxNumberOfPaymentsPerPeriodField;
			}
			set
			{
				this.maxNumberOfPaymentsPerPeriodField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? maxTotalAmountOfAllPaymentsField;
		public decimal? maxTotalAmountOfAllPayments
		{
			get
			{
				return this.maxTotalAmountOfAllPaymentsField;
			}
			set
			{
				this.maxTotalAmountOfAllPaymentsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string paymentPeriodField;
		public string paymentPeriod
		{
			get
			{
				return this.paymentPeriodField;
			}
			set
			{
				this.paymentPeriodField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string pinTypeField;
		public string pinType
		{
			get
			{
				return this.pinTypeField;
			}
			set
			{
				this.pinTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string returnUrlField;
		public string returnUrl
		{
			get
			{
				return this.returnUrlField;
			}
			set
			{
				this.returnUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string senderEmailField;
		public string senderEmail
		{
			get
			{
				return this.senderEmailField;
			}
			set
			{
				this.senderEmailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string memoField;
		public string memo
		{
			get
			{
				return this.memoField;
			}
			set
			{
				this.memoField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string startingDateField;
		public string startingDate
		{
			get
			{
				return this.startingDateField;
			}
			set
			{
				this.startingDateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string statusField;
		public string status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string ipnNotificationUrlField;
		public string ipnNotificationUrl
		{
			get
			{
				return this.ipnNotificationUrlField;
			}
			set
			{
				this.ipnNotificationUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private AddressList addressListField;
		public AddressList addressList
		{
			get
			{
				return this.addressListField;
			}
			set
			{
				this.addressListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string feesPayerField;
		public string feesPayer
		{
			get
			{
				return this.feesPayerField;
			}
			set
			{
				this.feesPayerField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? displayMaxTotalAmountField;
		public bool? displayMaxTotalAmount
		{
			get
			{
				return this.displayMaxTotalAmountField;
			}
			set
			{
				this.displayMaxTotalAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderIdentifier senderField;
		public SenderIdentifier sender
		{
			get
			{
				return this.senderField;
			}
			set
			{
				this.senderField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PreapprovalDetailsResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PreapprovalDetailsResponse object created from the passed in NVP map
	 	/// </returns>
		public static PreapprovalDetailsResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PreapprovalDetailsResponse preapprovalDetailsResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "approved";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.approved = System.Convert.ToBoolean(map[key]);
			}
			key = prefix + "cancelUrl";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.cancelUrl = map[key];
			}
			key = prefix + "curPayments";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.curPayments = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "curPaymentsAmount";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.curPaymentsAmount = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "curPeriodAttempts";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.curPeriodAttempts = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "curPeriodEndingDate";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.curPeriodEndingDate = map[key];
			}
			key = prefix + "currencyCode";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.currencyCode = map[key];
			}
			key = prefix + "dateOfMonth";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.dateOfMonth = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "dayOfWeek";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.dayOfWeek = (DayOfWeek)EnumUtils.GetValue(map[key],typeof(DayOfWeek));
			}
			key = prefix + "endingDate";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.endingDate = map[key];
			}
			key = prefix + "maxAmountPerPayment";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.maxAmountPerPayment = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "maxNumberOfPayments";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.maxNumberOfPayments = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "maxNumberOfPaymentsPerPeriod";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.maxNumberOfPaymentsPerPeriod = System.Convert.ToInt32(map[key]);
			}
			key = prefix + "maxTotalAmountOfAllPayments";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.maxTotalAmountOfAllPayments = System.Convert.ToDecimal(map[key]);
			}
			key = prefix + "paymentPeriod";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.paymentPeriod = map[key];
			}
			key = prefix + "pinType";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.pinType = map[key];
			}
			key = prefix + "returnUrl";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.returnUrl = map[key];
			}
			key = prefix + "senderEmail";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.senderEmail = map[key];
			}
			key = prefix + "memo";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.memo = map[key];
			}
			key = prefix + "startingDate";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.startingDate = map[key];
			}
			key = prefix + "status";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.status = map[key];
			}
			key = prefix + "ipnNotificationUrl";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.ipnNotificationUrl = map[key];
			}
			AddressList addressList =  AddressList.CreateInstance(map, prefix + "addressList", -1);
			if (addressList != null)
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.addressList = addressList;
			}
			key = prefix + "feesPayer";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.feesPayer = map[key];
			}
			key = prefix + "displayMaxTotalAmount";
			if (map.ContainsKey(key))
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.displayMaxTotalAmount = System.Convert.ToBoolean(map[key]);
			}
			SenderIdentifier sender =  SenderIdentifier.CreateInstance(map, prefix + "sender", -1);
			if (sender != null)
			{
				preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
				preapprovalDetailsResponse.sender = sender;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					preapprovalDetailsResponse = (preapprovalDetailsResponse == null) ? new PreapprovalDetailsResponse() : preapprovalDetailsResponse;
					preapprovalDetailsResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return preapprovalDetailsResponse;
		}
	}




	/// <summary>
	/// A request to create a Preapproval. A Preapproval is an
	/// agreement between a Paypal account holder (the sender) and
	/// the API caller (the service invoker) to make payment(s) on
	/// the the sender's behalf with various limitations defined. 
    /// </summary>
	public partial class PreapprovalRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ClientDetailsType clientDetailsField;
		public ClientDetailsType clientDetails
		{
			get
			{
				return this.clientDetailsField;
			}
			set
			{
				this.clientDetailsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string cancelUrlField;
		public string cancelUrl
		{
			get
			{
				return this.cancelUrlField;
			}
			set
			{
				this.cancelUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? dateOfMonthField;
		public int? dateOfMonth
		{
			get
			{
				return this.dateOfMonthField;
			}
			set
			{
				this.dateOfMonthField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private DayOfWeek? dayOfWeekField;
		public DayOfWeek? dayOfWeek
		{
			get
			{
				return this.dayOfWeekField;
			}
			set
			{
				this.dayOfWeekField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string endingDateField;
		public string endingDate
		{
			get
			{
				return this.endingDateField;
			}
			set
			{
				this.endingDateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? maxAmountPerPaymentField;
		public decimal? maxAmountPerPayment
		{
			get
			{
				return this.maxAmountPerPaymentField;
			}
			set
			{
				this.maxAmountPerPaymentField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? maxNumberOfPaymentsField;
		public int? maxNumberOfPayments
		{
			get
			{
				return this.maxNumberOfPaymentsField;
			}
			set
			{
				this.maxNumberOfPaymentsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private int? maxNumberOfPaymentsPerPeriodField;
		public int? maxNumberOfPaymentsPerPeriod
		{
			get
			{
				return this.maxNumberOfPaymentsPerPeriodField;
			}
			set
			{
				this.maxNumberOfPaymentsPerPeriodField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? maxTotalAmountOfAllPaymentsField;
		public decimal? maxTotalAmountOfAllPayments
		{
			get
			{
				return this.maxTotalAmountOfAllPaymentsField;
			}
			set
			{
				this.maxTotalAmountOfAllPaymentsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string paymentPeriodField;
		public string paymentPeriod
		{
			get
			{
				return this.paymentPeriodField;
			}
			set
			{
				this.paymentPeriodField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string returnUrlField;
		public string returnUrl
		{
			get
			{
				return this.returnUrlField;
			}
			set
			{
				this.returnUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string memoField;
		public string memo
		{
			get
			{
				return this.memoField;
			}
			set
			{
				this.memoField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string ipnNotificationUrlField;
		public string ipnNotificationUrl
		{
			get
			{
				return this.ipnNotificationUrlField;
			}
			set
			{
				this.ipnNotificationUrlField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string senderEmailField;
		public string senderEmail
		{
			get
			{
				return this.senderEmailField;
			}
			set
			{
				this.senderEmailField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string startingDateField;
		public string startingDate
		{
			get
			{
				return this.startingDateField;
			}
			set
			{
				this.startingDateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string pinTypeField;
		public string pinType
		{
			get
			{
				return this.pinTypeField;
			}
			set
			{
				this.pinTypeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string feesPayerField;
		public string feesPayer
		{
			get
			{
				return this.feesPayerField;
			}
			set
			{
				this.feesPayerField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? displayMaxTotalAmountField;
		public bool? displayMaxTotalAmount
		{
			get
			{
				return this.displayMaxTotalAmountField;
			}
			set
			{
				this.displayMaxTotalAmountField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private bool? requireInstantFundingSourceField;
		public bool? requireInstantFundingSource
		{
			get
			{
				return this.requireInstantFundingSourceField;
			}
			set
			{
				this.requireInstantFundingSourceField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderIdentifier senderField;
		public SenderIdentifier sender
		{
			get
			{
				return this.senderField;
			}
			set
			{
				this.senderField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public PreapprovalRequest(RequestEnvelope requestEnvelope, string cancelUrl, string currencyCode, string returnUrl, string startingDate)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.cancelUrl = cancelUrl;
			this.currencyCode = currencyCode;
			this.returnUrl = returnUrl;
			this.startingDate = startingDate;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PreapprovalRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.clientDetails != null)
			{
					string newPrefix = prefix + "clientDetails" + ".";
					sb.Append(this.clientDetailsField.ToNVPString(newPrefix));
			}
			if (this.cancelUrl != null)
			{
					sb.Append(prefix).Append("cancelUrl").Append("=").Append(HttpUtility.UrlEncode(this.cancelUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.currencyCode != null)
			{
					sb.Append(prefix).Append("currencyCode").Append("=").Append(HttpUtility.UrlEncode(this.currencyCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.dateOfMonth != null)
			{
					sb.Append(prefix).Append("dateOfMonth").Append("=").Append(this.dateOfMonth).Append("&");
			}
			if (this.dayOfWeek != null)
			{
					sb.Append(prefix).Append("dayOfWeek").Append("=").Append(EnumUtils.GetDescription(this.dayOfWeek));
					sb.Append("&");
			}
			if (this.endingDate != null)
			{
					sb.Append(prefix).Append("endingDate").Append("=").Append(HttpUtility.UrlEncode(this.endingDate, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.maxAmountPerPayment != null)
			{
					sb.Append(prefix).Append("maxAmountPerPayment").Append("=").Append(Convert.ToString(this.maxAmountPerPayment, DefaultCulture)).Append("&");
			}
			if (this.maxNumberOfPayments != null)
			{
					sb.Append(prefix).Append("maxNumberOfPayments").Append("=").Append(this.maxNumberOfPayments).Append("&");
			}
			if (this.maxNumberOfPaymentsPerPeriod != null)
			{
					sb.Append(prefix).Append("maxNumberOfPaymentsPerPeriod").Append("=").Append(this.maxNumberOfPaymentsPerPeriod).Append("&");
			}
			if (this.maxTotalAmountOfAllPayments != null)
			{
					sb.Append(prefix).Append("maxTotalAmountOfAllPayments").Append("=").Append(Convert.ToString(this.maxTotalAmountOfAllPayments, DefaultCulture)).Append("&");
			}
			if (this.paymentPeriod != null)
			{
					sb.Append(prefix).Append("paymentPeriod").Append("=").Append(HttpUtility.UrlEncode(this.paymentPeriod, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.returnUrl != null)
			{
					sb.Append(prefix).Append("returnUrl").Append("=").Append(HttpUtility.UrlEncode(this.returnUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.memo != null)
			{
					sb.Append(prefix).Append("memo").Append("=").Append(HttpUtility.UrlEncode(this.memo, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.ipnNotificationUrl != null)
			{
					sb.Append(prefix).Append("ipnNotificationUrl").Append("=").Append(HttpUtility.UrlEncode(this.ipnNotificationUrl, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.senderEmail != null)
			{
					sb.Append(prefix).Append("senderEmail").Append("=").Append(HttpUtility.UrlEncode(this.senderEmail, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.startingDate != null)
			{
					sb.Append(prefix).Append("startingDate").Append("=").Append(HttpUtility.UrlEncode(this.startingDate, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.pinType != null)
			{
					sb.Append(prefix).Append("pinType").Append("=").Append(HttpUtility.UrlEncode(this.pinType, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.feesPayer != null)
			{
					sb.Append(prefix).Append("feesPayer").Append("=").Append(HttpUtility.UrlEncode(this.feesPayer, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.displayMaxTotalAmount != null)
			{
					sb.Append(prefix).Append("displayMaxTotalAmount").Append("=").Append(this.displayMaxTotalAmount.ToString().ToLower()).Append("&");
			}
			if (this.requireInstantFundingSource != null)
			{
					sb.Append(prefix).Append("requireInstantFundingSource").Append("=").Append(this.requireInstantFundingSource.ToString().ToLower()).Append("&");
			}
			if (this.sender != null)
			{
					string newPrefix = prefix + "sender" + ".";
					sb.Append(this.senderField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The result of the PreapprovalRequest is a preapprovalKey. 
    /// </summary>
	public partial class PreapprovalResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string preapprovalKeyField;
		public string preapprovalKey
		{
			get
			{
				return this.preapprovalKeyField;
			}
			set
			{
				this.preapprovalKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public PreapprovalResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new PreapprovalResponse object created from the passed in NVP map
	 	/// </returns>
		public static PreapprovalResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			PreapprovalResponse preapprovalResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				preapprovalResponse = (preapprovalResponse == null) ? new PreapprovalResponse() : preapprovalResponse;
				preapprovalResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "preapprovalKey";
			if (map.ContainsKey(key))
			{
				preapprovalResponse = (preapprovalResponse == null) ? new PreapprovalResponse() : preapprovalResponse;
				preapprovalResponse.preapprovalKey = map[key];
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					preapprovalResponse = (preapprovalResponse == null) ? new PreapprovalResponse() : preapprovalResponse;
					preapprovalResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return preapprovalResponse;
		}
	}




	/// <summary>
	/// A request to make a refund based on various criteria. A
	/// refund can be made against the entire payKey, an individual
	/// transaction belonging to a payKey, a tracking id, or a
	/// specific receiver of a payKey. 
    /// </summary>
	public partial class RefundRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string transactionIdField;
		public string transactionId
		{
			get
			{
				return this.transactionIdField;
			}
			set
			{
				this.transactionIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string trackingIdField;
		public string trackingId
		{
			get
			{
				return this.trackingIdField;
			}
			set
			{
				this.trackingIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ReceiverList receiverListField;
		public ReceiverList receiverList
		{
			get
			{
				return this.receiverListField;
			}
			set
			{
				this.receiverListField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public RefundRequest(RequestEnvelope requestEnvelope)
	 	{
			this.requestEnvelope = requestEnvelope;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public RefundRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.currencyCode != null)
			{
					sb.Append(prefix).Append("currencyCode").Append("=").Append(HttpUtility.UrlEncode(this.currencyCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.transactionId != null)
			{
					sb.Append(prefix).Append("transactionId").Append("=").Append(HttpUtility.UrlEncode(this.transactionId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.trackingId != null)
			{
					sb.Append(prefix).Append("trackingId").Append("=").Append(HttpUtility.UrlEncode(this.trackingId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.receiverList != null)
			{
					string newPrefix = prefix + "receiverList" + ".";
					sb.Append(this.receiverListField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The result of a Refund request. 
    /// </summary>
	public partial class RefundResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private RefundInfoList refundInfoListField;
		public RefundInfoList refundInfoList
		{
			get
			{
				return this.refundInfoListField;
			}
			set
			{
				this.refundInfoListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public RefundResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new RefundResponse object created from the passed in NVP map
	 	/// </returns>
		public static RefundResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			RefundResponse refundResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				refundResponse = (refundResponse == null) ? new RefundResponse() : refundResponse;
				refundResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "currencyCode";
			if (map.ContainsKey(key))
			{
				refundResponse = (refundResponse == null) ? new RefundResponse() : refundResponse;
				refundResponse.currencyCode = map[key];
			}
			RefundInfoList refundInfoList =  RefundInfoList.CreateInstance(map, prefix + "refundInfoList", -1);
			if (refundInfoList != null)
			{
				refundResponse = (refundResponse == null) ? new RefundResponse() : refundResponse;
				refundResponse.refundInfoList = refundInfoList;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					refundResponse = (refundResponse == null) ? new RefundResponse() : refundResponse;
					refundResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return refundResponse;
		}
	}




	/// <summary>
	/// The request to set the options of a payment request. 
    /// </summary>
	public partial class SetPaymentOptionsRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private InitiatingEntity initiatingEntityField;
		public InitiatingEntity initiatingEntity
		{
			get
			{
				return this.initiatingEntityField;
			}
			set
			{
				this.initiatingEntityField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private DisplayOptions displayOptionsField;
		public DisplayOptions displayOptions
		{
			get
			{
				return this.displayOptionsField;
			}
			set
			{
				this.displayOptionsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string shippingAddressIdField;
		public string shippingAddressId
		{
			get
			{
				return this.shippingAddressIdField;
			}
			set
			{
				this.shippingAddressIdField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderOptions senderOptionsField;
		public SenderOptions senderOptions
		{
			get
			{
				return this.senderOptionsField;
			}
			set
			{
				this.senderOptionsField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ReceiverOptions> receiverOptionsField = new List<ReceiverOptions>();
		public List<ReceiverOptions> receiverOptions
		{
			get
			{
				return this.receiverOptionsField;
			}
			set
			{
				this.receiverOptionsField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public SetPaymentOptionsRequest(RequestEnvelope requestEnvelope, string payKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.payKey = payKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public SetPaymentOptionsRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.initiatingEntity != null)
			{
					string newPrefix = prefix + "initiatingEntity" + ".";
					sb.Append(this.initiatingEntityField.ToNVPString(newPrefix));
			}
			if (this.displayOptions != null)
			{
					string newPrefix = prefix + "displayOptions" + ".";
					sb.Append(this.displayOptionsField.ToNVPString(newPrefix));
			}
			if (this.shippingAddressId != null)
			{
					sb.Append(prefix).Append("shippingAddressId").Append("=").Append(HttpUtility.UrlEncode(this.shippingAddressId, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.senderOptions != null)
			{
					string newPrefix = prefix + "senderOptions" + ".";
					sb.Append(this.senderOptionsField.ToNVPString(newPrefix));
			}
			for (int i = 0; i < this.receiverOptions.Count; i++)
			{
				if (this.receiverOptions[i] != null)
				{
					string newPrefix = prefix + "receiverOptions" + "(" + i + ").";
					sb.Append(this.receiverOptions[i].ToNVPString(newPrefix));
				}
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The response message for the SetPaymentOption request 
    /// </summary>
	public partial class SetPaymentOptionsResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public SetPaymentOptionsResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new SetPaymentOptionsResponse object created from the passed in NVP map
	 	/// </returns>
		public static SetPaymentOptionsResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			SetPaymentOptionsResponse setPaymentOptionsResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				setPaymentOptionsResponse = (setPaymentOptionsResponse == null) ? new SetPaymentOptionsResponse() : setPaymentOptionsResponse;
				setPaymentOptionsResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					setPaymentOptionsResponse = (setPaymentOptionsResponse == null) ? new SetPaymentOptionsResponse() : setPaymentOptionsResponse;
					setPaymentOptionsResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return setPaymentOptionsResponse;
		}
	}




	/// <summary>
	/// The request to get the funding plans available for a
	/// payment. 
    /// </summary>
	public partial class GetFundingPlansRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetFundingPlansRequest(RequestEnvelope requestEnvelope, string payKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.payKey = payKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetFundingPlansRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The response to get the funding plans available for a
	/// payment. 
    /// </summary>
	public partial class GetFundingPlansResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<FundingPlan> fundingPlanField = new List<FundingPlan>();
		public List<FundingPlan> fundingPlan
		{
			get
			{
				return this.fundingPlanField;
			}
			set
			{
				this.fundingPlanField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetFundingPlansResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetFundingPlansResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetFundingPlansResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetFundingPlansResponse getFundingPlansResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getFundingPlansResponse = (getFundingPlansResponse == null) ? new GetFundingPlansResponse() : getFundingPlansResponse;
				getFundingPlansResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				FundingPlan fundingPlan =  FundingPlan.CreateInstance(map, prefix + "fundingPlan", i);
				if (fundingPlan != null)
				{
					getFundingPlansResponse = (getFundingPlansResponse == null) ? new GetFundingPlansResponse() : getFundingPlansResponse;
					getFundingPlansResponse.fundingPlan.Add(fundingPlan);
					i++;
				} 
				else
				{
					break;
				}
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getFundingPlansResponse = (getFundingPlansResponse == null) ? new GetFundingPlansResponse() : getFundingPlansResponse;
					getFundingPlansResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getFundingPlansResponse;
		}
	}




	/// <summary>
	/// The request to get the addresses available for a payment. 
    /// </summary>
	public partial class GetAvailableShippingAddressesRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string keyField;
		public string key
		{
			get
			{
				return this.keyField;
			}
			set
			{
				this.keyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetAvailableShippingAddressesRequest(RequestEnvelope requestEnvelope, string key)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.key = key;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetAvailableShippingAddressesRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.key != null)
			{
					sb.Append(prefix).Append("key").Append("=").Append(HttpUtility.UrlEncode(this.key, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The response to get the shipping addresses available for a
	/// payment. 
    /// </summary>
	public partial class GetAvailableShippingAddressesResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<Address> availableAddressField = new List<Address>();
		public List<Address> availableAddress
		{
			get
			{
				return this.availableAddressField;
			}
			set
			{
				this.availableAddressField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetAvailableShippingAddressesResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetAvailableShippingAddressesResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetAvailableShippingAddressesResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetAvailableShippingAddressesResponse getAvailableShippingAddressesResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getAvailableShippingAddressesResponse = (getAvailableShippingAddressesResponse == null) ? new GetAvailableShippingAddressesResponse() : getAvailableShippingAddressesResponse;
				getAvailableShippingAddressesResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				Address availableAddress =  Address.CreateInstance(map, prefix + "availableAddress", i);
				if (availableAddress != null)
				{
					getAvailableShippingAddressesResponse = (getAvailableShippingAddressesResponse == null) ? new GetAvailableShippingAddressesResponse() : getAvailableShippingAddressesResponse;
					getAvailableShippingAddressesResponse.availableAddress.Add(availableAddress);
					i++;
				} 
				else
				{
					break;
				}
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getAvailableShippingAddressesResponse = (getAvailableShippingAddressesResponse == null) ? new GetAvailableShippingAddressesResponse() : getAvailableShippingAddressesResponse;
					getAvailableShippingAddressesResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getAvailableShippingAddressesResponse;
		}
	}




	/// <summary>
	/// The request to get the addresses available for a payment. 
    /// </summary>
	public partial class GetShippingAddressesRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string keyField;
		public string key
		{
			get
			{
				return this.keyField;
			}
			set
			{
				this.keyField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetShippingAddressesRequest(RequestEnvelope requestEnvelope, string key)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.key = key;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetShippingAddressesRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.key != null)
			{
					sb.Append(prefix).Append("key").Append("=").Append(HttpUtility.UrlEncode(this.key, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// The response to get the shipping addresses available for a
	/// payment. 
    /// </summary>
	public partial class GetShippingAddressesResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private Address selectedAddressField;
		public Address selectedAddress
		{
			get
			{
				return this.selectedAddressField;
			}
			set
			{
				this.selectedAddressField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetShippingAddressesResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetShippingAddressesResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetShippingAddressesResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetShippingAddressesResponse getShippingAddressesResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getShippingAddressesResponse = (getShippingAddressesResponse == null) ? new GetShippingAddressesResponse() : getShippingAddressesResponse;
				getShippingAddressesResponse.responseEnvelope = responseEnvelope;
			}
			Address selectedAddress =  Address.CreateInstance(map, prefix + "selectedAddress", -1);
			if (selectedAddress != null)
			{
				getShippingAddressesResponse = (getShippingAddressesResponse == null) ? new GetShippingAddressesResponse() : getShippingAddressesResponse;
				getShippingAddressesResponse.selectedAddress = selectedAddress;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getShippingAddressesResponse = (getShippingAddressesResponse == null) ? new GetShippingAddressesResponse() : getShippingAddressesResponse;
					getShippingAddressesResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getShippingAddressesResponse;
		}
	}




	/// <summary>
	/// The request to get the remaining limits for a user 
    /// </summary>
	public partial class GetUserLimitsRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private AccountIdentifier userField;
		public AccountIdentifier user
		{
			get
			{
				return this.userField;
			}
			set
			{
				this.userField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string countryField;
		public string country
		{
			get
			{
				return this.countryField;
			}
			set
			{
				this.countryField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string currencyCodeField;
		public string currencyCode
		{
			get
			{
				return this.currencyCodeField;
			}
			set
			{
				this.currencyCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<string> limitTypeField = new List<string>();
		public List<string> limitType
		{
			get
			{
				return this.limitTypeField;
			}
			set
			{
				this.limitTypeField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetUserLimitsRequest(RequestEnvelope requestEnvelope, AccountIdentifier user, string country, string currencyCode, List<string> limitType)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.user = user;
			this.country = country;
			this.currencyCode = currencyCode;
			this.limitType = limitType;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetUserLimitsRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.user != null)
			{
					string newPrefix = prefix + "user" + ".";
					sb.Append(this.userField.ToNVPString(newPrefix));
			}
			if (this.country != null)
			{
					sb.Append(prefix).Append("country").Append("=").Append(HttpUtility.UrlEncode(this.country, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.currencyCode != null)
			{
					sb.Append(prefix).Append("currencyCode").Append("=").Append(HttpUtility.UrlEncode(this.currencyCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			for (int i = 0; i < this.limitType.Count; i++)
			{
				if (this.limitType[i] != null)
				{
					sb.Append(prefix).Append("limitType").Append("(").Append(i).Append(")").Append("=").Append(HttpUtility.UrlEncode(this.limitType[i], BaseConstants.ENCODING_FORMAT)).Append("&");
				}
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// A response that contains a list of remaining limits 
    /// </summary>
	public partial class GetUserLimitsResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<UserLimit> userLimitField = new List<UserLimit>();
		public List<UserLimit> userLimit
		{
			get
			{
				return this.userLimitField;
			}
			set
			{
				this.userLimitField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private WarningDataList warningDataListField;
		public WarningDataList warningDataList
		{
			get
			{
				return this.warningDataListField;
			}
			set
			{
				this.warningDataListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetUserLimitsResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetUserLimitsResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetUserLimitsResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetUserLimitsResponse getUserLimitsResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getUserLimitsResponse = (getUserLimitsResponse == null) ? new GetUserLimitsResponse() : getUserLimitsResponse;
				getUserLimitsResponse.responseEnvelope = responseEnvelope;
			}
			i = 0;
			while(true)
			{
				UserLimit userLimit =  UserLimit.CreateInstance(map, prefix + "userLimit", i);
				if (userLimit != null)
				{
					getUserLimitsResponse = (getUserLimitsResponse == null) ? new GetUserLimitsResponse() : getUserLimitsResponse;
					getUserLimitsResponse.userLimit.Add(userLimit);
					i++;
				} 
				else
				{
					break;
				}
			}
			WarningDataList warningDataList =  WarningDataList.CreateInstance(map, prefix + "warningDataList", -1);
			if (warningDataList != null)
			{
				getUserLimitsResponse = (getUserLimitsResponse == null) ? new GetUserLimitsResponse() : getUserLimitsResponse;
				getUserLimitsResponse.warningDataList = warningDataList;
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getUserLimitsResponse = (getUserLimitsResponse == null) ? new GetUserLimitsResponse() : getUserLimitsResponse;
					getUserLimitsResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getUserLimitsResponse;
		}
	}




	/// <summary>
	/// ReceiverInfo needs to be populate for the receiver who
	/// doesn't have paypal account. 
    /// </summary>
	public partial class ReceiverInfo : AccountIdentifier	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string countryCodeField;
		public string countryCode
		{
			get
			{
				return this.countryCodeField;
			}
			set
			{
				this.countryCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string firstNameField;
		public string firstName
		{
			get
			{
				return this.firstNameField;
			}
			set
			{
				this.firstNameField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string lastNameField;
		public string lastName
		{
			get
			{
				return this.lastNameField;
			}
			set
			{
				this.lastNameField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverInfo()
	 	{
		}


		public new string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(base.ToNVPString(prefix));
			if (this.countryCode != null)
			{
					sb.Append(prefix).Append("countryCode").Append("=").Append(HttpUtility.UrlEncode(this.countryCode, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.firstName != null)
			{
					sb.Append(prefix).Append("firstName").Append("=").Append(HttpUtility.UrlEncode(this.firstName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.lastName != null)
			{
					sb.Append(prefix).Append("lastName").Append("=").Append(HttpUtility.UrlEncode(this.lastName, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// FeeDisclosure contains the information related to Fees and
	/// taxes. 
    /// </summary>
	public partial class FeeDisclosure	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType feeField;
		public CurrencyType fee
		{
			get
			{
				return this.feeField;
			}
			set
			{
				this.feeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType taxesField;
		public CurrencyType taxes
		{
			get
			{
				return this.taxesField;
			}
			set
			{
				this.taxesField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public FeeDisclosure()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new FeeDisclosure object created from the passed in NVP map
	 	/// </returns>
		public static FeeDisclosure CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			FeeDisclosure feeDisclosure = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			CurrencyType fee =  CurrencyType.CreateInstance(map, prefix + "fee", -1);
			if (fee != null)
			{
				feeDisclosure = (feeDisclosure == null) ? new FeeDisclosure() : feeDisclosure;
				feeDisclosure.fee = fee;
			}
			CurrencyType taxes =  CurrencyType.CreateInstance(map, prefix + "taxes", -1);
			if (taxes != null)
			{
				feeDisclosure = (feeDisclosure == null) ? new FeeDisclosure() : feeDisclosure;
				feeDisclosure.taxes = taxes;
			}
			return feeDisclosure;
		}
	}




	/// <summary>
	/// SenderDisclosure contains the disclosure related to Sender 
    /// </summary>
	public partial class SenderDisclosure	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType amountToTransferField;
		public CurrencyType amountToTransfer
		{
			get
			{
				return this.amountToTransferField;
			}
			set
			{
				this.amountToTransferField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FeeDisclosure feeDisclosureField;
		public FeeDisclosure feeDisclosure
		{
			get
			{
				return this.feeDisclosureField;
			}
			set
			{
				this.feeDisclosureField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType totalAmountToTransferField;
		public CurrencyType totalAmountToTransfer
		{
			get
			{
				return this.totalAmountToTransferField;
			}
			set
			{
				this.totalAmountToTransferField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public SenderDisclosure()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new SenderDisclosure object created from the passed in NVP map
	 	/// </returns>
		public static SenderDisclosure CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			SenderDisclosure senderDisclosure = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			CurrencyType amountToTransfer =  CurrencyType.CreateInstance(map, prefix + "amountToTransfer", -1);
			if (amountToTransfer != null)
			{
				senderDisclosure = (senderDisclosure == null) ? new SenderDisclosure() : senderDisclosure;
				senderDisclosure.amountToTransfer = amountToTransfer;
			}
			FeeDisclosure feeDisclosure =  FeeDisclosure.CreateInstance(map, prefix + "feeDisclosure", -1);
			if (feeDisclosure != null)
			{
				senderDisclosure = (senderDisclosure == null) ? new SenderDisclosure() : senderDisclosure;
				senderDisclosure.feeDisclosure = feeDisclosure;
			}
			CurrencyType totalAmountToTransfer =  CurrencyType.CreateInstance(map, prefix + "totalAmountToTransfer", -1);
			if (totalAmountToTransfer != null)
			{
				senderDisclosure = (senderDisclosure == null) ? new SenderDisclosure() : senderDisclosure;
				senderDisclosure.totalAmountToTransfer = totalAmountToTransfer;
			}
			return senderDisclosure;
		}
	}




	/// <summary>
	/// This holds the conversion rate from "Sender currency for one
	/// bucks to equivalent value in the receivers currency" 
    /// </summary>
	public partial class ConversionRate	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private string senderCurrencyField;
		public string senderCurrency
		{
			get
			{
				return this.senderCurrencyField;
			}
			set
			{
				this.senderCurrencyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string receiverCurrencyField;
		public string receiverCurrency
		{
			get
			{
				return this.receiverCurrencyField;
			}
			set
			{
				this.receiverCurrencyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private decimal? exchangeRateField;
		public decimal? exchangeRate
		{
			get
			{
				return this.exchangeRateField;
			}
			set
			{
				this.exchangeRateField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ConversionRate()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ConversionRate object created from the passed in NVP map
	 	/// </returns>
		public static ConversionRate CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ConversionRate conversionRate = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			key = prefix + "senderCurrency";
			if (map.ContainsKey(key))
			{
				conversionRate = (conversionRate == null) ? new ConversionRate() : conversionRate;
				conversionRate.senderCurrency = map[key];
			}
			key = prefix + "receiverCurrency";
			if (map.ContainsKey(key))
			{
				conversionRate = (conversionRate == null) ? new ConversionRate() : conversionRate;
				conversionRate.receiverCurrency = map[key];
			}
			key = prefix + "exchangeRate";
			if (map.ContainsKey(key))
			{
				conversionRate = (conversionRate == null) ? new ConversionRate() : conversionRate;
				conversionRate.exchangeRate = System.Convert.ToDecimal(map[key]);
			}
			return conversionRate;
		}
	}




	/// <summary>
	/// ReceiverDisclosure contains the disclosure related to
	/// Receiver/Receivers. 
    /// </summary>
	public partial class ReceiverDisclosure	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private AccountIdentifier accountIdentifierField;
		public AccountIdentifier accountIdentifier
		{
			get
			{
				return this.accountIdentifierField;
			}
			set
			{
				this.accountIdentifierField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType amountReceivedFromSenderField;
		public CurrencyType amountReceivedFromSender
		{
			get
			{
				return this.amountReceivedFromSenderField;
			}
			set
			{
				this.amountReceivedFromSenderField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string countryCodeField;
		public string countryCode
		{
			get
			{
				return this.countryCodeField;
			}
			set
			{
				this.countryCodeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ConversionRate conversionRateField;
		public ConversionRate conversionRate
		{
			get
			{
				return this.conversionRateField;
			}
			set
			{
				this.conversionRateField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private FeeDisclosure feeDisclosureField;
		public FeeDisclosure feeDisclosure
		{
			get
			{
				return this.feeDisclosureField;
			}
			set
			{
				this.feeDisclosureField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private CurrencyType totalAmountReceivedField;
		public CurrencyType totalAmountReceived
		{
			get
			{
				return this.totalAmountReceivedField;
			}
			set
			{
				this.totalAmountReceivedField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverDisclosure()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ReceiverDisclosure object created from the passed in NVP map
	 	/// </returns>
		public static ReceiverDisclosure CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ReceiverDisclosure receiverDisclosure = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			AccountIdentifier accountIdentifier =  AccountIdentifier.CreateInstance(map, prefix + "accountIdentifier", -1);
			if (accountIdentifier != null)
			{
				receiverDisclosure = (receiverDisclosure == null) ? new ReceiverDisclosure() : receiverDisclosure;
				receiverDisclosure.accountIdentifier = accountIdentifier;
			}
			CurrencyType amountReceivedFromSender =  CurrencyType.CreateInstance(map, prefix + "amountReceivedFromSender", -1);
			if (amountReceivedFromSender != null)
			{
				receiverDisclosure = (receiverDisclosure == null) ? new ReceiverDisclosure() : receiverDisclosure;
				receiverDisclosure.amountReceivedFromSender = amountReceivedFromSender;
			}
			key = prefix + "countryCode";
			if (map.ContainsKey(key))
			{
				receiverDisclosure = (receiverDisclosure == null) ? new ReceiverDisclosure() : receiverDisclosure;
				receiverDisclosure.countryCode = map[key];
			}
			ConversionRate conversionRate =  ConversionRate.CreateInstance(map, prefix + "conversionRate", -1);
			if (conversionRate != null)
			{
				receiverDisclosure = (receiverDisclosure == null) ? new ReceiverDisclosure() : receiverDisclosure;
				receiverDisclosure.conversionRate = conversionRate;
			}
			FeeDisclosure feeDisclosure =  FeeDisclosure.CreateInstance(map, prefix + "feeDisclosure", -1);
			if (feeDisclosure != null)
			{
				receiverDisclosure = (receiverDisclosure == null) ? new ReceiverDisclosure() : receiverDisclosure;
				receiverDisclosure.feeDisclosure = feeDisclosure;
			}
			CurrencyType totalAmountReceived =  CurrencyType.CreateInstance(map, prefix + "totalAmountReceived", -1);
			if (totalAmountReceived != null)
			{
				receiverDisclosure = (receiverDisclosure == null) ? new ReceiverDisclosure() : receiverDisclosure;
				receiverDisclosure.totalAmountReceived = totalAmountReceived;
			}
			return receiverDisclosure;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class ReceiverDisclosureList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<ReceiverDisclosure> receiverDisclosureField = new List<ReceiverDisclosure>();
		public List<ReceiverDisclosure> receiverDisclosure
		{
			get
			{
				return this.receiverDisclosureField;
			}
			set
			{
				this.receiverDisclosureField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverDisclosureList()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new ReceiverDisclosureList object created from the passed in NVP map
	 	/// </returns>
		public static ReceiverDisclosureList CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			ReceiverDisclosureList receiverDisclosureList = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			i = 0;
			while(true)
			{
				ReceiverDisclosure receiverDisclosure =  ReceiverDisclosure.CreateInstance(map, prefix + "receiverDisclosure", i);
				if (receiverDisclosure != null)
				{
					receiverDisclosureList = (receiverDisclosureList == null) ? new ReceiverDisclosureList() : receiverDisclosureList;
					receiverDisclosureList.receiverDisclosure.Add(receiverDisclosure);
					i++;
				} 
				else
				{
					break;
				}
			}
			return receiverDisclosureList;
		}
	}




	/// <summary>
	/// 
    /// </summary>
	public partial class ReceiverInfoList	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private List<ReceiverInfo> receiverInfoField = new List<ReceiverInfo>();
		public List<ReceiverInfo> receiverInfo
		{
			get
			{
				return this.receiverInfoField;
			}
			set
			{
				this.receiverInfoField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public ReceiverInfoList(List<ReceiverInfo> receiverInfo)
	 	{
			this.receiverInfo = receiverInfo;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public ReceiverInfoList()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			for (int i = 0; i < this.receiverInfo.Count; i++)
			{
				if (this.receiverInfo[i] != null)
				{
					string newPrefix = prefix + "receiverInfo" + "(" + i + ").";
					sb.Append(this.receiverInfo[i].ToNVPString(newPrefix));
				}
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// GetPrePaymentDisclosureRequest is used to get the PrePayment
	/// Disclosure.; GetPrePaymentDisclosureRequest contains
	/// following parameters payKey :The pay key that identifies the
	/// payment for which you want to retrieve details. this is the
	/// pay key returned in the PayResponse message.
	/// receiverInfoList : This is an optional.This needs to be
	/// provided in case of Unilateral scenario. receiverInfoList
	/// has a list of ReceiverInfo type. List is provided here to
	/// support in future for Parallel/Chained Payemnts. Each
	/// ReceiverInfo has following variables firstName : firstName
	/// of recipient.  lastName : lastName of recipient. 
	/// countryCode : CountryCode of Recipient. 
    /// </summary>
	public partial class GetPrePaymentDisclosureRequest	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private RequestEnvelope requestEnvelopeField;
		public RequestEnvelope requestEnvelope
		{
			get
			{
				return this.requestEnvelopeField;
			}
			set
			{
				this.requestEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string payKeyField;
		public string payKey
		{
			get
			{
				return this.payKeyField;
			}
			set
			{
				this.payKeyField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ReceiverInfoList receiverInfoListField;
		public ReceiverInfoList receiverInfoList
		{
			get
			{
				return this.receiverInfoListField;
			}
			set
			{
				this.receiverInfoListField = value;
			}
		}
		

		/// <summary>
		/// Constructor with arguments
	 	/// </summary>
	 	public GetPrePaymentDisclosureRequest(RequestEnvelope requestEnvelope, string payKey)
	 	{
			this.requestEnvelope = requestEnvelope;
			this.payKey = payKey;
		}

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetPrePaymentDisclosureRequest()
	 	{
		}


		public string ToNVPString(string prefix)
		{
			StringBuilder sb = new StringBuilder();
			if (this.requestEnvelope != null)
			{
					string newPrefix = prefix + "requestEnvelope" + ".";
					sb.Append(this.requestEnvelopeField.ToNVPString(newPrefix));
			}
			if (this.payKey != null)
			{
					sb.Append(prefix).Append("payKey").Append("=").Append(HttpUtility.UrlEncode(this.payKey, BaseConstants.ENCODING_FORMAT)).Append("&");
			}
			if (this.receiverInfoList != null)
			{
					string newPrefix = prefix + "receiverInfoList" + ".";
					sb.Append(this.receiverInfoListField.ToNVPString(newPrefix));
			}
			return sb.ToString();
		}
	}




	/// <summary>
	/// GetPrePaymentDisclosureResponse contains the information
	/// related to PrePayment disclosure. status : indicates the
	/// status of response. If Status = RTR then it means that this
	/// is RTR transaction. If Status = NON_RTR then it means that
	/// this is non RTR transaction. If Status =
	/// MISSING_RECEIVER_COUNTRY_INFORMATION then it means the
	/// Receiver country information is not found in PayPal
	/// database. So merchant has to call the API again with same
	/// set of parameter along with Receiver country code.This is
	/// useful in case of Unilateral scenario. where receiver is not
	/// holding paypal account. feePayer:Indicates who has agreed to
	/// Pay a Fee for the RTR transaction. Merchant can use this
	/// information to decide who actually has to pay the fee .
	/// senderDisclosure : This Variable Holds the disclosure
	/// related to sender. receiverDisclosureList : This list
	/// contains the disclosure information related to receivers.
	/// Merchant can just parse the details what ever is avaliable
	/// in the response and display the same to user. 
    /// </summary>
	public partial class GetPrePaymentDisclosureResponse	{
		
		// Default US culture info
		private static CultureInfo DefaultCulture = new CultureInfo("en-US");

		/// <summary>
		/// 
		/// </summary>
		private ResponseEnvelope responseEnvelopeField;
		public ResponseEnvelope responseEnvelope
		{
			get
			{
				return this.responseEnvelopeField;
			}
			set
			{
				this.responseEnvelopeField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private Status? statusField;
		public Status? status
		{
			get
			{
				return this.statusField;
			}
			set
			{
				this.statusField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string feesPayerField;
		public string feesPayer
		{
			get
			{
				return this.feesPayerField;
			}
			set
			{
				this.feesPayerField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private SenderDisclosure senderDisclosureField;
		public SenderDisclosure senderDisclosure
		{
			get
			{
				return this.senderDisclosureField;
			}
			set
			{
				this.senderDisclosureField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private ReceiverDisclosureList receiverDisclosureListField;
		public ReceiverDisclosureList receiverDisclosureList
		{
			get
			{
				return this.receiverDisclosureListField;
			}
			set
			{
				this.receiverDisclosureListField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private string disclaimerField;
		public string disclaimer
		{
			get
			{
				return this.disclaimerField;
			}
			set
			{
				this.disclaimerField = value;
			}
		}
		

		/// <summary>
		/// 
		/// </summary>
		private List<ErrorData> errorField = new List<ErrorData>();
		public List<ErrorData> error
		{
			get
			{
				return this.errorField;
			}
			set
			{
				this.errorField = value;
			}
		}
		

		/// <summary>
		/// Default Constructor
	 	/// </summary>
	 	public GetPrePaymentDisclosureResponse()
	 	{
		}


		/// <summary>
		/// Factory method for creating new object instances. For use by the de-serialization classes only.
	 	/// </summary>
	 	/// <param name="map">NVP map as returned by an API call</param>
	 	/// <param name="prefix">NVP prefix for this class in the response</param>
	 	/// <param name="index">For array elements, index of this element in the response</param>
	 	/// <returns>
	 	/// A new GetPrePaymentDisclosureResponse object created from the passed in NVP map
	 	/// </returns>
		public static GetPrePaymentDisclosureResponse CreateInstance(Dictionary<string, string> map, string prefix, int index)
		{
			GetPrePaymentDisclosureResponse getPrePaymentDisclosureResponse = null;
			string key;
			int i = 0;
			if(index != -1)
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + "(" + index + ").";
				}
			} 
			else
			{
				if (prefix.Length > 0 && !prefix.EndsWith("."))
				{
					prefix = prefix + ".";
				}
			}
			ResponseEnvelope responseEnvelope =  ResponseEnvelope.CreateInstance(map, prefix + "responseEnvelope", -1);
			if (responseEnvelope != null)
			{
				getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
				getPrePaymentDisclosureResponse.responseEnvelope = responseEnvelope;
			}
			key = prefix + "status";
			if (map.ContainsKey(key))
			{
				getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
				getPrePaymentDisclosureResponse.status = (Status)EnumUtils.GetValue(map[key],typeof(Status));
			}
			key = prefix + "feesPayer";
			if (map.ContainsKey(key))
			{
				getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
				getPrePaymentDisclosureResponse.feesPayer = map[key];
			}
			SenderDisclosure senderDisclosure =  SenderDisclosure.CreateInstance(map, prefix + "senderDisclosure", -1);
			if (senderDisclosure != null)
			{
				getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
				getPrePaymentDisclosureResponse.senderDisclosure = senderDisclosure;
			}
			ReceiverDisclosureList receiverDisclosureList =  ReceiverDisclosureList.CreateInstance(map, prefix + "receiverDisclosureList", -1);
			if (receiverDisclosureList != null)
			{
				getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
				getPrePaymentDisclosureResponse.receiverDisclosureList = receiverDisclosureList;
			}
			key = prefix + "disclaimer";
			if (map.ContainsKey(key))
			{
				getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
				getPrePaymentDisclosureResponse.disclaimer = map[key];
			}
			i = 0;
			while(true)
			{
				ErrorData error =  ErrorData.CreateInstance(map, prefix + "error", i);
				if (error != null)
				{
					getPrePaymentDisclosureResponse = (getPrePaymentDisclosureResponse == null) ? new GetPrePaymentDisclosureResponse() : getPrePaymentDisclosureResponse;
					getPrePaymentDisclosureResponse.error.Add(error);
					i++;
				} 
				else
				{
					break;
				}
			}
			return getPrePaymentDisclosureResponse;
		}
	}





}