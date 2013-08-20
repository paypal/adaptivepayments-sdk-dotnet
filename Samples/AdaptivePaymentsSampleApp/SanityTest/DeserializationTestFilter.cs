using System;
using System.Collections.Generic;
using System.Web;

using PayPal.Util;

namespace AdaptivePaymentsSampleApp.SanityTest
{
    public class DeserializationTestFilter : IHttpModule
    {
        private HttpApplication httpApp;

        public void Init(HttpApplication httpApp)
        {
            this.httpApp = httpApp;
            httpApp.PostRequestHandlerExecute +=
                        (new EventHandler(this.Application_PreSendRequestContent));
        }

        private void Application_PreSendRequestContent(Object source,
          EventArgs e)
        {
            HttpApplication application = (HttpApplication)source;
            HttpContext context = application.Context;

            if (context.Items.Contains("responseObject")) {
                Object responseObj = context.Items["responseObject"];       
                string originalResponse = (string) context.Items["responsePayload"];
                Dictionary<string, string> constructedMap = ReflectionUtil.decodeResponseObject(responseObj, string.Empty);
                NVPUtil nvpUtil = new NVPUtil();
                Dictionary<string, string> originalMap = nvpUtil.ParseNVPString(originalResponse);

                if (!originalMap.Equals(constructedMap)) {			        
			        foreach (string key in originalMap.Keys) {
				        if (!originalMap[key].Equals(constructedMap[key])) {
					        context.Response.Write(
                                "Original: " + key + " => " + originalMap[key]
									+ " : " + "Constructed: " + key + " => "
							        + constructedMap[key] + "<br/>");
				        }
			        }
		        }
            }            
        }

        public void Dispose()
        { }
    }
}
