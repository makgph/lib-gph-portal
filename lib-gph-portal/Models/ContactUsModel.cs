using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using sa.gov.libgph.Resources;

namespace sa.gov.libgph.Models
{
    public class ContactUsModel
    {
        [Display(ResourceType =typeof(ContactUsForm),Name ="Name")]
        [MaxLength(50, ErrorMessageResourceName = "MaxName", ErrorMessageResourceType =typeof(ContactUsForm))]
        [MinLength(5, ErrorMessageResourceName = "MinName", ErrorMessageResourceType =typeof(ContactUsForm))]
        [Required(ErrorMessageResourceName = "RequiredName", ErrorMessageResourceType = typeof(ContactUsForm))]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(ContactUsForm))]
        public string Name { get; set; }

        [Display(ResourceType = typeof(ContactUsForm), Name = "Email")]
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(ContactUsForm))]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"+ "@"+ @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName ="ValidateEmail",ErrorMessageResourceType =typeof(ContactUsForm))]
        public string Email { get; set; }
      
        
        [Display(ResourceType = typeof(ContactUsForm), Name = "Subject")]
        [MaxLength(100, ErrorMessageResourceName = "MaxSubject", ErrorMessageResourceType = typeof(ContactUsForm))]
        [MinLength(10, ErrorMessageResourceName = "MinSubject", ErrorMessageResourceType = typeof(ContactUsForm))]
        [Required(ErrorMessageResourceName = "RequiredSubject", ErrorMessageResourceType = typeof(ContactUsForm))]
        public string Subject { get; set; }

        [Display(ResourceType = typeof(ContactUsForm), Name = "Message")]
        [MaxLength(500, ErrorMessageResourceName = "MaxMessage", ErrorMessageResourceType = typeof(ContactUsForm))]
        [MinLength(10, ErrorMessageResourceName = "MinMessage", ErrorMessageResourceType = typeof(ContactUsForm))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(ContactUsForm))]
        public string Message { get; set; }

    }
}