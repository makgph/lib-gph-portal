using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class GetItems2Response
    {
        public Item_GetItems2Response[] items { get; set; }
        public int totalRecords { get; set; }
    }

    public class Item_GetItems2Response
    {
        public string id { get; set; }
        public string _version { get; set; }
        public Status_GetItems2Response status { get; set; }
        public string title { get; set; }
        public string callNumber { get; set; }
        public string hrid { get; set; }
        public Contributorname_GetItems2Response[] contributorNames { get; set; }
        public object[] formerIds { get; set; }
        public bool? discoverySuppress { get; set; }
        public string holdingsRecordId { get; set; }
        public string barcode { get; set; }
        public string itemLevelCallNumber { get; set; }
        public Note_GetItems2Response[] notes { get; set; }
        public object[] circulationNotes { get; set; }
        public Tags_GetItems2Response tags { get; set; }
        public object[] yearCaption { get; set; }
        public object[] electronicAccess { get; set; }
        public string[] statisticalCodeIds { get; set; }
        public object purchaseOrderLineIdentifier { get; set; }
        public Materialtype_GetItems2Response materialType { get; set; }
        public Permanentloantype_GetItems2Response permanentLoanType { get; set; }
        public Permanentlocation_GetItems2Response permanentLocation { get; set; }
        public Metadata_GetItems2Response metadata { get; set; }
        public Links_GetItems2Response links { get; set; }
        public Effectivecallnumbercomponents_GetItems2Response effectiveCallNumberComponents { get; set; }
        public string effectiveShelvingOrder { get; set; }
        public bool isBoundWith { get; set; }
        public Effectivelocation_GetItems2Response effectiveLocation { get; set; }
        public string itemLevelCallNumberTypeId { get; set; }
        public string copyNumber { get; set; }
    }

    public class Status_GetItems2Response
    {
        public string name { get; set; }
        public DateTime date { get; set; }
    }

    public class Tags_GetItems2Response
    {
        public object[] tagList { get; set; }
    }

    public class Materialtype_GetItems2Response
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Permanentloantype_GetItems2Response
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Permanentlocation_GetItems2Response
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Metadata_GetItems2Response
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }

    public class Links_GetItems2Response
    {
        public string self { get; set; }
    }

    public class Effectivecallnumbercomponents_GetItems2Response
    {
        public string callNumber { get; set; }
        public object prefix { get; set; }
        public object suffix { get; set; }
        public string typeId { get; set; }
    }

    public class Effectivelocation_GetItems2Response
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Contributorname_GetItems2Response
    {
        public string name { get; set; }
    }

    public class Note_GetItems2Response
    {
        public string itemNoteTypeId { get; set; }
        public string note { get; set; }
        public bool staffOnly { get; set; }
    }


}
