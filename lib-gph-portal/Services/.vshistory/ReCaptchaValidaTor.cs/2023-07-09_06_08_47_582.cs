using Newtonsoft.Json;
using System.Configuration;
using System.Net;

namespace sa.gov.libgph.Services
{
    public static class ReCaptchaValidaTor
    {
        public static bool Validate(string response)
        {
            string secret = ConfigurationManager.AppSettings["reCaptchaPrivateKey"];
            string ReCaptchaValidaTorURL = ConfigurationManager.AppSettings["ReCaptchaValidaTorURL"];
            string data = $"secret={secret}&response={response}";

            using (WebClient client = new WebClient())
            {
                string responseJson = client.UploadString(ReCaptchaValidaTorURL, data);
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

                return responseObject.success == "true";
            }
        }
    }
}