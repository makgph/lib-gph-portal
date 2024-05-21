using sa.gov.libgph.Models;
using sa.gov.libgph.Services;
using System;
using System.Net.Mail;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class ContactUsFormController : SurfaceController
    {

        // POST: ContactUsForm/ReceiveEmail
        [System.Web.Http.HttpPost]
        public ActionResult ReceiveEmail(ContactUsModel Form, string CurrentLanguage, string reCap_valiadtion)
        {
            var SuccessMessage = "تم ارسال الرسالة بنجاح  ";
            var ErrorMessage = "حدث خطأ حاول ارسال الرسالة مرة أخري";

            try
            {
                //reCaptcha Validation
                if (!ReCaptchaValidaTor.Validate(reCap_valiadtion))
                {
                    ErrorMessage += "يرجى التأكد من الريكابتشا مرة أخري ";
                    throw new Exception();
                }

                MailMessage Message = new MailMessage();
                SmtpClient client = new SmtpClient();

                Message.To.Add(new MailAddress("holy.mosque.library@gmail.com"));
                Message.From = new MailAddress(Form.Email);
                Message.Subject = Form.Subject;
                Message.Body = Form.Message;
                client.Send(Message);

                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", SuccessMessage + "*" + "Good" + "*" + CurrentLanguage);

                //return PartialView("~/Views/Shared/_Subscribe.cshtml", "notSubscribed" + "*" + CurrentLanguage);
            }
            catch
            {
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", ErrorMessage + "*" + "Error" + "*" + CurrentLanguage);
                //return PartialView("~/Views/Shared/_Subscribe.cshtml", "somethingwrong" + "*" + CurrentLanguage);
            }
        }


    }
}
