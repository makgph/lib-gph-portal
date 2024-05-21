using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace sa.gov.libgph.Services
{
    public static class ReCaptchaValidaTor
    {
        private bool ValidateReCaptcha(string response)
        {
            string secret = "YOUR_SECRET_KEY";
            string url = "https://www.google.com/recaptcha/api/siteverify";
            string data = $"secret={secret}&response={response}";

            using (WebClient client = new WebClient())
            {
                string responseJson = client.UploadString(url, data);
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

                return responseObject.success == "true";
            }
        }
    }
}