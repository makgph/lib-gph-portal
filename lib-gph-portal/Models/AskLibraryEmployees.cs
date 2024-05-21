using System;
using System.ComponentModel.DataAnnotations;
namespace sa.gov.libgph.Models

{
    public class AskLibraryEmployees
    {
        public int id { get; set; }
        public int type { get; set; }

        [Display(ResourceType = typeof(Resources.AskLibraryEmployees), Name = "Name")]
        [MaxLength(50, ErrorMessageResourceName = "MaxName", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [MinLength(5, ErrorMessageResourceName = "MinName", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [Required(ErrorMessageResourceName = "RequiredName", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        public string visitorName { get; set; }

        [Display(ResourceType = typeof(Resources.AskLibraryEmployees), Name = "Email")]
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName = "ValidateEmail", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        public string visitorEmail { get; set; }

        [Display(ResourceType = typeof(Resources.AskLibraryEmployees), Name = "Mobile")]
        [Required(ErrorMessageResourceName = "RequiredMobile", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [RegularExpression(@"^(05)[0-9]{8}$", ErrorMessageResourceName = "ValidateMobile", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]

        public string visitorMobile { get; set; }

        [Display(ResourceType = typeof(Resources.AskLibraryEmployees), Name = "Message")]
        [MaxLength(500, ErrorMessageResourceName = "MaxMessage", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [MinLength(10, ErrorMessageResourceName = "MinMessage", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.AskLibraryEmployees))]

        public string visitorMessage { get; set; }

        public string response { get; set; }

        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }

    }
}