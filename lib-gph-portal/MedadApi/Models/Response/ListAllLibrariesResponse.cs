using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class ListAllLibrariesResponse
    {
        public Location[] locations { get; set; }
        public int totalRecords { get; set; }
    }

    public class Location
    {
        public string id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public bool isActive { get; set; }
        public string institutionId { get; set; }
        public string campusId { get; set; }
        public string libraryId { get; set; }
        public string discoveryDisplayName { get; set; } = string.Empty;
        public string primaryServicePoint { get; set; }
        public string[] servicePointIds { get; set; }
        public object[] servicePoints { get; set; }
        public Metadata_GetListAllLibrariesResponse metadata { get; set; }
    }

    public class Metadata_GetListAllLibrariesResponse
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }

}