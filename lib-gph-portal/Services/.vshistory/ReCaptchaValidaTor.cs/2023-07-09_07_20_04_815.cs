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
            string data = $"secret=6Lczn_cdAAAAALocZmXRBTW8po5wmU6gjIq6EBNS&response=03AAYGu2QH8rfyiqdcK6lR8edMj0BAnwfpeQQiG3IsndxOTgPlbkdulWOsmyfLIG1VUNZ18RGD_x5cK8-fYch27--W4xHlMSYjmr_BMqigqoCoNwSL4dGLIfTZyabBkZ1CAGtEwExxiVDU7QHHsOe9XlBEYLwtaaiBpthP72ydOzRG4XhqpdDXFGy8TNLw6co557R8IJuNFWjyCv-pnaAc3tY2Yxf8waRxYmQRyTv7CJ8fcVOo5zatnIs1g8J-migvCYqloXBrWIvyRwrpQDE86w-qmXo3iGvlenHrlcrzgYlJ9Z4fwq3vRFlocyCi32L88El_WfYByAd0h15Vld2agZR8kdMNoXRX_zcWYkc3ADkkl522BZMCTA6oP_s4QE0Ik-1KKPlLF11-uZEZg08FOFSQ-dMBFRD5zLGj7EnBHejRmE9YkcU3swJdieu4aw09VBs1ZhA1ObsUVxoQNW1OUHgzmS-UDqxBOqG0K9g4em1FjEinOIoZwUcYWPfUR3Huw9e5E_DY8_Q25mNx5UMMQz4AB--rOyCDoDlhiQP5k-uCTAlnlS4IKwE";

            using (WebClient client = new WebClient())
            {
                string responseJson = client.UploadString(ReCaptchaValidaTorURL, data);
                dynamic responseObject = JsonConvert.DeserializeObject(responseJson);

                return responseObject.success == "true";
            }
        }
    }
}