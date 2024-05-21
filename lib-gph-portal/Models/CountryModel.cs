using System;

namespace sa.gov.libgph.Models
{
    //public class CountryModel
    //{
    //    public int id { get; set; }
    //    public string nameAr { get; set; }
    //    public string nameEn { get; set; }
    //    public string createdBy { get; set; }
    //    public DateTime createdDate { get; set; }
    //    public string updatedBy { get; set; }
    //    public DateTime updatedDate { get; set; }
    //}


    public class CountryModel
    {
        public CountryData[] data { get; set; }
        //public CountryMessage[] messages { get; set; }
        public int status { get; set; }
        public int dataLength { get; set; }
    }

    public class CountryData
    {
        public int id { get; set; }
        public string nameAr { get; set; }
        public string nameEn { get; set; }
        public string createdBy { get; set; }
        public DateTime? createdDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }
    }

    public class CountryMessage
    {
        public string body { get; set; }
        public string title { get; set; }
        public int type { get; set; }
    }


    
}