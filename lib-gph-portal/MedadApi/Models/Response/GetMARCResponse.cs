using Newtonsoft.Json;
using System;

namespace sa.gov.libgph.MedadApi.Models.Response
{
    public class GetMARCResponse
    {
        public string id { get; set; }
        public string snapshotId { get; set; }
        public string matchedId { get; set; }
        public int generation { get; set; }
        public string recordType { get; set; }
        public Rawrecord rawRecord { get; set; }
        public Parsedrecord parsedRecord { get; set; }
        public bool deleted { get; set; }
        public Externalidsholder externalIdsHolder { get; set; }
        public Additionalinfo additionalInfo { get; set; }
        public string state { get; set; }
        public string leaderRecordStatus { get; set; }
        public Metadata_GetMARCService metadata { get; set; }
    }

    public class Rawrecord
    {
        public string id { get; set; }
        public string content { get; set; }
    }

    public class Parsedrecord
    {
        public string id { get; set; }
        public Content content { get; set; }
        public string formattedContent { get; set; }
    }

    public class Content
    {
        public object[] fields { get; set; }
        public string leader { get; set; }
    }

    public class __001
    {
        [JsonProperty(PropertyName = "001")]
        public string _001 { get; set; }
    }
    public class __003
    {
        [JsonProperty(PropertyName = "003")]
        public string _003 { get; set; }
    }

    public class __005
    {
        [JsonProperty(PropertyName = "005")]
        public string _005 { get; set; }
    }
    public class __008
    {
        [JsonProperty(PropertyName = "008")]
        public string _008 { get; set; }
    }



    public class Field
    {
        public __001 _001 { get; set; }
        public __005 _005 { get; set; }
        public __003 _003 { get; set; }
        public __008 _008 { get; set; }
        public Tag082 _082 { get; set; }
        public Tag035 _035 { get; set; }
        public Tag245 _245 { get; set; }
        public Tag300 _300 { get; set; }
        public Tag260 _260 { get; set; }
        public Tag650 _650 { get; set; }
    }
  

    


    #region 082

    public class __082
    {
        [JsonProperty(PropertyName = "082")]
        public Tag082Object tag082Object { get; set; }
    }
    public class Tag082Object
    {

        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public object[] subfields { get; set; }

    }
    public class Tag082
    {

        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public Subfield82 subfields { get; set; }

    }
    public class Subfield82
    {
        public string a { get; set; }
        public string b { get; set; }
        [JsonProperty(PropertyName = "2")]

        public string _2 { get; set; }
        public string q { get; set; }
    }
    #endregion

    #region 245

    public class __245
    {
        [JsonProperty(PropertyName = "245")]
        public Tag245Object tag245Object { get; set; }
    }
    public class Tag245Object
    {

        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public object[] subfields { get; set; }

    }
    public class Tag245
    {

        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public Subfield245 subfields { get; set; }

    }
    public class Subfield245
    {
        public string a { get; set; }
        public string c { get; set; }
    }

    #endregion

    #region 300
    public class __300
    {
        [JsonProperty(PropertyName = "300")]
        public Tag300Object tag300Object { get; set; }
    }
    public class Tag300Object
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public object[] subfields { get; set; }
    }
    public class Tag300
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public Subfield300 subfields { get; set; }
    }
    public class Subfield300
    {
        public string a { get; set; }
        public string c { get; set; }
    }

    #endregion

    #region 650
    public class __650
    {
        [JsonProperty(PropertyName = "650")]
        public Tag650Object tag650Object { get; set; }
    }
    public class Tag650Object
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public object[] subfields { get; set; }
    }
    public class Tag650
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public Subfield650 subfields { get; set; }
    }
    public class Subfield650
    {
        public string a { get; set; }
        public string x { get; set; }
        [JsonProperty(PropertyName = "2")]

        public string _2 { get; set; }
    }
    #endregion

    #region 260
    public class __260
    {
        [JsonProperty(PropertyName = "260")]
        public Tag260Object tag260Object { get; set; }
    }
    public class Tag260Object
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public object[] subfields { get; set; }
    }
    public class Tag260
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public Subfield260 subfields { get; set; }
    }
    public class Subfield260
    {
        public string a { get; set; }
        public string e { get; set; }
    }
    #endregion

    #region 035

    public class __035
    {
        [JsonProperty(PropertyName = "035")]
        public Tag035Object tag035Object { get; set; }
    }
    public class Tag035Object
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public object[] subfields { get; set; }

    }

    public class Tag035
    {
        public string ind1 { get; set; }
        public string ind2 { get; set; }
        public Subfield035 subfields { get; set; }
    }

    public class Subfield035
    {
        public string a { get; set; }
    }
    #endregion

    public class Externalidsholder
    {
        public string instanceId { get; set; }
        public string instanceHrid { get; set; }
    }

    public class Additionalinfo
    {
        public bool suppressDiscovery { get; set; }
    }

    public class Metadata_GetMARCService
    {
        public DateTime createdDate { get; set; }
        public string createdByUserId { get; set; }
        public DateTime updatedDate { get; set; }
        public string updatedByUserId { get; set; }
    }

}