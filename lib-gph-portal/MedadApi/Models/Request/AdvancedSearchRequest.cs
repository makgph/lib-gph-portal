namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class AdvancedSearchRequest
    {
        public AdvancedSearchRequest(string resolvedQuery, int pageSize = 30)
        {
            Query = "?limit=500&query=" + resolvedQuery;
        }
        public string URL { get; } = "/search/instances";
        public string Query { get; private set; } = "";

    }


}