The AdaptivePaymentsSampleApp ASP.NET C# Web Application contains the PayPal Adaptive Payments API Samples. 


Prerequisites
-------------
*	Visual Studio 2005 or higher
*	NuGet 2.2 or higher in case of NuGet Install [Note: NuGet requires .NET Framework 4.0 or higher] 

AJAX
----
•	AJAX .NET Framework 2.0 - Visual Studio 2005
•	[Install ASPAJAXExtSetup.msi in Samples\AdaptivePaymentsSampleApp\AJAX\AJAX .NET Framework 2.0\Microsoft ASPNET 2.0 AJAX Extensions 1.0]
•	[Note: Uncomment tagPrefix="asp" in <pages><controls> and verb="GET,HEAD" <httpHandlers> in <system.web> in Web.config]

•	AJAX .NET Framework 3.5 - Visual Studio 2008 
•	[Note: Uncomment tagPrefix="asp" in <pages><controls> and verb="GET,HEAD" <httpHandlers> in <system.web> in Web.config]

•	AJAX .NET Framework 4.0 - Visual Studio 2010

•	AJAX .NET Framework 4.5 - Visual Studio 2012


The PayPal Adaptive Payments API Samples
----------------------------------------
*	Payments:
	Pay: Transfers funds from a sender's PayPal account to one or more receivers' PayPal accounts (up to 6 receivers)
	PaymentDetails: Obtains information about a payment created with the Pay API operation
	ExecutePayment: Executes a payment
	GetPaymentOptions: Obtain the settings specified with the SetPaymentOptions API operation
	SetPaymentOptions: Sets payment options

*	Preapprovals:
	Preapproval: Sets up preapprovals, which is an approval to make future payments on the sender's behalf
	PreapprovalDetails: Obtains information about a preapproval
	CancelPreapproval: Cancels a preapproval

*	Other Operations:
	Refund: Refunds all or part of a payment
	ConvertCurrency: Obtains the current foreign exchange (FX) rate for a specific amount and currency
	GetFundingPlans: Determines the funding sources that are available for a specified payment
	GetShippingAddresses: Obtains the selected shipping address


NuGet – Installing NuGet in Visual Studio 2010 and 2012
-------------------------------------------------------

Go to Visual Studio 2010 Menu --> Tools
Select Extension Manager…
Enter NuGet in the search box and click Online Gallery
Let it Retrieve information…
Select the retrieved NuGet Package Manager, click Download
Let it Download…
Click Install on the Visual Studio Extension Installer NuGet Package Manager
Let it Install…
Click Close and Restart Now

Go to Visual Studio 2010 Menu --> Tools, select Options…
Verify the following on the Options popup
Click Package Manager --> Package Sources
Available package sources:
Check box (checked) NuGet official package source
https://nuget.org/api/v2/
Name: NuGet official package source
Source: https://nuget.org/api/v2/
And click OK
 
Go to Menu --> Tools --> Library Package Manage --> Package Manager Console
Select NuGet official package source from the Package source dropdown box in the Package Manager Console
Go to Solution Explorer and note the existing references
Enter at PM> Install-Package PayPalAdaptivePaymentsSDK

On enter key-press, the output window should display: "Successfully installed"

After successful installation, note that the new references get added automatically

Also, go to Menu --> Tools --> Library Package Manager, select Manage NuGet Packages for Solution…
On Manage NuGet Packages, search for 'PayPalCoreSDK' to get the details
	

NuGet - Integrating NuGet with Visual Studio 2005 and 2008
----------------------------------------------------------

Prerequisites:
•	.NET Framework 4.0
•	NuGet.exe
	
Check if .NET Framework 4.0 is installed in the computer from Control Panel --> Get programs

Or run the following command from Windows command prompt:
>dir  /b  %windir%\Microsoft.NET\Framework\v*

Running the aforesaid command should list the .NET Framework versions installed as follows:
v1.0.3705
v1.1.4322
v2.0.50727
v3.0
v3.5
v4.0.30319

Note: Most Windows machines would have .NET Framework 4.0 installed as part of Windows (recommended) update.

If V4.X is not installed, then download and install
•	.NET Framework 4 (Standalone Installer) – (free to download):
http://www.microsoft.com/en-in/download/details.aspx?id=17718

Or

•	.NET Framework 4 (Web Installer) – (free to download):
http://www.microsoft.com/en-in/download/details.aspx?id=17851

Download NuGet.exe Command Line (free to download): http://nuget.codeplex.com/releases/view/58939

Save NuGet.exe to folder viz., 'C:\NuGet' and add its path to the Environment Variables Path:

Visual Studio 2005 or 2008
Go to Visual Studio Menu --> Tools
Select External Tools…
External Tools
External Tools having 5* default tools in the Menu contents, Click Add
*Note: The number of default tools may differ depending on the particular Visual Studio installation
 
Enter the following:
Title: NuGet Install
Command (Having in Environment Variables Path): NuGet.exe
Arguments: Install your.package.name -OutputDirectory .\packages
Initial directory: $(SolutionDir)
Use Output window: Check
Prompt for arguments: Check
Click Apply
Click OK

On Clicking Apply and OK, NuGet Install will be added (as External Command 6*) to Menu --> Tools
*Note: The External Command number may differ depending on the particular Visual Studio installation

Menu --> Tools, clicking NuGet Install will pop up for NuGet Install Arguments and Command Line
Also, NuGet Toolbar can be added, right-click on Visual Studio Menu and select Customize…
Customize by clicking New…
Enter Toolbar name: NuGet and click OK
Check NuGet Checkbox in the Toolbars tab for NuGet Toolbar to pop up
Click Commands tab and select Tools and External Command 6 (Having added NuGet Install as External Command 6*) 
*Note: The External Command number may differ depending on the particular Visual Studio installation
Drag and drop External Command 6 to NuGet Toolbar
Right-click NuGet Toolbar
Enter Name: Install Package
Right-click Change Button Image and select an image
Close Customize
Drag and drop NuGet Toolbar to the Menu
Click the NuGet Toolbar Install Package
Clicking on the NuGet Toolbar Install Package will pop up for NuGet Install Arguments and Command Line
Example NuGet Install:
Enter Arguments: 
Install PayPalCoreSDK -OutputDirectory .\packages

On clicking OK, the output window should display: "Successfully installed"

Menu View --> Output (Ctrl+Alt+O)

The 'PayPalCoreSDK' Package including the dependencies will be downloaded to the 'Packages' folder root directory of the Solution (.sln) file.

Select 'Packages' folder by clicking it and then click 'Show All Files' in the Solution Explorer
Note: If 'Packages' folder was not included in the Solution Explorer, click 'Show All Files' before clicking 'Refresh'
Add the references to the dependent files downloaded to 'Packages' folder:

Note: By default, the root directory of Nuget Installation is the same as that of the Solution (.sln) file.
In case of a direct installation using Visual Studio without loading any solution: 
The typical location for Visual Studio 2005:    
 'C:\Program Files (x86)\Microsoft Visual Studio 8\Common7\IDE\'
The typical Installation location for Visual Studio 2008:
'C:\Program Files (x86)\Microsoft Visual Studio 9.0\Common7\IDE\'


