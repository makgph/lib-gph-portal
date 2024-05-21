using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class ListMaterialContainersResponse
    {
        public Mtype[] mtypes { get; set; }
        public int totalRecords { get; set; }
    }

    public class Mtype
    {
        public string id { get; set; }
        public string name { get; set; }
        public string source { get; set; }
        public Metadata_ListMaterialContainersResponse metadata { get; set; }
    }

    public class Metadata_ListMaterialContainersResponse
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }


}