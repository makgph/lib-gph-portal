namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class GetBibwithDateRangeandMatTypeRequest
    {
        public string URL { get; } = "/search/instances";
        public string Query { get; } = @"?limit=100&query=(metadata.createdDate>=""2023-01-11"" and metadata.createdDate<=""2023-01-13"" and items.materialTypeId==""c8fcae0c-bbbb-45d7-a1f8-8043793ffb7e"") sortby title";
    }
}