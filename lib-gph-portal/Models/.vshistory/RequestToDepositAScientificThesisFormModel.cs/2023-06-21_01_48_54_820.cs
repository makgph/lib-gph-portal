using sa.gov.libgph.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;

namespace sa.gov.libgph.Models
{
    public class RequestToDepositAScientificThesisFormModel
    {

        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "ApplicantName")]
        [Required(ErrorMessageResourceName = "RequiredApplicantName", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string ApplicantName { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "UniversityNameOutsideKingdom")]
        [Required(ErrorMessageResourceName = "RequiredUniversityNameOutsideKingdom", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string UniversityNameOutsideKingdom { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "Faculty")]
        [Required(ErrorMessageResourceName = "RequiredFaculty", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]

        public string Faculty { get; set; }


        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "Department")]
        [Required(ErrorMessageResourceName = "RequiredDepartment", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string Department { get; set; }


        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "RequiredMobile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^(05)[0-9]{8}$", ErrorMessageResourceName = "ValidateMobile", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string Mobile { get; set; }

        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "Email")]
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName = "ValidateEmail", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        public string Email { get; set; }


        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "ThesisData")]
        [Required(ErrorMessageResourceName = "RequiredThesisData", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string ThesisData { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "ThesisTitle")]
        [Required(ErrorMessageResourceName = "RequiredThesisTitle", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string ThesisTitle { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "ScientificDegree")]
        [Required(ErrorMessageResourceName = "RequiredScientificDegree", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string ScientificDegree { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "YearOfDiscussion")]
        [Required(ErrorMessageResourceName = "RequiredYearOfDiscussion", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string YearOfDiscussion { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "NumberOfPages")]
        [Required(ErrorMessageResourceName = "RequiredNumberOfPages", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than or equal to {1}.")]

        public int NumberOfPages { get; set; } = 1;
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "NumberOfParts")]
        [Required(ErrorMessageResourceName = "RequiredNumberOfParts", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [Range(1, int.MaxValue, ErrorMessage = "The field {0} must be greater than or equal to {1}.")]
        public int NumberOfParts { get; set; } = 1;
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "IsAvailable")]
        //[Required(ErrorMessageResourceName = "RequiredIsAvailable", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public bool IsAvailable { get; set; } = false;


        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "IsAvailableWithChains")]
        //[Required(ErrorMessageResourceName = "RequiredIsAvailableWithChains", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public bool IsAvailableWithChains { get; set; }


        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "AvailabilityType")]
        [Required(ErrorMessageResourceName = "RequiredAvailabilityType", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public int AvailabilityType { get; set; }



        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "CallNum")]
        //[Required(ErrorMessageResourceName = "RequiredCallNum", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]

        public string CallNum { get; set; }




        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "Instructions")]
        [Required(ErrorMessageResourceName = "RequiredInstructions", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public string Instructions { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "Country")]
        [Required(ErrorMessageResourceName = "RequiredCountry", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]

        public string Country { get; set; }

        public CountryModel Countries { get; set; }
        public void GetCountries()
        {
            try
            {
                string CountriesURL = System.Web
                                            .Configuration
                                            .WebConfigurationManager
                                            .AppSettings["CountriesURL"];
                var token = "Bearer " + _userData.token;

                ApiClient apiClient = new ApiClient(new Uri(CountriesURL));
                apiClient.addHeaders("Authorization", token);
                var t = Task.Run(() => apiClient.GetAsync<CountryModel>());
                t.Wait();
                Countries = t.Result;
            }
            catch (Exception) { }

        }



        #region Files
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "thesisFile")]
        [Required(ErrorMessageResourceName = "RequiredthesisFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase thesisFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "thesisTitleFile")]
        [Required(ErrorMessageResourceName = "RequiredthesisTitleFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase thesisTitleFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "subjectsIndexFile")]
        [Required(ErrorMessageResourceName = "RequiredsubjectsIndexFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase subjectsIndexFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "arabicExtractFile")]
        [Required(ErrorMessageResourceName = "RequiredarabicExtractFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase arabicExtractFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "englishExtractFile")]
        [Required(ErrorMessageResourceName = "RequiredenglishExtractFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase englishExtractFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "introFile")]
        [Required(ErrorMessageResourceName = "RequiredintroFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase introFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "collectionFile")]
        [Required(ErrorMessageResourceName = "RequiredcollectionFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase collectionFile { get; set; }
        [Display(ResourceType = typeof(Resources.RequestToDepositAScientificThesis), Name = "quarterCollectionFile")]
        [Required(ErrorMessageResourceName = "RequiredquarterCollectionFile", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        [RegularExpression(@"^.*\.(pdf|docx|doc)$", ErrorMessageResourceName = "PDForWordFilesValidation", ErrorMessageResourceType = typeof(Resources.RequestToDepositAScientificThesis))]
        public HttpPostedFileBase quarterCollectionFile { get; set; }
        #endregion


        public string ReasonOfRejection { get; set; } = string.Empty;
        public bool? IsArchived { get; set; } = false;
        public int RequestStatusId { get; set; } = 4;
        public string UniversityId { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = null;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = null;
        public DateTime? UpdatedDate { get; set; } = null;
        public bool IsOutsideKingdom { get; set; } = true;
        public string roleId { get; set; } = string.Empty;




        //public static ValidationResult ValidateNames(string fullName, ValidationContext context)
        //{
        //    var model = context.ObjectInstance as RequestToDepositAScientificThesisFormModel;
        //    if (model != null && model.ApplicantName == "John" && model.Department == "Doe")
        //    {
        //        return new ValidationResult("The full name cannot be John Doe.");
        //    }
        //    return ValidationResult.Success;
        //}
    }
}