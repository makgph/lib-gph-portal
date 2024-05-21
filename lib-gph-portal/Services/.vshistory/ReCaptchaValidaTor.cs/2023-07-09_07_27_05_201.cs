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
            //string data = $"secret=6Lczn_cdAAAAALocZmXRBTW8po5wmU6gjIq6EBNS&response={response}";
            NameValueCollection data = new NameValueCollection();
            data["secret"] = secret;
            data["response"] = response;

            using (WebClient client = new WebClient())
            {
                byte[] responseBytes = client.UploadValues(ReCaptchaValidaTorURL, "POST", data);
                string responseJson = Encoding.UTF8.GetString(responseBytes);

                // Deserialize the JSON response into a dynamic object
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

                //string responseJson = client.UploadString(ReCaptchaValidaTorURL, data);

                return responseObject.success == "true";
            }
        }
    }
}