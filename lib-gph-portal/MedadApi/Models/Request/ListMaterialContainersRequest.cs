namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class ListAllLibrariesRequest
    {

        public string URL { get; } = "/locations";
        public string Query { get; private set; } = "?limit=2000";
    }
}