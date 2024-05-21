namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class GetBibByDateRangeRequest
    {
        public string URL { get; } = "/search/instances";
        public string Query { get; } = @"?limit=100&query=(metadata.createdDate>=""2023-01-11"" and metadata.createdDate<=""2023-01-13"") sortby title";
    }
}