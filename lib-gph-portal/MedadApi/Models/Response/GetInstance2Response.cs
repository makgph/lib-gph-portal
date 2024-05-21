using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class GetInstance2Response
    {
        public string context { get; set; }
        public string id { get; set; }
        public string _version { get; set; }
        public string hrid { get; set; }
        public string source { get; set; }
        public string title { get; set; }
        public string indexTitle { get; set; }
        public object[] parentInstances { get; set; }
        public object[] childInstances { get; set; }
        public bool isBoundWith { get; set; }
        public Alternativetitle_GetInstance2Response[] alternativeTitles { get; set; }
        public object[] editions { get; set; }
        public object[] series { get; set; }
        public Identifier_GetInstance2Response[] identifiers { get; set; }
        public Contributor_GetInstance2Response[] contributors { get; set; }
        public string[] subjects { get; set; }
        public Classification_GetInstance2Response[] classifications { get; set; }
        public Publication_GetInstance2Response[] publication { get; set; }
        public object[] publicationFrequency { get; set; }
        public object[] publicationRange { get; set; }
        public object[] electronicAccess { get; set; }
        public string instanceTypeId { get; set; }
        public string[] instanceFormatIds { get; set; }
        public string[] physicalDescriptions { get; set; }
        public string[] languages { get; set; }
        public object[] notes { get; set; }
        public string modeOfIssuanceId { get; set; }
        public bool previouslyHeld { get; set; }
        public bool staffSuppress { get; set; }
        public bool discoverySuppress { get; set; }
        public object[] statisticalCodeIds { get; set; }
        public DateTime statusUpdatedDate { get; set; }
        public Metadata_GetInstance2Response metadata { get; set; }
        public Tags_GetInstance2Response tags { get; set; }
        public object[] natureOfContentTermIds { get; set; }
        public Publicationperiod_GetInstance2Response publicationPeriod { get; set; }
        public object[] precedingTitles { get; set; }
        public object[] succeedingTitles { get; set; }
        public Links_GetInstance2Response links { get; set; }
    }

    public class Metadata_GetInstance2Response
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }

    public class Tags_GetInstance2Response
    {
        public object[] tagList { get; set; }
    }

    public class Publicationperiod_GetInstance2Response
    {
        public int start { get; set; }
    }

    public class Links_GetInstance2Response
    {
        public string self { get; set; }
    }

    public class Alternativetitle_GetInstance2Response
    {
        public string alternativeTitleTypeId { get; set; }
        public string alternativeTitle { get; set; }
    }

    public class Identifier_GetInstance2Response
    {
        public string identifierTypeId { get; set; }
        public string value { get; set; }
    }

    public class Contributor_GetInstance2Response
    {
        public string contributorNameTypeId { get; set; }
        public string name { get; set; }
        public string contributorTypeId { get; set; }
        public string contributorTypeText { get; set; }
        public bool primary { get; set; }
    }

    public class Classification_GetInstance2Response
    {
        public string classificationNumber { get; set; }
        public string classificationTypeId { get; set; }
    }

    public class Publication_GetInstance2Response
    {
        public string publisher { get; set; }
        public string place { get; set; }
        public string dateOfPublication { get; set; }
        public string role { get; set; }
    }



}