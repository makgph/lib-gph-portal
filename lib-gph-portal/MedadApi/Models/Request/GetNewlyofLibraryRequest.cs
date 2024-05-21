using System;
using System.Globalization;

namespace sa.gov.libgph.MedadApi.Models.Request
{

    public class GetNewlyofLibraryRequest
    {
        public GetNewlyofLibraryRequest(string TypeId,int days=30)
        {
            daysCounter= days;
            this.DTFormat.Calendar = new GregorianCalendar();
            DTFormat.ShortDatePattern = "yyyy-MM-dd";
            Query = "?limit=10&query=(metadata.createdDate<=\"" + DateTime.Now.ToString("yyyy-MM-dd", DTFormat) + "\" and metadata.createdDate>=\"" + DateTime.Now.AddDays(-daysCounter).ToString("yyyy-MM-dd", DTFormat) + "\" and items.materialTypeId==\"" + TypeId + "\") sortby title";
            if (string.IsNullOrEmpty(TypeId))
            {
                Query = "?limit=10&query=(metadata.createdDate<=\"" + DateTime.Now.ToString("yyyy-MM-dd", DTFormat) + "\" and metadata.createdDate>=\"" + DateTime.Now.AddDays(-daysCounter).ToString("yyyy-MM-dd", DTFormat)+ "\")sortby title";

            }
        }
        public string URL { get; } = $"/search/instances";
        public string Query { get; }
        private DateTimeFormatInfo DTFormat { get; } = new CultureInfo("en", false).DateTimeFormat;
        private int daysCounter  = 60;

    }


}