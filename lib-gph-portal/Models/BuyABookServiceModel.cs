using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace sa.gov.libgph.Models
{
    public class BuyABookServiceModel
    {
        //public int id { get; set; } = 100;
        //[Display(ResourceType = typeof(Resources.SuggestingBuyingBook), Name = "Name")]
        //[MaxLength(50, ErrorMessageResourceName = "MaxName", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //[MinLength(5, ErrorMessageResourceName = "MinName", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //[Required(ErrorMessageResourceName = "RequiredName", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //[RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]

        //public string VisitorName { get; set; } = "";
        //[Display(ResourceType = typeof(Resources.SuggestingBuyingBook), Name = "Email")]
        //[Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //[RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName = "ValidateEmail", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //public string VisitorEmail { get; set; } = "";

        //[Display(ResourceType = typeof(Resources.SuggestingBuyingBook), Name = "Mobile")]
        //[Required(ErrorMessageResourceName = "RequiredMobile", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //public string VisitorMobile { get; set; } = "";
        //public string Qualifications { get; set; } = "";

        //[Display(ResourceType = typeof(Resources.SuggestingBuyingBook), Name = "BookTitle")]
        //[MaxLength(500, ErrorMessageResourceName = "MaxBookTitle", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //[MinLength(10, ErrorMessageResourceName = "MinBookTitle", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //[Required(ErrorMessageResourceName = "RequiredBookTitle", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingBook))]
        //public string SuggestedBookTitle { get; set; } = "";
        //public string authorName { get; set; } = "";
        //public string publisherName { get; set; } = "";
        //public string placeOfPublication { get; set; } = "";
        //public string yearOfPublication { get; set; } = "";
        //public string standardBookNumber { get; set; } = "";
        //public int bookTypeId { get; set; } = 18;
        //public string additionalInformation { get; set; } = "";
        //public string createdBy { get; set; } = "Portal";
        //public DateTime? createdDate { get; set; } = null;
        //public string updatedBy { get; set; } = "";
        //public DateTime? updatedDate { get; set; } = null;

        public int Id { get; set; } = 0;
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "VisitorName")]
        [Required(ErrorMessageResourceName = "Required_VisitorName", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string VisitorName { get; set; }
        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "VisitorEmail")]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName = "ValidateEmail", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        [Required(ErrorMessageResourceName = "Required_VisitorEmail", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string VisitorEmail { get; set; }
        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "VisitorMobile")]
        [Required(ErrorMessageResourceName = "Required_VisitorMobile", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        [RegularExpression(@"^(05)[0-9]{8}$", ErrorMessageResourceName = "ValidateMobile", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]

        public string VisitorMobile { get; set; }
        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "Qualifications")]
        [Required(ErrorMessageResourceName = "Required_Qualifications", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string Qualifications { get; set; }
        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "SuggestedBookTitle")]
        [Required(ErrorMessageResourceName = "Required_SuggestedBookTitle", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string SuggestedBookTitle { get; set; }

        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "AuthorName")]
        [Required(ErrorMessageResourceName = "Required_AuthorName", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string AuthorName { get; set; }

        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "PublisherName")]
        //[Required(ErrorMessageResourceName = "Required_PublisherName", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string PublisherName { get; set; }

        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "PlaceOfPublication")]
        //[Required(ErrorMessageResourceName = "Required_PlaceOfPublication", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string PlaceOfPublication { get; set; }

        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "YearOfPublication")]
        //[Required(ErrorMessageResourceName = "Required_YearOfPublication", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string YearOfPublication { get; set; }

        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "StandardBookNumber")]
        [Required(ErrorMessageResourceName = "Required_StandardBookNumber", ErrorMessageResourceType = typeof(Resources.SuggestingBuyingAbook))]
        public string StandardBookNumber { get; set; }
        public int BookTypeId { get; set; }

        [Display(ResourceType = typeof(Resources.SuggestingBuyingAbook), Name = "AdditionalInformation")]
         public string AdditionalInformation { get; set; }
        public string CreatedBy { get; set; } = "Portal";
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public string UpdatedBy { get; set; } = "Portal";
        public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    }
}