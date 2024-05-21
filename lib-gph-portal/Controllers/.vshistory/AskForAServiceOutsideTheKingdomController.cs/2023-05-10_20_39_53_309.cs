using Newtonsoft.Json;
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


            if (request.libraryIdString == "77109509-2542-4482-9ec9-32b3d18a90b4")
            {
                request.libraryId = 1;
            }
            if (request.libraryIdString == "847220d6-a710-4430-916e-886b3bd43a4b")
            {
                request.libraryId = 2;
            }
            if (request.libraryIdString == "c9f16e47-09b6-4ef4-ae94-1d43b8bd1a2f")
            {
                request.libraryId = 3;
            }
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
        public ActionResult RequestToDepositAScientificThesis(RequestToDepositAScientificThesisFormModel formModel, string CurrentLanguage, string reCap_valiadtion_ScientificThesis, string FormId)
        {
            var SuccessMessage = " تم ارسال طلب الخدمة بنجاح  ";
            var ErrorMessage = string.Empty;
            var serverResponse = new ServerResponse() { CurrentLangauge = CurrentLanguage, FormId = FormId };

            try
            {

                if (formModel.IsAvailable)
                {
                    if (formModel.IsAvailableWithChains)
                    {
                        //if (formModel.AvailabilityType == 1|| formModel.AvailabilityType == 2|| formModel.AvailabilityType == 3 || formModel.AvailabilityType == 4 )
                        //{
                        //    if (formModel.thesisFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف الرسالة مطلوب");
                        //    }
                        //    if (formModel.thesisTitleFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف عنوان الرسالة مطلوب");
                        //    }
                        //    if (formModel.subjectsIndexFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف فهرس الرسالة مطلوب");
                        //    }
                        //}
                        //if (formModel.AvailabilityType == 2 || formModel.AvailabilityType == 3 || formModel.AvailabilityType == 4)
                        //    {
                        //    if (formModel.arabicExtractFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف المستخلص العربي  مطلوب");
                        //    }
                        //    if (formModel.arabicExtractFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف المستخلص الانجليزي  مطلوب");

                        //    }
                        //}

                        //if (formModel.AvailabilityType == 3 || formModel.AvailabilityType == 4)
                        //{
                        //    if (formModel.introFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف مقدمة الرسالة  مطلوب");
                        //    }

                        //}

                        //if (formModel.AvailabilityType == 4)
                        //{
                        //    if (formModel.quarterCollectionFile is null)
                        //    {
                        //        serverResponse.Messages.Add("ملف 25% من الرسالة  مطلوب");
                        //    }


                        //}

                        if (formModel.quarterCollectionFile is null)
                        {
                            serverResponse.Messages.Add("العنوان + فهرس الموضوعات + المستخلص العربي و الانجليزي + المقدمة + 25 % من الرسالة مطلوب");
                        }

                    }
                    if (!formModel.IsAvailableWithChains)
                    {

                        if (formModel.thesisFile is null)
                        {
                            serverResponse.Messages.Add("ملف الرسالة مطلوب");
                        }
                        //if (formModel.thesisTitleFile is null)
                        //{
                        //    serverResponse.Messages.Add("ملف عنوان الرسالة مطلوب");
                        //}
                        //if (formModel.subjectsIndexFile is null)
                        //{
                        //    serverResponse.Messages.Add("ملف فهرس الرسالة مطلوب");
                        //}
                        //if (formModel.arabicExtractFile is null)
                        //{
                        //    serverResponse.Messages.Add("ملف المستخلص العربي  مطلوب");
                        //}
                        //if (formModel.arabicExtractFile is null)
                        //{
                        //    serverResponse.Messages.Add("ملف المستخلص الانجليزي  مطلوب");

                        //}
                        //if (formModel.introFile is null)
                        //{
                        //    serverResponse.Messages.Add("ملف مقدمة الرسالة  مطلوب");
                        //}

                        //if (formModel.quarterCollectionFile is null)
                        //{
                        //    serverResponse.Messages.Add("ملف 25% من الرسالة  مطلوب");
                        //}


                    }
                }
                //reCaptcha Validation
                if (reCap_valiadtion_ScientificThesis != "valid")
                {
                    serverResponse.Messages.Add("يرجى التأكد من الريكابتشا مرة أخري ");
                }
                if (serverResponse.Messages.Count != 0)
                {
                    serverResponse.Messages.Add("حدث خطأ حاول طلب الخدمة مرة أخري ");
                    throw new Exception();
                }

                PostScientificThesisRequest(formModel);


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



        public object PostScientificThesisRequest(RequestToDepositAScientificThesisFormModel from)
        {
            string RequestToDepositAScientificThesisAPIURL = System.Web
                                                .Configuration
                                                .WebConfigurationManager
                                                .AppSettings["RequestToDepositAScientificThesisAPIURL"];
            var request = new RequestToDepositAScientificThesisModel();

            request = ConvertToRequestToDepositAScientificThesisRequestModel(from);

            try
            {

                ApiClient apiClient = new ApiClient(new Uri(RequestToDepositAScientificThesisAPIURL));

                Dictionary<string, HttpPostedFileBase> files = new Dictionary<string, HttpPostedFileBase>
                {
                    { nameof(from.thesisTitleFile), from.thesisTitleFile },
                    { nameof(from.thesisFile), from.thesisFile },
                    { nameof(from.subjectsIndexFile), from.subjectsIndexFile },
                    { nameof(from.quarterCollectionFile), from.quarterCollectionFile },
                    { nameof(from.introFile), from.introFile },
                    { nameof(from.englishExtractFile), from.englishExtractFile },
                    { nameof(from.collectionFile), from.collectionFile },
                    { nameof(from.arabicExtractFile), from.arabicExtractFile }
                };

                var t = Task.Run(() => apiClient.PostFiles(RequestToDepositAScientificThesisAPIURL, request, files));
                t.Wait();

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
                UserId = "3e8a7d5e-0d16-4890-9b61-caea9b96692e"

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
