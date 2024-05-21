using Newtonsoft.Json;
using sa.gov.libgph.Models;
using sa.gov.libgph.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class SuggestingBuyingABookController : SurfaceController
    {
        // GET: SuggestingBuyingABook
        [System.Web.Http.HttpPost]
        public ActionResult SuggestABook(BuyABookServiceModel Form, string CurrentLanguage, string reCap_valiadtion)
        {
            var SuccessMessage = "تم ارسال طلب الخدمة بنجاح  ";
            var ErrorMessage = "حدث خطأ حاول طلب الخدمة مرة أخري";

            try
            {
                //reCaptcha Validation
                if (reCap_valiadtion != "valid")
                {
                    ErrorMessage += "يرجى التأكد من الريكابتشا مرة أخري ";
                    throw new Exception();
                }

                //string BuyABook_APIURL = System.Web
                //                               .Configuration
                //                               .WebConfigurationManager
                //                               .AppSettings["BuyABook_APIURL"];





                //ApiClient apiClient = new ApiClient(new Uri(BuyABook_APIURL));

                //JsonConvert.DeserializeObject(apiClient.PostAsync(Form).Result);

                PostRequest(Form);
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", SuccessMessage + "*" + "Good" + "*" + CurrentLanguage);

            }
            catch (Exception e)
            {
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", ErrorMessage + "*" + e.Message + "*" + "Error" + "*" + CurrentLanguage);

            }
        }


        public object PostRequest(BuyABookServiceModel Suggestion)
        {
            string BuyABook_APIURL = System.Web
                                               .Configuration
                                               .WebConfigurationManager
                                               .AppSettings["BuyABook_APIURL"];


            try
            {

                ApiClient apiClient = new ApiClient(new Uri(BuyABook_APIURL));

                var t = Task.Run(() => apiClient.PostAsync(Suggestion));
                t.Wait();

                var smsReturn = JsonConvert.DeserializeObject((t.Result));

                return smsReturn;


            }
            catch (Exception ex)
            {
                // messageList.Add(new Message { Body = ex.Message, Type = MessageEnum.Error });
                return null;
            }

        }

    }
}