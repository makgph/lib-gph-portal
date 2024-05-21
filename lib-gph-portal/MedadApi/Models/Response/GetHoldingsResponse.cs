using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class GetHoldingsResponse
    {
        public string id { get; set; }
        public int _version { get; set; }
        public string hrid { get; set; }
        public string holdingsTypeId { get; set; }
        public string[] formerIds { get; set; }
        public string instanceId { get; set; }
        public string permanentLocationId { get; set; }
        public string effectiveLocationId { get; set; }
        public object[] electronicAccess { get; set; }
        public string callNumberTypeId { get; set; }
        public string callNumber { get; set; }
        public object[] notes { get; set; }
        public object[] holdingsStatements { get; set; }
        public object[] holdingsStatementsForIndexes { get; set; }
        public object[] holdingsStatementsForSupplements { get; set; }
        public object[] statisticalCodeIds { get; set; }
        public object[] holdingsItems { get; set; }
        public object[] bareHoldingsItems { get; set; }
        public Metadata_GetHoldingsResponse metadata { get; set; }
        public string sourceId { get; set; }
    }

    public class Metadata_GetHoldingsResponse
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }


}