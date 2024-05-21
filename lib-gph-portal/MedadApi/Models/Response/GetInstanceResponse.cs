using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{


    public class GetInstanceResponse
    {
        public Instance[] instances { get; set; }
        public int totalRecords { get; set; }
        public Resultinfo resultInfo { get; set; }
    }

    public class Resultinfo
    {
        public int totalRecords { get; set; }
        public object[] facets { get; set; }
        public object[] diagnostics { get; set; }
    }

    public class Instance_GetInstanceResponse
    {
        public string id { get; set; }
        public int _version { get; set; }
        public string hrid { get; set; }
        public string source { get; set; }
        public string title { get; set; }
        public string indexTitle { get; set; }
        public Alternativetitle[] alternativeTitles { get; set; }
        public string[] editions { get; set; }
        public object[] series { get; set; }
        public Identifier[] identifiers { get; set; }
        public Contributor_GetInstanceResponse[] contributors { get; set; }
        public string[] subjects { get; set; }
        public Classification[] classifications { get; set; }
        public Publication_GetInstanceResponse[] publication { get; set; }
        public object[] publicationFrequency { get; set; }
        public object[] publicationRange { get; set; }
        public Publicationperiod publicationPeriod { get; set; }
        public object[] electronicAccess { get; set; }
        public string instanceTypeId { get; set; }
        public string[] instanceFormatIds { get; set; }
        public object[] instanceFormats { get; set; }
        public string[] physicalDescriptions { get; set; }
        public string[] languages { get; set; }
        public Note[] notes { get; set; }
        public string modeOfIssuanceId { get; set; }
        public bool previouslyHeld { get; set; }
        public bool staffSuppress { get; set; }
        public bool discoverySuppress { get; set; }
        public object[] statisticalCodeIds { get; set; }
        public DateTime statusUpdatedDate { get; set; }
        public Metadata metadata { get; set; }
        public object[] holdingsRecords2 { get; set; }
        public object[] natureOfContentTermIds { get; set; }
    }

    public class Publicationperiod
    {
        public int start { get; set; }
    }

    public class Metadata
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }

    public class Alternativetitle
    {
        public string alternativeTitleTypeId { get; set; }
        public string alternativeTitle { get; set; }
    }

    public class Identifier
    {
        public string value { get; set; }
        public string identifierTypeId { get; set; }
    }

    public class Contributor_GetInstanceResponse
    {
        public string name { get; set; }
        public string contributorTypeId { get; set; }
        public string contributorTypeText { get; set; }
        public string contributorNameTypeId { get; set; }
        public bool primary { get; set; }
    }

    public class Classification
    {
        public string classificationNumber { get; set; }
        public string classificationTypeId { get; set; }
    }

    public class Publication_GetInstanceResponse
    {
        public string publisher { get; set; }
        public string place { get; set; }
        public string dateOfPublication { get; set; }
        public string role { get; set; }
    }

    public class Note
    {
        public string note { get; set; }
        public bool staffOnly { get; set; }
        public string instanceNoteTypeId { get; set; }
    }

}