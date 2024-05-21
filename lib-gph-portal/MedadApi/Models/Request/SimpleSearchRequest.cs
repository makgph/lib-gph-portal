namespace sa.gov.libgph.MedadApi.Models.Request
{
    public class SimpleSearchRequest
    {
        public SimpleSearchRequest(string searchKeyWord, int pageSize = 30)
        {
            Query = $@"?expandAll=true&limit={pageSize}&query=(title=={searchKeyWord} or contributors.name={searchKeyWord} or subjects =={searchKeyWord}  or keyword =={searchKeyWord} or items.effectiveLocationId=={searchKeyWord} ) sortby title";

        }
        public string URL { get; } = "/search/instances";
        public string Query { get; private set; }

    }


}