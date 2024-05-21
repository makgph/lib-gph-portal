using Newtonsoft.Json;
using RestSharp;
using sa.gov.libgph.Models;
using sa.gov.libgph.Services;
using StackExchange.Profiling.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class AskLibraryEmployeesController : SurfaceController
    {

      

        // POST:  AskLibraryEmployees/ReceiveEmail
        [System.Web.Http.HttpPost]
        public ActionResult AskEmployee(AskLibraryEmployees Form, string CurrentLanguage, string reCap_valiadtion)
        {
            var SuccessMessage = "تم ارسال طلب الخدمة بنجاح  ";
            var ErrorMessage = "حدث خطأ حاول طلب الخدمة مرة أخري";

            try
            {
                //reCaptcha Validation
                if (!ReCaptchaValidaTor.Validate(reCap_valiadtion))
                {
                    ErrorMessage += "يرجى التأكد من الريكابتشا مرة أخري ";
                    throw new Exception();
                }


                PostRequest(Form);


                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", SuccessMessage + "*" + "Good" + "*" + CurrentLanguage);

            }
            catch (Exception e)
            {
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", ErrorMessage + "*" + e.Message + "*" + "Error" + "*" + CurrentLanguage);

            }
        }

        

        public object PostRequest(AskLibraryEmployees Question)
        {
            string AskEmployee_APIURL = System.Web
                                                .Configuration
                                                .WebConfigurationManager
                                                .AppSettings["AskEmployee_APIURL"];


            try
            {
                //string smsApi = configuration.GetValue<string>("SMSapi");
                string smsApi = AskEmployee_APIURL;
                Question.updatedDate = null;
                Question.createdBy = "Portal";

                ApiClient apiClient = new ApiClient(new Uri(smsApi));

                var t = Task.Run(() => apiClient.PostAsync(Question));
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

       
        //public WasfetyPostPrescriptionResponse PostPrescription(WasfetyPostPrescription wasfetyPostPrescription)
        //{
        //    try
        //    {

        //        string wasfatyPostPrescriptionUrl = configuration.GetValue<string>("wasfatyPostPrescription");
        //        ApiClient apiClient = new ApiClient(new Uri(wasfatyPostPrescriptionUrl));
        //        WasfetyPostPrescriptionResponse ssoAuthReturn = JsonConvert.DeserializeObject<WasfetyPostPrescriptionResponse>(apiClient.PostAsync<WasfetyPostPrescription>(wasfetyPostPrescription).Result);

        //        return ssoAuthReturn;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }

        //}



    }
}
