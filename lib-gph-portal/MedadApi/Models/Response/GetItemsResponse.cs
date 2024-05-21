using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class GetItemsResponse
    {
        public Item_GetItemsResponse[] items { get; set; }
        public int totalRecords { get; set; }
        public Resultinfo_GetItemsResponse resultInfo { get; set; }
    }

    public class Resultinfo_GetItemsResponse
    {
        public int totalRecords { get; set; }
        public object[] facets { get; set; }
        public object[] diagnostics { get; set; }
    }

    public class Item_GetItemsResponse
    {
        public string id { get; set; }
        public int _version { get; set; }
        public string hrid { get; set; }
        public string holdingsRecordId { get; set; }
        public object[] formerIds { get; set; }
        public bool discoverySuppress { get; set; }
        public string barcode { get; set; }
        public string effectiveShelvingOrder { get; set; }
        public string itemLevelCallNumber { get; set; }
        public Effectivecallnumbercomponents_GetItemsResponse effectiveCallNumberComponents { get; set; }
        public object[] yearCaption { get; set; }
        public object[] notes { get; set; }
        public object[] circulationNotes { get; set; }
        public Status_GetItemsResponse status { get; set; }
        public string materialTypeId { get; set; }
        public string permanentLoanTypeId { get; set; }
        public string permanentLocationId { get; set; }
        public string effectiveLocationId { get; set; }
        public object[] electronicAccess { get; set; }
        public string[] statisticalCodeIds { get; set; }
        public Tags_GetItemsResponse tags { get; set; }
        public Metadata_GetItemsResponse metadata { get; set; }
    }

    public class Effectivecallnumbercomponents_GetItemsResponse
    {
        public string callNumber { get; set; }
    }

    public class Status_GetItemsResponse
    {
        public string name { get; set; }
        public DateTime date { get; set; }
    }

    public class Tags_GetItemsResponse
    {
        public object[] tagList { get; set; }
    }

    public class Metadata_GetItemsResponse
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }
}
