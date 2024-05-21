using sa.gov.libgph.Services;
using System;
using System.Linq;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;



namespace sa.gov.libgph.Controllers
{
    public class NewsletterSubscriptionController : SurfaceController
    {

        [HttpPost]

        public ActionResult Subscribe(string SubscriberEmail, string CurrentLanguage, string reCaptchavaliadtion)
        {

            try
            {
                //reCaptcha Validation
                if (reCaptchavaliadtion != "valid") { throw new Exception(); }

                if (isSubscribed(SubscriberEmail))
                {
                    //Already Subscribed
                    return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "هذا البريد مشترك بالفعل فى النشرة البريدية" + "*" + "Warning" + "*" + CurrentLanguage);
                }
                else
                {
                    // New Subscriber
                    var ContentService = Services.ContentService;
                    var ParentID = Guid.Parse("edf383fd-b1c1-407a-bc9b-258312ea1a73");
                    var Form = ContentService.Create(SubscriberEmail.ToString(), ParentID, "newsletterSubscriber");
                    Form.SetValue("subscriberEmail", SubscriberEmail);

                    ContentService.SaveAndPublish(Form);

                    //Sending Email
                    var Email = new EmailHandler();
                    Email.EmailReceiver = SubscriberEmail;
                    Email.EmailSubject = "الاشتراك فى المجموعة البريدية";
                    Email.EmailBody = "أنت الآن مشترك فى المجموعة البريدية";
                    Email.SendEmail();

                }
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "تم الاشتراك فى مجموعتنا البريدية بنجاح" + "*" + "Good" + "*" + CurrentLanguage);

            }
            catch
            {
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "عذرا حدث خطأ يرجي المحاولة مرة أخري" + "*" + "Danger" + "*" + CurrentLanguage);

            }
        }


        // POST: NewsletterSubscription/UnSubscribe/Alhadik@ysolution.net
        [System.Web.Http.HttpPost]
        public ActionResult UnSubscribe(string SubscriberEmail, string CurrentLanguage, string reCaptchavaliadtion)
        {
            try
            {
                //reCaptcha Validation
                if (string.IsNullOrEmpty(reCaptchavaliadtion)) { throw new Exception(); }

                if (isSubscribed(SubscriberEmail))
                {
                    var ParentID = GetParentID(SubscriberEmail);
                    //delete
                    if (ParentID == 30412) { throw new Exception(); }
                    else
                    {
                        var ContentService = Services.ContentService;
                        ContentService.Delete(ContentService.GetById(ParentID));

                        // Sending Email
                        var Email = new EmailHandler();
                        Email.EmailReceiver = SubscriberEmail;
                        Email.EmailSubject = "إلغاءالاشتراك فى المجموعة البريدية";
                        Email.EmailBody = "أنت الآن غير مشترك فى المجموعة البريدية";
                        Email.SendEmail();

                    }

                    return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "تم إلغاء الاشتراك فى المجموعة البريدية" + "*" + "Good" + "*" + CurrentLanguage);

                }
                else
                {
                    //not a subscriber
                    return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "هذا البريد غير مشترك فى مجموعتنا البريدية" + "*" + "Warning" + "*" + CurrentLanguage);

                }
            }
            catch
            {
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "عذرا حدث خطأ ما يرجي المحاولة مرة أخري" + "*" + "Error" + "*" + CurrentLanguage);
            }
        }
        // NewsletterSubscription/isSubscribed/Alhadik@ysolution.net
        public bool isSubscribed(string SubscriberEmail)
        {
            var Subscribers = Umbraco.ContentAtRoot().FirstOrDefault().ChildrenOfType("newsletterSubscribers").FirstOrDefault().ChildrenOfType("newsletterSubscriber").ToArray();
            for (int i = 0; i < Subscribers.Length; i++)
            {
                if (Subscribers[i].Value<string>("subscriberEmail") == SubscriberEmail)
                {
                    return true;
                }
            }

            return false;
        }



        // NewsletterSubscription/ParentID/Alhadik@ysolution.net
        public int GetParentID(string SubscriberEmail)
        {

            var Subscribers = Umbraco.ContentAtRoot().FirstOrDefault().ChildrenOfType("newsletterSubscribers").FirstOrDefault().ChildrenOfType("newsletterSubscriber").ToArray();
            for (int i = 0; i < Subscribers.Length; i++)
            {
                if (Subscribers[i].Value<string>("subscriberEmail") == SubscriberEmail)
                {
                    return Subscribers[i].Id;
                }
            }

            return 30412;
        }


    }
}
