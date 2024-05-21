namespace sa.gov.libgph.MedadApi.Models.Response
{


    public class SearchResponse
    {
        public int totalRecords { get; set; }
        public Instance[] instances { get; set; }
    }

    public class Instance
    {
        public string id { get; set; }
        public string title { get; set; }
        public Contributor[] contributors { get; set; }
        public Publication[] publication { get; set; }
        public bool staffSuppress { get; set; }
        public bool discoverySuppress { get; set; }
    }

    public class Contributor
    {
        public string name { get; set; }
        public string contributorNameTypeId { get; set; }
        public bool primary { get; set; }
    }

    public class Publication
    {
        public string publisher { get; set; }
        public string dateOfPublication { get; set; }
    }
}