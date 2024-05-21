using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using sa.gov.libgph.Resources;
namespace sa.gov.libgph.Models

{
    public class StudentForm
    {
        [Display(ResourceType = typeof(Resources.StudentForm), Name = "studentName")]
        [MaxLength(50, ErrorMessageResourceName = "MaxName", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        [MinLength(5, ErrorMessageResourceName = "MinName", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        [Required(ErrorMessageResourceName = "RequiredName", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessageResourceName = "Charactersonly", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        public string studentName { get; set; }

        [Display(ResourceType = typeof(Resources.StudentForm), Name = "studentEmail")]
        [Required(ErrorMessageResourceName = "RequiredEmail", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        [RegularExpression(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$", ErrorMessageResourceName = "ValidateEmail", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        public string studentEmail { get; set; }

        [Display(ResourceType = typeof(Resources.StudentForm), Name = "studentMessage")]
        [MaxLength(500, ErrorMessageResourceName = "MaxMessage", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        [MinLength(10, ErrorMessageResourceName = "MinMessage", ErrorMessageResourceType = typeof(Resources.StudentForm))]
        [Required(ErrorMessageResourceName = "RequiredMessage", ErrorMessageResourceType = typeof(Resources.StudentForm))]

        public string studentMessage { get; set; }
        public string ParentID { get; set; }

    }
}