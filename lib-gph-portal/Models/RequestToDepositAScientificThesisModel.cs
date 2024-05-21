using System;
namespace sa.gov.libgph.Models

{
    public class RequestToDepositAScientificThesisModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string ApplicantName { get; set; }
        public string UniversityId { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string ThesisData { get; set; }
        public string ThesisTitle { get; set; }
        public string ScientificDegree { get; set; }
        public string YearOfDiscussion { get; set; }
        public int NumberOfPages { get; set; }
        public int NumberOfParts { get; set; }
        public bool IsAvailable { get; set; }
        public bool IsAvailableWithChains { get; set; }
        public int AvailabilityType { get; set; }
        public string ThesisFile { get; set; }
        public string ThesisTitleFile { get; set; }
        public string SubjectsIndexFile { get; set; }
        public string ArabicExtractFile { get; set; }
        public string EnglishExtractFile { get; set; }
        public string IntroFile { get; set; }
        public string CollectionFile { get; set; }
        public string QuarterCollectionFile { get; set; }
        public string CallNum { get; set; }
        public int RequestStatusId { get; set; }
        public bool? IsArchived { get; set; }

        public string ReasonOfRejection { get; set; } = string.Empty;
        public string Instructions { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedDate { get; set; }


        public string UniversityNameOutsideKingdom { get; set; }
        public bool IsOutsideKingdom { get; set; } = false;

        public object ThesisDepositionRequestReply { get; set; } = null;

        //country


    }
}