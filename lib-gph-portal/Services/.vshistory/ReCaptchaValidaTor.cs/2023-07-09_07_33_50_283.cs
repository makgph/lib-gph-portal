using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Text;

namespace sa.gov.libgph.Services
{
    public static class ReCaptchaValidaTor
    {
        public static bool Validate(string response)
        {
            string secret = ConfigurationManager.AppSettings["reCaptchaPrivateKey"];
            string ReCaptchaValidaTorURL = ConfigurationManager.AppSettings["ReCaptchaValidaTorURL"];
            NameValueCollection data = new NameValueCollection();
            data["secret"] = secret;
            data["response"] = response;

            using (WebClient client = new WebClient())
            {
                byte[] responseBytes = client.UploadValues(ReCaptchaValidaTorURL, "POST", data);
                string responseJson = Encoding.UTF8.GetString(responseBytes);
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);
                return responseObject.success == "true";
            }
        }
    }
}