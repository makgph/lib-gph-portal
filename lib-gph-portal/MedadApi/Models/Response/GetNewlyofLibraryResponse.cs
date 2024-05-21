namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class GetNewlyofLibraryResponse
    {
        public int totalRecords { get; set; }
        public Instance[] instances { get; set; }
    }

    public class Instance_GetNewlyofLibraryResponse
    {
        public string id { get; set; }
        public string title { get; set; }
        public Contributor_GetNewlyofLibraryResponse[] contributors { get; set; }
        public Publication_GetNewlyofLibraryResponse[] publication { get; set; }
        public bool staffSuppress { get; set; }
        public bool discoverySuppress { get; set; }
    }

    public class Contributor_GetNewlyofLibraryResponse
    {
        public string name { get; set; }
        public string contributorNameTypeId { get; set; }
        public bool primary { get; set; }
    }

    public class Publication_GetNewlyofLibraryResponse
    {
        public string publisher { get; set; }
        public string dateOfPublication { get; set; }
    }
}