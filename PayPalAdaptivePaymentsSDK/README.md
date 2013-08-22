
# PayPal Adaptive Payments SDK

The PayPal Adaptive Payments API enables merchants and developers to pay almost anyone and set up automated payments. The PayPal Adaptive Payments SDK provides the following methods:

   * Payments
      * Pay: Transfers funds from a sender's PayPal account to one or more receivers' PayPal accounts (up to 6 receivers).
      * PaymentDetails: Obtains information about a payment created with the Pay API operation.
      * ExecutePayment: Executes a payment.
      * GetPaymentOptions: Obtain the settings specified with the SetPaymentOptions API operation.
      * SetPaymentOptions: Sets payment options.
   * Preapprovals
      * Preapproval: Sets up preapprovals, which is an approval to make future payments on the sender's behalf.
      * PreapprovalDetails: Obtains information about a preapproval.
      * CancelPreapproval: Cancels a preapproval.
   * Other Operations
      * Refund: Refunds all or part of a payment
      * ConvertCurrency: Obtains the current foreign exchange (FX) rate for a specific amount and currency.
      * GetFundingPlans: Determines the funding sources that are available for a specified payment.
      * GetShippingAddresses: Obtains the selected shipping address.

## Prerequisites

   * Visual Studio 2005 or higher
   * .NET Framework 2.0 or higher
   * (Optional) NuGet 2.2 for managing dependencies

## Using the SDK

   To use the SDK in your application, you must
   
   * Get the PayPalAdaptivePaymentsSDK dll via NuGet or from the download bundle and add references to the PayPalAdaptivePaymentsSDK and PayPalCoreSDK libraries.
   * Configure your app as detailed in the configuration section.
   
## SDK Configuration

  An application that uses the PayPal SDKs can be configured in one of two ways -
  
  * Using the Web.Config / App.Config files.

	```html
    <configSections>
	<section name="paypal" type="PayPal.Manager.SDKConfigHandler, PayPalCoreSDK" />
	<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />
	</configSections>
	<!-- PayPal SDK config -->
	<paypal>
	<settings>
	    <add name="mode" value="sandbox"/>	    
	    <add name="connectionTimeout" value="30000"/>
	    .....
	</settings>
	<accounts>
	    <account apiUsername="jb-us-seller_api1.paypal.com" apiPassword="..." apiSignature="..." applicationId='...' />
	    <account apiUsername="enduser_biz_api1.gmail.com" apiPassword="..." apiCertificate="..." privateKeyPassword="..." applicationId='...' />
	</accounts>
	</paypal>
    ```
  
  * Or, by dynamically passing in a dictionary (that you can load from a database or as suits your needs).

    ```csharp
    Dictionary<string, string> config = new Dictionary<string, string>();
    config.Add("mode", "sandbox");
    config.Add("account1.apiUsername", "jb-us-seller_api1.paypal.com");
    config.Add("account1.apiPassword", "...");
    config.Add("account1.apiSignature", "...");
    config.Add("account1.applicationId", "...");    

    AdaptivePaymentsService service = new  AdaptivePaymentsService(config);
    ```

	You can refer full list of configuration parameters in [wiki](https://github.com/paypal/sdk-core-dotnet/wiki/SDK-Configuration-Parameters)
	
## Links

   * [Installing NuGet in Visual Studio 2005 & 2008] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2005-&-2008)
   * [Installing NuGet in Visual Studio 2010 & 2012] (https://github.com/paypal/sdk-core-dotnet/wiki/Using-Nuget-in-Visual-Studio-2010-&-2012)
