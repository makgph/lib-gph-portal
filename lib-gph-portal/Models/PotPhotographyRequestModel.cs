using sa.gov.libgph.Services;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace sa.gov.libgph.Models

{
    public class PotPhotographyRequestModel
    {
        private readonly UserData _userData;
        public PotPhotographyRequestModel()
        {
            var auth = new Authentication();
            _userData = auth.Login();
        }
        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "Name")]
        [Required(ErrorMessageResourceName = "RequiredName", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        //[MaxLength(50, ErrorMessageResourceName = "MaxName", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        //[MinLength(5, ErrorMessageResourceName = "MinName", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]

        public string BeneficiaryName { get; set; }

        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "Email")]
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName = "ValidateEmail", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]

        public string BeneficiaryEmail { get; set; }
        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "RequiredMobile", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        [RegularExpression(@"^(05)[0-9]{8}$", ErrorMessageResourceName = "ValidateMobile", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]

        public string BeneficiaryMobile { get; set; }

        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "BeneficiaryQualification")]
        [Required(ErrorMessageResourceName = "RequiredBeneficiaryQualification", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]

        public string BeneficiaryQualification { get; set; }

        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "Purpose")]
        public string Purpose { get; set; } = string.Empty;


        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "BookTitle")]
        //[MaxLength(50, ErrorMessageResourceName = "MaxBookTitle", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        //[MinLength(5, ErrorMessageResourceName = "MinBookTitle", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        [Required(ErrorMessageResourceName = "RequiredBookTitle", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]

        public string BookTitle { get; set; }

        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "Country")]
        [Required(ErrorMessageResourceName = "RequiredCountry", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]

        public string Country { get; set; }
        public int libraryId { get; set; } = 0;
        public string libraryIdString { get; set; } = string.Empty;


        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "StartPage")]
        [Required(ErrorMessageResourceName = "RequiredStartPage", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        public int StartPage { get; set; } = 1;

        [Display(ResourceType = typeof(Resources.PotPhotographyRequest), Name = "EndPage")]
        [Required(ErrorMessageResourceName = "RequiredEndPage", ErrorMessageResourceType = typeof(Resources.PotPhotographyRequest))]
        public int EndPage { get; set; } = 1;



        // Don't Modify
        public int Id { get; } = 0;
        public int RequestStatusId { get; } = 4;
        public string FilePath { get; } = null;
        public string CreatedBy { get; } = null;
        public DateTime? CreatedDate { get; } = DateTime.Now;
        public string UpdatedBy { get; } = null;
        public DateTime? UpdatedDate { get; } = null;
        public bool IsArchived { get; } = false;
        public bool IsOutsideKingdom { get; } = true;
        public string ReasonOfRejection { get; } = null;
        public string Instructions { get; } = null;

        // country
        public CountryModel Countries { get; set; }
        public LiberaryModel Liberaries { get; set; }
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

        public void GetLiberaries()
        {
            try
            {
                string LiberariesURL = System.Web
                                            .Configuration
                                            .WebConfigurationManager
                                            .AppSettings["LiberariesURL"];

                var token = "Bearer "+ _userData.token;
                ApiClient apiClient = new ApiClient(new Uri(LiberariesURL));
                apiClient.addHeaders("Authorization", token);
                var t = Task.Run(() => apiClient.GetAsync<LiberaryModel>());
                t.Wait();
                Liberaries = t.Result as LiberaryModel;
            }
            catch (Exception) { }

        }


    }
}