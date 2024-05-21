using sa.gov.libgph.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class StudentFormController : SurfaceController
    {
        // GET: StudentForm
        [System.Web.Http.HttpPost]
        public ActionResult RegisterForm(StudentForm Form, string CurrentLanguage, string reCap_valiadtion)
        {
            var SuccessMessage = "تم التسجيل بنجاح  ";
            var ErrorMessage = "حدث خطأ حاول التسجيل مرة أخري";

            try
            {
                //reCaptcha Validation
                if (reCap_valiadtion != "valid")
                {
                    ErrorMessage += "يرجى التأكد من الريكابتشا مرة أخري ";
                    throw new Exception();
                }

                if (isSubscribed(Form))
                {
                    //Already Subscribed
                    // [Your Request is accepted * Good * ar-SA] ==> "Your Request is accepted" , "Good" , "ar-SA"

                    return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", "أنت بالفعل قدمت طلب تسجيل في هذا الكورس" + "*" + "Warning" + "*" + CurrentLanguage);
                }
                else
                {
                    // New Subscriber
                    var ContentService = Services.ContentService;
                    var ParentID = Guid.Parse(Form.ParentID);

                    var _Form = ContentService.Create(Form.studentName, ParentID, "registrationForm");
                    _Form.SetValue("studentName", Form.studentName);
                    _Form.SetValue("email", Form.studentEmail);
                    _Form.SetValue("massege", Form.studentMessage);
                    _Form.SetValue("status", "Not Decided Yet");
                    ContentService.Save(_Form);

                    //Sending Mail 
                    var CurrentCourse = Umbraco.ContentQuery.Content(ParentID);
                    var Subject = "ارسال طلب تسجيل كورس";
                    var MessageBody = $"{CurrentCourse.Name} - تم بنجاح ارسال طلب تسجيل كورس";

                    MailMessage Message = new MailMessage();
                    SmtpClient client = new SmtpClient();


                    var LibraryEmail = System.Web
                                             .Configuration
                                             .WebConfigurationManager
                                             .AppSettings["LibraryEmail"];
                    Message.From = new MailAddress(LibraryEmail);
                    Message.To.Add(new MailAddress(Form.studentEmail));
                    Message.Subject = Form.studentName + " - " + Subject;
                    Message.Body = Form.studentMessage + " - " + MessageBody;
                    client.Send(Message);

                    return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", SuccessMessage + "*" + "Good" + "*" + CurrentLanguage);
                }
            }
            catch (Exception e)
            {
                return PartialView("~/Views/Partials/ServerResponse/_ServerResponse.cshtml", ErrorMessage + "*" + e.Message + "*" + "Error" + "*" + CurrentLanguage);

            }
        }

        public bool isSubscribed(StudentForm Form)
        {
            Guid parentID = new Guid(Form.ParentID);
            var Courses = Umbraco.ContentQuery.Content(parentID).ChildrenOfType("registrationForm").ToArray();

            for (int i = 0; i < Courses.Length; i++)
            {
                if (Courses[i].Value<string>("email") == Form.studentEmail)
                {
                    return true;
                }
            }

            return false;
        }

    }
}