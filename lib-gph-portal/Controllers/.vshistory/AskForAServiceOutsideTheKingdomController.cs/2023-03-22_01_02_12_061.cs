using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using sa.gov.libgph.Models;
using sa.gov.libgph.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace sa.gov.libgph.Controllers
{
    public class AskForAServiceOutsideTheKingdomController : SurfaceController
    {
        #region Ask for a Service Pot Photography
        [System.Web.Http.HttpPost]
        public ActionResult AskForAServicePotPhotography(PotPhotographyRequestModel request, string CurrentLanguage, string reCap_valiadtion_PotPhotography, string FormId)
        {
            var SuccessMessage = " تم ارسال طلب الخدمة بنجاح  ";
            var ErrorMessage = " حدث خطأ حاول طلب الخدمة مرة أخري ";
            var serverResponse = new ServerResponse() { CurrentLangauge = CurrentLanguage, FormId = FormId };

            try
            {
                //reCaptcha Validation
                if (reCap_valiadtion_PotPhotography != "valid")
                {
                    serverResponse.Messages.Add("يرجى التأكد من الريكابتشا مرة أخري ");
                    throw new Exception();
                }
                if (request.StartPage > request.EndPage)
                {
                    serverResponse.Messages.Add("يجب أن تكون صفحة البداية أقل من صفحة النهاية");
                    throw new Exception();
                }
                if ((request.EndPage - request.StartPage) > 30)
                {
                    serverResponse.Messages.Add("يجب مراعاة ألا يتجاوز عدد الصفحات 30 صفحة");
                    throw new Exception();
                }

                PostPotPhotographyRequest(request);

                serverResponse.Messages.Add(SuccessMessage);

                return PartialView("~/Views/Partials/ServerResponse/_response.cshtml", serverResponse);

            }
            catch (Exception e)
            {
                serverResponse.Type = ServerResponseType.Error;
                serverResponse.Messages.Add(ErrorMessage);
                //serverResponse.Messages.Add(e.Message);
                return PartialView("~/Views/Partials/ServerResponse/_response.cshtml", serverResponse);

            }
        }



        public object PostPotPhotographyRequest(PotPhotographyRequestModel request)
        {
            string AskForAServicePotPhotography_APIURL = System.Web
                                                .Configuration
                                                .WebConfigurationManager
                                                .AppSettings["AskForAServicePotPhotographyAPIURL"];


            try
            {


                ApiClient apiClient = new ApiClient(new Uri(AskForAServicePotPhotography_APIURL));

                var t = Task.Run(() => apiClient.PostAsync(request));
                t.Wait();

                return JsonConvert.DeserializeObject((t.Result));

            }
            catch (Exception)
            {
                return null;
            }

        }

        #endregion

        #region Request to Deposit a Scientific Thesis

        [System.Web.Http.HttpPost]
        public ActionResult RequestToDepositAScientificThesis( RequestToDepositAScientificThesisFormModel Form444444444444, string CurrentLanguage, string reCap_valiadtion_ScientificThesis, string FormId)
        {
            var SuccessMessage = " تم ارسال طلب الخدمة بنجاح  ";
            var ErrorMessage = " حدث خطأ حاول طلب الخدمة مرة أخري ";
            var serverResponse = new ServerResponse() { CurrentLangauge = CurrentLanguage, FormId = FormId };

            try
            {
                //reCaptcha Validation
                if (reCap_valiadtion_ScientificThesis != "valid")
                {
                    ErrorMessage += "يرجى التأكد من الريكابتشا مرة أخري ";
                    throw new Exception();
                }
                var bb = new RequestToDepositAScientificThesisFormModel();
                bb.YearOfDiscussion = Form444444444444.YearOfDiscussion;
                bb.ApplicantName = Form444444444444.ApplicantName;
                bb.UniversityNameOutsideKingdom = Form444444444444.UniversityNameOutsideKingdom;
                bb.Department = Form444444444444.Department;
                bb.Faculty = Form444444444444.Faculty;

                //PostScientificThesisRequest(Form444444444444);


                serverResponse.Messages.Add(SuccessMessage);

                return PartialView("~/Views/Partials/ServerResponse/_response.cshtml", serverResponse);

            }
            catch (Exception e)
            {
                serverResponse.Type = ServerResponseType.Error;
                serverResponse.Messages.Add(ErrorMessage);
                //serverResponse.Messages.Add(e.Message);
                return PartialView("~/Views/Partials/ServerResponse/_response.cshtml", serverResponse);

            }
        }



        public object PostScientificThesisRequest(HttpPostedFileBase thesisTitleFile, RequestToDepositAScientificThesisFormModel from)
        {
            string RequestToDepositAScientificThesisAPIURL = System.Web
                                                .Configuration
                                                .WebConfigurationManager
                                                .AppSettings["RequestToDepositAScientificThesisAPIURL"];
            var request = new RequestToDepositAScientificThesisModel();

            request = ConvertToRequestToDepositAScientificThesisRequestModel(from);
            request.ThesisTitleFile = thesisTitleFile.FileName;
            try
            {


                ApiClient apiClient = new ApiClient(new Uri(RequestToDepositAScientificThesisAPIURL));


                Dictionary<string, HttpPostedFileBase> files = new Dictionary<string, HttpPostedFileBase>();

                var file =new KeyValuePair<string, HttpPostedFileBase>();
                files.Add("thesisTitleFile", thesisTitleFile);
               

                var t = Task.Run(() => apiClient.UploadImage(RequestToDepositAScientificThesisAPIURL, request, files));
                t.Wait();

                //var smsReturn = JsonConvert.DeserializeObject((t.Result));
                var fff = t.Result;
                return t.Result;


            }
            catch (Exception)
            {
                return null;
            }

        }
        private RequestToDepositAScientificThesisModel ConvertToRequestToDepositAScientificThesisRequestModel(RequestToDepositAScientificThesisFormModel model)
        {
            return new RequestToDepositAScientificThesisModel()
            {

                Faculty = model.Faculty,
                Department = model.Department,
                UniversityNameOutsideKingdom = model.UniversityNameOutsideKingdom,
                ApplicantName = model.ApplicantName,
                YearOfDiscussion = model.YearOfDiscussion,
                AvailabilityType = model.AvailabilityType,
                CallNum = model.CallNum,
                Email = model.Email,
                Instructions = model.Instructions,
                IsAvailable = model.IsAvailable,
                Mobile = model.Mobile,
                NumberOfParts = model.NumberOfParts,
                IsOutsideKingdom = model.IsOutsideKingdom,
                IsAvailableWithChains = model.IsAvailableWithChains,
                NumberOfPages = model.NumberOfPages,
                ScientificDegree = model.ScientificDegree,
                ThesisTitle = model.ThesisTitle,
                CreatedBy = model.CreatedBy,
                IntroFile = "",
                ArabicExtractFile = "",
                CollectionFile = "",
                EnglishExtractFile = "",
                CreatedDate = model.CreatedDate,
                Id = 0,
                IsArchived = model.IsArchived,
                QuarterCollectionFile = "",
                ReasonOfRejection = "",
                RequestStatusId = model.RequestStatusId,
                SubjectsIndexFile = "",
                ThesisData = "",
                ThesisFile = "",
                ThesisTitleFile = "",
                UniversityId = model.UniversityId,
                UpdatedBy = "",
                UpdatedDate = model.UpdatedDate,
                UserId = ""

            };
        }

        #endregion
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
